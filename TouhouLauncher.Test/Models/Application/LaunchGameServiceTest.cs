#nullable disable

using Moq;
using System.Diagnostics;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.SettingsInfo;
using TouhouLauncher.Models.Infrastructure.Execution.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using System.Threading.Tasks;

namespace TouhouLauncher.Test.Models.Application {
	public class LaunchGameServiceTest {
		private readonly Mock<FileSystemExecutorService> _fileSystemExecutorServiceMock = new();
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);
		private readonly Mock<FileSystemNp21ntConfigRepository> _fileSystemNp21ntConfigRepository = new(null, null, null);
		private readonly Mock<Np21ntConfigDefaultsService> _np21ntConfigDefaultsServiceMock = new();

		private readonly LaunchGameService _launchGameService;

		public LaunchGameServiceTest() {
			_launchGameService = new(
				_fileSystemExecutorServiceMock.Object,
				_settingsAndGamesManagerMock.Object,
				_fileSystemNp21ntConfigRepository.Object,
				_np21ntConfigDefaultsServiceMock.Object
			);
		}

		[Fact]
		public async void Returns_false_when_saving_emulator_config_fails() {
			_fileSystemNp21ntConfigRepository.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult(testNp21ntConfig));

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.SaveAsync(It.IsAny<Np21ntConfig>()))
				.Returns(Task.FromResult(false));

			var result = await _launchGameService.LaunchGame(testOfficialGame2);

			Assert.False(result);
		}

		[Fact]
		public async void Returns_false_when_game_location_is_wrong() {
			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns<Process>(null);

			var result = await _launchGameService.LaunchGame(testOfficialGame1);

			Assert.False(result);
		}

		[Fact]
		public async void Returns_true_when_game_location_is_correct() {
			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new Process());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.GeneralSettings)
				.Returns(new GeneralSettings() { CloseOnGameLaunch = false });

			var result = await _launchGameService.LaunchGame(testOfficialGame1);

			Assert.True(result);
		}

		[Fact]
		public async void Returns_true_after_using_emulator_config_defaults_when_loading_config_fails() {
			_fileSystemNp21ntConfigRepository.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Np21ntConfig>(null));

			_np21ntConfigDefaultsServiceMock.Setup(obj => obj.CreateNp21ntConfigDefaults())
				.Returns(testNp21ntConfig);

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.SaveAsync(It.IsAny<Np21ntConfig>()))
				.Returns(Task.FromResult(true));

			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new Process());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.GeneralSettings)
				.Returns(new GeneralSettings() { CloseOnGameLaunch = false });

			var result = await _launchGameService.LaunchGame(testOfficialGame2);

			_np21ntConfigDefaultsServiceMock.Verify(obj => obj.CreateNp21ntConfigDefaults(), Times.Once);

			Assert.True(result);
		}
	}
}
