#nullable disable

namespace TouhouLauncher.Models.Application.GameInfo {
	public record FanGame : Game {
		public FanGame() {
			base.Categories = GameCategories.FanGame;
        }

		public new GameCategories Categories => base.Categories;
	}
}
