﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class GameLocationsSettingsViewModel : ViewModelBase {
		private readonly FileSystemBrowserService _fileSystemBrowserService;
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public GameLocationsSettingsViewModel(
			FileSystemBrowserService fileSystemBrowserService,
			SettingsAndGamesManager settingsAndGamesManager
		) {
			_fileSystemBrowserService = fileSystemBrowserService;
			_settingsAndGamesManager = settingsAndGamesManager;

			GameLocations = new ObservableCollection<GameLocation>();

			foreach (var game in _settingsAndGamesManager.OfficialGames) {
				GameLocations.Add(new(_fileSystemBrowserService, _settingsAndGamesManager, game));
			}
		}

		public ObservableCollection<GameLocation> GameLocations { get; }

		public class GameLocation : ObservableObject {
			private readonly FileSystemBrowserService _fileSystemBrowserService;
			private readonly SettingsAndGamesManager _settingsAndGamesManager;
			private readonly OfficialGame _game;

			public GameLocation(
				FileSystemBrowserService fileSystemBrowserService,
				SettingsAndGamesManager settingsAndGamesManager,
				OfficialGame game
			) {
				_fileSystemBrowserService = fileSystemBrowserService;
				_settingsAndGamesManager = settingsAndGamesManager;
				_game = game;

				BrowseCommand = new RelayCommand(() => {
					var browseResult = BrowseForGame();

					if (browseResult == null) {
						return;
					}

					Location = browseResult;
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

			private string BrowseForGame() =>
				_game.Categories.HasFlag(GameCategories.MainPC98)
					? _fileSystemBrowserService.BrowseFiles(
						new("Hard disk image files", "*.hdi", "*.t98"),
						new("All files", "*.*")
					)
					: _fileSystemBrowserService.BrowseFiles(
						new("Executable files", "*.exe"),
						new("All files", "*.*")
					);
		}
	}
}
