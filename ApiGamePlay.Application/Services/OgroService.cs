using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
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
            _OgroRepo.Adicionar(ogro);
        }

        public List<Ogro> ConsultaOgro()
        {
            return _OgroRepo.RetornarTodos();
        }

        public ReadOgroDto consultaOgroPorId(int id)
        {
            ReadOgroDto ogroDto = _mapper.Map<ReadOgroDto>(id);

            return ogroDto;
        }

        public void ModificaOgro(int id, UpdateOgroDto ogroDto)
        {
            Ogro ogro = _OgroRepo.RetornarPorId(id);
            if(ogro != null)
            {
                ogro.Dano = ogroDto.Dano;
                ogro.Defesa = ogroDto.Defesa;
                ogro.Vida = ogroDto.Vida;
                _OgroRepo.Atualizar(ogro);
            }
        }

        public void DeletaOgro(int id)
        {
            Ogro ogro = _OgroRepo.RetornarPorId(id);
            if(ogro != null)
            {
                _OgroRepo.Deletar(ogro);
            } 
        }
    }
}
