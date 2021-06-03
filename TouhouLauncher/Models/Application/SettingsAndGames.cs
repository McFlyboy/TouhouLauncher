using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Application {
    public record SettingsAndGames {
        public GeneralSettings GeneralSettings { get; init; }

        public OfficialGame[] OfficialGames { get; init; }

        public List<FanGame> FanGames { get; init; }
    }
}
