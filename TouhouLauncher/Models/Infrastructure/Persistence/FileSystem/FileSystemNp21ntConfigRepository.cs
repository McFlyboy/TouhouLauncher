using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;

public class FileSystemNp21ntConfigRepository(
    FileAccessService fileAccessService,
    SettingsAndGamesManager settingsAndGamesManager,
    Np21ntConfigDefaultsService np21ntConfigDefaultsService
    ) : INp21ntConfigRepository
{
    public virtual async Task<Np21ntConfigSaveError?> SaveAsync(Np21ntConfig? config) =>
        (await fileAccessService.WriteFileFromIniAsync(
            $"{settingsAndGamesManager.EmulatorSettings.FolderLocation}\\np21nt.ini",
            config?.ToIni()
        ))?.Transform(error => new Np21ntConfigSaveError(error.Message));

    public virtual async Task<Either<Np21ntConfigLoadError, Np21ntConfig>> LoadAsync() =>
        (await fileAccessService.ReadFileToIniAsync<Np21ntConfigIni>(
            $"{settingsAndGamesManager.EmulatorSettings.FolderLocation}\\np21nt.ini"
        )).ResolveToEither<Np21ntConfigLoadError, Np21ntConfig>(
            error => new Np21ntConfigLoadError(error.Message),
            ini => ini.ToDomain(np21ntConfigDefaultsService.CreateNp21ntConfigDefaults())
        );
}
