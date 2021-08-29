#nullable disable

using System.Collections.Generic;
using System.Linq;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class GamePickerList {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public GamePickerList(SettingsAndGamesManager settingsAndGamesManager) {
			_settingsAndGamesManager = settingsAndGamesManager;

			GameList = new List<Game>();
		}

		public List<Game> GameList { get; }

		public void PopulateGameList(GameCategories categories) {
			GameList.Clear();
			GameList.AddRange(
				categories switch {
					GameCategories.FanGame => _settingsAndGamesManager.FanGames,
					_ => _settingsAndGamesManager.OfficialGames
						.Where(game => categories.HasFlag(game.Categories))
				}
			);
		}
	}
}
