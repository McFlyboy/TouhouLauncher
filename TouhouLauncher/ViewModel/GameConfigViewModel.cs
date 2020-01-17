using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Model;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.ViewModel {
	public class GameConfigViewModel : ViewModelBase {
		public string WindowTitle {
			get {
				return "Configure " + _gameConfig.GameTitle;
			}
		}
		public string GameLocation {
			get {
				return _gameConfig.GameLocation;
			}
			set {
				_gameConfig.GameLocation = value;
			}
		}
		public ICommand BrowseCommand { get; }
		public ICommand OKCommand { get; }
		public ICommand CancelCommand { get; }

		private readonly GameConfigModel _gameConfig;
		public GameConfigViewModel() {
			_gameConfig = new GameConfigModel();
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
		public void LoadGameConfig(Game game) {
			_gameConfig.LoadGameConfig(game);
			RaisePropertyChanged("WindowTitle");
			RaisePropertyChanged("GameLocation");
		}
	}
}
