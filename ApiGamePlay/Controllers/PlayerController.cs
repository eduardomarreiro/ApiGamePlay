using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Interfaces.IServices;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
using ApiGamePlay.Shared.Requests;
using ApiGamePlay.Shared.Requests.PlayerRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGamePlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : BaseController
    {
        public IPlayerService _service;
        
        public PlayerController(IPlayerService service, IMediator mediator) : base(mediator)
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
            _mediator.Publish(new DeletaPlayerRequest(id));
            return Ok();
        }

        [HttpGet("async/{id}")]
        public async Task<ReadPlayerDto> RetornarPlayerAsyncPorId(int id)
        {
            return await _service.GetPlayerById(id);
        }

        [HttpGet("mediator/{id}")]
        public async Task<ReadPlayerDto> RetornarPlayerMediatorPorId(int id)
        {
            GetPlayerPorIdRequest request = new GetPlayerPorIdRequest(id);

            return await _mediator.Send(request); ;
        }

        [HttpPut]
        public async Task<IActionResult> AttPlayer(ModificaPlayersRequest playerAtual)
        {
            await _mediator.Publish(playerAtual);
            return Ok();
        }

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
