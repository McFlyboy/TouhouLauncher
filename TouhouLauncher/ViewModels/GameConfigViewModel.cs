using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class GameConfigViewModel : ViewModelBase {
		private readonly GameConfig _gameConfig;
		private readonly FileSystemBrowserService _fileSystemBrowserService;

		public GameConfigViewModel(
			GameConfig gameConfig,
			FileSystemBrowserService fileSystemBrowserService
		) {
			_gameConfig = gameConfig;
			_fileSystemBrowserService = fileSystemBrowserService;

			BrowseCommand = new RelayCommand(() => {
				var browseResult = _fileSystemBrowserService.BrowseFiles(
					new("Executable files", "*.exe"),
					new("All files", "*.*")
				);

				if (browseResult == null) {
					return;
				}

				GameLocation = browseResult;
				RaisePropertyChanged(nameof(GameLocation));
			});

			OkCommand = new RelayCommand<Window>(async window => {
				bool success = await _gameConfig.SaveAsync();

				if (!success) {
					return;
				}

				window.Close();
			});

			CancelCommand = new RelayCommand<Window>(window => {
				window.Close();
			});
		}

		public string WindowTitle => $"Configure {_gameConfig.TargetGame.Title}";

		public string GameLocation {
			get => _gameConfig.GameLocation;
			set => _gameConfig.GameLocation = value;
		}

		public ICommand BrowseCommand { get; }

		public ICommand OkCommand { get; }

		public ICommand CancelCommand { get; }
	}
}
