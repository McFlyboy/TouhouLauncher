using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Models.Settings;
using TouhouLauncher.Views;

namespace TouhouLauncher.Models {
	public class HomeModel {
		private readonly GameDB _gameDB;
		private readonly SettingsContainer _settingsContainer;

		public HomeModel(
			GameDB gameDB,
			SettingsContainer settingsContainer
		) {
			_gameDB = gameDB;
			_settingsContainer = settingsContainer;

			OfficialGameCategories = new List<OfficialGame.CategoryFlag>();
			if (_settingsContainer.GeneralSettings.CombineMainCategories) {
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

		public List<OfficialGame.CategoryFlag> OfficialGameCategories { get; }
		public int ActiveCategoryId { get; private set; }
		public List<Game> GameList { get; }

		public void SetCurrentCategory(int id) {
			ActiveCategoryId = id;
			UpdateGameList();
		}

		public void LaunchGame(int id) {
			if (GameList[id].FileLocation.Length != 0) {
				LaunchExistingGame(GameList[id].FileLocation, _settingsContainer.GeneralSettings.CloseOnGameLaunch);
			}
			else {
				new GameConfigWindow(GameList[id]).ShowDialog();
			}
		}

		public void LaunchRandom() {
			// TODO
		}

		private void LaunchExistingGame(string gameLocation, bool exitOnLaunch = false) {
			var startInfo = new ProcessStartInfo(gameLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);

			Process.Start(startInfo);

			if (exitOnLaunch) {
				Application.Current.Shutdown();
			}
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
