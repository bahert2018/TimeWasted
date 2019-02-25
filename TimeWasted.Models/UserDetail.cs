using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class UserDetail
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{UserId}] {UserName}";
    }
}