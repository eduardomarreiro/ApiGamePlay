using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Interfaces
{
    public interface IEquipamentoRepository
    {
        public void AdicionarEquipamento(CreateEquipamentoDto AddEquipamento);

        public List<ReadEquipamentoDto> RetornarEquipamentos();
    }
}
