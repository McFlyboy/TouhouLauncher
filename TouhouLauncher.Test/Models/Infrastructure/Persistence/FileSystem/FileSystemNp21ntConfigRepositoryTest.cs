using Moq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;

namespace TouhouLauncher.Test.Models.Infrastructure.Persistence.FileSystem {
	public class FileSystemNp21ntConfigRepositoryTest {
		private readonly Mock<FileAccessService> _fileAccessServiceMock = new();
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);

		private readonly FileSystemNp21ntConfigRepository _fileSystemNp21ntConfigRepository;

		public FileSystemNp21ntConfigRepositoryTest() {
			_fileSystemNp21ntConfigRepository = new(
				_fileAccessServiceMock.Object,
				_settingsAndGamesManagerMock.Object
			);
		}

		[Fact]
		public async void Saves_np21nt_config_to_file_system_async_and_returns_result() {
			_settingsAndGamesManagerMock
				.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileAccessServiceMock
				.Setup(obj => obj.WriteFileFromIniAsync(It.IsAny<string>(), It.IsAny<Np21ntConfigIni>()))
				.Returns(Task.FromResult(true));

			var result = await _fileSystemNp21ntConfigRepository.SaveAsync(testNp21ntConfig);

			Assert.True(result);
		}

		[Fact]
		public async void Loads_np21nt_config_from_file_system_async_and_returns_result() {
			_settingsAndGamesManagerMock
				.SetupGet(obj => obj.EmulatorSettings)
				.Returns(testEmulatorSettings);

			_fileAccessServiceMock
				.Setup(obj => obj.ReadFileToIniAsync<Np21ntConfigIni>(It.IsAny<string>()))
				.Returns(Task.FromResult(testNp21ntConfigIni));

			var result = await _fileSystemNp21ntConfigRepository.LoadAsync();

			Assert.Equal(5, result.NekoProject21.WindPosX);
			Assert.True(result.NekoProject21.WinSnap);
			Assert.Equal("some text...", result.NekoProject21.FdFolder);
			Assert.Equal(
				new DipSwitch3 {
					Segment1 = new DipSwitch() {
						Switch1 = true,
						Switch2 = false,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = false,
						Switch7 = true,
						Switch8 = true
					},
					Segment2 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = false,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = false,
						Switch8 = true
					},
					Segment3 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = true,
						Switch8 = true
					}
				},
				result.NekoProject21.DipSwtch
			);
			Assert.Equal(
				new DipSwitch8 {
					Segment1 = new DipSwitch() {
						Switch1 = false,
						Switch2 = false,
						Switch3 = false,
						Switch4 = false,
						Switch5 = false,
						Switch6 = false,
						Switch7 = false,
						Switch8 = true
					},
					Segment2 = new DipSwitch() {
						Switch1 = false,
						Switch2 = false,
						Switch3 = true,
						Switch4 = false,
						Switch5 = false,
						Switch6 = false,
						Switch7 = true,
						Switch8 = true
					},
					Segment3 = new DipSwitch() {
						Switch1 = false,
						Switch2 = true,
						Switch3 = false,
						Switch4 = false,
						Switch5 = false,
						Switch6 = true,
						Switch7 = false,
						Switch8 = true
					},
					Segment4 = new DipSwitch() {
						Switch1 = false,
						Switch2 = true,
						Switch3 = true,
						Switch4 = false,
						Switch5 = false,
						Switch6 = true,
						Switch7 = true,
						Switch8 = true
					},
					Segment5 = new DipSwitch() {
						Switch1 = true,
						Switch2 = false,
						Switch3 = false,
						Switch4 = false,
						Switch5 = true,
						Switch6 = false,
						Switch7 = false,
						Switch8 = true
					},
					Segment6 = new DipSwitch() {
						Switch1 = true,
						Switch2 = false,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = false,
						Switch7 = true,
						Switch8 = true
					},
					Segment7 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = false,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = false,
						Switch8 = true
					},
					Segment8 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = true,
						Switch8 = true
					}
				},
				result.NekoProject21.MemSwtch
			);
			Assert.Equal(
				new byte[] {
					0x01,
					0x23,
					0x45,
					0x67,
					0x89,
					0xab
				},
				result.NekoProject21.Snd14Vol
			);
		}
	}
}
