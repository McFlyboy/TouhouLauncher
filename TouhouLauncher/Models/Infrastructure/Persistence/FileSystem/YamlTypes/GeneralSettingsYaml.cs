using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record GeneralSettingsYaml : Yaml {
		public bool? CloseOnGameLaunch { get; init; }

		public bool? CombineMainCategories { get; init; }

		public GeneralSettings ToDomain() => new(
			closeOnGameLaunch: CloseOnGameLaunch ?? false,
			combineMainCategories: CombineMainCategories ?? false
		);
	}

	namespace Extensions {
		public static class GeneralSettingsExtensionsForGeneralSettingsYaml {
			public static GeneralSettingsYaml ToYaml(this GeneralSettings domain) => new() {
				CloseOnGameLaunch = domain.CloseOnGameLaunch,
				CombineMainCategories = domain.CombineMainCategories
			};
		}
	}
}
