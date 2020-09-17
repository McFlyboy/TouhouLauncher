using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Controls;
using System.Windows.Input;
using TouhouLauncher.View.UserControls;

namespace TouhouLauncher.ViewModel {
	public class SettingsViewModel : ViewModelBase {

		public UserControl DisplayedSettings {
			get {
				return _settingsCategoryControls[_categoryIndex];
			}
		}
		public ICommand BackCommand { get; }

		private readonly UserControl[] _settingsCategoryControls;
		private int _categoryIndex;
		private readonly INavigationService _navigationService;

		public SettingsViewModel(INavigationService navigationService) {
			_navigationService = navigationService;
			_settingsCategoryControls = new UserControl[] {
				new GameLocationsSettings()
			};
			_categoryIndex = 0;
			BackCommand = new RelayCommand(() => {
				_navigationService.NavigateTo("HomePage.xaml");
			});
		}
		private void SetCategoryIndex(int index) {
			_categoryIndex = index;
		}
	}
}
