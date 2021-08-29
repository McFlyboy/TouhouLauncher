#nullable disable

using Moq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;

namespace TouhouLauncher.Test.Models.Application {
	public class SettingsAndGamesManagerTest {
		private readonly Mock<FileSystemSettingsAndGamesRepository> _fileSystemSettingsAndGamesServiceMock = new(null, null);
		private readonly Mock<OfficialGamesTemplateService> _officialGamesTemplateServiceMock = new();

		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public SettingsAndGamesManagerTest() {
			_settingsAndGamesManager = new(
				_fileSystemSettingsAndGamesServiceMock.Object,
				_officialGamesTemplateServiceMock.Object
			);
		}

		[Fact]
		public async void Saves_settings_and_games_and_returns_result() {
			_fileSystemSettingsAndGamesServiceMock
				.Setup(obj => obj.SaveAsync(It.IsAny<SettingsAndGames>()))
				.Returns(Task.FromResult(true));

			var result = await _settingsAndGamesManager.SaveAsync();

			Assert.True(result);
		}

		[Fact]
		public async void Returns_false_and_stores_default_settings_and_games_when_no_settings_and_games_exist() {
			_fileSystemSettingsAndGamesServiceMock
				.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<SettingsAndGames>(null));

			_officialGamesTemplateServiceMock
				.Setup(obj => obj.CreateOfficialGamesFromTemplate())
				.Returns(testOfficialGames);

			var result = await _settingsAndGamesManager.LoadAsync();

			Assert.False(result);

			Assert.NotNull(_settingsAndGamesManager.GeneralSettings);

			Assert.NotNull(_settingsAndGamesManager.EmulatorSettings);

			Assert.NotNull(_settingsAndGamesManager.OfficialGames);
			Assert.NotEmpty(_settingsAndGamesManager.OfficialGames);

			Assert.NotNull(_settingsAndGamesManager.FanGames);
			Assert.Empty(_settingsAndGamesManager.FanGames);
		}

		[Fact]
		public async void Returns_true_and_stores_loaded_settings_and_games_when_settings_and_games_exist() {
			_fileSystemSettingsAndGamesServiceMock
				.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult(testSettingsAndGames));

			var result = await _settingsAndGamesManager.LoadAsync();

			Assert.True(result);

			Assert.NotNull(_settingsAndGamesManager.GeneralSettings);

			Assert.NotNull(_settingsAndGamesManager.EmulatorSettings);

			Assert.NotNull(_settingsAndGamesManager.OfficialGames);
			Assert.NotEmpty(_settingsAndGamesManager.OfficialGames);

			Assert.NotNull(_settingsAndGamesManager.FanGames);
			Assert.NotEmpty(_settingsAndGamesManager.FanGames);
		}
	}
}
