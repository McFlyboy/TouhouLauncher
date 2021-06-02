using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class GameLocationsSettingsViewModel : ViewModelBase {
		private readonly FileBrowserService _fileBrowserService;
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public GameLocationsSettingsViewModel(
			FileBrowserService fileBrowserService,
			SettingsAndGamesManager settingsAndGamesManager
		) {
			_fileBrowserService = fileBrowserService;
			_settingsAndGamesManager = settingsAndGamesManager;

            GameLocations = new ObservableCollection<GameLocation>();

			foreach (var game in _settingsAndGamesManager.OfficialGames) {
				GameLocations.Add(new(_fileBrowserService, _settingsAndGamesManager, game));
            }
		}

        public ObservableCollection<GameLocation> GameLocations { get; }

		public class GameLocation : ObservableObject {
			private readonly FileBrowserService _fileBrowserService;
			private readonly SettingsAndGamesManager _settingsAndGamesManager;
			private readonly OfficialGame _game;

			public GameLocation(
				FileBrowserService fileBrowserService,
				SettingsAndGamesManager settingsAndGamesManager,
				OfficialGame game
			) {
				_fileBrowserService = fileBrowserService;
				_settingsAndGamesManager = settingsAndGamesManager;
				_game = game;

				BrowseCommand = new RelayCommand(() => {
					Location = BrowseForGame();
					RaisePropertyChanged(nameof(Location));
				});
			}

			public string Name => _game.Title;

			public string Location {
				get => _game.FileLocation;
				set {
					_game.FileLocation = value;
					_ = _settingsAndGamesManager.SaveAsync();
				}
			}

			public ICommand BrowseCommand { get; }

			private string BrowseForGame() {
				return _fileBrowserService.BrowseFiles(
					new("Executable files", "*.exe"),
					new("All files", "*.*")
				);
			}
		}
	}
}
