namespace TouhouLauncher.Model.GameInfo {
	public class OfficialGame : Game {
		public string DownloadableFileLocation { get; set; }
		public GameCategory Category { get; set; }
		public enum GameCategory {
			MainPC98,
			MainWindows,
			FightingGame,
			SpinOff,
		}
	}
}
