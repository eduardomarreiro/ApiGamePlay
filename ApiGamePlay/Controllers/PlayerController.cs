using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiGamePlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public PlayerService _service;

        public PlayerController(PlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Player> RetornarPlayers()
        {
            return _service.ConsultaPlayers();
        }

        [HttpPost]
        public void AddPlayer(CreatePlayerDto Adicioneplayer)
        {
            _service.AdicionarPlayer(Adicioneplayer);
        }

        [HttpDelete]
        public IActionResult DeletePlayer(int id)
        {
            _service.RemoverPlayer(id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult AttPlayer(int Id, Player playerAtual)
        {
            _service.ModificaPlayer(Id, playerAtual);
            return Ok();
        }
    }
}
