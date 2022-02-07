using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Shared.Requests.PlayerRequest
{
    public class ModificaPlayersRequest : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Level { get; set; }

        public ModificaPlayersRequest(int id, string nome, int vida, int level)
        {
            Id = id;
            Nome = nome;
            Vida = vida;
            Level = level;
        }
    }
}
