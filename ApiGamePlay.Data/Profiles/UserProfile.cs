using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>();
        }
    }
}
