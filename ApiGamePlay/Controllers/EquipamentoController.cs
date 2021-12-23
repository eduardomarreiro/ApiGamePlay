using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamePlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        public EquipamentoService _service;

        public EquipamentoController(EquipamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostEquipamento(CreateEquipamentoDto equipamento)
        {
            _service.AdicionarEquipamento(equipamento);
            return Ok();
        }

        [HttpGet]
        public List<ReadEquipamentoDto> GetEquipamentos()
        {
            return _service.ConsultaEquipamentos();
        }

        [HttpPut] 
        public  IActionResult AtualizarEquipamnto(Equipamento equipamento)
        {
            _service.ModificaEquipamento(equipamento);
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteEquipamentoPorId(int id)
        {
            _service.DeleteEquipamentoPorId(id);
            return Ok();
        }
    }
}