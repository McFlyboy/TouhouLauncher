using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application;

public class ActiveGameCategory(GameCategoryService gameCategoryService)
{
    public GameCategories CurrentCategory { get; set; } = gameCategoryService.GetDefaultGameCategory();
}
