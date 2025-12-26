using System.Threading.Tasks;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application;

public interface ISettingsAndGamesRepository
{
    public Task<SettingsAndGamesSaveError?> SaveAsync(SettingsAndGames? settingsAndGames);

    public Task<Either<SettingsAndGamesLoadError, SettingsAndGames>> LoadAsync();
}

public record SettingsAndGamesSaveError(string Reason) : TouhouLauncherError
{
    public override string Message => $"Unable to save launcher settings.\n\nReason:\n{Reason}";
}

public record SettingsAndGamesLoadError(string Reason) : TouhouLauncherError
{
    public override string Message => $"Unable to load launcher settings.\n\nReason:\n{Reason}";
}
