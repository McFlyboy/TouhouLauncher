using TouhouLauncher.Models.Serialization;
using TouhouLauncher.Models.Settings;

namespace TouhouLauncher.Services.Serialization {
	public class SettingsSerializerService {
		private readonly IFileSerializerService _fileSerializerService;
		private readonly string filePath;

		public SettingsSerializerService(IFileSerializerService fileSerializerService) {
			_fileSerializerService = fileSerializerService;
			filePath = "Settings." + fileSerializerService.FileLastName;
		}

		public bool SerializeToFile(Settings settings) {
			return _fileSerializerService.SerializeToFile(SerializableSettings.FromDomain(settings), filePath);
		}

		public Settings DeserializeFromFile() {
			return _fileSerializerService.DeserializeFromFile<SerializableSettings>(filePath)?.ToDomain();
		}
	}
}
