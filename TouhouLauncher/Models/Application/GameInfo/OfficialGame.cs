namespace TouhouLauncher.Models.Application.GameInfo {
	public record OfficialGame : Game {
		public OfficialGame(
			string title,
			string? imageLocation,
			string? audioLocation,
			int? releaseYear,
			string? fileLocation,
			GameCategories categories,
			string downloadableFileLocation
		) : base(
			title: title,
			imageLocation: imageLocation,
			audioLocation: audioLocation,
			releaseYear: releaseYear,
			fileLocation: fileLocation,
			categories: categories
		) {
			DownloadableFileLocation = downloadableFileLocation;
		}

		public string DownloadableFileLocation { get; init; }
	}
}
