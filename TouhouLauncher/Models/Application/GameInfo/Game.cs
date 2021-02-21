namespace TouhouLauncher.Models.Application.GameInfo {
	public abstract class Game {
		public string Title { get; init; }

		public string Subtitle { get; init; }

		public string FullTitle => Title + Subtitle != null ? $": {Subtitle}" : string.Empty;

		public string ImageLocation { get; init; }

		public string AudioLocation { get; init; }

		public int ReleaseYear { get; init; }

		public string FileLocation { get; set; }
	}
}
