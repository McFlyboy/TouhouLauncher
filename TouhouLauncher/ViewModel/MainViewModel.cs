using GalaSoft.MvvmLight;
using TouhouLauncher.Model;

namespace TouhouLauncher.ViewModel {
	public class MainViewModel : ViewModelBase {
		public string Page {
			get {
				return "Pages/" + _page;
			}
			set {
				_page = value;
				RaisePropertyChanged("Page");
			}
		}

		private string _page;
		public MainViewModel() {
			_page = "HomePage.xaml";
		}
	}
}
