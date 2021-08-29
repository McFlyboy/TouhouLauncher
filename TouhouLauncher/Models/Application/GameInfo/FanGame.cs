namespace TouhouLauncher.Models.Application.GameInfo {
	public record FanGame : Game {
		public FanGame(
			string title,
			string imageLocation,
			string audioLocation,
			int releaseYear,
			string fileLocation
		) : base(
			title: title,
			imageLocation: imageLocation,
			audioLocation: audioLocation,
			releaseYear: releaseYear,
			fileLocation: fileLocation,
			categories: GameCategories.FanGame
		) { }
	}
}
