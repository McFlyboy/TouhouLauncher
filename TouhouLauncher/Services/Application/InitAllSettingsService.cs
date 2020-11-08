using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Services.Application {
	public class InitAllSettingsService {
		private readonly GameDB _gameDB;
		private readonly SettingsContainer _settingsContainer;
		private readonly ISettingsService _settingsService;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		public InitAllSettingsService(
			GameDB gameDB,
			SettingsContainer settingsContainer,
			ISettingsService settingsService,
			OfficialGamesTemplateService officialGamesTemplateService
		) {
			_gameDB = gameDB;
			_settingsContainer = settingsContainer;
			_settingsService = settingsService;
			_officialGamesTemplateService = officialGamesTemplateService;
		}

		public void InitAllSettings() {
			var (officialGames, fanGames, generalSettings) = _settingsService.Load();

			_gameDB.OfficialGames = officialGames ?? _officialGamesTemplateService.CreateOfficialGamesFromTemplate();
			_gameDB.FanGames = fanGames ?? new List<FanGame>();
			_settingsContainer.GeneralSettings = generalSettings ?? new GeneralSettings();
		}
	}
}
