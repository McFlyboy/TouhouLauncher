﻿using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem {
	public class FileSystemSettingsAndGamesService : ISettingsAndGamesService {
		private readonly FileAccessService _fileAccessService;
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		private readonly string filePath;

		public FileSystemSettingsAndGamesService(
			FileAccessService fileAccessService,
			OfficialGamesTemplateService officialGamesTemplateService
		) {
			_fileAccessService = fileAccessService;
			_officialGamesTemplateService = officialGamesTemplateService;

			filePath = "Settings.yaml";
		}

		public virtual async Task<bool> SaveAsync(SettingsAndGames settingsAndGames) {
			return await _fileAccessService.WriteFileFromYamlAsync(filePath, settingsAndGames?.ToYaml());
		}

		public virtual async Task<SettingsAndGames> LoadAsync() {
			return (await _fileAccessService.ReadFileToYamlAsync<SettingsAndGamesYaml>(filePath))
				?.ToDomain(_officialGamesTemplateService.CreateOfficialGamesFromTemplate());
		}
	}
}
