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
			HeaderList = new ObservableCollection<HeaderButton>();
			for (int i = 0; i < _mainModel.Categories.Count; i++) {
				var button = new CategoryHeaderButton(i, this);
				HeaderList.Add(button);
			}
			HeaderList.Add(new HeaderButton("LAUNCH\nRANDOM GAME", "", "#4284C4", "#5395D5", LaunchRandom));
			GameList = new ObservableCollection<GameButton>();
			for (int i = 0; i < _mainModel.GameList.Count; i++) {
				GameList.Add(new GameButton(i, this));
			}
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
			public override string HeaderColor {
				get {
					return _id == _parent._mainModel.ActiveCategoryId ? "#FFFFFF" : "#342E30";
				}
			}
			public override string HeaderHoverColor {
				get {
					return _id == _parent._mainModel.ActiveCategoryId ? "#FFFFFF" : "#453F41";
				}
			}
			public override string HeaderTextColor {
				get {
					return _id == _parent._mainModel.ActiveCategoryId ? "#342E30" : "#FFFFFF";
				}
			}
			public override bool HeaderEnabled {
				get {
					return _id != _parent._mainModel.ActiveCategoryId;
				}
			}

			private readonly int _id;
			private readonly MainViewModel _parent;
			public CategoryHeaderButton(int id, MainViewModel parent) : base("", "", "", "", null) {
				_id = id;
				_parent = parent;
				switch (_parent._mainModel.Categories[id]) {
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
					_parent.SetCurrentCategory(_id);
				});
			}
		}
		public class GameButton {
			public string GameName {
				get {
					if (_parent._mainModel.GameList[_id].Subtitle.Length != 0) {
						return _parent._mainModel.GameList[_id].Title + ":\n" + _parent._mainModel.GameList[_id].Subtitle;
					}
					return _parent._mainModel.GameList[_id].Title;
				}
			}
			public string GameImage {
				get {
					return _parent._mainModel.GameList[_id].ImageLocation;
				}
			}
			public string GameReleaseYear {
				get {
					return "Release: " + _parent._mainModel.GameList[_id].ReleaseYear.ToString();
				}
			}
			public ICommand GameCommand { get; }

			private readonly int _id;
			private readonly MainViewModel _parent;
			public GameButton(int id, MainViewModel parent) {
				_id = id;
				_parent = parent;
				GameCommand = new RelayCommand(() => {
					_parent._mainModel.GameList[_id].Launch();
				});
			}
		}
		private void SetCurrentCategory(int id) {
			_mainModel.SetCurrentCategory(id);
			foreach (HeaderButton button in HeaderList) {
				button.RaisePropertyChanged("HeaderColor");
				button.RaisePropertyChanged("HeaderHoverColor");
				button.RaisePropertyChanged("HeaderTextColor");
				button.RaisePropertyChanged("HeaderEnabled");
			}
			GameList.Clear();
			for (int i = 0; i < _mainModel.GameList.Count; i++) {
				GameList.Add(new GameButton(i, this));
			}
		}
		private void LaunchRandom() {
			_mainModel.LaunchRandom();
		}
	}
}
