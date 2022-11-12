using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Mazaare3.Models;

namespace Mazaare3.Data
{
    public  class Seed
    {
        public static async Task SeedAds(AppDBContext db){
            if(!db.Ads.Any()){
            
            var AdsDataSource = await System.IO.File.ReadAllTextAsync("Data/Mazare3Json.json");
            var ads = JsonSerializer.Deserialize<List<Ad>>(AdsDataSource);
            await db.Ads.AddRangeAsync(ads);
            await db.SaveChangesAsync();

            }
        }

        public static async Task SeedCategories(AppDBContext db)
        {
            if(!db.Categories.Any()){
             List<Category> categories = new List<Category>();
              categories.Add(new Category{CategoryName="Sell"});
              categories.Add(new Category{CategoryName="Rent"});
              await db.AddRangeAsync(categories);
              await db.SaveChangesAsync();
            }
           

        }
    }
}