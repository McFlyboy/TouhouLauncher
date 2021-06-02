using TouhouLauncher.Models.Application;
using Xunit;

namespace TouhouLauncher.Test.Models.Application {
	public class OfficialGamesTemplateServiceTest {
		private readonly OfficialGamesTemplateService _officialGamesTemplateService = new();

		[Fact]
		public void Returns_all_official_games() {
			var result = _officialGamesTemplateService.CreateOfficialGamesFromTemplate();

			Assert.NotNull(result);
			Assert.Equal(29, result.Length);
		}
	}
}
