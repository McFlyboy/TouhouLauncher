using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.ViewModels {
	public class GameConfigViewModel : ViewModelBase {
		private readonly GameConfig _gameConfig;

		public GameConfigViewModel(GameConfig gameConfig) {
			_gameConfig = gameConfig;

			BrowseCommand = new RelayCommand(() => {
				_gameConfig.Browse();
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
