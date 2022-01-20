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
    public interface IEquipamentoService 
    {
        void AdicionarEquipamento(CreateEquipamentoDto equipamentoDto);
        List<ReadEquipamentoDto> ConsultaEquipamentos();
        ReadEquipamentoDto ConsultaEquipamentoPorId(int id);
        void ModificaEquipamento(int id, UpdateEquipamentoDto equipamentoDto);
        void DeleteEquipamentoPorId(int id);
    }
}
