using GalaSoft.MvvmLight;
using System.Collections.Generic;
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
			var settings = SettingsSerializerService.Instance.DeserializeFromFile()
				?? new Settings() {
					OfficialGames = GameDBTemplate.CreateOfficialGamesFromTemplate(),
					FanGames = new List<FanGame>(),
					GeneralSettings = new GeneralSettings()
				};

			GameDB.Instance.OfficialGames = settings.OfficialGames;
			GameDB.Instance.FanGames = settings.FanGames;
			SettingsManager.Instance.GeneralSettings = settings.GeneralSettings;
		}
	}
}
