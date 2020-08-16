using TouhouLauncher.Model.Settings;

namespace TouhouLauncher.Model.Serialization.Yaml {
	class GeneralSettingsYaml {
		public bool CloseOnGameLaunch { get; set; }

		public GeneralSettings ToDomain() {
			return new GeneralSettings() {
				CloseOnGameLaunch = CloseOnGameLaunch
			};
		}
	}
}
