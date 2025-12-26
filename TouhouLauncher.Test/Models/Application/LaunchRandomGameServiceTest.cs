using NSubstitute;
using System;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Test.Models.Application;

public class LaunchRandomGameServiceTest
{
    private readonly SettingsAndGamesManager _settingsAndGamesManagerMock = Substitute.For<SettingsAndGamesManager>(null, null);
    private readonly LaunchGameService _launchGameServiceMock = Substitute.For<LaunchGameService>(null, null, null, null, null);
    private readonly Random _randomMock = Substitute.For<Random>();

    private readonly LaunchRandomGameService _launchRandomGameService;

    public LaunchRandomGameServiceTest()
    {
        _launchRandomGameService = new(
            _settingsAndGamesManagerMock,
            _launchGameServiceMock,
            _randomMock
        );
    }

    [Fact]
    public async Task Returns_error_when_no_games_exist()
    {
        _settingsAndGamesManagerMock.OfficialGames
            .Returns([]);

        _settingsAndGamesManagerMock.FanGames
            .Returns([]);

        var result = await _launchRandomGameService.LaunchRandomGame();

        Assert.NotNull(result);
        Assert.IsType<LaunchRandomGameServiceError.NoGamesFoundError>(result);
    }

    [Fact]
    public async Task Returns_error_when_a_game_fails_to_start()
    {
        _settingsAndGamesManagerMock.OfficialGames
            .Returns(testOfficialGames);

        _settingsAndGamesManagerMock.FanGames
            .Returns(testFanGames);

        _randomMock.Next(Arg.Any<int>())
            .Returns(0);

        _launchGameServiceMock.LaunchGame(Arg.Any<Game>())
            .Returns(Task.FromResult<TouhouLauncherError?>(new LaunchGameError.GameDoesNotExistError()));

        var result = await _launchRandomGameService.LaunchRandomGame();

        await _launchGameServiceMock.Received(1).LaunchGame(Arg.Any<Game>());

        Assert.NotNull(result);
        Assert.IsType<LaunchGameError.GameDoesNotExistError>(result);
    }

    [Fact]
    public async Task Returns_null_when_a_game_starts_successfully()
    {
        _settingsAndGamesManagerMock.OfficialGames
            .Returns(testOfficialGames);

        _settingsAndGamesManagerMock.FanGames
            .Returns(testFanGames);

        _randomMock.Next(Arg.Any<int>())
            .Returns(0);

        _launchGameServiceMock.LaunchGame(Arg.Any<Game>())
            .Returns(Task.FromResult<TouhouLauncherError?>(null));

        var result = await _launchRandomGameService.LaunchRandomGame();

        await _launchGameServiceMock.Received(1).LaunchGame(Arg.Any<Game>());

        Assert.Null(result);
    }
}
