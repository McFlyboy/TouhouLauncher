using System.Collections.Generic;

namespace TouhouLauncher.Model.Serialization.Yaml {
	class SettingsYaml {
		public OfficialGameYaml[] OfficialGames { get; set; }
		public List<FanGameYaml> FanGames { get; set; }
		public GeneralSettingsYaml GeneralSettings { get; set; }
	}
}
