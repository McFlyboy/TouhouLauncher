using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model {
	public class MainModel {
		public List<Game.CategoryFlag> Categories { get; }
		public int ActiveCategoryId { get; private set; }
		public List<Game> GameList { get; }

		private readonly GameDB _gameDB;
		public MainModel() {
			_gameDB = GameDB.Instance;
			Categories = new List<Game.CategoryFlag>();
			bool combineMainCategories = false;
			if (combineMainCategories) {
				Categories.Add(Game.CategoryFlag.MainPC98 | Game.CategoryFlag.MainWindows);
				ActiveCategoryId = 0;
			}
			else {
				Categories.Add(Game.CategoryFlag.MainPC98);
				Categories.Add(Game.CategoryFlag.MainWindows);
				ActiveCategoryId = 1;
			}
			Categories.Add(Game.CategoryFlag.FightingGame);
			Categories.Add(Game.CategoryFlag.SpinOff);
			Categories.Add(Game.CategoryFlag.FanGame);
			GameList = new List<Game>();
			UpdateGameList();
		}
		public void SetCurrentCategory(int id) {
			ActiveCategoryId = id;
			UpdateGameList();
		}
		public void LaunchRandom() {

		}
		private void UpdateGameList() {
			GameList.Clear();
			if (Categories[ActiveCategoryId] == Game.CategoryFlag.FanGame) {
				foreach (FanGame game in _gameDB.FanGames) {
					GameList.Add(game);
				}
				return;
			}
			foreach (OfficialGame game in _gameDB.OfficialGames) {
				if((game.Category & Categories[ActiveCategoryId]) != 0) {
					GameList.Add(game);
				}
			}
		}
	}
}
