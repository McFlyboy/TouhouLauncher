using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model {
	public class GameModel {
		private readonly GameDB _gameDB;
		public GameModel() {
			_gameDB = GameDB.Instance;
		}
		public List<Game> FilterGames(Game.GameCategory category) {
			List<Game> games = new List<Game>();
			if (category != Game.GameCategory.FanGame) {
				foreach (var game in _gameDB.OfficialGames) {
					if (game.Category == category) {
						games.Add(game);
					}
				}
			}
			else {
				foreach (var game in _gameDB.FanGames) {
					games.Add(game);
				}
			}
			return games;
		}
	}
}
