using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Services;

namespace TouhouLauncher.Models {
	public class ActiveGameCategory {
		private readonly GameCategoryService _gameCategoryService;

		public ActiveGameCategory(GameCategoryService gameCategoryService) {
			_gameCategoryService = gameCategoryService;

			CurrentCategory = _gameCategoryService.GetDefaultGameCategory();
		}

		public OfficialGame.CategoryFlag CurrentCategory { get; set; }
	}
}
