using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace TouhouLauncher.Model.GameInfo {
	public class GameDB {
		public static GameDB Instance { get; }
		static GameDB() {
			Instance = new GameDB();
		}

		public OfficialGame[] OfficialGames { get; set; }
		public List<FanGame> FanGames { get; set; }

		private GameDB() { }

		public void LaunchGame(string gameLocation, bool exitOnLaunch = false) {
			var startInfo = new ProcessStartInfo(gameLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);
			Process.Start(startInfo);
			if (exitOnLaunch) {
				Application.Current.Shutdown();
			}
		}
	}
}
