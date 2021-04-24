using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
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
			set => ChangeCategory((SettingsCategory)value);
		}

		public UserControl CurrentSettingsCategory => _category switch {
			SettingsCategory.GeneralSettings => new GeneralSettings(),
			SettingsCategory.GameLocations => new GameLocationsSettings(),
			_ => throw new InvalidEnumArgumentException(),
		};

		public ICommand BackCommand { get; }

		private void ChangeCategory(SettingsCategory category) {
			_category = category;
			RaisePropertyChanged(nameof(CurrentSettingsCategory));
		}

		private enum SettingsCategory {
			GeneralSettings,
			GameLocations
		}
	}
}
