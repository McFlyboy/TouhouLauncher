using TouhouLauncher.Models.Infrastructure.Serialization;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using TouhouLauncher.Services.Application.Serialization;

namespace TouhouLauncher.Services.Infrastructure.Serialization {
	public class SettingsSerializerService : ISettingsSerializerService {
		private readonly IFileSerializerService _fileSerializerService;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;
		private readonly string filePath;

		public SettingsSerializerService(
			IFileSerializerService fileSerializerService,
			OfficialGamesTemplateService officialGamesTemplateService
		) {
			_fileSerializerService = fileSerializerService;
			_officialGamesTemplateService = officialGamesTemplateService;
			filePath = "Settings." + fileSerializerService.FileLastName;
		}

		public bool Serialize(Settings settings) {
			return _fileSerializerService.SerializeToFile(SerializableSettings.FromDomain(settings), filePath);
		}

		public Settings Deserialize() {
			return _fileSerializerService.DeserializeFromFile<SerializableSettings>(filePath)
				?.ToDomain(_officialGamesTemplateService.CreateOfficialGamesFromTemplate());
		}
	}
}
