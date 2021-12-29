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
    public class PlayerEquipamentoRepository : Repository<PlayerEquipamento>, IPlayerEquipamentoRepository 
    {
        public IMapper _mapper;

        public PlayerEquipamentoRepository(GamePlayContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public void DeletarEquipamento(int Id)
        {
            PlayerEquipamento playerEquipamento = _context.PlayersEquipamentos.FirstOrDefault(x => x.Id == Id);
            if (playerEquipamento != null)
            {
                _context.Remove(Id);
                _context.SaveChanges();
            }
        }

        public override List<PlayerEquipamento> RetornarTodos()
        {
            return _context.PlayersEquipamentos.Include(x => x.Equipamento).Include(y => y.Player).ToList();
        }
    }
}
