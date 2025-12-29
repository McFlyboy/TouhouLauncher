using NSubstitute;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure.Persistence.FileSystem;

public class FileSystemSettingsAndGamesRepositoryTest
{
    private readonly FileAccessService _fileAccessServiceMock = Substitute.For<FileAccessService>();
    private readonly OfficialGamesTemplateService _officialGamesTemplateServiceMock = Substitute.For<OfficialGamesTemplateService>();

    private readonly FileSystemSettingsAndGamesRepository _fileSystemSettingsAndGamesRepository;

    public FileSystemSettingsAndGamesRepositoryTest()
    {
        _fileSystemSettingsAndGamesRepository = new(
            _fileAccessServiceMock,
            _officialGamesTemplateServiceMock
        );
    }

    [Fact]
    public async Task Saves_settings_and_games_to_file_system_async_and_returns_result()
    {
        _fileAccessServiceMock
            .WriteFileFromYamlAsync(Arg.Any<string>(), Arg.Any<SettingsAndGamesYaml>())
            .Returns(Task.FromResult<FileWriteError?>(null));

        var result = await _fileSystemSettingsAndGamesRepository.SaveAsync(testSettingsAndGames);

        Assert.Null(result);
    }

    [Fact]
    public async Task Loads_settings_and_games_from_file_system_async_and_returns_result()
    {
        _fileAccessServiceMock
            .ReadFileToYamlAsync<SettingsAndGamesYaml>(Arg.Any<string>())
            .Returns(Task.FromResult<Either<TouhouLauncherError, SettingsAndGamesYaml>>(testSettingsAndGamesYaml));

        _officialGamesTemplateServiceMock
            .CreateOfficialGamesFromTemplate()
            .Returns(testOfficialGames);

        var result = await _fileSystemSettingsAndGamesRepository.LoadAsync();

        Assert.True(result.IsRight);
        Assert.Equal(testSettingsAndGames.GeneralSettings, result.GetRight().GeneralSettings);
        Assert.Equal(testSettingsAndGames.EmulatorSettings, result.GetRight().EmulatorSettings);
        Assert.Equal(testSettingsAndGames.OfficialGames[0], result.GetRight().OfficialGames[0]);
        Assert.Equal(testSettingsAndGames.OfficialGames[1], result.GetRight().OfficialGames[1]);
        Assert.Equal(testSettingsAndGames.OfficialGames[2], result.GetRight().OfficialGames[2]);
        Assert.Equal(testSettingsAndGames.FanGames[0], result.GetRight().FanGames[0]);
        Assert.Equal(testSettingsAndGames.FanGames[1], result.GetRight().FanGames[1]);
    }
}
