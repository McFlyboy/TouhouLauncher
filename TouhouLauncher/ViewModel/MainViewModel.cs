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
		private readonly string _standardCategoryColorCode = "#342E30";
		private readonly string _standardCategoryColorHoverCode = "#453F41";
		public MainViewModel() {
			_gameModel = new GameModel();
			CategoryList = new ObservableCollection<CategoryButton> {
				new CategoryButton("MAIN GAMES", "(PC-98)", true, _standardCategoryColorCode, _standardCategoryColorHoverCode, SetCategory),
				new CategoryButton("MAIN GAMES", "(WINDOWS)", true, _standardCategoryColorCode, _standardCategoryColorHoverCode, SetCategory),
				new CategoryButton("FIGHTING\nGAMES", "", false, _standardCategoryColorCode, _standardCategoryColorHoverCode, SetCategory),
				new CategoryButton("SPIN-OFFS", "", false, _standardCategoryColorCode, _standardCategoryColorHoverCode, SetCategory),
				new CategoryButton("FAN GAMES", "", false, _standardCategoryColorCode, _standardCategoryColorHoverCode, SetCategory),
				new CategoryButton("LAUNCH\nRANDOM GAME", "", false, "#4284C4", "#5395D5", SetCategory)
			};
			GameList = new ObservableCollection<GameButton>();
			foreach (OfficialGame game in _gameModel.MainPC98Games) {
				GameList.Add(new GameButton(game));
			}
		}
		public class CategoryButton {
			public string CategoryName { get; }
			public string CategoryDesc { get; }
			public int CategoryDescHeight { get { return _showDesc ? 15 : 0; } }
			public string CategoryColor { get; }
			public string CategoryHoverColor { get; }
			public ICommand CategoryCommand { get; }
			private readonly bool _showDesc;
			public CategoryButton(string name, string desc, bool showDesc, string colorCode, string colorHoverCode, Action action) {
				CategoryName = name;
				CategoryDesc = desc;
				_showDesc = showDesc;
				CategoryColor = colorCode;
				CategoryHoverColor = colorHoverCode;
				CategoryCommand = new RelayCommand(action);
			}
		}
		public class GameButton {
			public string GameName {
				get {
					if (_game.Subtitle.Length != 0) {
						return _game.Title + ": " + _game.Subtitle;
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
		private void SetCategory() {

		}
	}
}
