using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }  

    }
}
