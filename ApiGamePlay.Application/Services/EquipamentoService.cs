using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Application.Services
{
    public class EquipamentoService
    {
        public IEquipamentoRepository _EquipamentoRepo;
        public IMapper _mapper;
        public EquipamentoService(IEquipamentoRepository EquipamentoRepo, IMapper mapper)
        {
            _EquipamentoRepo = EquipamentoRepo;
            _mapper = mapper;
        }

        public void AdicionarEquipamento(CreateEquipamentoDto equipamentoDto)
        {
            Equipamento equipamento = _mapper.Map<Equipamento>(equipamentoDto);
            _EquipamentoRepo.AdicionarEquipamento(equipamentoDto);
        }

        public List<ReadEquipamentoDto> ConsultaEquipamentos()
        {
            return _EquipamentoRepo.RetornarEquipamentos();
        }

        public Equipamento ConsultaEquipamentoPorId(int id)
        {
            return _EquipamentoRepo.RetornarEquipamentoPorId(id);
        }

        public void ModificaEquipamento(Equipamento equipamento)
        {
            _EquipamentoRepo.AlterarEquipamento(equipamento);
        }

        public void DeleteEquipamentoPorId(int id)
        {
            _EquipamentoRepo.DeletarEquipamentoPorId(id);
        }
    }
}
