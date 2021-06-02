using GalaSoft.MvvmLight.Ioc;
using System;
using TouhouLauncher.Models.Application;
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
			dependencies.Register<GameLocationsSettingsViewModel>();

			/* ------ MODELS ------ */
			dependencies.Register<SettingsAndGamesManager>();
			dependencies.Register<GameConfig>();
			dependencies.Register<ActiveGameCategory>();
			dependencies.Register<GamePickerList>();
			dependencies.Register<LaunchGameService>();
			dependencies.Register<GameCategoryService>();
			dependencies.Register<OfficialGamesTemplateService>();
			dependencies.Register<FileBrowserService>();
			dependencies.Register<FileAccessService>();
			dependencies.Register<ISettingsAndGamesService, FileSystemSettingsAndGamesService>();
			dependencies.Register<LaunchRandomGameService>();
			dependencies.Register<Random>(() => new());
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

		public GameLocationsSettingsViewModel GameLocationsSettingsVM =>
			dependencies.GetInstance<GameLocationsSettingsViewModel>();
	}
}
