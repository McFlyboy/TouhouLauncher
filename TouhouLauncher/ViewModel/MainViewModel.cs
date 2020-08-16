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
			var yaml = SettingsSerializerService.Instance.DeserializeFromFile();

			SettingsManager.Instance.GeneralSettings = yaml.GeneralSettings.ToDomain();

			int safeLength = Math.Min(GameDB.Instance.OfficialGames.Length, yaml.OfficialGames.Length);
			for (int i = 0; i < safeLength; i++) {
				GameDB.Instance.OfficialGames[i].LocalFileLocation = yaml.OfficialGames[i].LocalFileLocation;
			}

			foreach (var fanGame in yaml.FanGames) {
				GameDB.Instance.FanGames.Add(fanGame.ToDomain());
			}
		}
	}
}
