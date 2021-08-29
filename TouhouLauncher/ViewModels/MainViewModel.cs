#nullable disable

using GalaSoft.MvvmLight;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class MainViewModel : ViewModelBase {
		private string _page;

		public MainViewModel(SettingsAndGamesManager settingsAndGamesManager) {
			MessengerInstance.Register<string>(this, ChangePageMessageToken, ChangePage);

			_page = "HomePage.xaml";

			_ = settingsAndGamesManager.LoadAsync();
		}

		public string Page => "Pages/" + _page;

		private void ChangePage(string page) {
			_page = page;
			RaisePropertyChanged(nameof(Page));
		}

		public static object ChangePageMessageToken { get; } = new();
	}
}
