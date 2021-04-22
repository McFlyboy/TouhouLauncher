using Moq;
using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using TouhouLauncher.Services.Infrastructure;
using TouhouLauncher.Services.Infrastructure.Serialization;
using Xunit;

namespace TouhouLauncher.Test.Models.Application.Settings {
	public class SettingsManagerTest {
		private readonly SettingsManager _settingsManager;

		private readonly Mock<FileSettingsService> _fileSettingsServiceMock;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		public SettingsManagerTest() {
			_fileSettingsServiceMock = new Mock<FileSettingsService>(
				new Mock<YamlFileSerializerService>().Object,
				null
			);
			_officialGamesTemplateService = new OfficialGamesTemplateService();

			_settingsManager = new SettingsManager(
				_fileSettingsServiceMock.Object,
				_officialGamesTemplateService
			);
		}

		[Fact]
		public void Returns_True_when_successful_saving() {
			_fileSettingsServiceMock
				.Setup(obj => obj.Save(
					It.IsAny<OfficialGame[]>(),
					It.IsAny<List<FanGame>>(),
					It.IsAny<GeneralSettings>()
				))
				.Returns(true);

			bool result = _settingsManager.Save();

			Assert.True(result);
		}

		[Fact]
		public void Creates_and_stores_default_settings_when_failed_loading() {
			_fileSettingsServiceMock
				.Setup(obj => obj.Load())
				.Returns<Tuple<OfficialGame[], List<FanGame>, GeneralSettings>>(null);

			bool result = _settingsManager.Load();

			Assert.False(result);

			Assert.NotNull(_settingsManager.OfficialGames);
			Assert.Equal(29, _settingsManager.OfficialGames.Length);
			Assert.Equal(1996, _settingsManager.OfficialGames[0].ReleaseYear);
			Assert.NotNull(_settingsManager.FanGames);
			Assert.Empty(_settingsManager.FanGames);
			Assert.NotNull(_settingsManager.GeneralSettings);
			Assert.False(_settingsManager.GeneralSettings.CloseOnGameLaunch);
			Assert.False(_settingsManager.GeneralSettings.CombineMainCategories);
		}

		[Fact]
		public void Stores_games_and_settings_on_successful_loading() {
			_fileSettingsServiceMock
				.Setup(obj => obj.Load())
				.Returns(new Tuple<OfficialGame[], List<FanGame>, GeneralSettings>(
					new OfficialGame[] {
						new OfficialGame() { Title = "An official game" },
						new OfficialGame() { Title = "Another official game" },
						new OfficialGame() { Title = "Extra official game" }
					},
					new List<FanGame>() {
						new FanGame() { Title = "A fan game" },
						new FanGame() { Title = "Another fan game" }
					},
					new GeneralSettings() { CloseOnGameLaunch = true }
				));

			bool result = _settingsManager.Load();

			Assert.True(result);

			Assert.Equal("An official game", _settingsManager.OfficialGames[0].Title);
			Assert.Equal("Another official game", _settingsManager.OfficialGames[1].Title);
			Assert.Equal("Another fan game", _settingsManager.FanGames[1].Title);
		}
	}
}
