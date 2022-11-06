using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class CoverImage
    {
        public int CoverImageId { get; set; }
        public string CoverImageURL { get; set; }

        [Required]
        public int AdId { get; set; }
        public Ad Ad{ get; set; }
    }
}
