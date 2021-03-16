using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
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

			//GameLocations = new ObservableCollection<GameLocation>() {
			//	new(_fileBrowserService) { Name = "Game 1", Location = string.Empty },
			//	new(_fileBrowserService) { Name = "Game 2", Location = string.Empty }
			//};

			var test = _settingsManager
				.OfficialGames
				.Select(
					(game) =>
						new GameLocation(_fileBrowserService) {
							Name = game.FullTitle,
							Location = game.FileLocation
						}
				);
		}

		public ObservableCollection<GameLocation> GameLocations { get; }

		public class GameLocation : ObservableObject {
			private readonly FileBrowserService _fileBrowserService;

			public GameLocation(FileBrowserService fileBrowserService) {
				_fileBrowserService = fileBrowserService;

				BrowseCommand = new RelayCommand(() => {
					Location = BrowseForGame();
					RaisePropertyChanged(nameof(Location));
				});
			}

			public string Name { get; init; }

			public string Location { get; set; }

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
