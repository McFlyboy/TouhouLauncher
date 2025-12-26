using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using Xunit;

namespace TouhouLauncher.Test.Models.Application;

public class FanGameEditingServiceTest
{
    private readonly SettingsAndGamesManager _settingsAndGamesManagerMock = Substitute.For<SettingsAndGamesManager>(null, null);

    private readonly FanGameEditingService _fanGameEditingService;

    public FanGameEditingServiceTest()
    {
        _fanGameEditingService = new(_settingsAndGamesManagerMock);
    }

    [Fact]
    public async Task Fails_to_create_and_save_fan_game_when_required_fields_are_missing()
    {
        var error = await _fanGameEditingService.SaveAsync();

        Assert.IsType<FanGameInfoMissingError>(error);
    }

    [Fact]
    public async Task Returns_error_when_saving_edited_fan_game_fails()
    {
        _settingsAndGamesManagerMock.SaveAsync()
            .Returns(Task.FromResult<SettingsAndGamesSaveError?>(new("error")));

        _fanGameEditingService.SetFanGameToEdit(
            new(
                title: "title",
                imageLocation: null,
                audioLocation: null,
                releaseYear: null,
                fileLocation: string.Empty,
                includeInRandomGame: true
            )
        );

        _fanGameEditingService.GameLocation = "location";

        var error = await _fanGameEditingService.SaveAsync();

        Assert.IsType<SettingsAndGamesSaveError>(error);
    }

    [Fact]
    public async Task Returns_null_when_saving_edited_fan_game_succeeds()
    {
        _settingsAndGamesManagerMock.SaveAsync()
            .Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

        _fanGameEditingService.SetFanGameToEdit(
            new(
                title: "title",
                imageLocation: null,
                audioLocation: null,
                releaseYear: null,
                fileLocation: string.Empty,
                includeInRandomGame: true
            )
        );

        _fanGameEditingService.GameLocation = "location";

        var error = await _fanGameEditingService.SaveAsync();

        Assert.Null(error);
        Assert.Equal(_fanGameEditingService.GameLocation, _fanGameEditingService.TargetFanGame!.FileLocation);
    }

    [Fact]
    public async Task Returns_null_when_creating_and_saving_new_fan_game_succeeds()
    {
        List<FanGame> fanGames = [];

        _settingsAndGamesManagerMock.FanGames
            .Returns(fanGames);

        _settingsAndGamesManagerMock.SaveAsync()
            .Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

        _fanGameEditingService.SetFanGameToEdit(null);

        _fanGameEditingService.GameTitle = "title";
        _fanGameEditingService.GameLocation = "location";

        var error = await _fanGameEditingService.SaveAsync();

        Assert.Null(error);
        Assert.Equal(
            new(
                title: "title",
                imageLocation: null,
                audioLocation: null,
                releaseYear: null,
                fileLocation: "location",
                includeInRandomGame: true
            ),
            fanGames.Last()
        );
    }

    [Fact]
    public async Task Returns_error_when_trying_to_delete_non_existing_game()
    {
        var error = await _fanGameEditingService.DeleteFanGame();

        Assert.IsType<FanGameNotSpecifiedError>(error);
    }

    [Fact]
    public async Task Returns_error_when_saving_deletion_of_fan_game_fails()
    {
        List<FanGame> fanGames = [
            new(
                title: "title",
                imageLocation: null,
                audioLocation: null,
                releaseYear: null,
                fileLocation: "location",
                includeInRandomGame: true
            )
        ];

        _settingsAndGamesManagerMock.FanGames
            .Returns(fanGames);

        _settingsAndGamesManagerMock.SaveAsync()
            .Returns(Task.FromResult<SettingsAndGamesSaveError?>(new("error")));

        _fanGameEditingService.SetFanGameToEdit(fanGames.First());

        var error = await _fanGameEditingService.DeleteFanGame();

        Assert.IsType<SettingsAndGamesSaveError>(error);
    }

    [Fact]
    public async Task Returns_null_when_saving_deletion_of_fan_game_succeeds()
    {
        List<FanGame> fanGames = [
            new(
                title: "title",
                imageLocation: null,
                audioLocation: null,
                releaseYear: null,
                fileLocation: "location",
                includeInRandomGame: true
            )
        ];

        _settingsAndGamesManagerMock.FanGames
            .Returns(fanGames);

        _settingsAndGamesManagerMock.SaveAsync()
            .Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

        _fanGameEditingService.SetFanGameToEdit(fanGames.First());

        var error = await _fanGameEditingService.DeleteFanGame();

        Assert.Null(error);
        Assert.Empty(fanGames);
    }
}
