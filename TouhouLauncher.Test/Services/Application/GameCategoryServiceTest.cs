using Moq;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using Xunit;

namespace TouhouLauncher.Test.Services.Application {
	public class GameCategoryServiceTest {
		private readonly GameCategoryService _gameCategoryService;

		private readonly Mock<SettingsManager> _settingsManagerMock;

		public GameCategoryServiceTest() {
			_settingsManagerMock = new Mock<SettingsManager>(null, null);
			_gameCategoryService = new GameCategoryService(_settingsManagerMock.Object);
		}

		[Fact]
		public void Combines_main_categories_when_combine_setting_is_enabled() {
			_settingsManagerMock
				.SetupGet(obj => obj.GeneralSettings)
				.Returns(new GeneralSettings() { CombineMainCategories = true });

			Assert.Equal(
				OfficialGame.CategoryFlag.MainPC98 | OfficialGame.CategoryFlag.MainWindows,
				_gameCategoryService.CreateGameCategoryList()[0]
			);

			Assert.Equal(
				OfficialGame.CategoryFlag.MainPC98 | OfficialGame.CategoryFlag.MainWindows,
				_gameCategoryService.GetDefaultGameCategory()
			);
		}

		[Fact]
		public void Separates_main_categories_when_combine_setting_is_disabled() {
			_settingsManagerMock
				.SetupGet(obj => obj.GeneralSettings)
				.Returns(new GeneralSettings() { CombineMainCategories = false });

			var categoryList = _gameCategoryService.CreateGameCategoryList();
			Assert.Equal(OfficialGame.CategoryFlag.MainPC98, categoryList[0]);
			Assert.Equal(OfficialGame.CategoryFlag.MainWindows, categoryList[1]);

			Assert.Equal(
				OfficialGame.CategoryFlag.MainWindows,
				_gameCategoryService.GetDefaultGameCategory()
			);
		}
	}
}
