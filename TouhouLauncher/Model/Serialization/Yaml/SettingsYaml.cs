using System;
using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model.Serialization.Yaml {
	class SettingsYaml {
		public OfficialGameYaml[] OfficialGames { get; set; }
		public List<FanGameYaml> FanGames { get; set; }
		public GeneralSettingsYaml GeneralSettings { get; set; }

		public Settings.Settings ToDomain() {
			var domain = new Settings.Settings();

			domain.OfficialGames = GameDBTemplate.CreateOfficialGamesFromTemplate();
			int safeLength = Math.Min(domain.OfficialGames.Length, OfficialGames.Length);
			for (int i = 0; i < safeLength; i++) {
				domain.OfficialGames[i].FileLocation = OfficialGames[i].FileLocation;
			}

			domain.FanGames = new List<FanGame>();
			foreach (var fanGame in FanGames) {
				domain.FanGames.Add(fanGame.ToDomain());
			}

			domain.GeneralSettings = GeneralSettings.ToDomain();

			return domain;
		}

		public static SettingsYaml FromDomain(Settings.Settings domain) {
			var yaml = new SettingsYaml();

			yaml.OfficialGames = new OfficialGameYaml[domain.OfficialGames.Length];
			for(int i = 0; i < yaml.OfficialGames.Length; i++) {
				yaml.OfficialGames[i] = OfficialGameYaml.FromDomain(domain.OfficialGames[i]);
			}

			yaml.FanGames = new List<FanGameYaml>();
			foreach (var fanGame in domain.FanGames) {
				yaml.FanGames.Add(FanGameYaml.FromDomain(fanGame));
			}

			yaml.GeneralSettings = GeneralSettingsYaml.FromDomain(domain.GeneralSettings);

			return yaml;
		}
	}
}
