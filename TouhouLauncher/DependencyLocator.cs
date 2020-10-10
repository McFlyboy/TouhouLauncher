using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using TouhouLauncher.Models;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Models.Settings;
using TouhouLauncher.Services.Serialization;
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

			/* ------ MODELS ------ */
			SimpleIoc.Default.Register<MainModel>();
			SimpleIoc.Default.Register<GameConfigModel>();
			SimpleIoc.Default.Register<HomeModel>();
			SimpleIoc.Default.Register<GameDB>();
			SimpleIoc.Default.Register<SettingsContainer>();

			/* ------ SERVICES ------ */
			SimpleIoc.Default.Register<IFileSerializerService, YamlFileSerializerService>();
			SimpleIoc.Default.Register<SettingsSerializerService>();
		}
		
		public MainViewModel MainVM =>
			ServiceLocator.Current.GetInstance<MainViewModel>();
		public GameConfigViewModel GameConfigVM =>
			ServiceLocator.Current.GetInstance<GameConfigViewModel>();
		public HomeViewModel HomeVM =>
			ServiceLocator.Current.GetInstance<HomeViewModel>();
		public SettingsViewModel SettingsVM =>
			ServiceLocator.Current.GetInstance<SettingsViewModel>();
	}
}
