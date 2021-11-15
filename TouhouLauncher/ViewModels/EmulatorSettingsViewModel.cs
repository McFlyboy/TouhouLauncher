using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
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

			ExternalLinkToEmulatorDownloadCommand = new RelayCommand(
				() => Process.Start(
					new ProcessStartInfo(
						"cmd",
						"/c start https://moriyashrine.org/files/file/387-pc-98-emulator-~-neko-project-ii/"
					) {
						CreateNoWindow = true
					}
				)
			);

			BrowseCommand = new RelayCommand(() => {
				var result = _fileSystemBrowserService.BrowseFolders("Select emulator folder");

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

		public ICommand ExternalLinkToEmulatorDownloadCommand { get; }

		public ICommand BrowseCommand { get; }
	}
}
