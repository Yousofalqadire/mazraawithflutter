using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }

    }
}
