using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Models
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

      
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
        public DbSet<UserImage> userImages { get; set; }

        public DbSet<CoverImage> CoverImages { get; set; }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<User> AppUsers { get; set; }
        
              public DbSet<Category> Categories { get; set; }


        public DbSet<Floor> Floors { get; set; }


        public DbSet<Room> Rooms { get; set; }

        public DbSet<Address> Addresses { get; set; }








    }
}
