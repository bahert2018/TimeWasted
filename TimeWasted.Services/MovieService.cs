using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWasted.Data;
using TimeWasted.Models;

namespace TimeWasted.Services
{
    public class MovieService
    {
        private readonly Guid _movieId;

        public MovieService(Guid movieId)
        {
            _movieId = movieId;
        }

        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movies()
                {
                    MovieId = model.MovieId,
                    Title = model.Title,
                    WatchedIt = model.WatchedIt,
                    Sequel = model.Sequel,
                    WatchLater = model.WatchLater,
                    WorthIt = model.WorthIt,
                    MovieLength = model.MovieLength,
                    TimeTotal = TimeTotal(model.MovieLength, model.Sequel),

                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
        public IEnumerable<MovieListItem> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Movies
                        .Where(e => e.OwnerId == _movieId)
                        .Select(
                            e =>
                                new MovieListItem
                                {
                                    MovieId = e.MovieId,
                                    Title = e.Title,
                                    WatchedIt = e.WatchedIt,
                                    Sequel = e.Sequel,
                                    WatchLater = e.WatchLater,
                                    TimeTotal = e.TimeTotal,
                                    WorthIt = e.WorthIt,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public MovieDetail GetMovieById(int MovieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == MovieId && e.OwnerId == _movieId);
                return
                    new MovieDetail
                    {
                        MovieId = entity.MovieId,
                        Title = entity.Title,
                        WatchedIt = entity.WatchedIt,
                        WatchLater = entity.WatchLater,
                        WorthIt = entity.WorthIt,
                        Sequel = entity.Sequel,
                        TimeTotal = entity.TimeTotal,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == model.MovieId && e.OwnerId == _movieId);

                entity.MovieId = model.MovieId;
                entity.Title = model.Title;
                entity.WatchedIt = model.WatchedIt;
                entity.WatchLater = model.WatchLater;
                entity.WorthIt = model.WorthIt;
                entity.Sequel = model.Sequel;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int MovieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == MovieId && e.OwnerId == _movieId);

                ctx.Movies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        private int TimeTotal(int Sequel, int MovieLength)
        {
            int Total = Sequel * MovieLength;
            return Total;
        }
    }
}