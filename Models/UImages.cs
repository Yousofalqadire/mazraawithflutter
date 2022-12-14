using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class UImages
    {
        public IFormFile CoverImage { get; set; }
        public IList<IFormFile> Images { get; set; }

        [Required]
        public int AdId { get; set; }
        public Ad Ad  { get; set; }
    }
}
