using System.Collections.Generic;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record SettingsAndGamesYaml : Yaml {
		public GeneralSettingsYaml GeneralSettings { get; init; }

		public EmulatorSettingsYaml EmulatorSettings { get; init; }

		public OfficialGameYaml[] OfficialGames { get; init; }

		public List<FanGameYaml> FanGames { get; init; }

		public SettingsAndGames ToDomain(OfficialGame[] officialGamesTemplate) {
			return new SettingsAndGames(
				GeneralSettings
					?.ToDomain()
					?? new GeneralSettings(),
				EmulatorSettings
					?.ToDomain()
					?? new EmulatorSettings() {
						FolderLocation = string.Empty
					},
				officialGamesTemplate
					.Select((template, index) =>
						OfficialGames?.ElementAtOrDefault(index)
							?.ToDomain(template)
							?? template
					).ToArray(),
				FanGames
					?.Select(game => game.ToDomain())
					?.ToList()
					?? new List<FanGame>()
			);
		}
	}

	namespace Extensions {
		public static class SettingsAndGamesExtensionsForSettingsAndGamesYaml {
			public static SettingsAndGamesYaml ToYaml(this SettingsAndGames settingsAndGames) {
				return new SettingsAndGamesYaml() {
					GeneralSettings = settingsAndGames.GeneralSettings
						.ToYaml(),

					EmulatorSettings = settingsAndGames.EmulatorSettings
						.ToYaml(),

					OfficialGames = settingsAndGames.OfficialGames
						.Select(game => game.ToYaml())
						.ToArray(),

					FanGames = settingsAndGames.FanGames
						.Select(game => game.ToYaml())
						.ToList()
				};
			}
		}
	}
}
