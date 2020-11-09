using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using TouhouLauncher.Services.Infrastructure;
using TouhouLauncher.Services.Infrastructure.Serialization;
using TouhouLauncher.ViewModels;

namespace TouhouLauncher {
	public class DependencyLocator {
		static DependencyLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			/* ------ VIEW MODELS ------ */
			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<GameConfigViewModel>();
			SimpleIoc.Default.Register<HomeViewModel>();
			SimpleIoc.Default.Register<SettingsViewModel>();
			SimpleIoc.Default.Register<GamePickerViewModel>();

			/* ------ MODELS ------ */
			SimpleIoc.Default.Register<SettingsManager>();
			SimpleIoc.Default.Register<GameConfig>();
			SimpleIoc.Default.Register<ActiveGameCategory>();
			SimpleIoc.Default.Register<GamePickerList>();

			/* ------ SERVICES ------ */
			SimpleIoc.Default.Register<ActivateGameService>();
			SimpleIoc.Default.Register<GameCategoryService>();
			SimpleIoc.Default.Register<OfficialGamesTemplateService>();
			SimpleIoc.Default.Register<FileBrowserService>();
			SimpleIoc.Default.Register<ISettingsService, FileSettingsService>();
			SimpleIoc.Default.Register<IFileSerializerService, YamlFileSerializerService>();
		}
		
		public MainViewModel MainVM =>
			ServiceLocator.Current.GetInstance<MainViewModel>();
		public GameConfigViewModel GameConfigVM =>
			ServiceLocator.Current.GetInstance<GameConfigViewModel>();
		public HomeViewModel HomeVM =>
			ServiceLocator.Current.GetInstance<HomeViewModel>();
		public SettingsViewModel SettingsVM =>
			ServiceLocator.Current.GetInstance<SettingsViewModel>();
		public GamePickerViewModel GamePickerVM =>
			ServiceLocator.Current.GetInstance<GamePickerViewModel>();
	}
}
