using Moq;
using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using System.Threading.Tasks;

namespace TouhouLauncher.Test.Models.Application {
	public class LaunchRandomGameServiceTest {
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);
		private readonly Mock<LaunchGameService> _launchGameServiceMock = new(null, null);
		private readonly Mock<Random> _randomMock = new();

		private readonly LaunchRandomGameService _launchRandomGameService;

		public LaunchRandomGameServiceTest() {
			_launchRandomGameService = new(
				_settingsAndGamesManagerMock.Object,
				_launchGameServiceMock.Object,
				_randomMock.Object
			);
		}

		[Fact]
		public async void Does_not_start_a_game_when_no_games_exist() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.OfficialGames)
				.Returns(Array.Empty<OfficialGame>());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.FanGames)
				.Returns(new List<FanGame>());

			var result = await _launchRandomGameService.LaunchRandomGame();

			Assert.False(result);
		}

		[Fact]
		public async void Starts_a_game_when_games_exist() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.OfficialGames)
				.Returns(testOfficialGames);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.FanGames)
				.Returns(testFanGames);

			_randomMock.Setup(obj => obj.Next(It.IsAny<int>()))
				.Returns(1);

			_launchGameServiceMock.Setup(obj => obj.LaunchGame(It.IsAny<Game>()))
				.Returns(Task.FromResult(true));

			var result = await _launchRandomGameService.LaunchRandomGame();

			_launchGameServiceMock
				.Verify(obj => obj.LaunchGame(It.IsAny<Game>()), Times.Once());

			Assert.True(result);
		}
	}
}
