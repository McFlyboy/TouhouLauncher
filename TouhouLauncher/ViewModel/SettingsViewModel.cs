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

		private readonly MainViewModel _mainViewModel;
		private readonly UserControl[] _settingsCategoryControls;
		private int _categoryIndex;

		public SettingsViewModel(MainViewModel mainViewModel) {
			_mainViewModel = mainViewModel;
			_settingsCategoryControls = new UserControl[] {
				new GameLocationsSettings()
			};
			_categoryIndex = 0;
			BackCommand = new RelayCommand(() => {
				_mainViewModel.Page = "HomePage.xaml";
			});
		}
		private void SetCategoryIndex(int index) {
			_categoryIndex = index;
		}
	}
}
