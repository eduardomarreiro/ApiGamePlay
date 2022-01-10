using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public List<ReadPlayerDto> RetornarPlayers()
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

        [HttpGet("async/{id}")]
        public async Task<ReadPlayerDto> RetornarPlayerAsyncPorId(int id)
        {
            return await _service.GetPlayerById(id);
        }

        //[HttpPut("{Id}")]
        //public IActionResult AttPlayer(int Id, UpdatePlayerDto playerAtual)
        //{
        //    _service.ModificaPlayer(Id, playerAtual);
        //    return Ok();
        //}

        //[HttpGet("{Id}")]

        //public IActionResult RetornarPlayerPorId(int Id)
        //{
        //    ReadPlayerDto playerDto = _service.ConsultaPlayerPorId(Id);
        //    if(playerDto != null)
        //    {
        //        return Ok(playerDto);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}

        //[HttpGet("{id}")]
        //public IActionResult RetornarPlayerEquipamentoPorId(int id)
        //{
        //    ReadPlayerDto playerDto = _service.RetornarPlayerEEQuipamentoPorId(id);
        //    if(playerDto == null)
        //    {
        //        return Ok(playerDto);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}
    }
}
