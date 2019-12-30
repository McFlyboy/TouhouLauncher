using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Model;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.ViewModel {
	public class MainViewModel : ViewModelBase {
		public ObservableCollection<CategoryButton> CategoryList { get; }
		public string CategoryPadding {
			get {
				return string.Format("{0}, 0", CategoryList.Count > 5 ? 10 : 30);
			}
		}
		public ObservableCollection<GameButton> GameList { get; }

		private readonly GameModel _gameModel;
		private readonly string _categoryColorCode = "#342E30";
		private readonly string _categoryColorHoverCode = "#453F41";
		private readonly string _launchRandomColorCode = "#4284C4";
		private readonly string _launchRandomColorHoverCode = "#5395D5";
		public MainViewModel() {
			_gameModel = new GameModel();
			CategoryList = new ObservableCollection<CategoryButton> {
				new CategoryButton("MAIN GAMES", "(PC-98)", _categoryColorCode, _categoryColorHoverCode, SetCategoryPC98),
				new CategoryButton("MAIN GAMES", "(WINDOWS)", _categoryColorCode, _categoryColorHoverCode, SetCategoryWindows),
				new CategoryButton("FIGHTING\nGAMES", "", _categoryColorCode, _categoryColorHoverCode, SetCategoryFighting),
				new CategoryButton("SPIN-OFFS", "", _categoryColorCode, _categoryColorHoverCode, SetCategorySpinOff),
				new CategoryButton("FAN GAMES", "", _categoryColorCode, _categoryColorHoverCode, SetCategoryFanGame),
				new CategoryButton("LAUNCH\nRANDOM GAME", "", _launchRandomColorCode, _launchRandomColorHoverCode, LaunchRandom)
			};
			GameList = new ObservableCollection<GameButton>();
			foreach (OfficialGame game in _gameModel.MainPC98Games) {
				GameList.Add(new GameButton(game));
			}
		}
		public class CategoryButton {
			public string CategoryName { get; }
			public string CategoryDesc { get; }
			public int CategoryDescHeight { get { return CategoryDesc.Length != 0 ? 15 : 0; } }
			public string CategoryColor { get; }
			public string CategoryHoverColor { get; }
			public ICommand CategoryCommand { get; }
			public CategoryButton(string name, string desc, string colorCode, string colorHoverCode, Action action) {
				CategoryName = name;
				CategoryDesc = desc;
				CategoryColor = colorCode;
				CategoryHoverColor = colorHoverCode;
				CategoryCommand = new RelayCommand(action);
			}
		}
		public class GameButton {
			public string GameName {
				get {
					if (_game.Subtitle.Length != 0) {
						return _game.Title + ":\n" + _game.Subtitle;
					}
					return _game.Title;
				}
			}
			public ICommand GameCommand { get; }

			private readonly Game _game;
			public GameButton(Game game) {
				_game = game;
				GameCommand = new RelayCommand(() => {
					_game.Launch();
				});
			}
		}
		private void SetCategoryPC98() {
			GameList.Clear();
			foreach (Game game in _gameModel.MainPC98Games) {
				GameList.Add(new GameButton(game));
			}
		}
		private void SetCategoryWindows() {
			GameList.Clear();
			foreach (Game game in _gameModel.MainWindowsGames) {
				GameList.Add(new GameButton(game));
			}
		}
		private void SetCategoryFighting() {
			GameList.Clear();
			foreach (Game game in _gameModel.FightingGames) {
				GameList.Add(new GameButton(game));
			}
		}
		private void SetCategorySpinOff() {
			GameList.Clear();
			foreach (Game game in _gameModel.SpinOffGames) {
				GameList.Add(new GameButton(game));
			}
		}
		private void SetCategoryFanGame() {
			GameList.Clear();
			foreach (Game game in _gameModel.FanGames) {
				GameList.Add(new GameButton(game));
			}
		}
		private void LaunchRandom() {

		}
	}
}
