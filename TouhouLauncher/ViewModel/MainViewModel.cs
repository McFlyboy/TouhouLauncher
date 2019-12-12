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
		public MainViewModel() {
			_gameModel = new GameModel();
			CategoryList = new ObservableCollection<CategoryButton> {
				new CategoryButton("Main Games\n(PC-98)", "#342E30", SetCategory),
				new CategoryButton("Main Games\n(Windows)", "#342E30", SetCategory),
				new CategoryButton("Fighting Games", "#342E30", SetCategory),
				new CategoryButton("Spin-offs", "#342E30", SetCategory),
				new CategoryButton("Fan games", "#342E30", SetCategory),
				new CategoryButton("Launch random\ngame", "#4284C4", SetCategory)
			};
			GameList = new ObservableCollection<GameButton>();
			for (int i = 0; i < 15; i++) {
				GameList.Add(new GameButton("Touhou " + String.Format("{0:D2}", i + 1), StartGame));
			}
		}
		public class CategoryButton {
			public string CategoryName { get; set; }
			public ICommand CategoryCommand { get; set; }
			public string CategoryColor { get; set; }
			public CategoryButton(string name, string colorCode, Action action) {
				CategoryName = name;
				CategoryColor = colorCode;
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
			_gameModel.StartGame("D:\\Games\\Touhou\\Touhou 10 Mountain of Faith\\th10e.exe");
		}
	}
}
