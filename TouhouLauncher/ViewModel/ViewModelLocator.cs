using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace TouhouLauncher.ViewModel {
	public class ViewModelLocator {
		static ViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<GameConfigViewModel>();
			SimpleIoc.Default.Register<HomeViewModel>();
			SimpleIoc.Default.Register<SettingsViewModel>();
		}
		
		public MainViewModel Main {
			get {
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}
		public GameConfigViewModel GameConfig {
			get {
				return ServiceLocator.Current.GetInstance<GameConfigViewModel>();
			}
		}
		public HomeViewModel Home {
			get {
				return ServiceLocator.Current.GetInstance<HomeViewModel>();
			}
		}
		public SettingsViewModel Settings {
			get {
				return ServiceLocator.Current.GetInstance<SettingsViewModel>();
			}
		}

		public static void Cleanup() {
			// TODO Clear the ViewModels
		}
	}
}
