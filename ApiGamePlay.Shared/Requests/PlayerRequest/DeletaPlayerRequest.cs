using ApiGamePlay.Shared.Dto.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Shared.Requests.PlayerRequest
{
    public class DeletaPlayerRequest : INotification
    {
        public int  Id { get; set; }

        public DeletaPlayerRequest(int id)
        {
            Id = id;
        }
    }
}
