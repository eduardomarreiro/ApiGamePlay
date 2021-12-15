using ApiGamePlay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Interfaces
{
    public interface IOgroRepository
    {
        public List<Ogro> ListarOgros();

        public void AdicionarOgro(Ogro ogro);

        public void DeletaOgro(int id);

        public void AtualizarOgro(int id, Ogro OgroAtual);


    }
}
