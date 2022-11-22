using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using AutoMapper;
using Mazaare3.Models;
using Mazaare3.Models.ViewModel;
using Mazaare3.Models.ViewModel.apiDto;
using Microsoft.EntityFrameworkCore;

namespace Mazaare3.Interfaces.Repositories
{
    
    public class AdsRepository : IAds
    {
        private readonly AppDBContext db;
        private readonly IMapper maper;

        public AdsRepository(AppDBContext db,IMapper _maper)
        {
            this.db = db;
            maper = _maper;
        }

        public async Task<IEnumerable<Ad>> GetAdByCategoryAsync(string category)
        {
            return await db.Ads.Where(x => x.Category == category).ToListAsync();
        }

        public async Task<AdDetail> GetAdByIdAsync(int id)
        {
            
            var ad = await db.Ads.SingleOrDefaultAsync(x => x.AdId == id);
            var userImages = await db.userImages.Where(x => x.AdId == ad.AdId).ToListAsync();
           List<ImageDto> images = new List<ImageDto>();
            foreach(var image in userImages){
                var photo = maper.Map<ImageDto>(image);
                images.Add(photo);
            }
           var adDetail = new AdDetail{AdId = ad.AdId,Category = ad.Category,
            Email = ad.Email,Images= images,Address= ad.Address,AlterMobile= ad.AlterMobile,
            Floors = ad.Floors,IsApproved = ad.IsApproved,Mobile=ad.Mobile,PostedDate= ad.PostedDate,
            Price = ad.Price,Title = ad.Title,Rooms = ad.Rooms};
            return adDetail;

        }

        public async Task<PagingList<Ad>> GetAllAdsAsync(UserParams userParams)
        {
            var query = db.Ads.AsNoTracking();
            return await PagingList<Ad>.CreatAsync(query,userParams.PageNumber,userParams.PageSize);
        }
    }
}