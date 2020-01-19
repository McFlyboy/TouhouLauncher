using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;
using TouhouLauncher.Model.Serialization;
using TouhouLauncher.View;

namespace TouhouLauncher.Model {
	public class MainModel {
		public List<OfficialGame.CategoryFlag> OfficialGameCategories { get; }
		public int ActiveCategoryId { get; private set; }
		public List<Game> GameList { get; }

		private readonly GameDB _gameDB;
		public MainModel() {
			_gameDB = GameDB.Instance;
			Settings.LoadInstance();
			OfficialGameCategories = new List<OfficialGame.CategoryFlag>();
			bool combineMainCategories = false;
			if (combineMainCategories) {
				OfficialGameCategories.Add(OfficialGame.CategoryFlag.MainPC98 | OfficialGame.CategoryFlag.MainWindows);
				ActiveCategoryId = 0;
			}
			else {
				OfficialGameCategories.Add(OfficialGame.CategoryFlag.MainPC98);
				OfficialGameCategories.Add(OfficialGame.CategoryFlag.MainWindows);
				ActiveCategoryId = 1;
			}
			OfficialGameCategories.Add(OfficialGame.CategoryFlag.FightingGame);
			OfficialGameCategories.Add(OfficialGame.CategoryFlag.SpinOff);
			OfficialGameCategories.Add(OfficialGame.CategoryFlag.None);
			GameList = new List<Game>();
			UpdateGameList();
		}
		public void SetCurrentCategory(int id) {
			ActiveCategoryId = id;
			UpdateGameList();
		}
		public void LaunchGame(int id) {
			if (GameList[id].LocalFileLocation.Length != 0) {
				GameList[id].Launch(Settings.Instance.CloseOnGameLaunch);
			}
			else {
				new GameConfigWindow(GameList[id]).ShowDialog();
			}
		}
		public void LaunchRandom() {

		}
		private void UpdateGameList() {
			GameList.Clear();
			if (OfficialGameCategories[ActiveCategoryId] == OfficialGame.CategoryFlag.None) {
				foreach (FanGame game in _gameDB.FanGames) {
					GameList.Add(game);
				}
				return;
			}
			foreach (OfficialGame game in _gameDB.OfficialGames) {
				if((game.Category & OfficialGameCategories[ActiveCategoryId]) != 0) {
					GameList.Add(game);
				}
			}
		}
	}
}
