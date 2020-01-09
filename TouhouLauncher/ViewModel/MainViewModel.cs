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
				new CategoryHeaderButton("MAIN GAMES", "(PC-98)", this, Game.GameCategory.MainPC98),
				new CategoryHeaderButton("MAIN GAMES", "(WINDOWS)", this, Game.GameCategory.MainWindows),
				new CategoryHeaderButton("FIGHTING\nGAMES", "", this, Game.GameCategory.FightingGame),
				new CategoryHeaderButton("SPIN-OFFS", "", this, Game.GameCategory.SpinOff),
				new CategoryHeaderButton("FAN GAMES", "", this, Game.GameCategory.FanGame),
				new HeaderButton("LAUNCH\nRANDOM GAME", "", "#4284C4", "#5395D5", LaunchRandom)
			};
			GameList = new ObservableCollection<GameButton>();
			CategoryHeaderButton firstCategoryButton = (CategoryHeaderButton)HeaderList[1];
			SetCurrentCategories(firstCategoryButton.CategoryFlags);
			firstCategoryButton.ActiveCategoryButton = true;
		}
		public class HeaderButton : ObservableObject {
			public string HeaderName { get; }
			public string HeaderDesc { get; }
			public int HeaderDescHeight { get { return HeaderDesc.Length != 0 ? 15 : 0; } }
			public virtual string HeaderColor { get; }
			public virtual string HeaderHoverColor { get; }
			public virtual string HeaderTextColor {
				get {
					return "#FFFFFF";
				}
			}
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
			public bool ActiveCategoryButton { get; set; }
			public override string HeaderColor {
				get {
					return ActiveCategoryButton ? "#FFFFFF" : "#342E30";
				}
			}
			public override string HeaderHoverColor {
				get {
					return ActiveCategoryButton ? "#FFFFFF" : "#453F41";
				}
			}
			public override string HeaderTextColor {
				get {
					return ActiveCategoryButton ? "#342E30" : "#FFFFFF";
				}
			}
			public Game.GameCategory CategoryFlags { get; private set; }

			private readonly MainViewModel _parent;

			public CategoryHeaderButton(string name, string desc, MainViewModel parent, Game.GameCategory categoryFlags) :
				base(name, desc, "", "", null)
			{
				_parent = parent;
				CategoryFlags = categoryFlags;
				HeaderCommand = new RelayCommand(() => {
					_parent.SetCurrentCategories(CategoryFlags);
					ActiveCategoryButton = true;
					RaisePropertyChanged("HeaderColor");
					RaisePropertyChanged("HeaderHoverColor");
					RaisePropertyChanged("HeaderTextColor");
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
					return "Release: " + _game.ReleaseYear.ToString();
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
			foreach (HeaderButton button in HeaderList) {
				if (button.GetType() == typeof(CategoryHeaderButton)) {
					CategoryHeaderButton catButton = (CategoryHeaderButton)button;
					catButton.ActiveCategoryButton = false;
					catButton.RaisePropertyChanged("HeaderColor");
					catButton.RaisePropertyChanged("HeaderHoverColor");
					catButton.RaisePropertyChanged("HeaderTextColor");
				}
			}
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
