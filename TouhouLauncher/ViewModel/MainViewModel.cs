using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Model;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.ViewModel {
	public class MainViewModel : ViewModelBase {
		public ObservableCollection<HeaderButton> HeaderList { get; }
		public string HeaderPadding {
			get {
				return string.Format("{0}, 0", HeaderList.Count > 5 ? 10 : 30);
			}
		}
		public ObservableCollection<GameButton> GameList { get; }

		private readonly GameModel _gameModel;
		public MainViewModel() {
			_gameModel = new GameModel();
			HeaderList = new ObservableCollection<HeaderButton> {
				new CategoryHeaderButton("MAIN GAMES", "(PC-98)", SetCurrentCategories, Game.GameCategory.MainPC98),
				new CategoryHeaderButton("MAIN GAMES", "(WINDOWS)", SetCurrentCategories, Game.GameCategory.MainWindows),
				new CategoryHeaderButton("FIGHTING\nGAMES", "", SetCurrentCategories, Game.GameCategory.FightingGame),
				new CategoryHeaderButton("SPIN-OFFS", "", SetCurrentCategories, Game.GameCategory.SpinOff),
				new CategoryHeaderButton("FAN GAMES", "", SetCurrentCategories, Game.GameCategory.FanGame),
				new HeaderButton("LAUNCH\nRANDOM GAME", "", "#4284C4", "#5395D5", LaunchRandom)
			};
			GameList = new ObservableCollection<GameButton>();
			foreach (OfficialGame game in _gameModel.FilterGames(Game.GameCategory.First)) {
				GameList.Add(new GameButton(game));
			}
		}
		public class HeaderButton {
			public string HeaderName { get; }
			public string HeaderDesc { get; }
			public int HeaderDescHeight { get { return HeaderDesc.Length != 0 ? 15 : 0; } }
			public string HeaderColor { get; }
			public string HeaderHoverColor { get; }
			public ICommand HeaderCommand { get; protected set; }
			public HeaderButton(string name, string desc, string colorCode, string colorHoverCode, Action action) {
				HeaderName = name;
				HeaderDesc = desc;
				HeaderColor = colorCode;
				HeaderHoverColor = colorHoverCode;
				if (action != null) {
					HeaderCommand = new RelayCommand(action);
				}
			}
		}
		public class CategoryHeaderButton : HeaderButton {
			private readonly Action<Game.GameCategory> _categoryAction;
			private readonly Game.GameCategory _categoryFlags;
			public CategoryHeaderButton(string name, string desc, Action<Game.GameCategory> action, Game.GameCategory categoryFlags) :
				base(name, desc, "#342E30", "#453F41", null)
			{
				_categoryFlags = categoryFlags;
				_categoryAction = action;
				HeaderCommand = new RelayCommand(() => {
					_categoryAction(_categoryFlags);
				});
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
			public string GameImage {
				get {
					return _game.ImageLocation;
				}
			}
			public string GameReleaseYear {
				get {
					return _game.ReleaseYear.ToString();
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
		private void SetCurrentCategories(Game.GameCategory categoryFlags) {
			GameList.Clear();
			for (int i = (int)Game.GameCategory.First; i < (int)Game.GameCategory.Last; i <<= 1) {
				if ((i & (int)categoryFlags) == 0) {
					continue;
				}
				foreach (Game game in _gameModel.FilterGames((Game.GameCategory)i)) {
					GameList.Add(new GameButton(game));
				}
			}
		}
		private void LaunchRandom() {

		}
	}
}
