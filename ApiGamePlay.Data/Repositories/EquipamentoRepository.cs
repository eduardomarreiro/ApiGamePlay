using ApiGamePlay.Data.Context;
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

namespace ApiGamePlay.Data.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository 
    {
        public GamePlayContext _context;
        public IMapper _mapper;
        public EquipamentoRepository(GamePlayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public Equipamento RetornarEquipamentoPorId(int id)
        {
            Equipamento equipamento = _context.Equipamentos.FirstOrDefault(x => x.Id == id);
            return equipamento;
        }

        public void AdicionarEquipamento(CreateEquipamentoDto AddEquipamento)
        {
            Equipamento equipamento = new Equipamento();
            equipamento = _mapper.Map<Equipamento>(AddEquipamento);
            _context.Equipamentos.Add(equipamento);
            _context.SaveChanges();
        }

        public List<ReadEquipamentoDto> RetornarEquipamentos()
        {
            List<Equipamento> EquipamentoDb;
            EquipamentoDb = _context.Equipamentos.ToList();
            List<ReadEquipamentoDto> EquipamentosDtos;
            EquipamentosDtos = _mapper.Map<List<ReadEquipamentoDto>>(EquipamentoDb);
            
            return EquipamentosDtos;
        }
        public void AlterarEquipamento(Equipamento obj)
        {
            _context.Equipamentos.Update(obj);
            _context.SaveChanges();
        }

        public void DeletarEquipamentoPorId(int id)
        {
            Equipamento equipamento = _context.Equipamentos.FirstOrDefault(x => x.Id == id);
            if (equipamento != null)
            {
                _context.Remove(equipamento);
                _context.SaveChanges();
            }
        }
    }
}
