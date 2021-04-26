using System;
using System.Collections.Generic;
using System.Linq;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Services.Application
{
    public class LaunchRandomGameService
    {
		private readonly SettingsManager _settingsManager;
		private readonly ActivateGameService _activateGameService;
		private readonly Random _random;

		public LaunchRandomGameService(
			SettingsManager settingsManager,
			ActivateGameService activateGameService,
			Random random
		)
        {
			_settingsManager = settingsManager;
			_activateGameService = activateGameService;
			_random = random;
		}

        public bool LaunchRandomGame()
        {
			var officialGames = _settingsManager.OfficialGames
				.Where(game => game.FileLocation != string.Empty)
				.Select(game => (Game)game)
				.ToList();

			var fanGames = _settingsManager.FanGames
				.Select(game => (Game)game)
				.ToList();

			var allGames = new List<Game>();
			allGames.AddRange(officialGames);
			allGames.AddRange(fanGames);

			if (allGames.Count == 0)
			{
				//TODO: show error
				return false;
			}

			int randomNumber = _random.Next(allGames.Count);
			var selectedGame = allGames[randomNumber];

			_activateGameService.LaunchGame(selectedGame);
			return true;
		}
    }
}
