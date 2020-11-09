namespace TouhouLauncher.Models.Application.GameInfo {
	public class OfficialGame : Game {
		public string DownloadableFileLocation { get; set; }

		public CategoryFlag Category { get; set; }

		public enum CategoryFlag {
			None         = 0x0,
			MainPC98     = 0x1,
			MainWindows  = 0x2,
			FightingGame = 0x4,
			SpinOff      = 0x8
		}
	}
}
