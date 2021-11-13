using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Test.Models.Application {
	public class LaunchRandomGameServiceTest {
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);
		private readonly Mock<LaunchGameService> _launchGameServiceMock = new(null, null, null, null, null);
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
		public async void Returns_error_when_no_games_exist() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.OfficialGames)
				.Returns(Array.Empty<OfficialGame>());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.FanGames)
				.Returns(new List<FanGame>());

			var result = await _launchRandomGameService.LaunchRandomGame();

			Assert.NotNull(result);
			Assert.IsType<LaunchRandomGameServiceError.NoGamesFoundError>(result);
		}

		[Fact]
		public async void Returns_error_when_a_game_fails_to_start() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.OfficialGames)
				.Returns(testOfficialGames);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.FanGames)
				.Returns(testFanGames);

			_randomMock.Setup(obj => obj.Next(It.IsAny<int>()))
				.Returns(0);

			_launchGameServiceMock.Setup(obj => obj.LaunchGame(It.IsAny<Game>()))
				.Returns(Task.FromResult<TouhouLauncherError?>(new LaunchGameError.GameDoesNotExistError()));

			var result = await _launchRandomGameService.LaunchRandomGame();

			_launchGameServiceMock.Verify(obj => obj.LaunchGame(It.IsAny<Game>()), Times.Once());

			Assert.NotNull(result);
			Assert.IsType<LaunchGameError.GameDoesNotExistError>(result);
		}

		[Fact]
		public async void Returns_null_when_a_game_starts_successfully() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.OfficialGames)
				.Returns(testOfficialGames);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.FanGames)
				.Returns(testFanGames);

			_randomMock.Setup(obj => obj.Next(It.IsAny<int>()))
				.Returns(0);

			_launchGameServiceMock.Setup(obj => obj.LaunchGame(It.IsAny<Game>()))
				.Returns(Task.FromResult<TouhouLauncherError?>(null));

			var result = await _launchRandomGameService.LaunchRandomGame();

			_launchGameServiceMock.Verify(obj => obj.LaunchGame(It.IsAny<Game>()), Times.Once());

			Assert.Null(result);
		}
	}
}
