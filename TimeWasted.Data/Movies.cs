using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Data
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        [Display(Name = "Show Title")]
        public string Title { get; set; }

        [Display(Name = "How is the movie or one of the movies")]
        public int MovieLength { get; set; }

        [Display(Name = "How many movies were made in that story line? (Sequals or just the one)")]
        public int Sequel { get; set; }

        [Display(Name = "Have you seen this movie before?")]
        public bool WatchedIt { get; set; }

        //[Display(Name = "Would you Like to watch this later?")]
        //public bool WatchLater { get; set; }
         
        [Display(Name = "Was the movie worth it?")]
        public bool WorthIt { get; set; }


        [Display(Name = "Total Time")]
        public int TimeTotal { get; set; }

        public Guid OwnerId { get; set; }


        //public virtual AllShows AllShows { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
