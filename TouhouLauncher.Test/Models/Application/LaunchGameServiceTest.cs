using Moq;
using System.Diagnostics;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.SettingsInfo;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Infrastructure.Execution.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

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
		public async void Returns_error_when_saving_emulator_config_fails() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(testNp21ntConfig));

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.SaveAsync(It.IsAny<Np21ntConfig?>()))
				.Returns(Task.FromResult(new Np21ntConfigSaveError("Error"))!);

			var error = await _launchGameService.LaunchGame(testOfficialGame2);

			Assert.NotNull(error);
		}

		[Fact]
		public async void Returns_error_when_game_location_is_wrong() {
			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new ExecutorServiceError.ExecutableDoesNotExistError("some location"));

			var error = await _launchGameService.LaunchGame(testOfficialGame1);

			Assert.NotNull(error);
		}

		[Fact]
		public async void Returns_null_when_game_location_is_correct() {
			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new Process());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.GeneralSettings)
				.Returns(
					new GeneralSettings(
						closeOnGameLaunch: false,
						combineMainCategories: false
					)
				);

			var error = await _launchGameService.LaunchGame(testOfficialGame1);

			Assert.Null(error);
		}

		[Fact]
		public async void Returns_null_after_using_emulator_config_defaults_when_loading_config_fails() {
			_fileSystemNp21ntConfigRepository.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(new Np21ntConfigLoadError("Error")));

			_np21ntConfigDefaultsServiceMock.Setup(obj => obj.CreateNp21ntConfigDefaults())
				.Returns(testNp21ntConfig);

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.SaveAsync(It.IsAny<Np21ntConfig?>()))
				.Returns(Task.FromResult<Np21ntConfigSaveError?>(null));

			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new Process());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.GeneralSettings)
				.Returns(
					new GeneralSettings(
						closeOnGameLaunch: false,
						combineMainCategories: false
					)
				);

			var error = await _launchGameService.LaunchGame(testOfficialGame2);

			_np21ntConfigDefaultsServiceMock.Verify(obj => obj.CreateNp21ntConfigDefaults(), Times.Once);

			Assert.Null(error);
		}
	}
}
