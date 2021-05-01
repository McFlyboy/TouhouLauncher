using System.Diagnostics;
using System.IO;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Views;

namespace TouhouLauncher.Services.Application {
	public class ActivateGameService {
		private readonly SettingsManager _settingsManager;
		private readonly GameConfig _gameConfig;

		public ActivateGameService(
			SettingsManager settingsManager,
			GameConfig gameConfig
		) {
			_settingsManager = settingsManager;
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

		public virtual void LaunchGame(Game game) {
			if (!File.Exists(game.FileLocation)) {
				return;
            }

			var startInfo = new ProcessStartInfo(game.FileLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);

			Process.Start(startInfo);

			if (_settingsManager.GeneralSettings.CloseOnGameLaunch) {
				System.Windows.Application.Current.Shutdown();
			}
		}

		private void ConfigureGame(Game game) {
			_gameConfig.SetGameToConfigure(game);
			new GameConfigWindow().ShowDialog();
		}
	}
}
