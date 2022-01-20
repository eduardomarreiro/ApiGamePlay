using ApiGamePlay.Application.Services;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Interfaces.IServices;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Update;
using AutoMapper;
using Moq;
using System;
using Xunit;

namespace Application.Tests
{
    public class PlayerServiceTest
    {
        private readonly PlayerService _sut;
        private readonly Mock<IPlayerRepository> _playerRepo;
        private readonly Mock<IMapper> _mapper;

        public PlayerServiceTest()
        {
            _playerRepo = new Mock<IPlayerRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new PlayerService(_playerRepo.Object, _mapper.Object);
        }

        [Fact]
        public void AtualizarPlayerVerificaSeOMetodoFoiChamado()
        {
            //Arrange
            int id = 1;
            UpdatePlayerDto updatePlayer = new UpdatePlayerDto();
            updatePlayer.Vida = 200;
            updatePlayer.Level = 1;
            updatePlayer.Nome = "Ricardo";
            
            Player player = new Player();
            player.Id = id;
            player.Level = 2;
            player.Nome = "Rafael";
            player.Vida = 400;

            _playerRepo.Setup(x => x.RetornarPorId(id)).Returns(player);
            //Act
            
            _sut.ModificarPlayer(id, updatePlayer);
            //_playerRepo.Verify(x => x.Atualizar(player), z => z.)

            //Assert
            _playerRepo.Verify(z => z.Atualizar(player), Times.Once());
        }
    }
}
