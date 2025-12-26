using NSubstitute;
using TouhouLauncher.Models.Application;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using System.Threading.Tasks;

namespace TouhouLauncher.Test.Models.Application;

public class GameConfigServiceTest
{
    private readonly SettingsAndGamesManager _settingsAndGamesManagerMock = Substitute.For<SettingsAndGamesManager>(null, null);

    private readonly GameConfigService _gameConfigService;

    public GameConfigServiceTest()
    {
        _gameConfigService = new(_settingsAndGamesManagerMock);
    }

    [Fact]
    public void Sets_game_to_configure_and_sets_game_settings()
    {
        _gameConfigService.SetGameToConfigure(testOfficialGame1);

        Assert.Equal(testOfficialGame1, _gameConfigService.TargetGame);
        Assert.Equal(testOfficialGame1.FileLocation, _gameConfigService.GameLocation);
        Assert.Equal(testOfficialGame1.IncludeInRandomGame, _gameConfigService.IncludeInRandomGame);
    }

    [Fact]
    public async Task Doesnt_save_changes_when_target_game_is_null_and_returns_error()
    {
        var error = await _gameConfigService.SaveAsync();

        Assert.NotNull(error);

        await _settingsAndGamesManagerMock.DidNotReceive().SaveAsync();
    }

    [Fact]
    public async Task Stores_game_settings_in_game_and_saves_changes_and_returns_save_result()
    {
        _settingsAndGamesManagerMock.SaveAsync()
            .Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

        _gameConfigService.SetGameToConfigure(testOfficialGame1);

        var error = await _gameConfigService.SaveAsync();

        Assert.Null(error);
        Assert.Equal(_gameConfigService.GameLocation, testOfficialGame1.FileLocation);
        Assert.Equal(_gameConfigService.IncludeInRandomGame, testOfficialGame1.IncludeInRandomGame);

        await _settingsAndGamesManagerMock.Received(1).SaveAsync();
    }
}
