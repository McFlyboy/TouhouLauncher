namespace TouhouLauncher.Model.Settings {
	class SettingsManager {
		public static SettingsManager Instance { get; }

		static SettingsManager() {
			Instance = new SettingsManager();
		}

		private SettingsManager() { }

		public GeneralSettings GeneralSettings { get; set; }
	}
}
