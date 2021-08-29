#nullable disable

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Views;

namespace TouhouLauncher.ViewModels {
	public class GamePickerViewModel : ViewModelBase {
		private readonly GamePickerList _gamePickerList;
		private readonly ActiveGameCategory _activeGameCategory;
		private readonly LaunchGameService _launchGameService;
		private readonly GameConfig _gameConfig;

		public GamePickerViewModel(
			GamePickerList gamePickerList,
			ActiveGameCategory activeGameCategory,
			LaunchGameService launchGameService,
			GameConfig gameConfig
		) {
			_gamePickerList = gamePickerList;
			_activeGameCategory = activeGameCategory;
			_launchGameService = launchGameService;
			_gameConfig = gameConfig;

			GameButtons = new ObservableCollection<GameButton>();

			UpdateGames();
		}

		public ObservableCollection<GameButton> GameButtons { get; }

		public void UpdateGames() {
			_gamePickerList.PopulateGameList(_activeGameCategory.CurrentCategory);
			CreateGameButtons(_gamePickerList.GameList);
		}

		private void CreateGameButtons(List<Game> games) {
			GameButtons.Clear();
			foreach (var game in games) {
				GameButtons.Add(
					new GameButton(game, _launchGameService, _gameConfig)
				);
			}
		}

		public class GameButton {
			private readonly LaunchGameService _launchGameService;
			private readonly GameConfig _gameConfig;
			private readonly Game _game;

			public GameButton(
				Game game,
				LaunchGameService launchGameService,
				GameConfig gameConfig
			) {
				_launchGameService = launchGameService;
				_gameConfig = gameConfig;
				_game = game;

				Command = new RelayCommand(() => {
					if (!_game.FileLocation.Equals(string.Empty)) {
						_ = _launchGameService.LaunchGame(_game);
					}
					else {
						_gameConfig.SetGameToConfigure(_game);
						new GameConfigWindow().ShowDialog();
					}
				});
			}

			public string Name => string.Join(":\n", _game.Title.Split(": "));

			public string Image => _game.ImageLocation;

			public string ReleaseYear => "Release: " + _game.ReleaseYear;

			public ICommand Command { get; }
		}
	}
}
