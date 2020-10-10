using System.Collections.Generic;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Models.Settings;
using TouhouLauncher.Services.Serialization;

namespace TouhouLauncher.Models {
	public class MainModel {
		public MainModel(
			GameDB gameDB,
			SettingsContainer settingsContainer,
			SettingsSerializerService settingsSerializerService
		) {
			var settings = settingsSerializerService.DeserializeFromFile()
				?? new Settings.Settings() {
					OfficialGames = GameDBTemplate.CreateOfficialGamesFromTemplate(),
					FanGames = new List<FanGame>(),
					GeneralSettings = new GeneralSettings()
				};

			gameDB.OfficialGames = settings.OfficialGames;
			gameDB.FanGames = settings.FanGames;
			settingsContainer.GeneralSettings = settings.GeneralSettings;
		}
	}
}
