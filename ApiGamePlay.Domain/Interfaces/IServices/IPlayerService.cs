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
    public interface IPlayerService
    {
        void AdicionarPlayer(CreatePlayerDto playerDto);
        List<ReadPlayerDto> ConsultaPlayers();
        ReadPlayerDto ConsultaPlayerPorId(int id);
        void ModificarPlayer(int id, UpdatePlayerDto playerDto);
        void RemoverPlayer(int id);

        Task<ReadPlayerDto> GetPlayerById(int id);
    }
}
