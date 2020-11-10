using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Services.Application;

namespace TouhouLauncher.Models.Application.Settings {
	public class SettingsManager {
		private readonly ISettingsService _settingsService;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		public SettingsManager(
			ISettingsService settingsService,
			OfficialGamesTemplateService officialGamesTemplateService
		) {
			_settingsService = settingsService;
			_officialGamesTemplateService = officialGamesTemplateService;
		}

		public OfficialGame[] OfficialGames { get; set; }

		public List<FanGame> FanGames { get; set; }

		public GeneralSettings GeneralSettings { get; set; }

		public bool Save() {
			return _settingsService.Save(OfficialGames, FanGames, GeneralSettings);
		}

		public bool Load() {
			var result = _settingsService.Load();
			var (officialGames, fanGames, generalSettings) = result
				?? new Tuple<OfficialGame[], List<FanGame>, GeneralSettings>(
					_officialGamesTemplateService.CreateOfficialGamesFromTemplate(),
					new List<FanGame>(),
					new GeneralSettings()
				);

			OfficialGames = officialGames;
			FanGames = fanGames;
			GeneralSettings = generalSettings;

			return result != null;
		}
	}
}
