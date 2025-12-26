using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Common.Extensions;

namespace TouhouLauncher.Models.Application;

public class LaunchGameService(
    IExecutorService executorService,
    SettingsAndGamesManager settingsAndGamesManager,
    INp21ntConfigRepository np21ntConfigRepository,
    Np21ntConfigDefaultsService np21ntConfigDefaultsService,
    PathExistanceService pathExistanceService
)
{
    public virtual async Task<TouhouLauncherError?> LaunchGame(Game game)
    {
        if (!pathExistanceService.PathExists(game.FileLocation))
            return new LaunchGameError.GameDoesNotExistError();

        bool isPc98Game = game.Categories.HasFlag(GameCategories.MainPC98);

        string? emulatorLocation = settingsAndGamesManager.EmulatorSettings.FolderLocation
            ?.Transform(folderLocation => $"{folderLocation}\\np21nt.exe");

        if (isPc98Game)
        {
            if (!pathExistanceService.PathExists(emulatorLocation))
                return string.IsNullOrEmpty(settingsAndGamesManager.EmulatorSettings.FolderLocation)
                    ? new LaunchGameError.EmulatorLocationNotSetError()
                    : new LaunchGameError.EmulatorDoesNotExistError();

            var configError = await ConfigureEmulatorForGame(game);

            if (configError != null)
                return configError;
        }

        string executableLocation = isPc98Game ? emulatorLocation! : game.FileLocation!;

        var result = executorService.StartExecutable(executableLocation);

        return result.Resolve<ExecutorServiceError?>(
            error => error,
            process =>
            {
                if (settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch)
                    System.Windows.Application.Current.Shutdown();

                return null;
            }
        );
    }

    private async Task<Np21ntConfigSaveError?> ConfigureEmulatorForGame(Game game)
    {
        Np21ntConfig config = (await np21ntConfigRepository.LoadAsync())
            .Resolve(
                error => np21ntConfigDefaultsService.CreateNp21ntConfigDefaults(),
                config => config
            );

        if (config.NekoProject21.Hdd1File == game.FileLocation)
            return null;

        Np21ntConfig editedConfig = config with
        {
            NekoProject21 = config.NekoProject21 with
            {
                Hdd1File = game.FileLocation!
            }
        };

        var error = await np21ntConfigRepository.SaveAsync(editedConfig);

        return error;
    }
}

public abstract record LaunchGameError : TouhouLauncherError
{
    public record GameDoesNotExistError : LaunchGameError
    {
        public override string Message => "The requested game could not be found. " +
            "Please check that the game's file location is correct";
    }

    public record EmulatorLocationNotSetError : LaunchGameError
    {
        public override string Message => "An emulator must be connected before you can launch a PC-98 game";
    }

    public record EmulatorDoesNotExistError : LaunchGameError
    {
        public override string Message => "The PC-98 emulator was not found. " +
            "Please update the emulator's location in settings before trying again";
    }
}
