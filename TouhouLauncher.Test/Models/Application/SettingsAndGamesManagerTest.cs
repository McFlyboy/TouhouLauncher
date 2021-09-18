using Moq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using TouhouLauncher.Models.Common;

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
				.Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

			var error = await _settingsAndGamesManager.SaveAsync();

			Assert.Null(error);
		}

		[Fact]
		public async void Returns_error_when_no_settings_and_games_exist() {
			_fileSystemSettingsAndGamesServiceMock
				.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Either<SettingsAndGamesLoadError, SettingsAndGames>>(new SettingsAndGamesLoadError("Error")));

			_officialGamesTemplateServiceMock
				.Setup(obj => obj.CreateOfficialGamesFromTemplate())
				.Returns(testOfficialGames);

			var result = await _settingsAndGamesManager.LoadAsync();

			Assert.NotNull(result);
		}

		[Fact]
		public async void Returns_null_and_stores_loaded_settings_and_games_when_settings_and_games_exist() {
			_fileSystemSettingsAndGamesServiceMock
				.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Either<SettingsAndGamesLoadError, SettingsAndGames>>(testSettingsAndGames));

			var result = await _settingsAndGamesManager.LoadAsync();

			Assert.Null(result);

			Assert.True(_settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch);

			Assert.NotNull(_settingsAndGamesManager.EmulatorSettings.FolderLocation);

			Assert.NotEmpty(_settingsAndGamesManager.OfficialGames);

			Assert.NotEmpty(_settingsAndGamesManager.FanGames);
		}
	}
}
