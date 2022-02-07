using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Requests;
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
    public class PlayerRequestHandler : IRequestHandler<GetPlayerPorIdRequest, ReadPlayerDto>
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IMapper _mapper;
        public PlayerRequestHandler(IPlayerRepository playerRepo, IMapper mapper)
        {
            _playerRepo = playerRepo;
            _mapper = mapper;
        }

        public async Task<ReadPlayerDto> Handle(GetPlayerPorIdRequest request, CancellationToken cancellationToken)
        {
            var player = await _playerRepo.RetornarPorIdAsync(request.Id);
            if (player != null)
            {
                ReadPlayerDto playerDto = _mapper.Map<ReadPlayerDto>(player);
                return playerDto;
            }
                return new ReadPlayerDto();
        }

    }
}