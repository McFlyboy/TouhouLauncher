using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models;
using TouhouLauncher.Models.GameInfo;

namespace TouhouLauncher.ViewModels {
	public class HomeViewModel : ViewModelBase {
		private readonly HomeModel _homeModel;
		private readonly MainViewModel _mainViewModel;

		public HomeViewModel(
			MainViewModel mainViewModel,
			HomeModel homeModel
		) {
			_homeModel = homeModel;
			_mainViewModel = mainViewModel;

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
				_mainViewModel.Page = "SettingsPage.xaml";
			});
		}

		public ObservableCollection<HeaderButton> HeaderList { get; }
		public string HeaderPadding => string.Format("{0}, 0", HeaderList.Count > 5 ? 10 : 30);
		public ObservableCollection<GameButton> GameList { get; }
		public ICommand OpenSettingsCommand { get; }

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

		public class HeaderButton : ObservableObject {
			public HeaderButton(string name, string desc, string colorCode, string colorHoverCode, Action action) {
				HeaderName = name;
				HeaderDesc = desc;
				HeaderColor = colorCode;
				HeaderHoverColor = colorHoverCode;
				if (action != null) {
					HeaderCommand = new RelayCommand(action);
				}
			}

			public string HeaderName { get; protected set; }
			public string HeaderDesc { get; protected set; }
			public int HeaderDescHeight => HeaderDesc.Length != 0 ? 15 : 0;
			public virtual string HeaderColor { get; }
			public virtual string HeaderHoverColor { get; }
			public string HeaderTextColor => "#FFFFFF";
			public virtual bool HeaderEnabled => true;
			public ICommand HeaderCommand { get; protected set; }
		}

		public class CategoryHeaderButton : HeaderButton {
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

			public override string HeaderColor => _id == _parent._homeModel.ActiveCategoryId
				? "#694F77"
				: "#342E30";
			public override string HeaderHoverColor => "#453F41";
			public override bool HeaderEnabled => _id != _parent._homeModel.ActiveCategoryId;
		}

		public class GameButton {
			private readonly int _id;
			private readonly HomeViewModel _parent;

			public GameButton(int id, HomeViewModel parent) {
				_id = id;
				_parent = parent;

				GameCommand = new RelayCommand(() => {
					_parent._homeModel.LaunchGame(_id);
				});
			}

			public string GameName =>
				_parent._homeModel.GameList[_id].Title +
				(!_parent._homeModel.GameList[_id].Subtitle.Equals(string.Empty) ? ":\n" : string.Empty) +
				_parent._homeModel.GameList[_id].Subtitle;
			public string GameImage => _parent._homeModel.GameList[_id].ImageLocation;
			public string GameReleaseYear => "Release: " + _parent._homeModel.GameList[_id].ReleaseYear;
			public ICommand GameCommand { get; }
		}
	}
}
