using Moq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure.Persistence.FileSystem {
	public class FileSystemSettingsAndGamesRepositoryTest {
		private readonly Mock<FileAccessService> _fileAccessServiceMock = new();
		private readonly Mock<OfficialGamesTemplateService> _officialGamesTemplateServiceMock = new();

		private readonly FileSystemSettingsAndGamesRepository _fileSystemSettingsAndGamesRepository;

		public FileSystemSettingsAndGamesRepositoryTest() {
			_fileSystemSettingsAndGamesRepository = new(
				_fileAccessServiceMock.Object,
				_officialGamesTemplateServiceMock.Object
			);
		}

		[Fact]
		public async void Saves_settings_and_games_to_file_system_async_and_returns_result() {
			_fileAccessServiceMock
				.Setup(obj => obj.WriteFileFromYamlAsync(It.IsAny<string>(), It.IsAny<SettingsAndGamesYaml>()))
				.Returns(Task.FromResult<FileWriteError?>(null));

			var result = await _fileSystemSettingsAndGamesRepository.SaveAsync(testSettingsAndGames);

			Assert.True(result);
		}

		[Fact]
		public async void Loads_settings_and_games_from_file_system_async_and_returns_result() {
			_fileAccessServiceMock
				.Setup(obj => obj.ReadFileToYamlAsync<SettingsAndGamesYaml>(It.IsAny<string>()))
				.Returns(Task.FromResult<Either<TouhouLauncherError, SettingsAndGamesYaml>>(testSettingsAndGamesYaml));

			_officialGamesTemplateServiceMock
				.Setup(obj => obj.CreateOfficialGamesFromTemplate())
				.Returns(testOfficialGames);

			var result = await _fileSystemSettingsAndGamesRepository.LoadAsync();

			Assert.NotNull(result);
			Assert.Equal(testSettingsAndGames.GeneralSettings, result?.GeneralSettings);
			Assert.Equal(testSettingsAndGames.EmulatorSettings, result?.EmulatorSettings);
			Assert.Equal(testSettingsAndGames.OfficialGames[0], result?.OfficialGames[0]);
			Assert.Equal(testSettingsAndGames.OfficialGames[1], result?.OfficialGames[1]);
			Assert.Equal(testSettingsAndGames.OfficialGames[2], result?.OfficialGames[2]);
			Assert.Equal(testSettingsAndGames.FanGames[0], result?.FanGames[0]);
			Assert.Equal(testSettingsAndGames.FanGames[1], result?.FanGames[1]);
		}
	}
}
