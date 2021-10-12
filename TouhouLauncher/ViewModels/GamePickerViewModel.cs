using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Views;

namespace TouhouLauncher.ViewModels {
	public class GamePickerViewModel : ViewModelBase {
		private readonly GamePickerList _gamePickerList;
		private readonly ActiveGameCategory _activeGameCategory;
		private readonly LaunchGameService _launchGameService;
		private readonly GameConfigService _gameConfigService;

		public GamePickerViewModel(
			GamePickerList gamePickerList,
			ActiveGameCategory activeGameCategory,
			LaunchGameService launchGameService,
			GameConfigService gameConfigService
		) {
			_gamePickerList = gamePickerList;
			_activeGameCategory = activeGameCategory;
			_launchGameService = launchGameService;
			_gameConfigService = gameConfigService;

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
			foreach (Game game in games) {
				GameButtons.Add(
					new GameButton(game, _launchGameService, _gameConfigService)
				);
			}
		}

		public class GameButton {
			private readonly Game _game;
			private readonly LaunchGameService _launchGameService;
			private readonly GameConfigService _gameConfigService;

			public GameButton(
				Game game,
				LaunchGameService launchGameService,
				GameConfigService gameConfigService
			) {
				_game = game;
				_launchGameService = launchGameService;
				_gameConfigService = gameConfigService;

				Command = new RelayCommand(async () => {
					if (!string.IsNullOrEmpty(_game.FileLocation)) {
						var error = await _launchGameService.LaunchGame(_game);

						if (error != null) {
							MessageBox.Show(error.Message, "Error");
						}
					}
					else {
						_gameConfigService.SetGameToConfigure(_game);
						new GameConfigWindow().ShowDialog();
					}
				});
			}

			public string Name => string.Join(":\n", _game.Title.Split(": "));

			public string Image => _game.ImageLocation ?? string.Empty;

			public string ReleaseYear => _game.ReleaseYear
				?.Transform(releaseYear => $"Release: {releaseYear}")
				?? string.Empty;

			public ICommand Command { get; }
		}
	}
}
