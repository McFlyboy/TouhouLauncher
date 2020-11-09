using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Models.Infrastructure.Serialization {
	class SerializableSettings {
		public SerializableOfficialGame[] OfficialGames { get; set; }
		public List<SerializableFanGame> FanGames { get; set; }
		public SerializableGeneralSettings GeneralSettings { get; set; }

		public Tuple<OfficialGame[], List<FanGame>, GeneralSettings> ToDomain(
			OfficialGame[] officialGamesTemplate
		) {
			var officialGames = officialGamesTemplate;
			int safeLength = Math.Min(officialGames.Length, OfficialGames.Length);
			for (int i = 0; i < safeLength; i++) {
				officialGames[i].FileLocation = OfficialGames[i].FileLocation;
			}

			var fanGames = new List<FanGame>();
			foreach (var fanGame in FanGames) {
				fanGames.Add(fanGame.ToDomain());
			}

			var generalSettings = GeneralSettings.ToDomain();

			return new Tuple<OfficialGame[], List<FanGame>, GeneralSettings>(
				officialGames,
				fanGames,
				generalSettings
			);
		}

		public static SerializableSettings FromDomain(
			OfficialGame[] officialGames,
			List<FanGame> fanGames,
			GeneralSettings generalSettings
		) {
			var serializable = new SerializableSettings();

			serializable.OfficialGames = new SerializableOfficialGame[officialGames.Length];
			for(int i = 0; i < serializable.OfficialGames.Length; i++) {
				serializable.OfficialGames[i] = SerializableOfficialGame.FromDomain(officialGames[i]);
			}

			serializable.FanGames = new List<SerializableFanGame>();
			foreach (var fanGame in fanGames) {
				serializable.FanGames.Add(SerializableFanGame.FromDomain(fanGame));
			}

			serializable.GeneralSettings = SerializableGeneralSettings.FromDomain(generalSettings);

			return serializable;
		}
	}
}
