using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class TimeCreate
    {
        [Required]
        public string Title { get; set; }
        public bool Watchedbefore { get; set; }
        public bool WorthIt { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodesPerSeason { get; set; }
        public int EpisodeLength { get; set; }

        public override string ToString() => Title;
    }
}