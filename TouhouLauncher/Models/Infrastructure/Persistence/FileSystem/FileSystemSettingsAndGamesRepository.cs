using System;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;

public class FileSystemSettingsAndGamesRepository(
    FileAccessService fileAccessService,
    OfficialGamesTemplateService officialGamesTemplateService
) : ISettingsAndGamesRepository
{
    private readonly string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\McFlyboy\Touhou Launcher\Settings.yaml";

    public virtual async Task<SettingsAndGamesSaveError?> SaveAsync(SettingsAndGames? settingsAndGames) =>
        (await fileAccessService.WriteFileFromYamlAsync(filePath, settingsAndGames?.ToYaml()))
            ?.Transform(error => new SettingsAndGamesSaveError(error.Message));

    public virtual async Task<Either<SettingsAndGamesLoadError, SettingsAndGames>> LoadAsync() =>
        (await fileAccessService.ReadFileToYamlAsync<SettingsAndGamesYaml>(filePath))
            .ResolveToEither<SettingsAndGamesLoadError, SettingsAndGames>(
                error => new SettingsAndGamesLoadError(error.Message),
                yaml => yaml.ToDomain(officialGamesTemplateService.CreateOfficialGamesFromTemplate())
            );
}
