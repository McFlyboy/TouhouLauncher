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
			List<Game> allGames = _settingsAndGamesManager.OfficialGames
				.Cast<Game>()
				.Concat(
					_settingsAndGamesManager.FanGames
						.Cast<Game>()
				)
				.Where(game => !string.IsNullOrEmpty(game.FileLocation) && game.IncludeInRandomGame)
				.ToList();

			if (allGames.Count == 0) {
				return new LaunchRandomGameServiceError.NoGamesFoundError();
			}

			int randomNumber = _random.Next(allGames.Count);
			Game selectedGame = allGames[randomNumber];

			return await _launchGameService.LaunchGame(selectedGame);
		}
	}

	public abstract record LaunchRandomGameServiceError : TouhouLauncherError {
		public record NoGamesFoundError : LaunchRandomGameServiceError {
			public override string Message => "Could not find any games to start that matched the filtered search";
		}
	}
}
