using Moq;
using TouhouLauncher.Models.Application;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using System.Threading.Tasks;

namespace TouhouLauncher.Test.Models.Application {
	public class GameConfigServiceTest {
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);

		private readonly GameConfigService _gameConfigService;

		public GameConfigServiceTest() {
			_gameConfigService = new(_settingsAndGamesManagerMock.Object);
		}

		[Fact]
		public void Sets_game_to_configure_and_sets_game_location_to_location_of_game() {
			_gameConfigService.SetGameToConfigure(testOfficialGame1);

			Assert.Equal(testOfficialGame1, _gameConfigService.TargetGame);
			Assert.Equal(testOfficialGame1.FileLocation, _gameConfigService.GameLocation);
		}

		[Fact]
		public async void Doesnt_save_changes_when_target_game_is_null_and_returns_error() {
			var error = await _gameConfigService.SaveAsync();

			Assert.NotNull(error);

			_settingsAndGamesManagerMock.Verify(obj => obj.SaveAsync(), Times.Never);
		}

		[Fact]
		public async void Stores_game_location_in_game_and_saves_changes_and_returns_save_result() {
			_settingsAndGamesManagerMock.Setup(obj => obj.SaveAsync())
				.Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

			_gameConfigService.SetGameToConfigure(testOfficialGame1);

			var error = await _gameConfigService.SaveAsync();

			Assert.Null(error);
			Assert.Equal(_gameConfigService.GameLocation, testOfficialGame1.FileLocation);

			_settingsAndGamesManagerMock.Verify(obj => obj.SaveAsync(), Times.Once);
		}
	}
}
