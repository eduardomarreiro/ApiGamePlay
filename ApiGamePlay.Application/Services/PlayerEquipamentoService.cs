using ApiGamePlay.Data.Repositories;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
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

        public PlayerEquipamentoService(IPlayerRepository PlayerRepo, IPlayerEquipamentoRepository PlayerEquipamentoRepo, IEquipamentoRepository EquipamentoRepo)
        {
            _PlayerRepo = PlayerRepo;
            _PlayerEquipamentoRepo = PlayerEquipamentoRepo;
            _EquipamentoRepo = EquipamentoRepo;
        }
        public void AdicionarEquipamentoAoPlayer(CreatePlayerEquipamentoDto InsiraEquipamentoAoPlayer)
        {
            Player player = _PlayerRepo.RetornarPlayerPorId(InsiraEquipamentoAoPlayer.PlayerId);
            Equipamento equipamento = _EquipamentoRepo.RetornarEquipamentoPorId(InsiraEquipamentoAoPlayer.EquipamentoId);
            PlayerEquipamento playerEquipamento = new PlayerEquipamento();
            if (equipamento != null && player != null)
            {
                playerEquipamento.EquipamentoId = InsiraEquipamentoAoPlayer.EquipamentoId;
                playerEquipamento.PlayerId = InsiraEquipamentoAoPlayer.PlayerId;
                _PlayerEquipamentoRepo.AdicionarEquipamentoAoPlayer(playerEquipamento);
                // converter InsiraEquipamentoAoPlayer para playerEquipamento ok
                // após fazer a conversão, usar como parâmetro ok 
                // usar a classe de serviços no controller *** como ???
            }
        }
        public List<PlayerEquipamento> RetornarPlayerEquipamento()
        {
            return _PlayerEquipamentoRepo.RecuperaPlayerEquipamento();
        }

        public void DelatarPlayerEquipamentoPorId(int Id)
        {
            _PlayerEquipamentoRepo.DeletarEquipamentoPlayerPorId(Id);
        }


    }
}
