using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application;

public class GameConfigService(SettingsAndGamesManager settingsAndGamesManager)
{
    public Game? TargetGame { get; private set; } = null;

    public string GameLocation { get; set; } = string.Empty;

    public bool IncludeInRandomGame { get; set; } = false;

    public async Task<TouhouLauncherError?> SaveAsync()
    {
        if (TargetGame == null)
            return new TargetGameNotSetError();

        TargetGame.FileLocation = GameLocation;
        TargetGame.IncludeInRandomGame = IncludeInRandomGame;

        return await settingsAndGamesManager.SaveAsync();
    }

    public void SetGameToConfigure(Game game)
    {
        TargetGame = game;
        GameLocation = TargetGame.FileLocation ?? string.Empty;
        IncludeInRandomGame = TargetGame.IncludeInRandomGame;
    }
}

public record TargetGameNotSetError : TouhouLauncherError
{
    public override string Message => "Target game to configure was not set correctly";
}
