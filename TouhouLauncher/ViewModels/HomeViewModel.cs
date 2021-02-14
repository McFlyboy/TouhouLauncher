using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Services.Application;

namespace TouhouLauncher.ViewModels {
	public class HomeViewModel : ViewModelBase {
		private readonly GamePickerViewModel _gamePickerViewModel;
		private readonly ActiveGameCategory _activeGameCategory;
		private readonly GameCategoryService _gameCategoryService;

		public HomeViewModel(
			GamePickerViewModel gamePickerViewModel,
			ActiveGameCategory activeGameCategory,
			GameCategoryService gameCategoryService
		) {
			_gamePickerViewModel = gamePickerViewModel;
			_activeGameCategory = activeGameCategory;
			_gameCategoryService = gameCategoryService;

			MessengerInstance.Register<object>(this, RebuildHeadersMessageToken, RebuildHeaders);

			HeaderList = new ObservableCollection<HeaderButton>();

			var gameCategoryList = _gameCategoryService.CreateGameCategoryList();

			foreach (var category in gameCategoryList) {
				HeaderList.Add(new CategoryHeaderButton(category, this));
			}

			HeaderList.Add(CreateRandomGameHeader());

			OpenSettingsCommand = new RelayCommand(() => {
				MessengerInstance.Send("SettingsPage.xaml", MainViewModel.ChangePageMessageToken);
			});
		}

		public ObservableCollection<HeaderButton> HeaderList { get; }

		public string HeaderPadding => $"{(HeaderList.Count > 5 ? 10 : 30)}, 0";

		public ICommand OpenSettingsCommand { get; }

		private HeaderButton CreateRandomGameHeader() {
			return new HeaderButton(
				name: "LAUNCH\nRANDOM GAME",
				colorCode: "#4284C4",
				colorHoverCode: "#5395D5",
				action: LaunchRandom
			);
		}

		private void RebuildHeaders(object _ = null) {
			var gameCategoryList = _gameCategoryService.CreateGameCategoryList();

			HeaderList.Clear();

			foreach (var category in gameCategoryList) {
				HeaderList.Add(new CategoryHeaderButton(category, this));
			}

			HeaderList.Add(CreateRandomGameHeader());

			if (
				(_activeGameCategory.CurrentCategory & OfficialGame.CategoryFlag.MainPC98) != OfficialGame.CategoryFlag.None
				|| (_activeGameCategory.CurrentCategory & OfficialGame.CategoryFlag.MainWindows) != OfficialGame.CategoryFlag.None
			) {
				SetCurrentCategory(_gameCategoryService.GetDefaultGameCategory());
			}
		}

		private void SetCurrentCategory(OfficialGame.CategoryFlag categoryFlags) {
			_activeGameCategory.CurrentCategory = categoryFlags;

			_gamePickerViewModel.UpdateGames();

			foreach (HeaderButton button in HeaderList) {
				button.RaisePropertyChanged("HeaderColor");
				button.RaisePropertyChanged("HeaderHoverColor");
				button.RaisePropertyChanged("HeaderTextColor");
				button.RaisePropertyChanged("HeaderEnabled");
			}
		}

		private void LaunchRandom() {
			//TODO
		}

		public static object RebuildHeadersMessageToken { get; } = new();

		public class HeaderButton : ObservableObject {
			public HeaderButton(
				string name = "",
				string desc = "",
				string colorCode = "",
				string colorHoverCode = "",
				Action action = null
			) {
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
			private readonly OfficialGame.CategoryFlag _categoryFlags;
			private readonly HomeViewModel _parent;

			public CategoryHeaderButton(
				OfficialGame.CategoryFlag categoryFlags,
				HomeViewModel parent
			) : base() {
				_categoryFlags = categoryFlags;
				_parent = parent;
				switch (_categoryFlags) {
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
						HeaderName = "UNKNOWN\nCATEGORY";
						break;
				}
				HeaderCommand = new RelayCommand(() => {
					_parent.SetCurrentCategory(_categoryFlags);
				});
			}

			public override string HeaderColor =>
				_categoryFlags == _parent._activeGameCategory.CurrentCategory
					? "#694F77"
					: "#342E30";

			public override string HeaderHoverColor => "#453F41";

			public override bool HeaderEnabled =>
				_categoryFlags != _parent._activeGameCategory.CurrentCategory;
		}
	}
}
