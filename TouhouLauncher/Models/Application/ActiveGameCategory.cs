using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Services.Application;

namespace TouhouLauncher.Models.Application {
	public class ActiveGameCategory {

		public ActiveGameCategory(GameCategoryService gameCategoryService) {
			CurrentCategory = gameCategoryService.GetDefaultGameCategory();
		}

		public OfficialGame.CategoryFlag CurrentCategory { get; set; }
	}
}
