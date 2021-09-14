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
			foreach (Game game in games) {
				GameButtons.Add(
					new GameButton(game, _launchGameService, _gameConfig)
				);
			}
		}

		public class GameButton {
			private readonly Game _game;
			private readonly LaunchGameService _launchGameService;
			private readonly GameConfig _gameConfig;

			public GameButton(
				Game game,
				LaunchGameService launchGameService,
				GameConfig gameConfig
			) {
				_game = game;
				_launchGameService = launchGameService;
				_gameConfig = gameConfig;

				Command = new RelayCommand(() => {
					if (!string.IsNullOrEmpty(_game.FileLocation)) {
						_launchGameService.LaunchGame(_game)
							.ContinueWith(async result => {
								var error = await result;

								if (error != null) {
									MessageBox.Show(error.Message, "Error");
								}
							});
					}
					else {
						_gameConfig.SetGameToConfigure(_game);
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
