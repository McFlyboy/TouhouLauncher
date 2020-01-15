using System.Diagnostics;
using System.IO;
using System.Windows;

namespace TouhouLauncher.Model.GameInfo {
	public abstract class Game {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string ImageLocation { get; set; }
		public string AudioLocation { get; set; }
		public int ReleaseYear { get; set; }
		public string LocalFileLocation { get; set; }
		public CategoryFlag Category { get; protected set; }
		public void Launch(bool exitOnLaunch = false) {
			if (LocalFileLocation.Length == 0) {
				return;
			}
			ProcessStartInfo startInfo = new ProcessStartInfo(LocalFileLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);
			Process.Start(startInfo);
			if (exitOnLaunch) {
				Application.Current.Shutdown();
			}
		}
		public enum CategoryFlag {
			MainPC98     = 0x01,
			MainWindows  = 0x02,
			FightingGame = 0x04,
			SpinOff      = 0x08,
			FanGame      = 0x10,

			First = MainPC98,
			Last = FanGame
		}
	}
}
