using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Services.Application {
	public class GameCategoryService {
		private readonly SettingsContainer _settingsContainer;

		public GameCategoryService(SettingsContainer settingsContainer) {
			_settingsContainer = settingsContainer;
		}
		
		public List<OfficialGame.CategoryFlag> CreateGameCategoryList() {
			var gameCategories = new List<OfficialGame.CategoryFlag>();

			if (_settingsContainer.GeneralSettings.CombineMainCategories) {
				gameCategories.Add(OfficialGame.CategoryFlag.MainPC98 | OfficialGame.CategoryFlag.MainWindows);
			}
			else {
				gameCategories.Add(OfficialGame.CategoryFlag.MainPC98);
				gameCategories.Add(OfficialGame.CategoryFlag.MainWindows);
			}
			gameCategories.Add(OfficialGame.CategoryFlag.FightingGame);
			gameCategories.Add(OfficialGame.CategoryFlag.SpinOff);
			gameCategories.Add(OfficialGame.CategoryFlag.None);

			return gameCategories;
		}

		public OfficialGame.CategoryFlag GetDefaultGameCategory() {
			return _settingsContainer.GeneralSettings.CombineMainCategories
				? OfficialGame.CategoryFlag.MainPC98 | OfficialGame.CategoryFlag.MainWindows
				: OfficialGame.CategoryFlag.MainWindows;
		}
	}
}
