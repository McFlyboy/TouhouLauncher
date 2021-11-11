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
		private readonly FanGameEditingService _fanGameEditingService;

		public GamePickerViewModel(
			GamePickerList gamePickerList,
			ActiveGameCategory activeGameCategory,
			LaunchGameService launchGameService,
			GameConfigService gameConfigService,
			FanGameEditingService fanGameEditingService
		) {
			_gamePickerList = gamePickerList;
			_activeGameCategory = activeGameCategory;
			_launchGameService = launchGameService;
			_gameConfigService = gameConfigService;
			_fanGameEditingService = fanGameEditingService;

			MessengerInstance.Register<object?>(this, UpdateGamesToken, _ => UpdateGames());

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
					new GameButton(game, this, _launchGameService, _gameConfigService, _fanGameEditingService)
				);
			}
		}

		public static object UpdateGamesToken { get; } = new();

		public class GameButton {
			private readonly Game _game;
			private readonly GamePickerViewModel _parent;
			private readonly LaunchGameService _launchGameService;
			private readonly GameConfigService _gameConfigService;
			private readonly FanGameEditingService _fanGameEditingService;

			public GameButton(
				Game game,
				GamePickerViewModel parent,
				LaunchGameService launchGameService,
				GameConfigService gameConfigService,
				FanGameEditingService fanGameEditingService
			) {
				_game = game;
				_parent = parent;
				_launchGameService = launchGameService;
				_gameConfigService = gameConfigService;
				_fanGameEditingService = fanGameEditingService;

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

				EditCommand = new RelayCommand(() => {
					_fanGameEditingService.SetFanGameToEdit((FanGame)_game);

					_parent.MessengerInstance.Send("FanGameEditorPage.xaml", MainViewModel.ChangePageMessageToken);
				});
			}

			public string Name => string.Join(":\n", _game.Title.Split(": "));

			public string Image => _game.ImageLocation ?? string.Empty;

			public string ReleaseYear => _game.ReleaseYear
				?.Transform(releaseYear => $"Release: {releaseYear}")
				?? string.Empty;

			public Visibility ShowEditButton => _game.Categories.HasFlag(GameCategories.FanGame)
				? Visibility.Visible
				: Visibility.Hidden;

			public ICommand Command { get; }

			public ICommand EditCommand { get; }
		}
	}
}
