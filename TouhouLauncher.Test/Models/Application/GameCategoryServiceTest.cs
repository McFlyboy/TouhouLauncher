using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;
using Xunit;

namespace TouhouLauncher.Test.Models.Application;

public class GameCategoryServiceTest
{
    private readonly SettingsAndGamesManager _settingsAndGamesManagerMock = Substitute.For<SettingsAndGamesManager>(null, null);

    private readonly GameCategoryService _gameCategoryService;

    public GameCategoryServiceTest()
    {
        _gameCategoryService = new(_settingsAndGamesManagerMock);
    }

    [Fact]
    public void Combines_main_categories_when_combine_setting_is_enabled()
    {
        _settingsAndGamesManagerMock.GeneralSettings
            .Returns(
                new GeneralSettings(
                    closeOnGameLaunch: false,
                    combineMainCategories: true
                )
            );

        List<GameCategories> categoryListResult = _gameCategoryService.CreateGameCategoryList();

        Assert.Equal(GameCategories.MainGame, categoryListResult.First());

        GameCategories dafaultCategoryResult = _gameCategoryService.GetDefaultGameCategory();

        Assert.Equal(GameCategories.MainGame, dafaultCategoryResult);
    }

    [Fact]
    public void Separates_main_categories_when_combine_setting_is_disabled()
    {
        _settingsAndGamesManagerMock.GeneralSettings
            .Returns(
                new GeneralSettings(
                    closeOnGameLaunch: false,
                    combineMainCategories: false
                )
            );

        List<GameCategories> categoryListResult = _gameCategoryService.CreateGameCategoryList();

        Assert.Equal(GameCategories.MainPC98, categoryListResult[0]);
        Assert.Equal(GameCategories.MainWindows, categoryListResult[1]);

        GameCategories dafaultCategoryResult = _gameCategoryService.GetDefaultGameCategory();

        Assert.Equal(GameCategories.MainWindows, dafaultCategoryResult);
    }
}
