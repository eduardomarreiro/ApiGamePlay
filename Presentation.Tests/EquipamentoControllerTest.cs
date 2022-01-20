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
    public class EquipamentoControllerTest
    {
        private readonly EquipamentoController _sut;
        private readonly Mock<IEquipamentoService> _equipamentoService;

        public EquipamentoControllerTest()
        {
            _equipamentoService = new Mock<IEquipamentoService>();
            _sut = new EquipamentoController(_equipamentoService.Object);
        }
       
        [Fact]
        public void RetornarEquipamentosDeveListaDeReadEquipamentoDto()
        {
            //Arrange
            List<ReadEquipamentoDto> equipamentoDtosList = new List<ReadEquipamentoDto>();
            ReadEquipamentoDto DoranShield = new ReadEquipamentoDto();
           
            DoranShield.Level = 1;
            DoranShield.Nome = "Escudo de Doran";
            DoranShield.Dano = 0;
            
            equipamentoDtosList.Add(DoranShield);
            _equipamentoService.Setup(x => x.ConsultaEquipamentos()).Returns(equipamentoDtosList);

            //Act
            var resultado = _sut.GetEquipamentos();

            //Assert
            _equipamentoService.Verify(v => v.ConsultaEquipamentos(), Times.Once());
            Assert.IsType<List<ReadEquipamentoDto>>(resultado);
        }
        public void RetornarEquipamentoPorId_Deve_Retornar_ReadEquipamentoDto()
        {
            //arrange
            ReadEquipamentoDto equipamentoDto = new ReadEquipamentoDto();
            equipamentoDto.Nome = "Manopla do infito";
            equipamentoDto.Level = 1;
            equipamentoDto.Dano = 50;
            equipamentoDto.Level = 8;

            _equipamentoService.Setup(x => x.ConsultaEquipamentoPorId(It.IsAny<int>())).Returns(equipamentoDto);

            //act

            var resultado = _sut.GetEquipamentos();

            //assert
        }
    }
}
