using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application;

public class GameCategoryService(SettingsAndGamesManager settingsAndGamesManager)
{
    public List<GameCategories> CreateGameCategoryList()
    {
        var gameCategories = new List<GameCategories>();

        if (settingsAndGamesManager.GeneralSettings.CombineMainCategories)
        {
            gameCategories.Add(GameCategories.MainGame);
        }
        else
        {
            gameCategories.Add(GameCategories.MainPC98);
            gameCategories.Add(GameCategories.MainWindows);
        }
        gameCategories.Add(GameCategories.FightingGame);
        gameCategories.Add(GameCategories.SpinOff);
        gameCategories.Add(GameCategories.FanGame);

        return gameCategories;
    }

    public GameCategories GetDefaultGameCategory() =>
        settingsAndGamesManager.GeneralSettings.CombineMainCategories
            ? GameCategories.MainGame
            : GameCategories.MainWindows;
}
