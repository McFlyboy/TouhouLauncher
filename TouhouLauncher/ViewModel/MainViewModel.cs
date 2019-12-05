using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace TouhouLauncher.ViewModel {
	public class MainViewModel : ViewModelBase {
		public List<CategoryButton> CategoryList { get; }
		public MainViewModel() {
			CategoryList = new List<CategoryButton>();
			CategoryList.Add(new CategoryButton("Main Games\n(PC 98)", new RelayCommand(() => { Debug.WriteLine("Test :P"); })));
			CategoryList.Add(new CategoryButton("Main Games\n(Windows)", new RelayCommand(() => { Debug.WriteLine("Test :P"); })));
			CategoryList.Add(new CategoryButton("Fighting Games", new RelayCommand(() => { Debug.WriteLine("Test :P"); })));
			CategoryList.Add(new CategoryButton("Spin-offs", new RelayCommand(() => { Debug.WriteLine("Test :P"); })));
			//CategoryList.Add(new CategoryButton("Fan Games", new RelayCommand(() => { Debug.WriteLine("Test :P"); })));
		}
		public class CategoryButton {
			public string CategoryName { get; set; }
			public ICommand CategoryCommand { get; set; }
			public CategoryButton(string categoryName, ICommand categoryCommand) {
				CategoryName = categoryName;
				CategoryCommand = categoryCommand;
			}
		}
	}
}
