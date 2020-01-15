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

		private readonly MainModel _mainModel;
		public MainViewModel() {
			_mainModel = new MainModel();
			GameList = new ObservableCollection<GameButton>();
			HeaderList = new ObservableCollection<HeaderButton>();
			for (int i = 0; i < _mainModel.Categories.Count; i++) {
				var button = new CategoryHeaderButton(this, _mainModel.Categories[i]);
				if (i == _mainModel.ActiveCategory) {
					button.ActiveCategoryButton = true;
					SetCurrentCategories(button.CategoryFlags);
				}
				HeaderList.Add(button);
			}
			HeaderList.Add(new HeaderButton("LAUNCH\nRANDOM GAME", "", "#4284C4", "#5395D5", LaunchRandom));
		}
		public class HeaderButton : ObservableObject {
			public string HeaderName { get; protected set; }
			public string HeaderDesc { get; protected set; }
			public int HeaderDescHeight { get { return HeaderDesc.Length != 0 ? 15 : 0; } }
			public virtual string HeaderColor { get; }
			public virtual string HeaderHoverColor { get; }
			public virtual string HeaderTextColor {
				get {
					return "#FFFFFF";
				}
			}
			public virtual bool HeaderEnabled {
				get {
					return true;
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
			public override bool HeaderEnabled {
				get {
					return !ActiveCategoryButton;
				}
			}
			public Game.CategoryFlag CategoryFlags { get; private set; }

			private readonly MainViewModel _parent;

			public CategoryHeaderButton(MainViewModel parent, Game.CategoryFlag categoryFlags) :
				base("", "", "", "", null)
			{
				_parent = parent;
				CategoryFlags = categoryFlags;
				switch (CategoryFlags) {
					case Game.CategoryFlag.MainPC98:
						HeaderName = "MAIN GAMES";
						HeaderDesc = "(PC-98)";
						break;
					case Game.CategoryFlag.MainWindows:
						HeaderName = "MAIN GAMES";
						HeaderDesc = "(WINDOWS)";
						break;
					case Game.CategoryFlag.MainPC98 | Game.CategoryFlag.MainWindows:
						HeaderName = "MAIN GAMES";
						break;
					case Game.CategoryFlag.FightingGame:
						HeaderName = "FIGHTING\nGAMES";
						break;
					case Game.CategoryFlag.SpinOff:
						HeaderName = "SPIN-OFFS";
						break;
					case Game.CategoryFlag.FanGame:
						HeaderName = "FAN GAMES";
						break;
					default:
						HeaderName = "Un-named\ncategory";
						break;
				}
				HeaderCommand = new RelayCommand(() => {
					_parent.SetCurrentCategories(CategoryFlags);
					ActiveCategoryButton = true;
					RaisePropertyChanged("HeaderColor");
					RaisePropertyChanged("HeaderHoverColor");
					RaisePropertyChanged("HeaderTextColor");
					RaisePropertyChanged("HeaderEnabled");
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
		private void SetCurrentCategories(Game.CategoryFlag categoryFlags) {
			GameList.Clear();
			foreach (HeaderButton button in HeaderList) {
				if (button.GetType() == typeof(CategoryHeaderButton)) {
					CategoryHeaderButton catButton = (CategoryHeaderButton)button;
					catButton.ActiveCategoryButton = false;
					catButton.RaisePropertyChanged("HeaderColor");
					catButton.RaisePropertyChanged("HeaderHoverColor");
					catButton.RaisePropertyChanged("HeaderTextColor");
					catButton.RaisePropertyChanged("HeaderEnabled");
				}
			}
			for (int i = (int)Game.CategoryFlag.First; i < (int)Game.CategoryFlag.Last; i <<= 1) {
				if ((i & (int)categoryFlags) == 0) {
					continue;
				}
				foreach (Game game in _mainModel.FilterGames((Game.CategoryFlag)i)) {
					GameList.Add(new GameButton(game));
				}
			}
		}
		private void LaunchRandom() {
			
		}
	}
}
