using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Model;

namespace TouhouLauncher.ViewModel {
	public class MainViewModel : ViewModelBase {
		public ObservableCollection<CategoryButton> CategoryList { get; }
		public string CategoryPadding { get { return "10, 0"; } }
		public ObservableCollection<GameButton> GameList { get; }

		private GameModel _gameModel;
		private string _standardCategoryColorCode = "#342E30";
		private string _standardCategoryColorHoverCode = "#453F41";
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
			for (int i = 0; i < 15; i++) {
				GameList.Add(new GameButton("Touhou " + String.Format("{0:D2}", i + 1), StartGame));
			}
		}
		public class CategoryButton {
			public string CategoryName { get; set; }
			public string CategoryDesc { get; set; }
			public int CategoryDescHeight { get { return _showDesc ? 15 : 0; } }
			public string CategoryColor { get; set; }
			public string CategoryHoverColor { get; set; }
			public ICommand CategoryCommand { get; set; }
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
			public string GameName { get; set; }
			public ICommand GameCommand { get; set; }
			public GameButton(string gameName, Action action) {
				GameName = gameName;
				GameCommand = new RelayCommand(action);
			}
		}
		private void SetCategory() {

		}
		private void StartGame() {
			_gameModel.LaunchGame("D:\\Games\\Touhou\\Touhou 10 Mountain of Faith\\th10e.exe");
		}
	}
}
