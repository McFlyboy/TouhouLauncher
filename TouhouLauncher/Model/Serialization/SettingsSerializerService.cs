using TouhouLauncher.Model.Serialization.Yaml;

namespace TouhouLauncher.Model.Serialization {
	class SettingsSerializerService {
		public static SettingsSerializerService Instance { get; }

		static SettingsSerializerService() {
			Instance = new SettingsSerializerService();
		}

		private const string FILE_PATH = "Settings.yaml";

		private readonly SerializerService serializerService;

		private SettingsSerializerService() {
			serializerService = new SerializerService();
		}

		public bool SerializeToFile(Settings.Settings settings) {
			return serializerService.SerializeToFile(SettingsYaml.FromDomain(settings), FILE_PATH);
		}

		public Settings.Settings DeserializeFromFile() {
			return serializerService.DeserializeFromFile<SettingsYaml>(FILE_PATH)?.ToDomain();
		}
	}
}
