﻿using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Data.Repositories;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Interfaces.IServices;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
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
    public class OgroController : ControllerBase
    {
        public IOgroService _service;

        public OgroController(IOgroService service)
        {
            _service = service;
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteOgro(int Id)
        {
            _service.DeletaOgro(Id);
            return Ok();
        }

        [HttpGet]
        public List<Ogro> RetornarOgro()
        {
            return _service.ConsultaOgro();
        }
        [HttpPost]
        public void AddOgro(CreateOgroDto AdicioneOgro)
        {
            _service.AdicionarOgro(AdicioneOgro);
        }

        [HttpPut("{id}")]
        public IActionResult AttOgro(int id, UpdateOgroDto OgroAtual)
        {
            _service.ModificaOgro(id, OgroAtual);
            return Ok();
        }
    }
}
