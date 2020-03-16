using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using TouhouLauncher.Model;

namespace TouhouLauncher.ViewModel {
	public class SettingsViewModel : ViewModelBase {
		public ICommand BackCommand { get; }

		private readonly SettingsModel _settingsModel;
		public SettingsViewModel() {
			_settingsModel = new SettingsModel();
			BackCommand = new RelayCommand(_settingsModel.CloseSettings);
		}
	}
}
