using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWasted.Data;
using TimeWasted.Models;
using static TimeWasted.Data.AllShows;

namespace TimeWasted.Services
{
    public class AllShowsServices
    {
        private readonly Guid _userId;

        public AllShowsServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShow(TimeCreate model)
        {
            var entity =
                 new AllShows()
                 {
                     OwnerId = _userId,
                     Title = model.Title,
                     Watchedbefore = model.Watchedbefore,
                     SeasonNumber = model.SeasonNumber,
                     EpisodesPerSeason = model.EpisodesPerSeason,
                     EpisodeLength = model.EpisodeLength,
                     WorthIt = model.WorthIt,
                     TotalTime = TotalTime(model.EpisodesPerSeason, model.EpisodeLength, model.SeasonNumber),

                     CreatedUtc = DateTimeOffset.Now
                 };
            using (var ctx = new ApplicationDbContext())
            {
                //if()

               

                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shows
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ShowListItem
                                {
                                    ShowId = e.ShowId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc,
                                    EpisodeLength= e.EpisodeLength,
                                    EpisodesPerSeason = e.EpisodesPerSeason,
                                    SeasonNumber = e.SeasonNumber,
                                    WorthIt = e.WorthIt,
                                    Watchedbefore = e.Watchedbefore,
                                    TotalTime = e.TotalTime
                                    
                                });
                return query.ToArray();
            }
        }

        public TimeDetail GetShowById(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                  ctx
                      .Shows
                      .Single(e => e.ShowId == showId && e.OwnerId == _userId);
                return
                  new TimeDetail
                  {
                      ShowId = entity.ShowId,
                      Title = entity.Title,
                      Watchedbefore = entity.Watchedbefore,
                      SeasonNumber = entity.SeasonNumber,
                      EpisodesPerSeason = entity.EpisodesPerSeason,
                      EpisodeLength = entity.EpisodeLength,
                      WorthIt = entity.WorthIt,
                      TotalTime = entity.TotalTime,
                      CreatedUtc = entity.CreatedUtc,
                      ModifiedUtc = entity.ModifiedUtc,
                  };
            }
        }

        public bool UpdateShow(TimeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == model.ShowId && e.OwnerId == _userId);

                entity.Watchedbefore = model.Watchedbefore;
                entity.SeasonNumber = model.SeasonNumber;
                entity.EpisodesPerSeason = model.EpisodesPerSeason;
                entity.EpisodeLength = model.EpisodeLength;
                entity.WorthIt = model.WorthIt;
                entity.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShow(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == showId && e.OwnerId == _userId);

                ctx.Shows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        // calc function 

        private int TotalTime (int tEp, int tEpL, int tSea)
        {
            int Total = tEp * tEpL * tSea;
            return Total;
        }
    }
}
