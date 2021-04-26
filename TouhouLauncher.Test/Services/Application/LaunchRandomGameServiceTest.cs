using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;
using Xunit;

namespace TouhouLauncher.Test.Services.Application
{
    public class LaunchRandomGameServiceTest
    {
        private readonly Mock<SettingsManager> _settingsManagerMock;
        private readonly Mock<ActivateGameService> _activateGameServiceMock;
        private readonly Mock<Random> _randomMock;
        private readonly LaunchRandomGameService _launchRandomGameService;
        
        public LaunchRandomGameServiceTest()
        {
            _settingsManagerMock = new Mock<SettingsManager>(null, null);
            _activateGameServiceMock = new Mock<ActivateGameService>(null, null);
            _randomMock = new Mock<Random>();
            _launchRandomGameService = new LaunchRandomGameService(_settingsManagerMock.Object, _activateGameServiceMock.Object, _randomMock.Object);
        }

        [Fact]
        public void Does_not_start_a_game_when_no_games_exist()
        {
            _settingsManagerMock
                .SetupGet(obj => obj.OfficialGames)
                .Returns(new OfficialGame[0]);

            _settingsManagerMock
                .SetupGet(obj => obj.FanGames)
                .Returns(new List<FanGame>());

            var result = _launchRandomGameService.LaunchRandomGame();
            Assert.False(result);
        }
    }
}
