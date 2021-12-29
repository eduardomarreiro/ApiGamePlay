using ApiGamePlay.Shared.Dto.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Shared.Dto.Update
{
    public class UpdatePlayerDto
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Level { get; set; }
        // public virtual List<ReadPlayerEquipamentoDto> PlayerEquipamento { get; set; }
    }
}
