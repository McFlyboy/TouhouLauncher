using GalaSoft.MvvmLight;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.ViewModels {
	public class MainViewModel : ViewModelBase {
		private string _page;

		public MainViewModel(SettingsManager settingsManager) {
			_page = "HomePage.xaml";

			settingsManager.Load();
		}

		public string Page {
			get => "Pages/" + _page;
			set {
				_page = value;
				RaisePropertyChanged(nameof(Page));
			}
		}
	}
}
