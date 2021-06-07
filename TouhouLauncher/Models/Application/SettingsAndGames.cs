using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Application {
    public record SettingsAndGames(
        GeneralSettings GeneralSettings,
        EmulatorSettings EmulatorSettings,
        OfficialGame[] OfficialGames,
        List<FanGame> FanGames
    );
}
