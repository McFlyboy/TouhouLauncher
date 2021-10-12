using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application {
	public class GameConfigService {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public GameConfigService(SettingsAndGamesManager settingsAndGamesManager) {
			_settingsAndGamesManager = settingsAndGamesManager;

			TargetGame = null;
			GameLocation = string.Empty;
		}
		
		public Game? TargetGame { get; private set; }

		public string GameLocation { get; set; }

		public async Task<TouhouLauncherError?> SaveAsync() {
			if (TargetGame == null) {
				return new TargetGameNotSetError();
			}

			TargetGame.FileLocation = GameLocation;
			return await _settingsAndGamesManager.SaveAsync();
		}

		public void SetGameToConfigure(Game game) {
			TargetGame = game;
			GameLocation = TargetGame.FileLocation ?? string.Empty;
		}
	}

	public record TargetGameNotSetError : TouhouLauncherError {
		public override string Message => "Target game to configure was not set correctly";
	}
}
