using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class Floor
    {
        public int FloorId { get; set; }
        [Required]
        public string FloorName { get; set; }
    }
}
