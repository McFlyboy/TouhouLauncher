using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Services.Application {
	public interface ISettingsService {
		public bool Save(
			OfficialGame[] officialGames,
			List<FanGame> fanGames,
			GeneralSettings generalSettings
		);

		public Tuple<OfficialGame[], List<FanGame>, GeneralSettings> Load();
	}
}
