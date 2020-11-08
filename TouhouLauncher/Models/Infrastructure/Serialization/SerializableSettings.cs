using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services;

namespace TouhouLauncher.Models.Infrastructure.Serialization {
	class SerializableSettings {
		public SerializableOfficialGame[] OfficialGames { get; set; }
		public List<SerializableFanGame> FanGames { get; set; }
		public SerializableGeneralSettings GeneralSettings { get; set; }

		public Settings ToDomain(OfficialGame[] officialGamesTemplate) {
			var domain = new Settings();

			domain.OfficialGames = officialGamesTemplate;
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

		public static SerializableSettings FromDomain(Settings domain) {
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
