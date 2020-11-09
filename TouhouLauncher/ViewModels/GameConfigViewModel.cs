using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Services.Application;

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
				_gameConfig.GameLocation = _fileBrowserService.BrowseFiles(
					"Executable files (*.exe)|*.exe|All files (*.*)|*.*"
				);
				RaisePropertyChanged("GameLocation");
			});

			OKCommand = new RelayCommand<Window>((Window window) => {
				_gameConfig.SaveGameLocation();
				window.Close();
			});

			CancelCommand = new RelayCommand<Window>((Window window) => {
				window.Close();
			});
		}

		public string WindowTitle => "Configure " + _gameConfig.GameTitle;

		public string GameLocation {
			get => _gameConfig.GameLocation;
			set => _gameConfig.GameLocation = value;
		}

		public ICommand BrowseCommand { get; }

		public ICommand OKCommand { get; }

		public ICommand CancelCommand { get; }
	}
}
