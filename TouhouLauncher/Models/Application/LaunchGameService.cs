using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;

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

		public virtual async Task<TouhouLauncherError?> LaunchGame(Game game) {
			if (game.Categories.HasFlag(GameCategories.MainPC98)) {
				if (_settingsAndGamesManager.EmulatorSettings.FolderLocation == null) {
					return new LaunchGameError.EmulatorLocationNotSetError();
				}

				var configError = await ConfigureEmulatorForGame(game);

				if (configError != null) {
					return configError;
				}
			}

			var executableLocation = game.Categories.HasFlag(GameCategories.MainPC98)
				? $"{_settingsAndGamesManager.EmulatorSettings.FolderLocation}\\np21nt.exe"
				: game.FileLocation;

			if (executableLocation == null) {
				return new LaunchGameError.GameLocationNotSetError();
			}

			var process = _executorService.StartExecutable(executableLocation);

			return process.Resolve<ExecutorServiceError?>(
				error => error,
				process => {
					if (_settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch) {
						System.Windows.Application.Current.Shutdown();
					}

					return null;
				}
			);
		}

		private async Task<Np21ntConfigSaveError?> ConfigureEmulatorForGame(Game game) {
			Np21ntConfig config = (await _np21ntConfigRepository.LoadAsync())
				.Resolve(
					error => _np21ntConfigDefaultsService.CreateNp21ntConfigDefaults(),
					config => config
				);

			if (config.NekoProject21.Hdd1File == game.FileLocation) {
				return null;
			}

			Np21ntConfig newConfig = config with {
				NekoProject21 = config.NekoProject21 with {
					Hdd1File = game.FileLocation ?? string.Empty
				}
			};

			var error = await _np21ntConfigRepository.SaveAsync(newConfig);

			return error;
		}
	}

	public abstract record LaunchGameError : TouhouLauncherError {
		public record EmulatorLocationNotSetError : LaunchGameError {
			public override string Message => "An emulator must be connected before you can launch a PC-98 game";
		}

		public record GameLocationNotSetError : LaunchGameError {
			public override string Message => "A game executable must be connected before you can launch this game";
		}
	}
}
