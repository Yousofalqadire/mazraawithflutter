using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Mazaare3.Models;

namespace Mazaare3.Interfaces
{
    public interface IAds
    {
        Task<PagingList<Ad>> GetAllAdsAsync(UserParams userParams);
        Task<Ad> GetAdByIdAsync(int id);
        Task<IEnumerable<Ad>> GetAdByCategoryAsync(string category);
    }
}