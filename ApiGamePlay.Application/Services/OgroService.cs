using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Application.Services
{
    public class OgroService
    {
        public IOgroRepository _OgroRepo;
        public IMapper _mapper;
        public OgroService(IOgroRepository OgroRepo, IMapper mapper)
        {
            _OgroRepo = OgroRepo;
            _mapper = mapper;
        }

        public void AdicionarOgro(Ogro ogro)
        {
            // Equipamento equipamento = _mapper.Map<Equipamento>(equipamentoDto);
            _OgroRepo.AdicionarOgro(ogro);
        }

        public List<Ogro> ConsultaOgro()
        {
            return _OgroRepo.ListarOgros();
        }

        //public Equipamento ConsultaOgroPorId(int id)
        //{
        //    return _OgroRepo.
        //}

        public void ModificaOgro(int id, Ogro ogro)
        {
            _OgroRepo.AtualizarOgro(id, ogro);
        }
    }
}
