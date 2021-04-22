using TouhouLauncher.Services.Application;
using Xunit;

namespace TouhouLauncher.Test.Services.Application {
	public class OfficialGamesTemplateServiceTest {
		private readonly OfficialGamesTemplateService _officialGamesTemplateService;

		public OfficialGamesTemplateServiceTest() {
			_officialGamesTemplateService = new();
		}

		[Fact]
		public void Returns_all_official_games() {
			Assert.Equal(29, _officialGamesTemplateService.CreateOfficialGamesFromTemplate().Length);
		}
	}
}
