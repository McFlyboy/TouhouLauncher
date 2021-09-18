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
		private readonly Mock<PathExistanceService> _pathExistanceServiceMock = new();

		private readonly LaunchGameService _launchGameService;

		public LaunchGameServiceTest() {
			_launchGameService = new(
				_fileSystemExecutorServiceMock.Object,
				_settingsAndGamesManagerMock.Object,
				_fileSystemNp21ntConfigRepository.Object,
				_np21ntConfigDefaultsServiceMock.Object,
				_pathExistanceServiceMock.Object
			);
		}

		[Fact]
		public async void Returns_error_when_game_does_not_exist() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists(It.IsAny<string?>()))
				.Returns(false);

			var error = await _launchGameService.LaunchGame(testOfficialGame1);

			Assert.NotNull(error);
			Assert.IsType<LaunchGameError.GameDoesNotExistError>(error);
		}

		[Fact]
		public async void Returns_error_when_emulator_location_has_not_been_set() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists("C:\\test\\location2.exe"))
				.Returns(true);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(new EmulatorSettings(null));

			var error = await _launchGameService.LaunchGame(testOfficialGame2);

			Assert.NotNull(error);
			Assert.IsType<LaunchGameError.EmulatorLocationNotSetError>(error);
		}

		[Fact]
		public async void Returns_error_when_emulator_does_not_exist() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists("C:\\test\\location2.exe"))
				.Returns(true);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			var error = await _launchGameService.LaunchGame(testOfficialGame2);

			Assert.NotNull(error);
			Assert.IsType<LaunchGameError.EmulatorDoesNotExistError>(error);
		}

		[Fact]
		public async void Returns_error_when_unable_to_save_emulator_config() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists(It.IsAny<string?>()))
				.Returns(true);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(testNp21ntConfig));

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.SaveAsync(It.IsAny<Np21ntConfig?>()))
				.Returns(Task.FromResult(new Np21ntConfigSaveError("error"))!);

			var error = await _launchGameService.LaunchGame(testOfficialGame2);

			Assert.NotNull(error);
			Assert.IsType<Np21ntConfigSaveError>(error);
		}

		[Fact]
		public async void Returns_error_when_unable_to_execute_game() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists(It.IsAny<string?>()))
				.Returns(true);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new ExecutorServiceError.ProcessExecuteError("location"));

			var error = await _launchGameService.LaunchGame(testOfficialGame1);

			Assert.NotNull(error);
			Assert.IsType<ExecutorServiceError.ProcessExecuteError>(error);
		}

		[Fact]
		public async void Returns_null_when_game_launches_successfully() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists(It.IsAny<string?>()))
				.Returns(true);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new Process());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.GeneralSettings)
				.Returns(testGeneralSettings with { CloseOnGameLaunch = false });

			var error = await _launchGameService.LaunchGame(testOfficialGame1);

			Assert.Null(error);

			_fileSystemExecutorServiceMock.Verify(obj => obj.StartExecutable(It.IsAny<string>()), Times.Once);
		}

		[Fact]
		public async void Returns_null_when_emulator_game_launches_successfully() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists(It.IsAny<string?>()))
				.Returns(true);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(testNp21ntConfig));

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.SaveAsync(It.IsAny<Np21ntConfig?>()))
				.Returns(Task.FromResult<Np21ntConfigSaveError?>(null));

			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new Process());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.GeneralSettings)
				.Returns(testGeneralSettings with { CloseOnGameLaunch = false });

			var error = await _launchGameService.LaunchGame(testOfficialGame2);

			Assert.Null(error);

			_fileSystemNp21ntConfigRepository.Verify(obj => obj.SaveAsync(It.IsAny<Np21ntConfig?>()), Times.Once);
			_fileSystemExecutorServiceMock.Verify(obj => obj.StartExecutable(It.IsAny<string>()), Times.Once);
		}

		[Fact]
		public async void Returns_null_when_emulator_game_launches_successfully_after_failing_to_load_emulator_config() {
			_pathExistanceServiceMock.Setup(obj => obj.PathExists(It.IsAny<string?>()))
				.Returns(true);

			_settingsAndGamesManagerMock.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.LoadAsync())
				.Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(new Np21ntConfigLoadError("error")));

			_np21ntConfigDefaultsServiceMock.Setup(obj => obj.CreateNp21ntConfigDefaults())
				.Returns(testNp21ntConfig);

			_fileSystemNp21ntConfigRepository.Setup(obj => obj.SaveAsync(It.IsAny<Np21ntConfig?>()))
				.Returns(Task.FromResult<Np21ntConfigSaveError?>(null));

			_fileSystemExecutorServiceMock.Setup(obj => obj.StartExecutable(It.IsAny<string>()))
				.Returns(new Process());

			_settingsAndGamesManagerMock.SetupGet(obj => obj.GeneralSettings)
				.Returns(testGeneralSettings with { CloseOnGameLaunch = false });

			var error = await _launchGameService.LaunchGame(testOfficialGame2);

			Assert.Null(error);

			_np21ntConfigDefaultsServiceMock.Verify(obj => obj.CreateNp21ntConfigDefaults(), Times.Once);
			_fileSystemNp21ntConfigRepository.Verify(obj => obj.SaveAsync(It.IsAny<Np21ntConfig?>()), Times.Once);
			_fileSystemExecutorServiceMock.Verify(obj => obj.StartExecutable(It.IsAny<string>()), Times.Once);
		}
	}
}
