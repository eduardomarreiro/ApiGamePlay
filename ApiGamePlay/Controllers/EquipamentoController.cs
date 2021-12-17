using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
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
        public IEquipamentoRepository _repo;
        public GamePlayContext _context;

        public EquipamentoController(GamePlayContext context, IEquipamentoRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult PostEquipamento(CreateEquipamentoDto equipamento)
        {
            _repo.AdicionarEquipamento(equipamento);
            return Ok();
        }

        [HttpGet]
        public List<ReadEquipamentoDto> GetEquipamentos()
        {
            return _repo.RetornarEquipamentos();
        }
    }
}