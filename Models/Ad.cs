using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class Ad
    {
        public int AdId { get; set; }
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Select Type of Ad")]
        public string Category { get; set; } 
        [Required(ErrorMessage = "Please Enter Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile")]
        public string Mobile { get; set; }
 
        public string AlterMobile { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        public bool IsApproved { get; set; }
        [Required(ErrorMessage = "Please Upload Cover Image")]
        public string CoverImage { get; set; }
        public DateTime PostedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Floors ")]
        public string Floors { get; set; }
        [Required(ErrorMessage = "Please Enter Rooms")]
        public string Rooms { get; set; }
 

    }
}
