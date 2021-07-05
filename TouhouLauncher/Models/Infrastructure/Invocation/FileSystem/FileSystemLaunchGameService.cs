using System;
using System.Diagnostics;
using System.IO;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Invocation.FileSystem {
	public class FileSystemLaunchGameService : ILaunchGameService {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public FileSystemLaunchGameService(SettingsAndGamesManager settingsAndGamesManager) {
			_settingsAndGamesManager = settingsAndGamesManager;
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
	}
}
