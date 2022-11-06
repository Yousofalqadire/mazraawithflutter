using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class ContactUs
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }

        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Your Message")]

        public string Message { get; set; }
    }
}
