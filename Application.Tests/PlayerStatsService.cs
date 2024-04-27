using Application.Dtos;
using Application.Interfaces;
using Application.Logic;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.Tests
{
    [TestFixture]
    public class PlayerStatsServiceTests
    {
        [Test]
        public async Task GetPlayerStats_ValidPlayerName_ReturnsPlayerDashboardDto()
        {
            // Arrange
            var playerName = "TestPlayer";
            var mockPlayerRepository = new Mock<IPlayerRepository>();
            mockPlayerRepository.Setup(repo => repo.GetByPlayerName(playerName))
                                .ReturnsAsync(new PlayerDto { Id = 1, Name = playerName, Level = 10 });
            var mockLogger = new Mock<ILogger<PlayerStatsService>>();

            var mockPlayerResultsRepository = new Mock<IPlayerResultsRepository>();
            mockPlayerResultsRepository.Setup(repo => repo.GetAsync(It.IsAny<int>()))
                                       .ReturnsAsync(new List<PlayerResultDto>
                                       {
                                       new PlayerResultDto { Kills = 10, Deaths = 5, WonGame = true },
                                       new PlayerResultDto { Kills = 8, Deaths = 6, WonGame = false }
                                       });

            var playerStatsService = new PlayerStatsService(mockLogger.Object, mockPlayerRepository.Object, mockPlayerResultsRepository.Object);

            // Act
            var result = await playerStatsService.GetPlayerStats(playerName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(playerName, result.PlayerName);
            Assert.AreEqual(10, result.Level);
            Assert.AreEqual(2, result.GamesPlayed);
            Assert.AreEqual(9, result.KillsPerGameAverage); // (10 + 8) / 2
        }

        [Test]
        public async Task GetPlayerStats_InvalidPlayerName_ReturnsNull()
        {
            // Arrange
            var playerName = "InvalidPlayer";
            var mockLogger = new Mock<ILogger<PlayerStatsService>>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();
            mockPlayerRepository.Setup(repo => repo.GetByPlayerName(playerName))
                                .ReturnsAsync((PlayerDto)null);

            var mockPlayerResultsRepository = new Mock<IPlayerResultsRepository>();
            var playerStatsService = new PlayerStatsService(mockLogger.Object, mockPlayerRepository.Object, mockPlayerResultsRepository.Object);

            // Act
            var result = await playerStatsService.GetPlayerStats(playerName);

            // Assert
            Assert.IsNull(result);
        }      
    }
}
