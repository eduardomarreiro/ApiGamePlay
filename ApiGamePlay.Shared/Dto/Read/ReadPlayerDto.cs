using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Shared.Dto.Read
{
    public class ReadPlayerDto 
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Level { get; set; }
        public virtual List<ReadEquipamentoDto> Equipamento { get; set; }
    }
}
