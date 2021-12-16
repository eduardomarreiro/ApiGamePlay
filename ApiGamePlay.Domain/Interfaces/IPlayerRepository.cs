using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Interfaces
{
    public interface IPlayerRepository 
    {
        public List<ReadPlayerDto> ListarPlayers();
        public void AdicionarPlayer(CreatePlayerDto AdicionePlayer);
        public void DeletaPlayer(int id);
        public void AtualizarPlayer(int id, Player playerAtual);

    }
}
