using System.Collections.Generic;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record SettingsAndGamesYaml : Yaml {
		public GeneralSettingsYaml GeneralSettings { get; init; }

		public OfficialGameYaml[] OfficialGames { get; init; }

		public List<FanGameYaml> FanGames { get; init; }

		public SettingsAndGames ToDomain(OfficialGame[] officialGamesTemplate) {
			return new SettingsAndGames() {
				GeneralSettings = GeneralSettings
					.ToDomain(),

				OfficialGames = officialGamesTemplate
					.Select((template, index) =>
						OfficialGames.ElementAtOrDefault(index)
						?.ToDomain(template)
						?? template
					).ToArray(),

				FanGames = FanGames
					.Select(game => game.ToDomain())
					.ToList()
			};
		}
	}

	namespace Extensions {
		public static class SettingsAndGamesExtensionsForSettingsAndGamesYaml {
			public static SettingsAndGamesYaml ToYaml(this SettingsAndGames settingsAndGames) {
				return new SettingsAndGamesYaml() {
					GeneralSettings = settingsAndGames.GeneralSettings
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
