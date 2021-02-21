namespace TouhouLauncher.Models.Application.GameInfo {
	public class OfficialGame : Game {
		public string DownloadableFileLocation { get; init; }

		public GameCategories Categories { get; init; }
	}
}
