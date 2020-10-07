using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using TouhouLauncher.ViewModel;

namespace TouhouLauncher.Services {
	public class WpfNavigationService : INavigationService {
		private readonly MainViewModel _mainViewModel;
		private string _previousPageKey;

		public WpfNavigationService(MainViewModel mainViewModel) {
			_mainViewModel = mainViewModel;
			_previousPageKey = mainViewModel.Page;
		}

		public string CurrentPageKey => _mainViewModel.Page;

		public void GoBack() {
			_mainViewModel.Page = _previousPageKey;
		}

		public void NavigateTo(string pageKey) {
			_previousPageKey = _mainViewModel.Page;
			_mainViewModel.Page = pageKey;
		}

		public void NavigateTo(string pageKey, object parameter) {
			throw new System.NotImplementedException();
		}
	}
}
