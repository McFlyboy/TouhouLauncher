using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;

namespace TouhouLauncher.ViewModels {
	public class GameLocationsSettingsViewModel : ViewModelBase {
		private readonly FileBrowserService _fileBrowserService;
		private readonly SettingsManager _settingsManager;

		public GameLocationsSettingsViewModel(
			FileBrowserService fileBrowserService,
			SettingsManager settingsManager
		) {
			_fileBrowserService = fileBrowserService;
			_settingsManager = settingsManager;

            GameLocations = new ObservableCollection<GameLocation>();

			foreach (var game in _settingsManager.OfficialGames) {
				GameLocations.Add(new(_fileBrowserService, _settingsManager, game));
            }
		}

        public ObservableCollection<GameLocation> GameLocations { get; }

		public class GameLocation : ObservableObject {
			private readonly FileBrowserService _fileBrowserService;
			private readonly SettingsManager _settingsManager;
			private readonly OfficialGame _game;

			public GameLocation(
				FileBrowserService fileBrowserService,
				SettingsManager settingsManager,
				OfficialGame game
			) {
				_fileBrowserService = fileBrowserService;
				_settingsManager = settingsManager;
				_game = game;

				BrowseCommand = new RelayCommand(() => {
					Location = BrowseForGame();
					RaisePropertyChanged(nameof(Location));
				});
			}

			public string Name => _game.FullTitle;

			public string Location {
				get => _game.FileLocation;
				set {
					_game.FileLocation = value;
					_settingsManager.Save();
				}
			}

			public ICommand BrowseCommand { get; }

			private string BrowseForGame() {
				return _fileBrowserService.BrowseFiles(
					new FileBrowserService.Filter(
						new FileBrowserService.Filter.FileType("Executable files", "*.exe"),
						new FileBrowserService.Filter.FileType("All files", "*.*")
					)
				);
			}
		}
	}
}
