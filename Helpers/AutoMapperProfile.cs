using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mazaare3.Models;
using Mazaare3.Models.ViewModel.apiDto;

namespace Mazaare3.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<UserImage,ImageDto>();
        }
    }
}