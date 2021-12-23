using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Interfaces
{
    public interface IPlayerEquipamentoRepository
    {
        public void AdicionarEquipamentoAoPlayer(PlayerEquipamento InsiraEquipamentoAoPlayer);
        public void DeletarEquipamentoPlayerPorId(int Id);
        public List<PlayerEquipamento> RecuperaPlayerEquipamento();

    }
}
