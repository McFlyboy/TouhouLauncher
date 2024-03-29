﻿using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application {
	public class FanGameEditingService {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public FanGameEditingService(SettingsAndGamesManager settingsAndGamesManager) {
			_settingsAndGamesManager = settingsAndGamesManager;

			TargetFanGame = null;
			GameTitle = string.Empty;
			YearOfRelease = null;
			GameLocation = string.Empty;
			CoverImageLocation = null;
			IncludeInRandomGame = true;
		}

		public FanGame? TargetFanGame { get; private set; }

		public string GameTitle { get; set; }

		public int? YearOfRelease { get; set; }

		public string GameLocation { get; set; }

		public string? CoverImageLocation { get; set; }

		public bool IncludeInRandomGame { get; set; }

		public async Task<TouhouLauncherError?> SaveAsync() {
			if (GameTitle.Length == 0 || GameLocation.Length == 0) {
				return new FanGameInfoMissingError();
			}

			if (TargetFanGame == null) {
				TargetFanGame = new(
					title: GameTitle,
					imageLocation: CoverImageLocation,
					audioLocation: null,
					releaseYear: YearOfRelease,
					fileLocation: GameLocation,
					includeInRandomGame: IncludeInRandomGame
				);

				_settingsAndGamesManager.FanGames.Add(TargetFanGame);
			}
			else {
				TargetFanGame.Title = GameTitle;
				TargetFanGame.ImageLocation = CoverImageLocation;
				TargetFanGame.AudioLocation = null;
				TargetFanGame.ReleaseYear = YearOfRelease;
				TargetFanGame.FileLocation = GameLocation;
				TargetFanGame.IncludeInRandomGame = IncludeInRandomGame;
			}

			return await _settingsAndGamesManager.SaveAsync();
		}

		public async Task<TouhouLauncherError?> DeleteFanGame() {
			if (TargetFanGame == null) {
				return new FanGameNotSpecifiedError();
			}

			_settingsAndGamesManager.FanGames.Remove(TargetFanGame);

			return await _settingsAndGamesManager.SaveAsync();
		}

		public void SetFanGameToEdit(FanGame? fanGame) {
			TargetFanGame = fanGame;
			GameTitle = fanGame?.Title ?? string.Empty;
			YearOfRelease = fanGame?.ReleaseYear;
			GameLocation = fanGame?.FileLocation ?? string.Empty;
			CoverImageLocation = fanGame?.ImageLocation;
			IncludeInRandomGame = fanGame?.IncludeInRandomGame ?? true;
		}
	}

	public record FanGameInfoMissingError : TouhouLauncherError {
		public override string Message => "Game title and location must both be specified in order to add a new fan game";
	}

	public record FanGameNotSpecifiedError : TouhouLauncherError {
		public override string Message => "A fan game has not been specified";
	}
}
