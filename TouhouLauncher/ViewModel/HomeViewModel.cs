using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Model;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.ViewModel {
	public class HomeViewModel : ViewModelBase {
		public ObservableCollection<HeaderButton> HeaderList { get; }
		public string HeaderPadding {
			get {
				return string.Format("{0}, 0", HeaderList.Count > 5 ? 10 : 30);
			}
		}
		public ObservableCollection<GameButton> GameList { get; }
		public ICommand OpenSettingsCommand { get; }

		private readonly HomeModel _homeModel;
		public HomeViewModel() {
			_homeModel = new HomeModel();
			HeaderList = new ObservableCollection<HeaderButton>();
			for (int i = 0; i < _homeModel.OfficialGameCategories.Count; i++) {
				var button = new CategoryHeaderButton(i, this);
				HeaderList.Add(button);
			}
			HeaderList.Add(new HeaderButton("LAUNCH\nRANDOM GAME", "", "#4284C4", "#5395D5", LaunchRandom));
			GameList = new ObservableCollection<GameButton>();
			for (int i = 0; i < _homeModel.GameList.Count; i++) {
				GameList.Add(new GameButton(i, this));
			}
			OpenSettingsCommand = new RelayCommand(() => {
				_homeModel.OpenSettings();
			});
		}
		public class HeaderButton : ObservableObject {
			public string HeaderName { get; protected set; }
			public string HeaderDesc { get; protected set; }
			public int HeaderDescHeight { get { return HeaderDesc.Length != 0 ? 15 : 0; } }
			public virtual string HeaderColor { get; }
			public virtual string HeaderHoverColor { get; }
			public string HeaderTextColor {
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
					return _id == _parent._homeModel.ActiveCategoryId ? "#453F41" : "#342E30";
				}
			}
			public override string HeaderHoverColor {
				get {
					return "#453F41";
				}
			}
			public override bool HeaderEnabled {
				get {
					return _id != _parent._homeModel.ActiveCategoryId;
				}
			}

			private readonly int _id;
			private readonly HomeViewModel _parent;
			public CategoryHeaderButton(int id, HomeViewModel parent) : base("", "", "", "", null) {
				_id = id;
				_parent = parent;
				switch (_parent._homeModel.OfficialGameCategories[id]) {
					case OfficialGame.CategoryFlag.MainPC98:
						HeaderName = "MAIN GAMES";
						HeaderDesc = "(PC-98)";
						break;
					case OfficialGame.CategoryFlag.MainWindows:
						HeaderName = "MAIN GAMES";
						HeaderDesc = "(WINDOWS)";
						break;
					case OfficialGame.CategoryFlag.MainPC98 | OfficialGame.CategoryFlag.MainWindows:
						HeaderName = "MAIN GAMES";
						break;
					case OfficialGame.CategoryFlag.FightingGame:
						HeaderName = "FIGHTING\nGAMES";
						break;
					case OfficialGame.CategoryFlag.SpinOff:
						HeaderName = "SPIN-OFFS";
						break;
					case OfficialGame.CategoryFlag.None:
						HeaderName = "FAN GAMES";
						break;
					default:
						HeaderName = "ERROR!!";
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
					if (_parent._homeModel.GameList[_id].Subtitle.Length != 0) {
						return _parent._homeModel.GameList[_id].Title + ":\n" + _parent._homeModel.GameList[_id].Subtitle;
					}
					return _parent._homeModel.GameList[_id].Title;
				}
			}
			public string GameImage {
				get {
					return _parent._homeModel.GameList[_id].ImageLocation;
				}
			}
			public string GameReleaseYear {
				get {
					return "Release: " + _parent._homeModel.GameList[_id].ReleaseYear.ToString();
				}
			}
			public ICommand GameCommand { get; }

			private readonly int _id;
			private readonly HomeViewModel _parent;
			public GameButton(int id, HomeViewModel parent) {
				_id = id;
				_parent = parent;
				GameCommand = new RelayCommand(() => {
					_parent._homeModel.LaunchGame(_id);
				});
			}
		}
		private void SetCurrentCategory(int id) {
			_homeModel.SetCurrentCategory(id);
			foreach (HeaderButton button in HeaderList) {
				button.RaisePropertyChanged("HeaderColor");
				button.RaisePropertyChanged("HeaderHoverColor");
				button.RaisePropertyChanged("HeaderTextColor");
				button.RaisePropertyChanged("HeaderEnabled");
			}
			GameList.Clear();
			for (int i = 0; i < _homeModel.GameList.Count; i++) {
				GameList.Add(new GameButton(i, this));
			}
		}
		private void LaunchRandom() {
			_homeModel.LaunchRandom();
		}
	}
}
