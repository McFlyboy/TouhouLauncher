using NSubstitute;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Test.Models.Application;

public class SettingsAndGamesManagerTest
{
    private readonly FileSystemSettingsAndGamesRepository _fileSystemSettingsAndGamesServiceMock = Substitute.For<FileSystemSettingsAndGamesRepository>(null, null);
    private readonly OfficialGamesTemplateService _officialGamesTemplateServiceMock = Substitute.For<OfficialGamesTemplateService>();

    private readonly SettingsAndGamesManager _settingsAndGamesManager;

    public SettingsAndGamesManagerTest()
    {
        _settingsAndGamesManager = new(
            _fileSystemSettingsAndGamesServiceMock,
            _officialGamesTemplateServiceMock
        );
    }

    [Fact]
    public async Task Saves_settings_and_games_and_returns_result()
    {
        _fileSystemSettingsAndGamesServiceMock
            .SaveAsync(Arg.Any<SettingsAndGames>())
            .Returns(Task.FromResult<SettingsAndGamesSaveError?>(null));

        var error = await _settingsAndGamesManager.SaveAsync();

        Assert.Null(error);
    }

    [Fact]
    public async Task Returns_error_when_no_settings_and_games_exist()
    {
        _fileSystemSettingsAndGamesServiceMock
            .LoadAsync()
            .Returns(Task.FromResult<Either<SettingsAndGamesLoadError, SettingsAndGames>>(new SettingsAndGamesLoadError("Error")));

        _officialGamesTemplateServiceMock
            .CreateOfficialGamesFromTemplate()
            .Returns(testOfficialGames);

        var result = await _settingsAndGamesManager.LoadAsync();

        Assert.NotNull(result);
    }

    [Fact]
    public async Task Returns_null_and_stores_loaded_settings_and_games_when_settings_and_games_exist()
    {
        _fileSystemSettingsAndGamesServiceMock
            .LoadAsync()
            .Returns(Task.FromResult<Either<SettingsAndGamesLoadError, SettingsAndGames>>(testSettingsAndGames));

        var result = await _settingsAndGamesManager.LoadAsync();

        Assert.Null(result);

        Assert.True(_settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch);

        Assert.NotNull(_settingsAndGamesManager.EmulatorSettings.FolderLocation);

        Assert.NotEmpty(_settingsAndGamesManager.OfficialGames);

        Assert.NotEmpty(_settingsAndGamesManager.FanGames);
    }
}
