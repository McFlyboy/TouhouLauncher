using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Model;

namespace TouhouLauncher.ViewModel {
	public class SettingsViewModel : ViewModelBase {
		public ObservableCollection<SettingsCategory> SettingCategories { get; set; }
		public ICommand BackCommand { get; }

		private readonly SettingsModel _settingsModel;
		public SettingsViewModel() {
			_settingsModel = new SettingsModel();
			SettingCategories = new ObservableCollection<SettingsCategory>();
			SettingCategories.Add(new SettingsCategory("Settings page 1"));
			SettingCategories.Add(new SettingsCategory("Settings page 2"));
			SettingCategories.Add(new SettingsCategory("Settings page 3"));
			SettingCategories.Add(new SettingsCategory("Settings page 4"));
			SettingCategories.Add(new SettingsCategory("Settings page 5"));
			BackCommand = new RelayCommand(() => {
				_settingsModel.CloseSettings();
			});
		}
		public class SettingsCategory {
			public string CategoryName { get; set; }
			public SettingsCategory(string categoryName) {
				CategoryName = categoryName;
			}
		}
	}
}
