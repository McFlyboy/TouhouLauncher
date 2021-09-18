using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application {
	public class LaunchRandomGameService {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;
		private readonly LaunchGameService _launchGameService;
		private readonly Random _random;

		public LaunchRandomGameService(
			SettingsAndGamesManager settingsAndGamesManager,
			LaunchGameService launchGameService,
			Random random
		) {
			_settingsAndGamesManager = settingsAndGamesManager;
			_launchGameService = launchGameService;
			_random = random;
		}

		public async Task<TouhouLauncherError?> LaunchRandomGame() {
			List<Game> officialGames = _settingsAndGamesManager.OfficialGames
				.Where(game => !string.IsNullOrEmpty(game.FileLocation))
				.Select(game => (Game)game)
				.ToList();

			List<Game> fanGames = _settingsAndGamesManager.FanGames
				.Select(game => (Game)game)
				.ToList();

			List<Game> allGames = officialGames.Concat(fanGames)
				.ToList();

			if (allGames.Count == 0) {
				return new LaunchRandomGameServiceError.NoGamesAddedError();
			}

			int randomNumber = _random.Next(allGames.Count);
			Game selectedGame = allGames[randomNumber];

			return await _launchGameService.LaunchGame(selectedGame);
		}
	}

	public abstract record LaunchRandomGameServiceError : TouhouLauncherError {
		public record NoGamesAddedError : LaunchRandomGameServiceError {
			public override string Message => "You must add at least one game before you can launch one at random";
		}
	}
}
