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
    }
}