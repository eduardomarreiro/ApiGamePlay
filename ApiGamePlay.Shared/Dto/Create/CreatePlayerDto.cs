using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Shared.Dto.Create
{
    public class CreatePlayerDto
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Level { get; set; }
    }
}
