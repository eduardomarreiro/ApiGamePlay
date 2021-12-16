﻿using ApiGamePlay.Data.Context;
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
    public class PlayerRepository : IPlayerRepository
    {
        public GamePlayContext _context;
        public IMapper _mapper;
        public PlayerRepository(GamePlayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadPlayerDto> ListarPlayers()
        {
            List<Player> PlayerDb;
            PlayerDb = _context.Players.ToList();
            List<ReadPlayerDto> PlayersDtos;

            PlayersDtos = _mapper.Map<List<ReadPlayerDto>>(PlayerDb);

            return PlayersDtos;
        }

        public void AdicionarPlayer(CreatePlayerDto AdicionePlayer)
        {
            Player player = new Player();

            player.Nome = AdicionePlayer.Nome;
            player.Vida = AdicionePlayer.Vida;
            player.Level = AdicionePlayer.Level;

            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void DeletaPlayer(int id)
        {
            Player player = _context.Players.FirstOrDefault(x => x.Id == id);
            if(player != null)
            {
                _context.Remove(player);
                _context.SaveChanges();
            }
        }
        public void AtualizarPlayer(int id, Player playerAtual)
        {
            Player updatePlayer = _context.Players.FirstOrDefault(x => x.Id == id);
            if(playerAtual != null)
            {
                updatePlayer.Nome = playerAtual.Nome;
                updatePlayer.Vida = playerAtual.Vida;
                updatePlayer.Level = playerAtual.Level;
                _context.SaveChanges();
            }
        }
    }
}
