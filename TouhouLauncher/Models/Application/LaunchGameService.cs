using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class LaunchGameService {
		private readonly IExecutorService _executorService;
		private readonly SettingsAndGamesManager _settingsAndGamesManager;
		private readonly INp21ntConfigRepository _np21ntConfigRepository;
		private readonly Np21ntConfigDefaultsService _np21ntConfigDefaultsService;

		public LaunchGameService(
			IExecutorService executorService,
			SettingsAndGamesManager settingsAndGamesManager,
			INp21ntConfigRepository np21ntConfigRepository,
			Np21ntConfigDefaultsService np21ntConfigDefaultsService
		) {
			_executorService = executorService;
			_settingsAndGamesManager = settingsAndGamesManager;
			_np21ntConfigRepository = np21ntConfigRepository;
			_np21ntConfigDefaultsService = np21ntConfigDefaultsService;
		}

		public virtual async Task<bool> LaunchGame(Game game) {
			if (game.Categories.HasFlag(GameCategories.MainPC98)) {
				var configSuccess = await ConfigureEmulatorForGame(game);

				if (!configSuccess) {
					return false;
				}
			}

			var executableLocation = game.Categories.HasFlag(GameCategories.MainPC98)
				? $"{_settingsAndGamesManager.EmulatorSettings.FolderLocation}\\np21nt.exe"
				: game.FileLocation;

			var process = _executorService.StartExecutable(executableLocation);

			if (process == null) {
				return false;
			}

			if (_settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch) {
				System.Windows.Application.Current.Shutdown();
			}

			return true;
		}

		private async Task<bool> ConfigureEmulatorForGame(Game game) {
			var config = (await _np21ntConfigRepository.LoadAsync())
				?? _np21ntConfigDefaultsService.CreateNp21ntConfigDefaults();

			if (config.NekoProject21.Hdd1File == game.FileLocation) {
				return true;
			}

			config.NekoProject21.Hdd1File = game.FileLocation;

			var saveSuccess = await _np21ntConfigRepository.SaveAsync(config);

			return saveSuccess;
		}
	}
}
