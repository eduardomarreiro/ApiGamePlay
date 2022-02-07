using ApiGamePlay.Shared.Dto.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Shared.Requests
{
    public class GetPlayerPorIdRequest : IRequest<ReadPlayerDto> 
    {
        public int Id { get; set; }
        public GetPlayerPorIdRequest(int id)
        {
            Id = id;
        }

    }
}
