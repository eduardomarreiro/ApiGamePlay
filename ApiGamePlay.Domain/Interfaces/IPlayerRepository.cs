using ApiGamePlay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Interfaces
{
    public interface IPlayerRepository 
    {
        public List<Player> ListarPlayers();
        public void AdicionarPlayer(Player AdicionePlayer);
        public void DeletaPlayer(int id);
        public void AtualizarPlayer(int id, Player playerAtual);

    }
}
