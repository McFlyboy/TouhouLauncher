using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models;
using TouhouLauncher.Models.GameInfo;

namespace TouhouLauncher.ViewModels {
	public class GameConfigViewModel : ViewModelBase {
		private readonly GameConfigModel _gameConfig;

		public GameConfigViewModel(GameConfigModel gameConfigModel) {
			_gameConfig = gameConfigModel;

			BrowseCommand = new RelayCommand(() => {
				_gameConfig.Browse();
				RaisePropertyChanged("GameLocation");
			});

			OKCommand = new RelayCommand<Window>((Window window) => {
				_gameConfig.SaveGameConfig();
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

		public void LoadGameConfig(Game game) {
			_gameConfig.LoadGameConfig(game);
			RaisePropertyChanged("WindowTitle");
			RaisePropertyChanged("GameLocation");
		}
	}
}
