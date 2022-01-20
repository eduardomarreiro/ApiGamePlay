using ApiGamePlay.Application.Services;
using ApiGamePlay.Controllers;
using ApiGamePlay.Domain.Interfaces.IServices;
using ApiGamePlay.Shared.Dto.Read;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presentation.Tests
{
    public class PlayerControllerTest
    {
        private readonly PlayerController _sut;
        private readonly Mock<IPlayerService> _playerService;

        public PlayerControllerTest()
        {
            _playerService = new Mock<IPlayerService>();
            _sut = new PlayerController(_playerService.Object);         
        }

        [Fact]
        public void RetornarPlayersDeveRetornarListaDeReadPlayerDto()
        {
            // arrange
            List<ReadPlayerDto> playerDtosList = new List<ReadPlayerDto>();
            ReadPlayerDto Eduardo = new ReadPlayerDto();

            Eduardo.Level = 1;
            Eduardo.Nome = "Eduardo";
            Eduardo.Vida = 500;

            playerDtosList.Add(Eduardo);
            _playerService.Setup(x => x.ConsultaPlayers()).Returns(playerDtosList);
            // act

            var resultado = _sut.RetornarPlayers();

            // assert
            _playerService.Verify(z => z.ConsultaPlayers(), Times.Once());
            Assert.IsType<List<ReadPlayerDto>>(resultado);
            Assert.NotEqual(0, resultado.Count); 
        }

        [Fact]
        public async void RetornarPlayerAsyncPorId_Deve_Retornar_ReadPlayerDto()
        {
            //arrange
            ReadPlayerDto playerDto = new ReadPlayerDto();
            playerDto.Level = 23;
            playerDto.Nome = "Rafael";
            playerDto.Vida = 800;

            _playerService.Setup(x => x.GetPlayerById(It.IsAny<int>())).ReturnsAsync(playerDto);
            //act
            var resultado = await _sut.RetornarPlayerAsyncPorId(4);

            //assert
            Assert.IsType<ReadPlayerDto>(resultado);
            Assert.Equal(playerDto.Nome, resultado.Nome);
        }
        
        [Fact]
        public async void RetornarPlayerPorIdRetornarVazioCasoNaoEncontrado()
        {
            //arrenge
            _playerService.Setup(z => z.GetPlayerById(It.IsAny<int>())).ReturnsAsync(new ReadPlayerDto());

            //act
            var resultado = await _sut.RetornarPlayerAsyncPorId(20);

            //assert

            Assert.IsType<ReadPlayerDto>(resultado);
            Assert.Null(resultado.Nome);
            _playerService.Verify(y => y.GetPlayerById(It.IsAny<int>()), Times.Once());
        }
    }
}
