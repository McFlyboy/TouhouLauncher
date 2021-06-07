using Moq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure.Persistence.FileSystem {
	public class FileSystemSettingsAndGamesServiceTest {
		private readonly Mock<FileAccessService> fileAccessServiceMock = new();
		private readonly Mock<OfficialGamesTemplateService> officialGamesTemplateServiceMock = new();

		private readonly FileSystemSettingsAndGamesService _fileSystemSettingsAndGamesService;

		public FileSystemSettingsAndGamesServiceTest() {
			_fileSystemSettingsAndGamesService = new(
				fileAccessServiceMock.Object,
				officialGamesTemplateServiceMock.Object
			);
		}

		[Fact]
		public async void Saves_settings_and_games_to_file_system_async_and_returns_result() {
			fileAccessServiceMock
				.Setup(obj => obj.WriteFileFromYamlAsync(It.IsAny<string>(), It.IsAny<SettingsAndGamesYaml>()))
				.Returns(Task.FromResult(true));

			var result = await _fileSystemSettingsAndGamesService.SaveAsync(testSettingsAndGames);

			Assert.True(result);
		}

		[Fact]
		public async void Loads_settings_and_games_from_file_system_async_and_returns_result() {
			fileAccessServiceMock
				.Setup(obj => obj.ReadFileToYamlAsync<SettingsAndGamesYaml>(It.IsAny<string>()))
				.Returns(Task.FromResult(testSettingsAndGamesYaml));

			officialGamesTemplateServiceMock
				.Setup(obj => obj.CreateOfficialGamesFromTemplate())
				.Returns(testOfficialGames);

			var result = await _fileSystemSettingsAndGamesService.LoadAsync();

			Assert.NotNull(result);
			Assert.Equal(testSettingsAndGames.GeneralSettings, result.GeneralSettings);
			Assert.Equal(testSettingsAndGames.EmulatorSettings, result.EmulatorSettings);
			Assert.Equal(testSettingsAndGames.OfficialGames[0], result.OfficialGames[0]);
			Assert.Equal(testSettingsAndGames.OfficialGames[1], result.OfficialGames[1]);
			Assert.Equal(testSettingsAndGames.OfficialGames[2], result.OfficialGames[2]);
			Assert.Equal(testSettingsAndGames.FanGames[0], result.FanGames[0]);
			Assert.Equal(testSettingsAndGames.FanGames[1], result.FanGames[1]);
		}
	}
}
