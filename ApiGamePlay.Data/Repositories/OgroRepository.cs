using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Repositories
{
    public class OgroRepository : IOgroRepository
    {
        public GamePlayContext _context;

        public OgroRepository(GamePlayContext context)
        {
            _context = context;
        }

        public List<Ogro> ListarOgros()
        {
            return _context.Ogros.ToList();
        }

        public void AdicionarOgro(Ogro ogro)
        {
            _context.Add(ogro);
            _context.SaveChanges();
        }


        public void DeletaOgro (int id)
        {
            Ogro ogro = _context.Ogros.FirstOrDefault(x => x.Id == id);

            if(ogro != null)
            {
                _context.Ogros.Remove(ogro);
                _context.SaveChanges();
            }         
        }


        public void AtualizarOgro(int id, Ogro OgroAtual)
        {
            Ogro updateOgro = _context.Ogros.FirstOrDefault(x => x.Id == id);
            if(OgroAtual != null)
            {
                updateOgro.Dano = OgroAtual.Dano;
                updateOgro.Defesa = OgroAtual.Defesa;
                updateOgro.Vida = OgroAtual.Vida;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Passe um ogro");
            }
        }
    }
}
