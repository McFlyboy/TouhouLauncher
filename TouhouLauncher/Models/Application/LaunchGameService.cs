using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class LaunchGameService {
		private readonly IExecutorService _executorService;
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public LaunchGameService(
			IExecutorService executorService,
			SettingsAndGamesManager settingsAndGamesManager
		) {
			_executorService = executorService;
			_settingsAndGamesManager = settingsAndGamesManager;
		}

		public virtual bool LaunchGame(Game game) {
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
