using ApiGamePlay.Data.Context;
using ApiGamePlay.Data.Repositories;
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
    public class PlayerController : ControllerBase
    {
        public IPlayerRepository _repo;
        public GamePlayContext _context;
        //  olá mundo!!!
        // segundo comentario 
        public PlayerController(GamePlayContext context, IPlayerRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public List<ReadPlayerDto> RetornarPlayers()
        {
            return _repo.ListarPlayers();
        }

        [HttpPost]
        public void AddPlayer(CreatePlayerDto Adicioneplayer)
        {
            _repo.AdicionarPlayer(Adicioneplayer);
        }

        [HttpDelete]
        public IActionResult DeletePlayer(int id)
        {
            _repo.DeletaPlayer(id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult AttPlayer(int Id, Player playerAtual)
        {
            _repo.AtualizarPlayer(Id, playerAtual);
            return Ok();
        }
    }
}
