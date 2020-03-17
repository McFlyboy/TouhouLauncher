using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Input;
using TouhouLauncher.Model;
using TouhouLauncher.View.UserControls;

namespace TouhouLauncher.ViewModel {
	public class SettingsViewModel : ViewModelBase {

		public UserControl DisplayedSettings {
			get {
				return _settingsCategoryControls[_categoryIndex];
			}
		}
		public ICommand BackCommand { get; }

		private readonly SettingsModel _settingsModel;
		private readonly UserControl[] _settingsCategoryControls;
		private int _categoryIndex;
		public SettingsViewModel() {
			_settingsModel = new SettingsModel();
			_settingsCategoryControls = new UserControl[] {
				new GameLocationsSettings()
			};
			_categoryIndex = 0;
			BackCommand = new RelayCommand(_settingsModel.CloseSettings);
		}
		private void SetCategoryIndex(int index) {
			_categoryIndex = index;
		}
	}
}
