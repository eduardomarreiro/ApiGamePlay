using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Models
{
    public class Player : Entidade
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Level { get; set; }
        public virtual List<PlayerEquipamento> PlayerEquipamento { get; set; }
    }
}
