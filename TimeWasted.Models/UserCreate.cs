using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Models
{
    public class UserCreate
    {
        public object usersId;

        [Required]
        public int UserId { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string UserName { get; set; }

        public override string ToString() => UserName;
    }
}