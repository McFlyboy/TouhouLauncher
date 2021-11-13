namespace TouhouLauncher.Models.Application.GameInfo {
	public abstract record Game {
		public Game(
			string title,
			string? imageLocation,
			string? audioLocation,
			int? releaseYear,
			string? fileLocation,
			bool includeInRandomGame,
			GameCategories categories
		) {
			Title = title;
			ImageLocation = imageLocation;
			AudioLocation = audioLocation;
			ReleaseYear = releaseYear;
			FileLocation = fileLocation;
			IncludeInRandomGame = includeInRandomGame;
			Categories = categories;
		}

		public string Title { get; set; }

		public string? ImageLocation { get; set; }

		public string? AudioLocation { get; set; }

		public int? ReleaseYear { get; set; }

		public string? FileLocation { get; set; }

		public bool IncludeInRandomGame { get; set; }

		public GameCategories Categories { get; init; }
	}
}
