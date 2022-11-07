using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<string>> GetCategoriesAsync();
    }
}