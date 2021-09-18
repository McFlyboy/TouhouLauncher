using GalaSoft.MvvmLight;
using System.Windows;
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
				SaveSettings();
			}
		}

		public bool CombineMainCategoriesChecked {
			get => _settingsAndGamesManager.GeneralSettings.CombineMainCategories;
			set {
				_settingsAndGamesManager.GeneralSettings.CombineMainCategories = value;
				SaveSettings();

				MessengerInstance.Send<object?>(null, HomeViewModel.RebuildHeadersMessageToken);
			}
		}

		private void SaveSettings() {
			_settingsAndGamesManager.SaveAsync()
				.ContinueWith(async result => {
					var error = await result;

					if (error != null) {
						MessageBox.Show(error.Message, "Error");
					}
				});
		}
	}
}
