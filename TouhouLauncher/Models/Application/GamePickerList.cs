using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Models.Application {
	public class GamePickerList {
		private readonly SettingsManager _settingsManager;

		public GamePickerList(SettingsManager settingsManager) {
			_settingsManager = settingsManager;

			GameList = new List<Game>();
		}

		public List<Game> GameList { get; }

		public void PopulateGameList(GameCategories categories) {
			GameList.Clear();
			switch (categories) {
				case GameCategories.FanGame:
					GameList.AddRange(_settingsManager.FanGames);
					break;
				default:
					foreach (var game in _settingsManager.OfficialGames) {
						if ((game.Categories & categories) != GameCategories.None) {
							GameList.Add(game);
						}
					}
					break;
			}
		}
	}
}
