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

namespace ApiGamePlay.Application.Services
{
    public class PlayerService
    {
        public IPlayerRepository _playerRepo;
        public IMapper _mapper;
        public PlayerService(IPlayerRepository playerRepo, IMapper mapper)
        {
            _playerRepo = playerRepo;
            _mapper = mapper;
        }

        public void AdicionarPlayer(CreatePlayerDto playerDto)
        {
            Player player = _mapper.Map<Player>(playerDto);
            _playerRepo.AdicionarPlayer(playerDto);
        }

        public List<Player> ConsultaPlayers()
        {
            return _playerRepo.ListarPlayers();
        }

        public Player ConsultaPlayerPorId(int id)
        {
            return _playerRepo.RetornarPlayerPorId(id);
        }

        public void ModificaPlayer(int id, Player player)
        {
            _playerRepo.AtualizarPlayer(id, player);
        }

        public void RemoverPlayer(int id)
        {
            _playerRepo.DeletaPlayer(id);

        }
    }
}



















//List<Player> players = _playerRepo.ListarPlayers(); 
//List<ReadPlayerDto> playersDtos = new List<ReadPlayerDto>();
//foreach(Player player in players)
//{
//    ReadPlayerDto playerDto = new ReadPlayerDto();
//    playerDto = _mapper.Map<ReadPlayerDto>(player);
//    playersDtos.Add(playerDto);
//}
//return playersDtos;