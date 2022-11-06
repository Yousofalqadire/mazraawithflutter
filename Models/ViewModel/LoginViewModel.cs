using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models.ViewModel
{
    public class LoginViewModel 
    {
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
   
        [Required(ErrorMessage = "Please Enter Your Mobile")]
        public string Mobile { get; set; }
     

    }
}
