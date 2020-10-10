using GalaSoft.MvvmLight;
using TouhouLauncher.Models;

namespace TouhouLauncher.ViewModels {
	public class MainViewModel : ViewModelBase {
		private string _page;

		public MainViewModel(MainModel _) {
			_page = "HomePage.xaml";
		}

		public string Page {
			get => "Pages/" + _page;
			set {
				_page = value;
				RaisePropertyChanged("Page");
			}
		}
	}
}
