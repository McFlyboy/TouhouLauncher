#nullable disable

namespace TouhouLauncher.Models.Application.GameInfo {
	public abstract record Game {
		public string Title { get; set; }

		public string ImageLocation { get; set; }

		public string AudioLocation { get; set; }

		public int ReleaseYear { get; set; }

		public string FileLocation { get; set; }

		public GameCategories Categories { get; init; }
	}
}
