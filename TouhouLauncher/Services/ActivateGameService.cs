using System.Diagnostics;
using System.IO;
using System.Windows;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Models.Settings;
using TouhouLauncher.Views;

namespace TouhouLauncher.Services {
	public class ActivateGameService {
		private readonly SettingsContainer _settingsContainer;

		public ActivateGameService(SettingsContainer settingsContainer) {
			_settingsContainer = settingsContainer;
		}

		public void ActivateGame(Game game) {
			if (!game.FileLocation.Equals(string.Empty)) {
				LaunchGame(game);
			}
			else {
				ConfigureGame(game);
			}
		}

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
	}
}
