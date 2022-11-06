using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        public string RoomName { get; set; }
    }
}
