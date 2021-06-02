namespace TouhouLauncher.Models.Application.GameInfo {
	public abstract record Game {
		public string Title { get; init; }

		public string ImageLocation { get; init; }

		public string AudioLocation { get; init; }

		public int ReleaseYear { get; init; }

		public string FileLocation { get; set; }

		public GameCategories Categories { get; init; }
	}
}
