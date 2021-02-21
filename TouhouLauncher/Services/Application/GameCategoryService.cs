using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Services.Application {
	public class GameCategoryService {
		private readonly SettingsManager _settingsManager;

		public GameCategoryService(SettingsManager settingsManager) {
			_settingsManager = settingsManager;
		}
		
		public List<GameCategories> CreateGameCategoryList() {
			var gameCategories = new List<GameCategories>();

			if (_settingsManager.GeneralSettings.CombineMainCategories) {
				gameCategories.Add(GameCategories.MainGame);
			}
			else {
				gameCategories.Add(GameCategories.MainPC98);
				gameCategories.Add(GameCategories.MainWindows);
			}
			gameCategories.Add(GameCategories.FightingGame);
			gameCategories.Add(GameCategories.SpinOff);
			gameCategories.Add(GameCategories.FanGame);

			return gameCategories;
		}

		public GameCategories GetDefaultGameCategory() {
			return _settingsManager.GeneralSettings.CombineMainCategories
				? GameCategories.MainGame : GameCategories.MainWindows;
		}
	}
}
