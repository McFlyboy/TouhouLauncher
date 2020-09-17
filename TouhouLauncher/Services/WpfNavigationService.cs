using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using TouhouLauncher.ViewModel;

namespace TouhouLauncher.Services {
	public class WpfNavigationService : INavigationService {
		public string CurrentPageKey => throw new System.NotImplementedException();

		public void GoBack() {
			throw new System.NotImplementedException();
		}

		public void NavigateTo(string pageKey) {
			ServiceLocator.Current.GetInstance<MainViewModel>().Page = pageKey;
		}

		public void NavigateTo(string pageKey, object parameter) {
			throw new System.NotImplementedException();
		}
	}
}
