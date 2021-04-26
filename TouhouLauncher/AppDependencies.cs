using GalaSoft.MvvmLight.Ioc;
using System;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using TouhouLauncher.Services.Infrastructure;
using TouhouLauncher.Services.Infrastructure.Serialization;
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
			dependencies.Register<SettingsManager>();
			dependencies.Register<GameConfig>();
			dependencies.Register<ActiveGameCategory>();
			dependencies.Register<GamePickerList>();

			/* ------ SERVICES ------ */
			dependencies.Register<ActivateGameService>();
			dependencies.Register<GameCategoryService>();
			dependencies.Register<OfficialGamesTemplateService>();
			dependencies.Register<FileBrowserService>();
			dependencies.Register<ISettingsService, FileSettingsService>();
			dependencies.Register<IFileSerializerService, YamlFileSerializerService>();
			dependencies.Register<LaunchRandomGameService>();
			dependencies.Register(() => new Random());
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
