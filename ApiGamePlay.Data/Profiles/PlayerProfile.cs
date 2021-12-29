using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, ReadPlayerDto>().ForMember(dest => dest.Equipamento, opt => opt
            .MapFrom(x => x.PlayerEquipamento
            .Select(z => z.Equipamento)));
            
            CreateMap<UpdatePlayerDto, Player>();
            
            CreateMap<CreatePlayerDto, Player>(); 
        }
    }
}
