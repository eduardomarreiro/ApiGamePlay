using ApiGamePlay.Application.Services;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiGamePlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserService _service;
        public AuthController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CreateUserDto userDto)
        {
            _service.AdicionarUser(userDto);
            return Ok();
        }

        [HttpGet]
        public List<ReadUserDto> GetUsers()
        {
            return _service.ConsultaUser();
        }

        [HttpGet("{id}")]
        public ReadUserDto ConsultarUserPorId(int id)
        {
            return _service.ConsultarUserPorId(id);
        }

        [HttpPut]
        public IActionResult AtualizarUserPorId(int id, UpdateUserDto userDto)
        {
            _service.ModificarUser(id, userDto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletarUSerPorId(int id)
        {
            _service.DeletarUserPorId(id);
            return Ok();
        }
    }
}
