using ApiGamePlay.Data.Context;
using ApiGamePlay.Data.Repositories;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
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
    public class OgroController : ControllerBase
    {
        public IOgroRepository _repo;
        public GamePlayContext _context;
        public OgroController(GamePlayContext context, IOgroRepository repo)
        {
            _context = context;
            _repo = repo;

        }

        [HttpDelete("deletandoVarios/{min}/{max}")]
        public IActionResult DeletandoOgros(int min, int max)
        {
            List<Ogro> Ogros = _context.Ogros.ToList();
            int QtdOgros = Ogros.Count;
            if(QtdOgros == 0)
            {
                return Ok();
            }
            foreach(var Ogro in Ogros)
            {
                if(Ogro.Id >= min && Ogro.Id <= max)
                {
                   _context.Remove(Ogro);
                   _context.SaveChanges();
                }
            }
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteOgro (int Id)
        {
            _repo.DeletaOgro(Id);
            return Ok();
        }

        [HttpGet]
        public List<Ogro> RetornarOgro()
        {
            return _repo.ListarOgros();
        }

        [HttpPost]
        public void AddOgro(Ogro AdicioneOgro)
        {
            _repo.AdicionarOgro(AdicioneOgro);
        }

        [HttpPut("{id}")]
        public IActionResult AttOgro(int id, Ogro OgroAtual)
        {
            _repo.AtualizarOgro(id, OgroAtual);
            return Ok();
        }
    }
}
