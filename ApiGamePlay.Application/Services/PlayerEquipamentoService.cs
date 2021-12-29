using ApiGamePlay.Data.Repositories;
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
    public class PlayerEquipamentoService
    {
        public IPlayerRepository _PlayerRepo;
        public IPlayerEquipamentoRepository _PlayerEquipamentoRepo;
        public IEquipamentoRepository _EquipamentoRepo;
        public IMapper _mapper;

        public PlayerEquipamentoService(IPlayerRepository PlayerRepo, IPlayerEquipamentoRepository PlayerEquipamentoRepo, IEquipamentoRepository EquipamentoRepo, IMapper mapper)
        {
            _PlayerRepo = PlayerRepo;
            _PlayerEquipamentoRepo = PlayerEquipamentoRepo;
            _EquipamentoRepo = EquipamentoRepo;
            _mapper = mapper;
        }
        public void AdicionarEquipamentoAoPlayer(CreatePlayerEquipamentoDto InsiraEquipamentoAoPlayer)
        {
            Player player = _PlayerRepo.RetornarPorId(InsiraEquipamentoAoPlayer.PlayerId);
            Equipamento equipamento = _EquipamentoRepo.RetornarPorId(InsiraEquipamentoAoPlayer.EquipamentoId);
            PlayerEquipamento playerEquipamento = new PlayerEquipamento();

            if (equipamento != null && player != null)
            {
                playerEquipamento.EquipamentoId = InsiraEquipamentoAoPlayer.EquipamentoId;
                playerEquipamento.PlayerId = InsiraEquipamentoAoPlayer.PlayerId;
                _PlayerEquipamentoRepo.Adicionar(playerEquipamento);
            }
        }
        public List<ReadPlayerEquipamentoDto> RetornarPlayerEquipamento()
        {
            List<PlayerEquipamento> playerEquipamentosList = _PlayerEquipamentoRepo.RetornarTodos();
            List<ReadPlayerEquipamentoDto> peDtoList = new List<ReadPlayerEquipamentoDto>();
           
            foreach(PlayerEquipamento playerEquip in playerEquipamentosList)
            {
                ReadPlayerEquipamentoDto readPlayerEquipamentoDto = new ReadPlayerEquipamentoDto();
                readPlayerEquipamentoDto = _mapper.Map<ReadPlayerEquipamentoDto>(playerEquip);
                peDtoList.Add(readPlayerEquipamentoDto);
            }              
            return peDtoList;
        }

        public void DelatarPlayerEquipamentoPorId(int id)
        {
            PlayerEquipamento playerEquipamento = _PlayerEquipamentoRepo.RetornarPorId(id);
            if(playerEquipamento != null)
            {
                _PlayerEquipamentoRepo.Deletar(playerEquipamento);
            }      
        }
    }
}
