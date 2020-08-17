using GalaSoft.MvvmLight;
using System;
using TouhouLauncher.Model.GameInfo;
using TouhouLauncher.Model.Serialization;
using TouhouLauncher.Model.Settings;

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
			InitApp();
		}

		private void InitApp() {
			var (officialGames, fanGames, generalSettings) = SettingsSerializerService.Instance
				.DeserializeFromFile()
				.ToDomain();

			GameDB.Instance.OfficialGames = officialGames;
			GameDB.Instance.FanGames = fanGames;
			SettingsManager.Instance.GeneralSettings = generalSettings;
		}
	}
}
