using GalaSoft.MvvmLight;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.ViewModels {
	public class GeneralSettingsViewModel : ViewModelBase {
		private readonly SettingsManager _settingsManager;

		public GeneralSettingsViewModel(SettingsManager settingsManager) {
			_settingsManager = settingsManager;
		}

		public bool CloseOnGameLaunchChecked {
			get => _settingsManager.GeneralSettings.CloseOnGameLaunch;
			set {
				_settingsManager.GeneralSettings.CloseOnGameLaunch = value;
				_settingsManager.Save();
			}
		}

		public bool CombineMainCategoriesChecked {
			get => _settingsManager.GeneralSettings.CombineMainCategories;
			set {
				_settingsManager.GeneralSettings.CombineMainCategories = value;
				_settingsManager.Save();

				MessengerInstance.Send<object>(null, HomeViewModel.RebuildHeadersMessageToken);
			}
		}
	}
}
