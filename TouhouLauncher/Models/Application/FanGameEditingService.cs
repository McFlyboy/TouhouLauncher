using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application {
	public class FanGameEditingService {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public FanGameEditingService(SettingsAndGamesManager settingsAndGamesManager) {
			_settingsAndGamesManager = settingsAndGamesManager;

			TargetFanGame = null;
			GameTitle = string.Empty;
			YearOfRelease = string.Empty;
			GameLocation = string.Empty;
			CoverImageLocation = string.Empty;
		}

		public FanGame? TargetFanGame { get; private set; }

		public string GameTitle { get; set; }

		public string YearOfRelease { get; set; }

		public string GameLocation { get; set; }

		public string CoverImageLocation { get; set; }

		public async Task<TouhouLauncherError?> SaveAsync() {
			if (TargetFanGame == null) {
				TargetFanGame = new(
					title: GameTitle,
					imageLocation: CoverImageLocation,
					audioLocation: null,
					releaseYear: int.Parse(YearOfRelease),
					fileLocation: GameLocation
				);

				_settingsAndGamesManager.FanGames.Add(TargetFanGame);
			}
			else {
				TargetFanGame.Title = GameTitle;
				TargetFanGame.ImageLocation = CoverImageLocation;
				TargetFanGame.AudioLocation = null;
				TargetFanGame.ReleaseYear = int.Parse(YearOfRelease);
				TargetFanGame.FileLocation = GameLocation;
			}

			return await _settingsAndGamesManager.SaveAsync();
		}

		public void SetFanGameToEdit(FanGame? fanGame) {
			TargetFanGame = fanGame;
			GameTitle = fanGame?.Title ?? string.Empty;
			YearOfRelease = fanGame?.ReleaseYear?.ToString() ?? string.Empty;
			GameLocation = fanGame?.FileLocation ?? string.Empty;
			CoverImageLocation = fanGame?.ImageLocation ?? string.Empty;
		}
	}
}
