using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class ActiveGameCategory {

		public ActiveGameCategory(GameCategoryService gameCategoryService) {
			CurrentCategory = gameCategoryService.GetDefaultGameCategory();
		}

		public GameCategories CurrentCategory { get; set; }
	}
}
