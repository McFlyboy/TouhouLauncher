using System;
using System.Collections.Generic;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Models.Infrastructure.Serialization;
using Xunit;

namespace TouhouLauncher.Test.Models.Infrastructure.Serialization {
	public class SerializableSettingsTest {
		[Fact]
		public void Converts_serializable_settings_to_domain_settings() {
			var settings = new SerializableSettings() {
				OfficialGames = new SerializableOfficialGame[] {
					new() { FileLocation = "Underwater" },
					new() { FileLocation = "On mars" }
				},
				FanGames = new List<SerializableFanGame>() {
					new() { Title = "Touhou", Subtitle = "Game" },
					new() { Title = "Another Touhou", Subtitle = "Another game" }
				},
				GeneralSettings = new() { CloseOnGameLaunch = true}
			};

			var result = settings.ToDomain(new OfficialGame[] {
				new() { Title = "An official game" },
				new() { Title = "Another official game" }
			});

			Assert.NotNull(result);

			var (officialGames, fanGames, generalSettings) = result;

			Assert.NotNull(officialGames);
			Assert.NotNull(fanGames);
			Assert.NotNull(generalSettings);

			Assert.Equal("An official game", officialGames[0].Title);
			Assert.Equal("On mars", officialGames[1].FileLocation);

			Assert.Equal("Another Touhou", fanGames[1].Title);
			Assert.Equal("Game", fanGames[0].Subtitle);

			Assert.True(generalSettings.CloseOnGameLaunch);
			Assert.False(generalSettings.CombineMainCategories);
		}

		[Fact]
		public void Converts_domain_settings_to_serializable_settings() {
			var officialGames = new OfficialGame[] {
				new() { Title = "An official game", FileLocation = "Underwater" },
				new() { Title = "Another official game", FileLocation = "On mars" }
			};
			var fanGames = new List<FanGame>() {
				new() { Title = "Touhou", Subtitle = "Game" },
				new() { Title = "Another Touhou", Subtitle = "Another game" }
			};
			var generalSettings = new GeneralSettings() { CloseOnGameLaunch = true };

			var result = SerializableSettings.FromDomain(officialGames, fanGames, generalSettings);

			Assert.NotNull(result);

			Assert.Equal("Underwater", result.OfficialGames[0].FileLocation);
			Assert.Equal("On mars", result.OfficialGames[1].FileLocation);

			Assert.Equal("Another Touhou", result.FanGames[1].Title);
			Assert.Equal("Game", result.FanGames[0].Subtitle);

			Assert.True(result.GeneralSettings.CloseOnGameLaunch);
			Assert.False(result.GeneralSettings.CombineMainCategories);
		}
	}
}
