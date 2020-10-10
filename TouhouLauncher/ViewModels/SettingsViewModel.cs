using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Input;
using TouhouLauncher.Views.UserControls;

namespace TouhouLauncher.ViewModels {
	public class SettingsViewModel : ViewModelBase {
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

		public UserControl DisplayedSettings => _settingsCategoryControls[_categoryIndex];
		public ICommand BackCommand { get; }
	}
}
