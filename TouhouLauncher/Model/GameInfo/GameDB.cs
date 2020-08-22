using System.Collections.Generic;

namespace TouhouLauncher.Model.GameInfo {
	public class GameDB {
		public static GameDB Instance { get; }
		static GameDB() {
			Instance = new GameDB();
		}

		public OfficialGame[] OfficialGames { get; set; }
		public List<FanGame> FanGames { get; set; }

		private GameDB() { }
	}
}
