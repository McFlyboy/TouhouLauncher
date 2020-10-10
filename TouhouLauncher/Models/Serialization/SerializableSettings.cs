using System;
using System.Collections.Generic;
using TouhouLauncher.Models.GameInfo;

namespace TouhouLauncher.Models.Serialization {
	class SerializableSettings {
		public SerializableOfficialGame[] OfficialGames { get; set; }
		public List<SerializableFanGame> FanGames { get; set; }
		public SerializableGeneralSettings GeneralSettings { get; set; }

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

		public static SerializableSettings FromDomain(Settings.Settings domain) {
			var serializable = new SerializableSettings();

			serializable.OfficialGames = new SerializableOfficialGame[domain.OfficialGames.Length];
			for(int i = 0; i < serializable.OfficialGames.Length; i++) {
				serializable.OfficialGames[i] = SerializableOfficialGame.FromDomain(domain.OfficialGames[i]);
			}

			serializable.FanGames = new List<SerializableFanGame>();
			foreach (var fanGame in domain.FanGames) {
				serializable.FanGames.Add(SerializableFanGame.FromDomain(fanGame));
			}

			serializable.GeneralSettings = SerializableGeneralSettings.FromDomain(domain.GeneralSettings);

			return serializable;
		}
	}
}
