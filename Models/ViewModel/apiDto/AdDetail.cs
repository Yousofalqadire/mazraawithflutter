using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mazaare3.Models.ViewModel.apiDto;
// this class to use for automapper to AdDto for flutter
namespace Mazaare3.Models.ViewModel
{
    public class AdDetail
    {
         public int AdId { get; set; }
       
        public string Title { get; set; }
       
        public string Category { get; set; } 
        
        public double Price { get; set; }
       
        public string Mobile { get; set; }
 
        public string AlterMobile { get; set; }

       
        public string Email { get; set; }
       
        public string Address { get; set; }
        public bool IsApproved { get; set; }
        public DateTime PostedDate { get; set; }
        public string Floors { get; set; }
        public string Rooms { get; set; }
        public List<ImageDto> Images{get; set;}
    }
}