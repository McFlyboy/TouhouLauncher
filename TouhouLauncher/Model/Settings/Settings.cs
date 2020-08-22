using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model.Settings {
	public class Settings {
		public OfficialGame[] OfficialGames { get; set; }
		public List<FanGame> FanGames { get; set; }
		public GeneralSettings GeneralSettings { get; set; }
	}
}
