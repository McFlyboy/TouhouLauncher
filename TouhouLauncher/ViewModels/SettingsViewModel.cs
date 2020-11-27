using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using TouhouLauncher.Views.UserControls.Settings;

namespace TouhouLauncher.ViewModels {
	public class SettingsViewModel : ViewModelBase {
		private readonly MainViewModel _mainViewModel;

		private SettingsCategory _category;

		public SettingsViewModel(MainViewModel mainViewModel) {
			_mainViewModel = mainViewModel;

			_category = SettingsCategory.General;

			SetCategoryToGeneralCommand = new RelayCommand(() => {
				ChangeCategory(SettingsCategory.General);
			});

			SetCategoryToGameLocationsCommand = new RelayCommand(() => {
				ChangeCategory(SettingsCategory.GameLocations);
			});

			BackCommand = new RelayCommand(() => {
				_mainViewModel.Page = "HomePage.xaml";
			});
		}

		public UserControl CurrentSettingsCategory => _category switch {
			SettingsCategory.General => new GeneralSettings(),
			SettingsCategory.GameLocations => new GameLocationsSettings(),
			_ => throw new InvalidEnumArgumentException(),
		};

		public ICommand SetCategoryToGeneralCommand { get; }

		public ICommand SetCategoryToGameLocationsCommand { get; }

		public ICommand BackCommand { get; }

		private void ChangeCategory(SettingsCategory category) {
			_category = category;
			RaisePropertyChanged(nameof(CurrentSettingsCategory));
		}

		private enum SettingsCategory {
			General,
			GameLocations
		}
	}
}
