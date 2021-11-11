using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.ViewModels {
	public class GameConfigViewModel : ViewModelBase {
		private readonly GameConfigService _gameConfigService;
		private readonly FileSystemBrowserService _fileSystemBrowserService;

		public GameConfigViewModel(
			GameConfigService gameConfigService,
			FileSystemBrowserService fileSystemBrowserService
		) {
			_gameConfigService = gameConfigService;
			_fileSystemBrowserService = fileSystemBrowserService;

			BrowseCommand = new RelayCommand(() => {
				if (_gameConfigService.TargetGame == null) {
					return;
				} 

				var browseResult = _gameConfigService.TargetGame.Categories.HasFlag(GameCategories.MainPC98)
					? _fileSystemBrowserService.BrowseFiles(
						"Select game",
						new("Hard disk image files", "*.hdi", "*.t98"),
						new("All files", "*.*")
					)
					: _fileSystemBrowserService.BrowseFiles(
						"Select game",
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
				var error = await _gameConfigService.SaveAsync();

				if (error != null) {
					MessageBox.Show(error.Message, "Error");
					return;
				}

				window.Close();
			});

			CancelCommand = new RelayCommand<Window>(window => {
				window.Close();
			});
		}

		public string WindowTitle => $"Configure {_gameConfigService.TargetGame?.Title ?? "unknown game"}";

		public string GameLocation {
			get => _gameConfigService.GameLocation;
			set => _gameConfigService.GameLocation = value;
		}

		public ICommand BrowseCommand { get; }

		public ICommand OkCommand { get; }

		public ICommand CancelCommand { get; }
	}
}
