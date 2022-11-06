using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class UserImage
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }

        public int AdId { get; set; }
        public Ad  Ad  { get; set; }
    }
}
