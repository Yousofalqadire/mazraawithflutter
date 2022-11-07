using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Mazaare3.Models;
using Microsoft.EntityFrameworkCore;

namespace Mazaare3.Interfaces.Repositories
{
    
    public class AdsRepository : IAds
    {
        private readonly AppDBContext db;

        public AdsRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Ad>> GetAdByCategoryAsync(string category)
        {
            return await db.Ads.Where(x => x.Category == category).ToListAsync();
        }

        public async Task<Ad> GetAdByIdAsync(int id)
        {
            return await db.Ads.SingleOrDefaultAsync(x => x.AdId == id);
        }

        public async Task<PagingList<Ad>> GetAllAdsAsync(UserParams userParams)
        {
            var query = db.Ads.AsNoTracking();
            return await PagingList<Ad>.CreatAsync(query,userParams.PageNumber,userParams.PageSize);
        }
    }
}