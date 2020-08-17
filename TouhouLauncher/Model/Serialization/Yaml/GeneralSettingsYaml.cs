using TouhouLauncher.Model.Settings;

namespace TouhouLauncher.Model.Serialization.Yaml {
	class GeneralSettingsYaml {
		public bool CloseOnGameLaunch { get; set; }

		public GeneralSettings ToDomain() {
			return new GeneralSettings() {
				CloseOnGameLaunch = CloseOnGameLaunch
			};
		}

		public static GeneralSettingsYaml FromDomain(GeneralSettings domain) {
			return new GeneralSettingsYaml() {
				CloseOnGameLaunch = domain.CloseOnGameLaunch
			};
		}
	}
}
