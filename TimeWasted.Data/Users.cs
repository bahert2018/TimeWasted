using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Data
{
    public class Users
    {
            [Key]
            public int UserId { get; set; }

            [Required]
            [Display(Name = "What is the User's name")]
            public string UserName { get; set; }

            [Required]
            public Guid OwnerId { get; set; }

            public int ShowId { get; set; }
            public int MovieId { get; set; }


            public virtual AllShows  AllShows { get; set; }
            public virtual Movies Movies { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
