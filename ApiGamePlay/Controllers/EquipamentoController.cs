using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Interfaces.IServices;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
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
        public IEquipamentoService _service;

        public EquipamentoController(IEquipamentoService service)
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
        public  IActionResult AtualizarEquipamnto(int id,  UpdateEquipamentoDto equipamento)
        {
            _service.ModificaEquipamento(id, equipamento);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEquipamentoPorId(int id)
        {
            _service.DeleteEquipamentoPorId(id);
            return Ok();
        }
    }
}