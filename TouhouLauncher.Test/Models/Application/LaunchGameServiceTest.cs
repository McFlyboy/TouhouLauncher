using NSubstitute;
using System.Diagnostics;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.SettingsInfo;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Infrastructure.Execution.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Application;

public class LaunchGameServiceTest
{
    private readonly FileSystemExecutorService _fileSystemExecutorServiceMock = Substitute.For<FileSystemExecutorService>();
    private readonly SettingsAndGamesManager _settingsAndGamesManagerMock = Substitute.For<SettingsAndGamesManager>(null, null);
    private readonly FileSystemNp21ntConfigRepository _fileSystemNp21ntConfigRepository = Substitute.For<FileSystemNp21ntConfigRepository>(null, null, null);
    private readonly Np21ntConfigDefaultsService _np21ntConfigDefaultsServiceMock = Substitute.For<Np21ntConfigDefaultsService>();
    private readonly PathExistanceService _pathExistanceServiceMock = Substitute.For<PathExistanceService>();

    private readonly LaunchGameService _launchGameService;

    public LaunchGameServiceTest()
    {
        _launchGameService = new(
            _fileSystemExecutorServiceMock,
            _settingsAndGamesManagerMock,
            _fileSystemNp21ntConfigRepository,
            _np21ntConfigDefaultsServiceMock,
            _pathExistanceServiceMock
        );
    }

    [Fact]
    public async Task Returns_error_when_game_does_not_exist()
    {
        _pathExistanceServiceMock.PathExists(Arg.Any<string?>())
            .Returns(false);

        var error = await _launchGameService.LaunchGame(testOfficialGame1);

        Assert.NotNull(error);
        Assert.IsType<LaunchGameError.GameDoesNotExistError>(error);
    }

    [Fact]
    public async Task Returns_error_when_emulator_location_has_not_been_set()
    {
        _pathExistanceServiceMock.PathExists("C:\\test\\location2.exe")
            .Returns(true);

        _settingsAndGamesManagerMock.EmulatorSettings
            .Returns(new EmulatorSettings(null));

        var error = await _launchGameService.LaunchGame(testOfficialGame2);

        Assert.NotNull(error);
        Assert.IsType<LaunchGameError.EmulatorLocationNotSetError>(error);
    }

    [Fact]
    public async Task Returns_error_when_emulator_does_not_exist()
    {
        _pathExistanceServiceMock.PathExists("C:\\test\\location2.exe")
            .Returns(true);

        _settingsAndGamesManagerMock.EmulatorSettings
            .Returns(testEmulatorSettings);

        var error = await _launchGameService.LaunchGame(testOfficialGame2);

        Assert.NotNull(error);
        Assert.IsType<LaunchGameError.EmulatorDoesNotExistError>(error);
    }

    [Fact]
    public async Task Returns_error_when_unable_to_save_emulator_config()
    {
        _pathExistanceServiceMock.PathExists(Arg.Any<string?>())
            .Returns(true);

        _settingsAndGamesManagerMock.EmulatorSettings
            .Returns(testEmulatorSettings);

        _fileSystemNp21ntConfigRepository.LoadAsync()
            .Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(testNp21ntConfig));

        _fileSystemNp21ntConfigRepository.SaveAsync(Arg.Any<Np21ntConfig?>())
            .Returns(Task.FromResult<Np21ntConfigSaveError?>(new("error")));

        var error = await _launchGameService.LaunchGame(testOfficialGame2);

        Assert.NotNull(error);
        Assert.IsType<Np21ntConfigSaveError>(error);
    }

    [Fact]
    public async Task Returns_error_when_unable_to_execute_game()
    {
        _pathExistanceServiceMock.PathExists(Arg.Any<string?>())
            .Returns(true);

        _settingsAndGamesManagerMock.EmulatorSettings
            .Returns(testEmulatorSettings);

        _fileSystemExecutorServiceMock.StartExecutable(Arg.Any<string>())
            .Returns(new ExecutorServiceError.ProcessExecuteError("location"));

        var error = await _launchGameService.LaunchGame(testOfficialGame1);

        Assert.NotNull(error);
        Assert.IsType<ExecutorServiceError.ProcessExecuteError>(error);
    }

    [Fact]
    public async Task Returns_null_when_game_launches_successfully()
    {
        _pathExistanceServiceMock.PathExists(Arg.Any<string?>())
            .Returns(true);

        _settingsAndGamesManagerMock.EmulatorSettings
            .Returns(testEmulatorSettings);

        _fileSystemExecutorServiceMock.StartExecutable(Arg.Any<string>())
            .Returns(new Process());

        _settingsAndGamesManagerMock.GeneralSettings
            .Returns(testGeneralSettings with { CloseOnGameLaunch = false });

        var error = await _launchGameService.LaunchGame(testOfficialGame1);

        Assert.Null(error);

        _fileSystemExecutorServiceMock.Received(1).StartExecutable(Arg.Any<string>());
    }

    [Fact]
    public async Task Returns_null_when_emulator_game_launches_successfully()
    {
        _pathExistanceServiceMock.PathExists(Arg.Any<string?>())
            .Returns(true);

        _settingsAndGamesManagerMock.EmulatorSettings
            .Returns(testEmulatorSettings);

        _fileSystemNp21ntConfigRepository.LoadAsync()
            .Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(testNp21ntConfig));

        _fileSystemNp21ntConfigRepository.SaveAsync(Arg.Any<Np21ntConfig?>())
            .Returns(Task.FromResult<Np21ntConfigSaveError?>(null));

        _fileSystemExecutorServiceMock.StartExecutable(Arg.Any<string>())
            .Returns(new Process());

        _settingsAndGamesManagerMock.GeneralSettings
            .Returns(testGeneralSettings with { CloseOnGameLaunch = false });

        var error = await _launchGameService.LaunchGame(testOfficialGame2);

        Assert.Null(error);

        await _fileSystemNp21ntConfigRepository.Received(1).SaveAsync(Arg.Any<Np21ntConfig?>());
        _fileSystemExecutorServiceMock.Received(1).StartExecutable(Arg.Any<string>());
    }

    [Fact]
    public async Task Returns_null_when_emulator_game_launches_successfully_after_failing_to_load_emulator_config()
    {
        _pathExistanceServiceMock.PathExists(Arg.Any<string?>())
            .Returns(true);

        _settingsAndGamesManagerMock.EmulatorSettings
            .Returns(testEmulatorSettings);

        _fileSystemNp21ntConfigRepository.LoadAsync()
            .Returns(Task.FromResult<Either<Np21ntConfigLoadError, Np21ntConfig>>(new Np21ntConfigLoadError("error")));

        _np21ntConfigDefaultsServiceMock.CreateNp21ntConfigDefaults()
            .Returns(testNp21ntConfig);

        _fileSystemNp21ntConfigRepository.SaveAsync(Arg.Any<Np21ntConfig?>())
            .Returns(Task.FromResult<Np21ntConfigSaveError?>(null));

        _fileSystemExecutorServiceMock.StartExecutable(Arg.Any<string>())
            .Returns(new Process());

        _settingsAndGamesManagerMock.GeneralSettings
            .Returns(testGeneralSettings with { CloseOnGameLaunch = false });

        var error = await _launchGameService.LaunchGame(testOfficialGame2);

        Assert.Null(error);

        _np21ntConfigDefaultsServiceMock.Received(1).CreateNp21ntConfigDefaults();
        await _fileSystemNp21ntConfigRepository.Received(1).SaveAsync(Arg.Any<Np21ntConfig?>());
        _fileSystemExecutorServiceMock.Received(1).StartExecutable(Arg.Any<string>());
    }
}
