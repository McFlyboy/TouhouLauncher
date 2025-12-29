using System.Collections.Generic;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes
{
    public record SettingsAndGamesYaml : Yaml
    {
        public GeneralSettingsYaml? GeneralSettings { get; init; }

        public EmulatorSettingsYaml? EmulatorSettings { get; init; }

        public OfficialGameYaml[]? OfficialGames { get; init; }

        public List<FanGameYaml>? FanGames { get; init; }

        public SettingsAndGames ToDomain(OfficialGame[] officialGamesTemplate) => new(
            GeneralSettings: GeneralSettings?.ToDomain()
                ?? new(
                    closeOnGameLaunch: false,
                    combineMainCategories: false
                ),
            EmulatorSettings: EmulatorSettings?.ToDomain()
                ?? new(
                    folderLocation: string.Empty
                ),
            OfficialGames: [.. officialGamesTemplate.Select((template, index) =>
                OfficialGames?.ElementAtOrDefault(index)
                    ?.ToDomain(template)
                    ?? template
            )],
            FanGames: FanGames?.Select(game => game.ToDomain())
                ?.Where(game => game != null)
                ?.Select(game => game!)
                ?.ToList()
                ?? []
        );
    }

    namespace Extensions
    {
        public static class SettingsAndGamesExtensionsForSettingsAndGamesYaml
        {
            public static SettingsAndGamesYaml ToYaml(this SettingsAndGames settingsAndGames) => new()
            {
                GeneralSettings = settingsAndGames.GeneralSettings.ToYaml(),
                EmulatorSettings = settingsAndGames.EmulatorSettings.ToYaml(),
                OfficialGames = [.. settingsAndGames.OfficialGames.Select(game => game.ToYaml())],
                FanGames = [.. settingsAndGames.FanGames.Select(game => game.ToYaml())]
            };
        }
    }
}
