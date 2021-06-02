using GalaSoft.MvvmLight;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class GeneralSettingsViewModel : ViewModelBase {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public GeneralSettingsViewModel(SettingsAndGamesManager settingsAndGamesManager) {
			_settingsAndGamesManager = settingsAndGamesManager;
		}

		public bool CloseOnGameLaunchChecked {
			get => _settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch;
			set {
				_settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch = value;
				_ = _settingsAndGamesManager.SaveAsync();
			}
		}

		public bool CombineMainCategoriesChecked {
			get => _settingsAndGamesManager.GeneralSettings.CombineMainCategories;
			set {
				_settingsAndGamesManager.GeneralSettings.CombineMainCategories = value;
				_ = _settingsAndGamesManager.SaveAsync();

				MessengerInstance.Send<object>(null, HomeViewModel.RebuildHeadersMessageToken);
			}
		}
	}
}
