using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class EmulatorSettingsViewModel : ViewModelBase {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;
		private readonly FileSystemBrowserService _fileSystemBrowserService;

		public EmulatorSettingsViewModel(
			SettingsAndGamesManager settingsAndGamesManager,
			FileSystemBrowserService fileSystemBrowserService
		) {
			_settingsAndGamesManager = settingsAndGamesManager;
			_fileSystemBrowserService = fileSystemBrowserService;

			BrowseCommand = new RelayCommand(() => {
				var result = _fileSystemBrowserService.BrowseFolders();

				if (result == null) {
					return;
				}

				FolderLocation = result;
				RaisePropertyChanged(nameof(FolderLocation));
			});
		}

		public string FolderLocation {
			get => _settingsAndGamesManager.EmulatorSettings.FolderLocation ?? string.Empty;
			set {
				_settingsAndGamesManager.EmulatorSettings.FolderLocation = value;
				_settingsAndGamesManager.SaveAsync()
					.ContinueWith(async result => {
						var error = await result;

						if (error != null) {
							MessageBox.Show(error.Message, "Error");
						}
					});
			}
		}

		public ICommand BrowseCommand { get; }
	}
}
