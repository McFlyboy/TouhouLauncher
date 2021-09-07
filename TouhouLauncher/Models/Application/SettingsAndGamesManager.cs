using System.Collections.Generic;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Application {
	public class SettingsAndGamesManager {
		private readonly ISettingsAndGamesRepository _settingsAndGamesRepository;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		private SettingsAndGames _settingsAndGames;

		public SettingsAndGamesManager(
			ISettingsAndGamesRepository settingsAndGamesRepository,
			OfficialGamesTemplateService officialGamesTemplateService
		) {
			_settingsAndGamesRepository = settingsAndGamesRepository;
			_officialGamesTemplateService = officialGamesTemplateService;

			_settingsAndGames = new(
					GeneralSettings: new(
						closeOnGameLaunch: false,
						combineMainCategories: false
					),
					EmulatorSettings: new(
						folderLocation: null
					),
					OfficialGames: System.Array.Empty<OfficialGame>(),
					FanGames: new()
				);
		}

		public virtual GeneralSettings GeneralSettings => _settingsAndGames.GeneralSettings;

		public virtual EmulatorSettings EmulatorSettings => _settingsAndGames.EmulatorSettings;

		public virtual OfficialGame[] OfficialGames => _settingsAndGames.OfficialGames;

		public virtual List<FanGame> FanGames => _settingsAndGames.FanGames;

		public async virtual Task<SettingsAndGamesSaveError?> SaveAsync() {
			return await _settingsAndGamesRepository.SaveAsync(_settingsAndGames);
		}

		public async Task<bool> LoadAsync() {
			var result = await _settingsAndGamesRepository.LoadAsync();

			_settingsAndGames = result.Resolve(
				error => new(
					GeneralSettings: new(
						closeOnGameLaunch: false,
						combineMainCategories: false
					),
					EmulatorSettings: new(
						folderLocation: null
					),
					OfficialGames: _officialGamesTemplateService.CreateOfficialGamesFromTemplate(),
					FanGames: new()
				),
				settingsAndGames => settingsAndGames
			);

			return result.IsRight;
		}
	}
}
