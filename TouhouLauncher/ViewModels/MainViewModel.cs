using GalaSoft.MvvmLight;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.ViewModels {
	public class MainViewModel : ViewModelBase {
		private string _page;

		public MainViewModel(SettingsManager settingsManager) {
			MessengerInstance.Register<string>(this, ChangePageMessageToken, ChangePage);

			_page = "HomePage.xaml";

			settingsManager.Load();
		}

		public string Page {
			get => "Pages/" + _page;
		}

		private void ChangePage(string page) {
			_page = page;
			RaisePropertyChanged(nameof(Page));
		}

		public static object ChangePageMessageToken { get; } = new();
	}
}
