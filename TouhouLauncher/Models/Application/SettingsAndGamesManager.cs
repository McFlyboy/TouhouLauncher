using System.Collections.Generic;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Application {
	public class SettingsAndGamesManager {
		private readonly ISettingsAndGamesService _settingsAndGamesService;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		private SettingsAndGames _settingsAndGames;

		public SettingsAndGamesManager(
			ISettingsAndGamesService settingsAndGamesService,
			OfficialGamesTemplateService officialGamesTemplateService
		) {
			_settingsAndGamesService = settingsAndGamesService;
			_officialGamesTemplateService = officialGamesTemplateService;

			_settingsAndGames = null;
		}

		public virtual GeneralSettings GeneralSettings => _settingsAndGames?.GeneralSettings;

		public virtual EmulatorSettings EmulatorSettings => _settingsAndGames?.EmulatorSettings;

		public virtual OfficialGame[] OfficialGames => _settingsAndGames?.OfficialGames;

		public virtual List<FanGame> FanGames => _settingsAndGames?.FanGames;

		public async virtual Task<bool> SaveAsync() {
			return await _settingsAndGamesService.SaveAsync(_settingsAndGames);
		}

		public async Task<bool> LoadAsync() {
			var result = await _settingsAndGamesService.LoadAsync();

			_settingsAndGames = result ?? new SettingsAndGames(
				GeneralSettings: new GeneralSettings(),
				EmulatorSettings: new EmulatorSettings() {
					FolderLocation = string.Empty
				},
				OfficialGames: _officialGamesTemplateService.CreateOfficialGamesFromTemplate(),
				FanGames: new List<FanGame>()
			);

			return result != null;
		}
	}
}
