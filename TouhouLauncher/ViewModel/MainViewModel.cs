using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace TouhouLauncher.ViewModel {
	public class MainViewModel : ViewModelBase {
		public List<CategoryButton> CategoryList { get; }
		public List<GameButton> GameList { get; }

		private CategoryButton _fanGameCategoryButton;
		public MainViewModel() {
			CategoryList = new List<CategoryButton> {
				new CategoryButton("Main Games\n(PC 98)", Test),
				new CategoryButton("Main Games\n(Windows)", Test),
				new CategoryButton("Fighting Games", Test),
				new CategoryButton("Spin-offs", Test)
			};
			_fanGameCategoryButton = new CategoryButton("Fan Games", Test);
			GameList = new List<GameButton>();
			GameList.Add(new GameButton("Touhou 01"));
			GameList.Add(new GameButton("Touhou 02"));
			GameList.Add(new GameButton("Touhou 03"));
			GameList.Add(new GameButton("Touhou 04"));
			GameList.Add(new GameButton("Touhou 05"));
			GameList.Add(new GameButton("Touhou 06"));
			GameList.Add(new GameButton("Touhou 07"));
			GameList.Add(new GameButton("Touhou 08"));
			GameList.Add(new GameButton("Touhou 09"));
			GameList.Add(new GameButton("Touhou 10"));
		}
		public class CategoryButton {
			public string CategoryName { get; set; }
			public ICommand CategoryCommand { get; set; }
			public CategoryButton(string name, Action action) {
				CategoryName = name;
				CategoryCommand = new RelayCommand(action);
			}
		}
		public class GameButton {
			public string GameName { get; set; }
			public GameButton(string gameName) {
				GameName = gameName;
			}
		}
		private void Test() {
			Debug.WriteLine("Test");
			CategoryList.Add(_fanGameCategoryButton);
			RaisePropertyChanged("");
		}
	}
}
