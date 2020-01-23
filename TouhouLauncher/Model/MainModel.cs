namespace TouhouLauncher.Model {
	public class MainModel {
		public string Page {
			get {
				return true ? "HomePage.xaml" : "SettingsPage.xaml";
			}
		}
	}
}
