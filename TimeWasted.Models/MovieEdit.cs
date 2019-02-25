using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class MovieEdit
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public bool WatchedIt { get; set; }
        public int Sequel { get; set; }
        public bool WatchLater { get; set; }
        public bool WorthIt { get; set; }
    }
}