#nullable disable

using Moq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;

namespace TouhouLauncher.Test.Models.Application {
	public class GamePickerListTest {
		private readonly Mock<SettingsAndGamesManager> _settingsAndGamesManagerMock = new(null, null);

		private readonly GamePickerList _gamePickerList;

		public GamePickerListTest() {
			_gamePickerList = new(_settingsAndGamesManagerMock.Object);
		}

		[Fact]
		public void Populates_list_with_no_games_when_no_categories() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.OfficialGames)
				.Returns(testOfficialGames);

			_gamePickerList.PopulateGameList(GameCategories.None);

			Assert.Empty(_gamePickerList.GameList);
		}

		[Fact]
		public void Populates_list_with_games_from_categories() {
			_settingsAndGamesManagerMock.SetupGet(obj => obj.OfficialGames)
				.Returns(testOfficialGames);

			_gamePickerList.PopulateGameList(GameCategories.MainGame);

			Assert.Equal(2, _gamePickerList.GameList.Count);
		}
	}
}
