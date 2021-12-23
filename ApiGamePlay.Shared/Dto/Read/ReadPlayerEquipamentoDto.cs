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
        public CreateEquipamentoDto Equipamento { get; set; }
        public CreatePlayerDto Player { get; set; }
    }
}
