namespace TouhouLauncher.Models.Application.GameInfo {
	public class FanGame : Game {
		public FanGame() {
			Categories = GameCategories.FanGame;
        }

		public GameCategories Categories { get; }
	}
}
