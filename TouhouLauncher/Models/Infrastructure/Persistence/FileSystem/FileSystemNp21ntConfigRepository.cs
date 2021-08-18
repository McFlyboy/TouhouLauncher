using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem {
	public class FileSystemNp21ntConfigRepository : INp21ntConfigRepository {
		private readonly FileAccessService _fileAccessService;
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public FileSystemNp21ntConfigRepository(
			FileAccessService fileAccessService,
			SettingsAndGamesManager settingsAndGamesManager
		) {
			_fileAccessService = fileAccessService;
			_settingsAndGamesManager = settingsAndGamesManager;
		}

		public async Task<bool> SaveAsync(Np21ntConfig config) =>
			await _fileAccessService.WriteFileFromIniAsync(
				$"{_settingsAndGamesManager.EmulatorSettings.FolderLocation}\\np21nt.ini",
				config?.ToIni()
			);

		public async Task<Np21ntConfig> LoadAsync() =>
			(await _fileAccessService.ReadFileToIniAsync<Np21ntConfigIni>(
				$"{_settingsAndGamesManager.EmulatorSettings.FolderLocation}\\np21nt.ini"
			))?.ToDomain();
	}
}
