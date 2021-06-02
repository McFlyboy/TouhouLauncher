using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class GameConfigViewModel : ViewModelBase {
		private readonly GameConfig _gameConfig;
		private readonly FileBrowserService _fileBrowserService;

		public GameConfigViewModel(
			GameConfig gameConfig,
			FileBrowserService fileBrowserService
		) {
			_gameConfig = gameConfig;
			_fileBrowserService = fileBrowserService;

			BrowseCommand = new RelayCommand(() => {
				var browseResult = _fileBrowserService.BrowseFiles(
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
