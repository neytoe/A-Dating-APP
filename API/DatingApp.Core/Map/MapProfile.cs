using AutoMapper;
using DatingApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Map
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<createUserDto, AppUser>();
            CreateMap<RegisterUserDto, AppUser>();
        }
    }
}
