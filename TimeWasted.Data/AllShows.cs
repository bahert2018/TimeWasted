using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Data
{
    public class AllShows
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        [Display(Name = "Did you watch it before?")]
        public bool Watchedbefore { get; set; }

        [Required]
        [Display(Name = "How many seasons are there?")]
        [Range(1, 70, ErrorMessage = "No show on earth has that many seasons -__-")]
        public int SeasonNumber { get; set; }

        [Required]
        [Display(Name = "How many episodes are there per season?")]
        [Range(1, 9999, ErrorMessage = "A season should at least have one episode... -__-")]
        public int EpisodesPerSeason { get; set; }

        [Required]
        [Display(Name = "How long is a normal episode")]
        [Range(1, 9999999, ErrorMessage = "No episode on earth is that long... -__-")]
        public int EpisodeLength { get; set; }

        [Required]
        [Display(Name = "Was the show worth it?")]
        public bool WorthIt { get; set; }

        [Required]
        [Display(Name = "Show Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Total show time.")]
        public int TotalTime { get; set; }

        [Required]
        public Guid OwnerId { get; set; }




        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

