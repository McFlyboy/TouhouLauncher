using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model {
	public class MainModel {
		public List<Game.CategoryFlag> Categories { get; }
		public int ActiveCategory { get; set; }
		public List<Game> GameList { get; }

		private readonly GameDB _gameDB;
		public MainModel() {
			_gameDB = GameDB.Instance;
			Categories = new List<Game.CategoryFlag>();
			bool combineMainCategories = false;
			if (combineMainCategories) {
				Categories.Add(Game.CategoryFlag.MainPC98 | Game.CategoryFlag.MainWindows);
				ActiveCategory = 0;
			}
			else {
				Categories.Add(Game.CategoryFlag.MainPC98);
				Categories.Add(Game.CategoryFlag.MainWindows);
				ActiveCategory = 1;
			}
			Categories.Add(Game.CategoryFlag.FightingGame);
			Categories.Add(Game.CategoryFlag.SpinOff);
			Categories.Add(Game.CategoryFlag.FanGame);
			GameList = new List<Game>();
		}
		public List<Game> FilterGames(Game.CategoryFlag category) {
			List<Game> games = new List<Game>();
			if (category != Game.CategoryFlag.FanGame) {
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
		public void UpdateGameList() {
			GameList.Clear();
			if (Categories[ActiveCategory] == Game.CategoryFlag.FanGame) {
				foreach (FanGame game in _gameDB.FanGames) {
					GameList.Add(game);
				}
				return;
			}
			foreach (OfficialGame game in _gameDB.OfficialGames) {
				if((game.Category & Categories[ActiveCategory]) != 0) {
					GameList.Add(game);
				}
			}
		}
	}
}
