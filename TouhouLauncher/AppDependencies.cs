using GalaSoft.MvvmLight.Ioc;
using System;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Infrastructure.Execution.FileSystem;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using TouhouLauncher.ViewModels;

namespace TouhouLauncher {
	public class AppDependencies {
		private readonly SimpleIoc dependencies;

		public AppDependencies() {
			dependencies = SimpleIoc.Default;

			/* ------ VIEW MODELS ------ */
			dependencies.Register<MainViewModel>();
			dependencies.Register<GameConfigViewModel>();
			dependencies.Register<HomeViewModel>();
			dependencies.Register<GamePickerViewModel>();
			dependencies.Register<SettingsViewModel>();
			dependencies.Register<GeneralSettingsViewModel>();
			dependencies.Register<EmulatorSettingsViewModel>();
			dependencies.Register<GameLocationsSettingsViewModel>();

			/* ------ MODELS ------ */
			dependencies.Register<SettingsAndGamesManager>();
			dependencies.Register<GameConfig>();
			dependencies.Register<ActiveGameCategory>();
			dependencies.Register<GamePickerList>();
			dependencies.Register<IExecutorService, FileSystemExecutorService>();
			dependencies.Register<GameCategoryService>();
			dependencies.Register<OfficialGamesTemplateService>();
			dependencies.Register<FileSystemBrowserService>();
			dependencies.Register<FileAccessService>();
			dependencies.Register<ISettingsAndGamesRepository, FileSystemSettingsAndGamesRepository>();
			dependencies.Register<LaunchGameService>();
			dependencies.Register<LaunchRandomGameService>();
			dependencies.Register<Random>(() => new());
			dependencies.Register<INp21ntConfigRepository, FileSystemNp21ntConfigRepository>();
			dependencies.Register<Np21ntConfigDefaultsService>();
			dependencies.Register<PathExistanceService>();
		}

		public MainViewModel MainVM =>
			dependencies.GetInstance<MainViewModel>();

		public GameConfigViewModel GameConfigVM =>
			dependencies.GetInstance<GameConfigViewModel>();

		public HomeViewModel HomeVM =>
			dependencies.GetInstance<HomeViewModel>();

		public GamePickerViewModel GamePickerVM =>
			dependencies.GetInstance<GamePickerViewModel>();

		public SettingsViewModel SettingsVM =>
			dependencies.GetInstance<SettingsViewModel>();

		public GeneralSettingsViewModel GeneralSettingsVM =>
			dependencies.GetInstance<GeneralSettingsViewModel>();

		public EmulatorSettingsViewModel EmulatorSettingsVM =>
			dependencies.GetInstance<EmulatorSettingsViewModel>();

		public GameLocationsSettingsViewModel GameLocationsSettingsVM =>
			dependencies.GetInstance<GameLocationsSettingsViewModel>();
	}
}
