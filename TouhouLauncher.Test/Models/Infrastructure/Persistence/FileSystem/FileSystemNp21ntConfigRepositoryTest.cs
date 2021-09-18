using Moq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure.Persistence.FileSystem {
	public class FileSystemNp21ntConfigRepositoryTest {
		private readonly Mock<FileAccessService> _fileAccessServiceMock = new();
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);
		private readonly Mock<Np21ntConfigDefaultsService> _np21ntConfigDefaultsService = new();

		private readonly FileSystemNp21ntConfigRepository _fileSystemNp21ntConfigRepository;

		public FileSystemNp21ntConfigRepositoryTest() {
			_fileSystemNp21ntConfigRepository = new(
				_fileAccessServiceMock.Object,
				_settingsAndGamesManagerMock.Object,
				_np21ntConfigDefaultsService.Object
			);
		}

		[Fact]
		public async void Saves_np21nt_config_to_file_system_async_and_returns_result() {
			_settingsAndGamesManagerMock
				.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileAccessServiceMock
				.Setup(obj => obj.WriteFileFromIniAsync(It.IsAny<string>(), It.IsAny<Np21ntConfigIni>()))
				.Returns(Task.FromResult<FileWriteError?>(null));

			var result = await _fileSystemNp21ntConfigRepository.SaveAsync(testNp21ntConfig);

			Assert.Null(result);
		}

		[Fact]
		public async void Loads_np21nt_config_from_file_system_async_and_returns_result() {
			_settingsAndGamesManagerMock
				.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileAccessServiceMock
				.Setup(obj => obj.ReadFileToIniAsync<Np21ntConfigIni>(It.IsAny<string>()))
				.Returns(Task.FromResult<Either<FileReadError, Np21ntConfigIni>>(testNp21ntConfigIni));

			_np21ntConfigDefaultsService
				.Setup(obj => obj.CreateNp21ntConfigDefaults())
				.Returns(testNp21ntConfig);

			var result = await _fileSystemNp21ntConfigRepository.LoadAsync();

			Assert.True(result.IsRight);
			Assert.Equal(5, result.GetRight().NekoProject21.WindPosX);
			Assert.True(result.GetRight().NekoProject21.WinSnap);
			Assert.Equal("some text...", result.GetRight().NekoProject21.FdFolder);
			Assert.Equal(
				new DipSwitch3(0xab, 0xcd, 0xef),
				result.GetRight().NekoProject21.DipSwtch
			);
			Assert.Equal(
				new DipSwitch8(0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef),
				result.GetRight().NekoProject21.MemSwtch
			);
			Assert.Equal(
				new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab },
				result.GetRight().NekoProject21.Snd14Vol
			);
		}
	}
}
