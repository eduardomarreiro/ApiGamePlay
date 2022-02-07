using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Requests.PlayerRequest;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Application.RequestHandlers.Players
{
    public class ModificaPlayerRequestHandler : INotificationHandler<ModificaPlayersRequest>
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IMapper _mapper;
        public ModificaPlayerRequestHandler(IPlayerRepository playerRepo, IMapper mapper)
        {
            _playerRepo = playerRepo;
            _mapper = mapper;
        }

        public async Task Handle(ModificaPlayersRequest notification, CancellationToken cancellationToken)
        {
            var player = await _playerRepo.RetornarPorIdAsync(notification.Id);
            if(player != null)
            {
                player.Vida = notification.Vida;
                player.Level = notification.Level;
                player.Nome = notification.Nome;
                await _playerRepo.AtualizarAsync(player);
            }
        }
    }
}
