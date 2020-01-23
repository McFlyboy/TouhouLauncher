using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace TouhouLauncher.ViewModel {
	public class ViewModelLocator {
		public ViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<GameConfigViewModel>();
			SimpleIoc.Default.Register<HomePageViewModel>();
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
		public HomePageViewModel HomePage {
			get {
				return ServiceLocator.Current.GetInstance<HomePageViewModel>();
			}
		}

		public static void Cleanup() {
			// TODO Clear the ViewModels
		}
	}
}
