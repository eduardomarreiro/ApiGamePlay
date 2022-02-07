using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Shared.Requests.PlayerRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Application.RequestHandlers.Players
{
    public class WritePlayerRequestHandler : INotificationHandler<DeletaPlayerRequest>
    {
        private readonly IPlayerRepository _playerRepo;
        public WritePlayerRequestHandler(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }
        public Task Handle(DeletaPlayerRequest notification, CancellationToken cancellationToken)
        {
            var player = _playerRepo.RetornarPorId(notification.Id);
            if(player != null)
            {
                Task.Run(() => _playerRepo.Deletar(player));
            }
            return null;
        }
    }
}
