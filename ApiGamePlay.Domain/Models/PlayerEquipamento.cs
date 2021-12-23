using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Models
{
    public class PlayerEquipamento : Entidade
    {
        public int EquipamentoId { get; set; }
        public virtual Equipamento Equipamento { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

    }
}
