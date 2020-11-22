using Moq;
using System;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Infrastructure.Serialization;
using TouhouLauncher.Services.Application;
using TouhouLauncher.Services.Infrastructure;
using TouhouLauncher.Services.Infrastructure.Serialization;
using Xunit;

namespace TouhouLauncher.Test.Services.Infrastructure {
	public class FileSettingsServiceTest {
		private readonly FileSettingsService _fileSettingsService;

		private readonly Mock<YamlFileSerializerService> _fileSerializerServiceMock;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		public FileSettingsServiceTest() {
			_fileSerializerServiceMock = new Mock<YamlFileSerializerService>();
			_officialGamesTemplateService = new OfficialGamesTemplateService();

			_fileSettingsService = new FileSettingsService(
				_fileSerializerServiceMock.Object,
				_officialGamesTemplateService
			);
		}

		[Fact]
		public void Returns_null_when_unable_to_load() {
			Assert.Null(_fileSettingsService.Load());
		}

		[Fact]
		public void Returns_settings_when_successful_loading() {
			_fileSerializerServiceMock
				.Setup(obj => obj.DeserializeFromFile<SerializableSettings>(It.IsAny<string>()))
				.Returns(new SerializableSettings() {
					OfficialGames = new SerializableOfficialGame[] {
						new() { FileLocation = "some location" },
						new() { FileLocation = "some other location" },
						new() { FileLocation = "a third location" }
					},
					FanGames = new() {
						new() { Title = "Fan Game" },
						new() { Title = "Fan Game 2", Subtitle = "Return of the Fan" }
					},
					GeneralSettings = new() {
						CloseOnGameLaunch = true
					}
				});

			var result = _fileSettingsService.Load();

			Assert.NotNull(result);

			var (officialGames, fanGames, generalSettings) = result;

			Assert.Equal("some other location", officialGames[1].FileLocation);
			Assert.Equal(1996, officialGames[0].ReleaseYear);
			Assert.Equal("Fan Game", fanGames[0].Title);
			Assert.Equal("Return of the Fan", fanGames[1].Subtitle);
			Assert.True(generalSettings.CloseOnGameLaunch);
		}

		[Fact]
		public void Returns_true_when_successful_saving() {
			_fileSerializerServiceMock
				.Setup(obj => obj.SerializeToFile(It.IsAny<SerializableSettings>(), It.IsAny<string>()))
				.Returns(true);

			Assert.True(_fileSettingsService.Save(new OfficialGame[] { }, new(), new()));
		}
	}
}
