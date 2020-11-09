using TouhouLauncher.Models.Infrastructure.Serialization;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using TouhouLauncher.Models.Application.GameInfo;
using System.Collections.Generic;
using System;
using TouhouLauncher.Services.Infrastructure.Serialization;

namespace TouhouLauncher.Services.Infrastructure {
	public class FileSettingsService : ISettingsService {
		private readonly IFileSerializerService _fileSerializerService;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;
		private readonly string filePath;

		public FileSettingsService(
			IFileSerializerService fileSerializerService,
			OfficialGamesTemplateService officialGamesTemplateService
		) {
			_fileSerializerService = fileSerializerService;
			_officialGamesTemplateService = officialGamesTemplateService;
			filePath = "Settings." + fileSerializerService.FileLastName;
		}

		public bool Save(
			OfficialGame[] officialGames,
			List<FanGame> fanGames,
			GeneralSettings generalSettings
		) {
			return _fileSerializerService.SerializeToFile(
				SerializableSettings.FromDomain(officialGames, fanGames, generalSettings),
				filePath
			);
		}

		public Tuple<OfficialGame[], List<FanGame>, GeneralSettings> Load() {
			return _fileSerializerService.DeserializeFromFile<SerializableSettings>(filePath)
				?.ToDomain(_officialGamesTemplateService.CreateOfficialGamesFromTemplate());
		}
	}
}
