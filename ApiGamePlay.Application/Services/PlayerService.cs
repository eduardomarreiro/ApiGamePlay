using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Interfaces.IServices;
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

namespace ApiGamePlay.Application.Services
{
    public class PlayerService : IPlayerService 
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
            Player player = new Player();
            player.Nome = playerDto.Nome;
            player.Level = playerDto.Level;
            player.Vida = playerDto.Vida;

            _playerRepo.Adicionar(player);
        }

        public List<ReadPlayerDto> ConsultaPlayers()
        {
            List<Player> playerList = _playerRepo.RetornarTodos();
            List<ReadPlayerDto> playerDtosList = new List<ReadPlayerDto>();
            foreach(Player player in playerList)
            {
                ReadPlayerDto playerDto = new ReadPlayerDto();
                playerDto = _mapper.Map<ReadPlayerDto>(player);
                playerDtosList.Add(playerDto);
            }
            return playerDtosList;
        }

        public ReadPlayerDto ConsultaPlayerPorId(int id)
        {
            Player player = _playerRepo.RetornarPorId(id);
            ReadPlayerDto playerDto = _mapper.Map<ReadPlayerDto>(player);
            return playerDto;
        }

        public void ModificarPlayer(int id, UpdatePlayerDto playerDto)
        {
            Player player = _playerRepo.RetornarPorId(id);
            if(player != null)
            {
                player.Vida = playerDto.Vida;
                playerDto.Nome = playerDto.Nome;
                playerDto.Level = playerDto.Level;
                _playerRepo.Atualizar(player);
            }
        }

        public void RemoverPlayer(int id)
        {
            Player player = _playerRepo.RetornarPorId(id);
            if (player != null)
            {
                _playerRepo.Deletar(player);
            }
        }

        public async Task<ReadPlayerDto> GetPlayerById(int id) 
        {
            Player player = await _playerRepo.PlayerPorIdAsync(id);            
            if (player != null)
            {
                ReadPlayerDto playerDto = _mapper.Map<ReadPlayerDto>(player);
                return playerDto;
            }
            else
                return null;
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