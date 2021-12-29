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
    public class PlayerEquipamentoProfile : Profile
    {
        public PlayerEquipamentoProfile()
        {
            CreateMap<CreatePlayerEquipamentoDto, PlayerEquipamento>();
            CreateMap<PlayerEquipamento, ReadPlayerEquipamentoDto>();
            CreateMap<UpdatePlayerEquipamentoDto, PlayerEquipamento>();
        }
    }
}
