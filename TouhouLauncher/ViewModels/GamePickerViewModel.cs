using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Services;

namespace TouhouLauncher.ViewModels {
	public class GamePickerViewModel : ViewModelBase {
		private readonly GamePickerList _gamePickerList;
		private readonly ActiveGameCategory _activeGameCategory;
		private readonly ActivateGameService _activateGameService;

		public GamePickerViewModel(
			GamePickerList gamePickerList,
			ActiveGameCategory activeGameCategory,
			ActivateGameService activateGameService
		) {
			_gamePickerList = gamePickerList;
			_activeGameCategory = activeGameCategory;
			_activateGameService = activateGameService;

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
					new GameButton(game, _activateGameService)
				);
			}
		}

		public class GameButton {
			private readonly ActivateGameService _activateGameService;
			private readonly Game _game;

			public GameButton(
				Game game,
				ActivateGameService activateGameService
			) {
				_activateGameService = activateGameService;
				_game = game;

				Command = new RelayCommand(() => {
					_activateGameService.ActivateGame(_game);
				});
			}

			public string Name =>
				_game.Title + (!_game.Subtitle.Equals(string.Empty) ? ":\n" : string.Empty) + _game.Subtitle;

			public string Image => _game.ImageLocation;

			public string ReleaseYear => "Release: " + _game.ReleaseYear;

			public ICommand Command { get; }
		}
	}
}
