namespace TouhouLauncher.Model.GameInfo {
	public class OfficialGame : Game {
		public string DownloadableFileLocation { get; set; }
		public new CategoryFlag Category {
			get {
				return base.Category;
			}
			set {
				base.Category = value;
			}
		}
	}
}
