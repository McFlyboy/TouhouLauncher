using GalaSoft.MvvmLight.Ioc;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using TouhouLauncher.Services.Infrastructure;
using TouhouLauncher.Services.Infrastructure.Serialization;
using TouhouLauncher.ViewModels;

namespace TouhouLauncher {
	public class DependencyLocator {
		public DependencyLocator() {

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
			SimpleIoc.Default.GetInstance<MainViewModel>();

		public GameConfigViewModel GameConfigVM =>
			SimpleIoc.Default.GetInstance<GameConfigViewModel>();

		public HomeViewModel HomeVM =>
			SimpleIoc.Default.GetInstance<HomeViewModel>();

		public SettingsViewModel SettingsVM =>
			SimpleIoc.Default.GetInstance<SettingsViewModel>();

		public GamePickerViewModel GamePickerVM =>
			SimpleIoc.Default.GetInstance<GamePickerViewModel>();
	}
}
