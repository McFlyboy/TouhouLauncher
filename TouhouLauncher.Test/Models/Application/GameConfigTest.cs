using Moq;
using TouhouLauncher.Models.Application;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using System.Threading.Tasks;

namespace TouhouLauncher.Test.Models.Application {
	public class GameConfigTest {
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);

		private readonly GameConfig _gameConfig;

		public GameConfigTest() {
			_gameConfig = new(_settingsAndGamesManagerMock.Object);
		}

		[Fact]
		public void Sets_game_to_configure_and_sets_game_location_to_location_of_game() {
			_gameConfig.SetGameToConfigure(testOfficialGame1);

			Assert.Equal(testOfficialGame1, _gameConfig.TargetGame);
			Assert.Equal(testOfficialGame1.FileLocation, _gameConfig.GameLocation);
		}

		[Fact]
		public async void Doesnt_save_changes_when_target_game_is_null_and_returns_error() {
			var error = await _gameConfig.SaveAsync();

			Assert.NotNull(error);

			_settingsAndGamesManagerMock.Verify(obj => obj.SaveAsync(), Times.Never);
		}

		[Fact]
		public async void Stores_game_location_in_game_and_saves_changes_and_returns_save_result() {
			_settingsAndGamesManagerMock.Setup(obj => obj.SaveAsync())
				.Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

			_gameConfig.SetGameToConfigure(testOfficialGame1);

			var error = await _gameConfig.SaveAsync();

			Assert.Null(error);
			Assert.Equal(_gameConfig.GameLocation, testOfficialGame1.FileLocation);

			_settingsAndGamesManagerMock.Verify(obj => obj.SaveAsync(), Times.Once);
		}
	}
}
