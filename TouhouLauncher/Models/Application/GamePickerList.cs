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

		public void PopulateGameList(OfficialGame.CategoryFlag categoryflags) {
			GameList.Clear();
			switch (categoryflags) {
				case OfficialGame.CategoryFlag.None:
					GameList.AddRange(_settingsManager.FanGames);
					break;
				default:
					foreach (var game in _settingsManager.OfficialGames) {
						if ((game.Category & categoryflags) != OfficialGame.CategoryFlag.None) {
							GameList.Add(game);
						}
					}
					break;
			}
		}
	}
}
