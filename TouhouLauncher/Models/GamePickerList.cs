using System.Collections.Generic;
using TouhouLauncher.Models.GameInfo;

namespace TouhouLauncher.Models {
	public class GamePickerList {
		private readonly GameDB _gameDB;

		public GamePickerList(GameDB gameDB) {
			_gameDB = gameDB;

			GameList = new List<Game>();
		}

		public List<Game> GameList { get; }

		public void PopulateGameList(OfficialGame.CategoryFlag categoryflags) {
			GameList.Clear();
			switch (categoryflags) {
				case OfficialGame.CategoryFlag.None:
					GameList.AddRange(_gameDB.FanGames);
					break;
				default:
					foreach (var game in _gameDB.OfficialGames) {
						if ((game.Category & categoryflags) != OfficialGame.CategoryFlag.None) {
							GameList.Add(game);
						}
					}
					break;
			}
		}
	}
}
