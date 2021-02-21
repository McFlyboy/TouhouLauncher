using Moq;
using System.Collections.Generic;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using Xunit;

namespace TouhouLauncher.Test.Models.Application {
	public class GamePickerListTest {
		private readonly GamePickerList _gamePickerList;

		private readonly Mock<SettingsManager> _settingsManagerMock;

		public GamePickerListTest() {
			_settingsManagerMock = new Mock<SettingsManager>(null, null);
			_gamePickerList = new GamePickerList(_settingsManagerMock.Object);
		}

		[Fact]
		public void Populates_game_list_with_fan_games_when_fan_game_flag_selected() {
			_settingsManagerMock
				.SetupGet(obj => obj.FanGames)
				.Returns(new List<FanGame>() {
					new() { Title = "some game title" },
					new() { Title = "some other game title" },
					new() { Title = "another game title" }
				});

			_gamePickerList.PopulateGameList(GameCategories.FanGame);

			Assert.Equal(3, _gamePickerList.GameList.Count);
			Assert.Equal("some game title", _gamePickerList.GameList[0].Title);
			Assert.Equal("some other game title", _gamePickerList.GameList[1].Title);
			Assert.Equal("another game title", _gamePickerList.GameList[2].Title);
		}

		[Fact]
		public void Populates_game_list_with_official_games_that_fits_the_specified_flags() {
			_settingsManagerMock
				.SetupGet(obj => obj.OfficialGames)
				.Returns(new OfficialGame[] {
					new() {
						Title = "some game title",
						Categories = GameCategories.MainWindows
					},
					new() {
						Title = "some spinoff title",
						Categories = GameCategories.SpinOff
					},
					new() {
						Title = "an old game title",
						Categories = GameCategories.MainPC98
					}
				});

			_gamePickerList.PopulateGameList(
				GameCategories.MainGame
			);

			Assert.Equal(2, _gamePickerList.GameList.Count);
			Assert.Equal("some game title", _gamePickerList.GameList[0].Title);
			Assert.Equal("an old game title", _gamePickerList.GameList[1].Title);
		}
	}
}
