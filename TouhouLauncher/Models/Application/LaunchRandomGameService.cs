﻿using System;
using System.Linq;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class LaunchRandomGameService {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;
		private readonly ActivateGameService _activateGameService;
		private readonly Random _random;

		public LaunchRandomGameService(
			SettingsAndGamesManager settingsAndGamesManager,
			ActivateGameService activateGameService,
			Random random
		) {
			_settingsAndGamesManager = settingsAndGamesManager;
			_activateGameService = activateGameService;
			_random = random;
		}

		public bool LaunchRandomGame() {
			var officialGames = _settingsAndGamesManager.OfficialGames
				.Where(game => game.FileLocation != string.Empty)
				.Select(game => (Game)game)
				.ToList();

			var fanGames = _settingsAndGamesManager.FanGames
				.Select(game => (Game)game)
				.ToList();

			var allGames = officialGames.Concat(fanGames)
				.ToList();

			if (allGames.Count == 0) {
				return false;
			}

			int randomNumber = _random.Next(allGames.Count);
			var selectedGame = allGames[randomNumber];

			return _activateGameService.LaunchGame(selectedGame);
		}
	}
}