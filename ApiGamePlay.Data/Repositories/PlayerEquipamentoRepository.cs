using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Repositories
{
    public class PlayerEquipamentoRepository : IPlayerEquipamentoRepository
    {
        public GamePlayContext _context;
        public IMapper _mapper;

        public PlayerEquipamentoRepository(GamePlayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AdicionarEquipamentoAoPlayer(PlayerEquipamento playerEquipamento)
        {
                _context.PlayersEquipamentos.Add(playerEquipamento);
                _context.SaveChanges();
        }
        public List<PlayerEquipamento> RecuperaPlayerEquipamento()
        {
            List<PlayerEquipamento> playerEquipamentos;
            playerEquipamentos = _context.PlayersEquipamentos.ToList();
            return playerEquipamentos;
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
    }
}
