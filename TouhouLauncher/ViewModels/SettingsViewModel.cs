using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Input;
using TouhouLauncher.Views.UserControls.Settings;

namespace TouhouLauncher.ViewModels {
	public class SettingsViewModel : ViewModelBase {
		private SettingsCategory _category;

		public SettingsViewModel() {
			_category = SettingsCategory.GeneralSettings;

			BackCommand = new RelayCommand(() => {
				MessengerInstance.Send("HomePage.xaml", MainViewModel.ChangePageMessageToken);
			});
		}

		public int CurrentSettingsCategoryIndex {
			get => (int)_category;
			set {
				_category = (SettingsCategory)value;
				RaisePropertyChanged(nameof(CurrentSettingsCategory));
			}
		}

		public UserControl CurrentSettingsCategory => _category switch {
			SettingsCategory.GeneralSettings => new GeneralSettings(),
			SettingsCategory.EmulatorSettings => new EmulatorSettings(),
			SettingsCategory.GameLocations => new GameLocationsSettings(),
			_ => new UserControl(),
		};

		public ICommand BackCommand { get; }

		private enum SettingsCategory {
			GeneralSettings,
			EmulatorSettings,
			GameLocations
		}
	}
}
