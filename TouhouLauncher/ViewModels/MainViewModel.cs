using GalaSoft.MvvmLight;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.ViewModels {
	public class MainViewModel : ViewModelBase {
		private string _page;

		public MainViewModel(SettingsManager settingsManager) {
			MessengerInstance.Register<ChangePageMessage>(this, ChangePage);

			_page = "HomePage.xaml";

			settingsManager.Load();
		}

		public string Page {
			get => "Pages/" + _page;
		}

		private void ChangePage(ChangePageMessage pageChangeMessage) {
			_page = pageChangeMessage.NewPage;
			RaisePropertyChanged(nameof(Page));
		}

		public class ChangePageMessage {
			public string NewPage { get; init; }
		}
	}
}
