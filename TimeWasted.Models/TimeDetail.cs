using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class TimeDetail
    {
        public int ShowId { get; set; }
        public string Title { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodesPerSeason { get; set; }
        public int EpisodeLength { get; set; }
        public bool WorthIt { get; set; }
        public bool Watchedbefore { get; set; }
        public int TotalTime { get; set; }
        public int MovieLength { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ShowId}] {Title}";
    }
}
