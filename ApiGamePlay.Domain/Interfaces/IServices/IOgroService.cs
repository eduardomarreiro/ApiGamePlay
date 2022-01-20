using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Interfaces.IServices
{
    public interface IOgroService
    {
        void AdicionarOgro(CreateOgroDto ogroDto);
        List<Ogro> ConsultaOgro();
        ReadOgroDto consultaOgroPorId(int id);
        void ModificaOgro(int id, UpdateOgroDto ogroDto);
        void DeletaOgro(int id);
    }
}
