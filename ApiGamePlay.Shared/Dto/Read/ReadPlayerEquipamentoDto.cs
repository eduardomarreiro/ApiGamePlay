using ApiGamePlay.Shared.Dto.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Shared.Dto.Read
{
    public class ReadPlayerEquipamentoDto
    {
        public ReadEquipamentoDto Equipamento { get; set; }
        public ReadPlayerDto Player { get; set; }
    }
}
