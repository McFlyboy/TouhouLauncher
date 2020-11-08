using GalaSoft.MvvmLight;
using TouhouLauncher.Services.Application;

namespace TouhouLauncher.ViewModels {
	public class MainViewModel : ViewModelBase {
		private string _page;

		public MainViewModel(InitAllSettingsService mainModel) {
			_page = "HomePage.xaml";

			mainModel.InitAllSettings();
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
