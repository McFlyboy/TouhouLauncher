using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Common.Extensions;

namespace TouhouLauncher.Models.Application {
	public class LaunchGameService {
		private readonly IExecutorService _executorService;
		private readonly SettingsAndGamesManager _settingsAndGamesManager;
		private readonly INp21ntConfigRepository _np21ntConfigRepository;
		private readonly Np21ntConfigDefaultsService _np21ntConfigDefaultsService;
		private readonly PathExistanceService _pathExistanceService;

		public LaunchGameService(
			IExecutorService executorService,
			SettingsAndGamesManager settingsAndGamesManager,
			INp21ntConfigRepository np21ntConfigRepository,
			Np21ntConfigDefaultsService np21ntConfigDefaultsService,
			PathExistanceService pathExistanceService
		) {
			_executorService = executorService;
			_settingsAndGamesManager = settingsAndGamesManager;
			_np21ntConfigRepository = np21ntConfigRepository;
			_np21ntConfigDefaultsService = np21ntConfigDefaultsService;
			_pathExistanceService = pathExistanceService;
		}

		public virtual async Task<TouhouLauncherError?> LaunchGame(Game game) {
			if (!_pathExistanceService.PathExists(game.FileLocation)) {
				return new LaunchGameError.GameDoesNotExistError();
			}

			bool isPc98Game = game.Categories.HasFlag(GameCategories.MainPC98);

			string? emulatorLocation = _settingsAndGamesManager.EmulatorSettings.FolderLocation
				?.Transform(folderLocation => $"{folderLocation}\\np21nt.exe");

			if (isPc98Game) {
				if (!_pathExistanceService.PathExists(emulatorLocation)) {
					return string.IsNullOrEmpty(_settingsAndGamesManager.EmulatorSettings.FolderLocation)
						? new LaunchGameError.EmulatorLocationNotSetError()
						: new LaunchGameError.EmulatorDoesNotExistError();
				}

				var configError = await ConfigureEmulatorForGame(game);

				if (configError != null) {
					return configError;
				}
			}

			string executableLocation = isPc98Game ? emulatorLocation! : game.FileLocation!;

			var result = _executorService.StartExecutable(executableLocation);

			return result.Resolve<ExecutorServiceError?>(
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

			Np21ntConfig editedConfig = config with {
				NekoProject21 = config.NekoProject21 with {
					Hdd1File = game.FileLocation!
				}
			};

			var error = await _np21ntConfigRepository.SaveAsync(editedConfig);

			return error;
		}
	}

	public abstract record LaunchGameError : TouhouLauncherError {
		public record GameDoesNotExistError : LaunchGameError {
			public override string Message => "The requested game could not be found. " +
				"Please check that the game's file location is correct";
		}

		public record EmulatorLocationNotSetError : LaunchGameError {
			public override string Message => "An emulator must be connected before you can launch a PC-98 game";
		}

		public record EmulatorDoesNotExistError : LaunchGameError {
			public override string Message => "The PC-98 emulator was not found. " +
				"Please update the emulator's location in settings before trying again";
		}
	}
}
