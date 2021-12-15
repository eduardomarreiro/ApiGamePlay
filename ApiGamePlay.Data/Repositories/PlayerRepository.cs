using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public GamePlayContext _context;
        public PlayerRepository(GamePlayContext context)
        {
            _context = context;
        }

        public List<Player> ListarPlayers()
        {
            return _context.Players.ToList();
        }

        public void AdicionarPlayer(Player AdicionePlayer)
        {
            _context.Add(AdicionePlayer);
            _context.SaveChanges();
        }

        public void DeletaPlayer(int id)
        {
            Player player = _context.Players.FirstOrDefault(x => x.Id == id);
            if(player != null)
            {
                _context.Remove(player);
                _context.SaveChanges();
            }
        }
        public void AtualizarPlayer(int id, Player playerAtual)
        {
            Player updatePlayer = _context.Players.FirstOrDefault(x => x.Id == id);
            if(playerAtual != null)
            {
                updatePlayer.Nome = playerAtual.Nome;
                updatePlayer.Vida = playerAtual.Vida;
                updatePlayer.Level = playerAtual.Level;
                _context.SaveChanges();
            }
        }
    }
}
