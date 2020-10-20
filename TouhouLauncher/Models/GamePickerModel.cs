using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Models.Settings;
using TouhouLauncher.Views;

namespace TouhouLauncher.Models {
	public class GamePickerModel {
		private readonly GameDB _gameDB;
		private readonly SettingsContainer _settingsContainer;

		public GamePickerModel(
			GameDB gameDB,
			SettingsContainer settingsContainer
		) {
			_gameDB = gameDB;
			_settingsContainer = settingsContainer;

			GameList = new List<Game>();
		}

		public List<Game> GameList { get; }

		private void LaunchGame(Game game) {
			var startInfo = new ProcessStartInfo(game.FileLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);

			Process.Start(startInfo);

			if (_settingsContainer.GeneralSettings.CloseOnGameLaunch) {
				Application.Current.Shutdown();
			}
		}

		private void ConfigureGame(Game game) {
			new GameConfigWindow(game).ShowDialog();
		}

		private void PopulateGameList(OfficialGame.CategoryFlag categoryflags) {
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
