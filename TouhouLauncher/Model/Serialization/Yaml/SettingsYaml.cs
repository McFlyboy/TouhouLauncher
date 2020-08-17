using System;
using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;
using TouhouLauncher.Model.Settings;

namespace TouhouLauncher.Model.Serialization.Yaml {
	class SettingsYaml {
		public OfficialGameYaml[] OfficialGames { get; set; }
		public List<FanGameYaml> FanGames { get; set; }
		public GeneralSettingsYaml GeneralSettings { get; set; }

		public Tuple<OfficialGame[], List<FanGame>, GeneralSettings> ToDomain() {
			var officialGames = GameDBTemplate.CreateOfficialGamesFromTemplate();
			int safeLength = Math.Min(officialGames.Length, OfficialGames.Length);
			for (int i = 0; i < safeLength; i++) {
				officialGames[i].LocalFileLocation = OfficialGames[i].LocalFileLocation;
			}

			var fangames = new List<FanGame>();
			foreach (var fanGame in FanGames) {
				fangames.Add(fanGame.ToDomain());
			}

			var generalSettings = GeneralSettings.ToDomain();

			return Tuple.Create(officialGames, fangames, generalSettings);
		}

		public static SettingsYaml FromDomain(Tuple<OfficialGame[], List<FanGame>, GeneralSettings> domain) {
			var yaml = new SettingsYaml();

			yaml.OfficialGames = new OfficialGameYaml[domain.Item1.Length];
			for(int i = 0; i < yaml.OfficialGames.Length; i++) {
				yaml.OfficialGames[i] = OfficialGameYaml.FromDomain(domain.Item1[i]);
			}

			yaml.FanGames = new List<FanGameYaml>();
			foreach (var fanGame in domain.Item2) {
				yaml.FanGames.Add(FanGameYaml.FromDomain(fanGame));
			}

			yaml.GeneralSettings = GeneralSettingsYaml.FromDomain(domain.Item3);

			return yaml;
		}
	}
}
