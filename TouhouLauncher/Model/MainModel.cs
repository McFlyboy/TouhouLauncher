namespace TouhouLauncher.Model {
	public class MainModel {
		public string Page {
			get {
				return "Pages/" + _page;
			}
			set {
				_page = value;
			}
		}
		private string _page;
		public MainModel() {
			_page = "HomePage.xaml";
		}
	}
}
