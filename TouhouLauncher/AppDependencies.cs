using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Execution.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using TouhouLauncher.ViewModels;

namespace TouhouLauncher;

public class AppDependencies
{
    public AppDependencies()
    {
        ServiceProvider serviceProvider = new ServiceCollection()
            /* ------ VIEW MODELS ------ */
            .AddSingleton<MainViewModel>()
            .AddSingleton<GameConfigViewModel>()
            .AddSingleton<HomeViewModel>()
            .AddSingleton<GamePickerViewModel>()
            .AddSingleton<SettingsViewModel>()
            .AddSingleton<GeneralSettingsViewModel>()
            .AddSingleton<EmulatorSettingsViewModel>()
            .AddSingleton<GamesSettingsViewModel>()
            .AddSingleton<FanGameEditorViewModel>()

            /* ------ MODELS ------ */
            .AddSingleton<SettingsAndGamesManager>()
            .AddSingleton<GameConfigService>()
            .AddSingleton<ActiveGameCategory>()
            .AddSingleton<GamePickerList>()
            .AddSingleton<IExecutorService, FileSystemExecutorService>()
            .AddSingleton<GameCategoryService>()
            .AddSingleton<OfficialGamesTemplateService>()
            .AddSingleton<FileSystemBrowserService>()
            .AddSingleton<FileAccessService>()
            .AddSingleton<ISettingsAndGamesRepository, FileSystemSettingsAndGamesRepository>()
            .AddSingleton<LaunchGameService>()
            .AddSingleton<LaunchRandomGameService>()
            .AddSingleton<Random>()
            .AddSingleton<INp21ntConfigRepository, FileSystemNp21ntConfigRepository>()
            .AddSingleton<Np21ntConfigDefaultsService>()
            .AddSingleton<PathExistanceService>()
            .AddSingleton<FanGameEditingService>()
            .BuildServiceProvider();

        Ioc.Default.ConfigureServices(serviceProvider);
    }

    public MainViewModel MainVM =>
        Ioc.Default.GetRequiredService<MainViewModel>();

    public GameConfigViewModel GameConfigVM =>
        Ioc.Default.GetRequiredService<GameConfigViewModel>();

    public HomeViewModel HomeVM =>
        Ioc.Default.GetRequiredService<HomeViewModel>();

    public GamePickerViewModel GamePickerVM =>
        Ioc.Default.GetRequiredService<GamePickerViewModel>();

    public SettingsViewModel SettingsVM =>
        Ioc.Default.GetRequiredService<SettingsViewModel>();

    public GeneralSettingsViewModel GeneralSettingsVM =>
        Ioc.Default.GetRequiredService<GeneralSettingsViewModel>();

    public EmulatorSettingsViewModel EmulatorSettingsVM =>
        Ioc.Default.GetRequiredService<EmulatorSettingsViewModel>();

    public GamesSettingsViewModel GameLocationsSettingsVM =>
        Ioc.Default.GetRequiredService<GamesSettingsViewModel>();

    public FanGameEditorViewModel FanGameEditorVM =>
        Ioc.Default.GetRequiredService<FanGameEditorViewModel>();
}
