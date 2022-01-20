using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Interfaces.IServices;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
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
    public class EquipamentoService : IEquipamentoService
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
            _EquipamentoRepo.Adicionar(equipamento);
        }

        public List<ReadEquipamentoDto> ConsultaEquipamentos()
        {
            List<Equipamento> list = _EquipamentoRepo.RetornarTodos();
            
            return _mapper.Map<List<ReadEquipamentoDto>>(list);
        }

        public ReadEquipamentoDto ConsultaEquipamentoPorId(int id)
        {
            ReadEquipamentoDto equipamentoDto = _mapper.Map<ReadEquipamentoDto>(id);
            _EquipamentoRepo.RetornarPorId(id);
            return equipamentoDto;
        }

        public void ModificaEquipamento(int id, UpdateEquipamentoDto equipamentoDto)
        {
            Equipamento equipamento = _EquipamentoRepo.RetornarPorId(id);
            if(equipamento != null)
            {
                equipamento.Id = id;
                equipamento.Level = equipamentoDto.Level;
                equipamento.Dano = equipamentoDto.Dano;
                equipamento.Nome = equipamentoDto.Nome;
                _EquipamentoRepo.Atualizar(equipamento);
            }       
        }

        public void DeleteEquipamentoPorId(int id)
        {
            Equipamento equipamento = _EquipamentoRepo.RetornarPorId(id);
            if (equipamento != null)
            {
                _EquipamentoRepo.Deletar(equipamento);
            }
        }
    }
}
