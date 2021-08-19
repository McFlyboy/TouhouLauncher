using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class LaunchGameService {
		private readonly IExecutorService _executorService;
		private readonly SettingsAndGamesManager _settingsAndGamesManager;
		private readonly INp21ntConfigRepository _np21ntConfigRepository;

		public LaunchGameService(
			IExecutorService executorService,
			SettingsAndGamesManager settingsAndGamesManager,
			INp21ntConfigRepository np21ntConfigRepository
		) {
			_executorService = executorService;
			_settingsAndGamesManager = settingsAndGamesManager;
			_np21ntConfigRepository = np21ntConfigRepository;
		}

		public virtual async Task<bool> LaunchGame(Game game) {
			if (game.Categories.HasFlag(GameCategories.MainPC98)) {
				var config = await _np21ntConfigRepository.LoadAsync();

				config.NekoProject21.Hdd1File = game.FileLocation;

				var saveResult = await _np21ntConfigRepository.SaveAsync(config);

				if (saveResult == false) {
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
	}
}
