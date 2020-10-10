using System.Collections.Generic;
using TouhouLauncher.Models.GameInfo;

namespace TouhouLauncher.Models.Settings {
	public class Settings {
		public OfficialGame[] OfficialGames { get; set; }
		public List<FanGame> FanGames { get; set; }
		public GeneralSettings GeneralSettings { get; set; }
	}
}
