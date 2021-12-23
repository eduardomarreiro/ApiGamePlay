using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiGamePlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerEquipamentoController : ControllerBase
    {
        private PlayerEquipamentoService _service;

        public PlayerEquipamentoController(PlayerEquipamentoService service)
        {
            _service = service;
        }
        
        [HttpDelete]
        public IActionResult DeletePlayerEquipamento(int id)
        {
            _service.DelatarPlayerEquipamentoPorId(id);
            return Ok();
        }
        
        [HttpPost]
        public IActionResult AddPlayerEquipamento(CreatePlayerEquipamentoDto playerEquipamentoInserido)
        {
            _service.AdicionarEquipamentoAoPlayer(playerEquipamentoInserido);
            return Ok();
        }
        [HttpGet]
        public List<PlayerEquipamento> GetPlayerEquipamento()
        {
            return _service.RetornarPlayerEquipamento();
        }

        public IActionResult DeletePlayerAndEquipamento(int id)
        {
            _service.DelatarPlayerEquipamentoPorId(id);
            return Ok();
        }
    }
}
