using TouhouLauncher.Model.Settings;

namespace TouhouLauncher.Model.Serialization.Yaml {
	class GeneralSettingsYaml {
		public bool CloseOnGameLaunch { get; set; }
		public bool CombineMainCategories { get; set; }

		public GeneralSettings ToDomain() {
			return new GeneralSettings() {
				CloseOnGameLaunch = CloseOnGameLaunch,
				CombineMainCategories = CombineMainCategories
			};
		}

		public static GeneralSettingsYaml FromDomain(GeneralSettings domain) {
			return new GeneralSettingsYaml() {
				CloseOnGameLaunch = domain.CloseOnGameLaunch,
				CombineMainCategories = domain.CombineMainCategories
			};
		}
	}
}
