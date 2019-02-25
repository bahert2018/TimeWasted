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

        [Required]
        [Display(Name = "Show Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Have you seen this movie before?")]
        public bool WatchedIt { get; set; }

        [Required]
        [Display(Name = "How many movies were made in that story line? (Sequals or just the one)")]
        public int Sequel { get; set; }

        [Required]
        [Display(Name = "Do you want to watch this movie later?")]
        public bool WatchLater { get; set; }
         
        [Display(Name = "Was the movie worth it?")]
        public bool WorthIt { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
