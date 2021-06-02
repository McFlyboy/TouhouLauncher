using System;
using System.Diagnostics;
using System.IO;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Views;

namespace TouhouLauncher.Models.Application {
	public class ActivateGameService {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;
		private readonly GameConfig _gameConfig;

		public ActivateGameService(
			SettingsAndGamesManager settingsAndGamesManager,
			GameConfig gameConfig
		) {
			_settingsAndGamesManager = settingsAndGamesManager;
			_gameConfig = gameConfig;
		}

		public void ActivateGame(Game game) {
			if (!game.FileLocation.Equals(string.Empty)) {
				LaunchGame(game);
			}
			else {
				ConfigureGame(game);
			}
		}

		public virtual bool LaunchGame(Game game) {
			if (!File.Exists(game.FileLocation)) {
				return false;
			}

			var startInfo = new ProcessStartInfo(game.FileLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);

			try {
				Process.Start(startInfo);
			}
			catch(Exception) {
				return false;
			}

			if (_settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch) {
				System.Windows.Application.Current.Shutdown();
			}

			return true;
		}

		private void ConfigureGame(Game game) {
			_gameConfig.SetGameToConfigure(game);
			new GameConfigWindow().ShowDialog();
		}
	}
}
