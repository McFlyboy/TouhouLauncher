#nullable disable

using Moq;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;
using Xunit;

namespace TouhouLauncher.Test.Models.Application {
	public class GameCategoryServiceTest {
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);

		private readonly GameCategoryService _gameCategoryService;

		public GameCategoryServiceTest() {
			_gameCategoryService = new(_settingsAndGamesManagerMock.Object);
		}

		[Fact]
		public void Combines_main_categories_when_combine_setting_is_enabled() {
			_settingsAndGamesManagerMock
				.SetupGet(obj => obj.GeneralSettings)
				.Returns(
					new GeneralSettings(
						closeOnGameLaunch: false,
						combineMainCategories: true
					)
				);

			Assert.Equal(
				GameCategories.MainGame,
				_gameCategoryService.CreateGameCategoryList().First()
			);

			Assert.Equal(
				GameCategories.MainGame,
				_gameCategoryService.GetDefaultGameCategory()
			);
		}

		[Fact]
		public void Separates_main_categories_when_combine_setting_is_disabled() {
			_settingsAndGamesManagerMock
				.SetupGet(obj => obj.GeneralSettings)
				.Returns(
					new GeneralSettings(
						closeOnGameLaunch: false,
						combineMainCategories: false
					)
				);

			var categoryList = _gameCategoryService.CreateGameCategoryList();
			Assert.Equal(GameCategories.MainPC98, categoryList[0]);
			Assert.Equal(GameCategories.MainWindows, categoryList[1]);

			Assert.Equal(
				GameCategories.MainWindows,
				_gameCategoryService.GetDefaultGameCategory()
			);
		}
	}
}
