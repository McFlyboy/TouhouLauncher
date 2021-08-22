using Moq;
using System.Diagnostics;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.SettingsInfo;
using TouhouLauncher.Models.Infrastructure.Execution.FileSystem;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;

namespace TouhouLauncher.Test.Models.Application {
	public class LaunchGameServiceTest {
		private readonly Mock<FileSystemExecutorService> _fileSystemExecutorServiceMock = new();
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);
		private readonly Mock<FileSystemNp21ntConfigRepository> _fileSystemNp21ntConfigRepository = new(null, null);

		private readonly LaunchGameService _launchGameService;

		public LaunchGameServiceTest() {
			_launchGameService = new(
				_fileSystemExecutorServiceMock.Object,
				_settingsAndGamesManagerMock.Object,
				_fileSystemNp21ntConfigRepository.Object
			);
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
	}
}
