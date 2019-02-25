using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class TimeEdit
    {
        public int ShowId { get; set; }
        public bool Watchedbefore { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodesPerSeason { get; set; }
        public int EpisodeLength { get; set; }
        public bool WorthIt { get; set; }
        public string Title { get; set; }
    }
}
