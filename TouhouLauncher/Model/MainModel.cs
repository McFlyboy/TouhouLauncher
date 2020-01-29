namespace TouhouLauncher.Model {
	public class MainModel {
		public string Page {
			get {
				return _showHomePage ? "HomePage.xaml" : "SettingsPage.xaml";
			}
		}

		private bool _showHomePage;
		public MainModel() {
			_showHomePage = true;
		}
		public void SwitchPage() {
			_showHomePage = !_showHomePage;
		}
	}
}
