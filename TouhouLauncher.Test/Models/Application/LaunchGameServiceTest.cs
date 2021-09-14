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
	}
}
