using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using Xunit;

namespace TouhouLauncher.Test.Models.Application;

public class OfficialGamesTemplateServiceTest
{
    private readonly OfficialGamesTemplateService _officialGamesTemplateService = new();

    [Fact]
    public void Returns_all_official_games()
    {
        OfficialGame[] result = _officialGamesTemplateService.CreateOfficialGamesFromTemplate();

        Assert.Equal(30, result.Length);
    }
}
