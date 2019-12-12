using System.Diagnostics;

namespace TouhouLauncher.Model {
	class GameModel {
		public void StartGame(string gameName) {
			Process test = new Process();
			test.StartInfo.FileName = gameName;
			test.Start();
		}
	}
}
