using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application.Settings {
	public class Settings {
		public OfficialGame[] OfficialGames { get; set; }
		public List<FanGame> FanGames { get; set; }
		public GeneralSettings GeneralSettings { get; set; }
	}
}
