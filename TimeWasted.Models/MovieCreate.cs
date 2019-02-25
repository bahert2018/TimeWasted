using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class MovieCreate
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool WatchedIt { get; set; }

        [Required]
        public int Sequel { get; set; }

        [Required]
        public bool WatchLater { get; set; }

        [Required]
        public bool WorthIt { get; set; }

        public override string ToString() => Title;
    }
}