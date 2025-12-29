using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application;

public class LaunchRandomGameService(
    SettingsAndGamesManager settingsAndGamesManager,
    LaunchGameService launchGameService,
    Random random
)
{
    public async Task<TouhouLauncherError?> LaunchRandomGame()
    {
        List<Game> allGames = [..
            settingsAndGamesManager.OfficialGames
                .Cast<Game>()
                .Concat(settingsAndGamesManager.FanGames.Cast<Game>())
                .Where(game => !string.IsNullOrEmpty(game.FileLocation) && game.IncludeInRandomGame)
            ];

        if (allGames.Count == 0)
            return new LaunchRandomGameServiceError.NoGamesFoundError();

        int randomNumber = random.Next(allGames.Count);
        Game selectedGame = allGames[randomNumber];

        return await launchGameService.LaunchGame(selectedGame);
    }
}

public abstract record LaunchRandomGameServiceError : TouhouLauncherError
{
    public record NoGamesFoundError : LaunchRandomGameServiceError
    {
        public override string Message => "Could not find any games to start that matched the filtered search";
    }
}
