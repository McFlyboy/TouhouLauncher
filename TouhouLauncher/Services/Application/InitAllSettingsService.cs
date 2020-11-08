using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application.Serialization;

namespace TouhouLauncher.Services.Application {
	public class InitAllSettingsService {
		private readonly GameDB _gameDB;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;
		private readonly SettingsContainer _settingsContainer;
		private readonly ISettingsSerializerService _settingsSerializerService;

		public InitAllSettingsService(
			GameDB gameDB,
			OfficialGamesTemplateService officialGamesTemplateService,
			SettingsContainer settingsContainer,
			ISettingsSerializerService settingsSerializerService
		) {
			_gameDB = gameDB;
			_officialGamesTemplateService = officialGamesTemplateService;
			_settingsContainer = settingsContainer;
			_settingsSerializerService = settingsSerializerService;
		}

		public void InitAllSettings() {
			var settings = _settingsSerializerService.Deserialize()
				?? new Settings() {
					OfficialGames = _officialGamesTemplateService.CreateOfficialGamesFromTemplate(),
					FanGames = new List<FanGame>(),
					GeneralSettings = new GeneralSettings()
				};

			_gameDB.OfficialGames = settings.OfficialGames;
			_gameDB.FanGames = settings.FanGames;
			_settingsContainer.GeneralSettings = settings.GeneralSettings;
		}
	}
}
