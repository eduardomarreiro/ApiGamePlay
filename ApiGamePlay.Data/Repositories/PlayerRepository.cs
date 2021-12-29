using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Repositories
{
    public class PlayerRepository : Repository <Player>, IPlayerRepository 
    {
        public IMapper _mapper;

        public PlayerRepository(GamePlayContext context, IMapper mapper): base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<Player> RetornarTodos()
        {
            
            return _context.Players.Include(x => x.PlayerEquipamento)
                .ThenInclude(z => z.Equipamento).ToList();
        }
    }
}
