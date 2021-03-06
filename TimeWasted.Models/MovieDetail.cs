﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int MovieLength { get; set; }
        public int Sequel { get; set; }
        public bool WatchedIt { get; set; }
        public bool WatchLater { get; set; }
        public bool WorthIt { get; set; }
        public int TimeTotal { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{MovieId}] {Title}";
    }
}