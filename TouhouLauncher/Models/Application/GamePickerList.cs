using System.Collections.Generic;
using System.Linq;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application;

public class GamePickerList(SettingsAndGamesManager settingsAndGamesManager)
{
    public List<Game> GameList { get; } = [];

    public void PopulateGameList(GameCategories categories)
    {
        GameList.Clear();
        GameList.AddRange(
            categories switch
            {
                GameCategories.FanGame => settingsAndGamesManager.FanGames,
                _ => settingsAndGamesManager.OfficialGames.Where(game => categories.HasFlag(game.Categories))
            }
        );
    }
}
