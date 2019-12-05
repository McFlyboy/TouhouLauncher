using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace TouhouLauncher.ViewModel {
	public class ViewModelLocator {
		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<MainViewModel>();
		}
		
		public MainViewModel Main {
			get {
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}
		
		public static void Cleanup() {
			// TODO Clear the ViewModels
		}
	}
}
