#nullable disable

using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class GameConfig {
		private readonly SettingsAndGamesManager _settingsAndGamesManager;

		public GameConfig(SettingsAndGamesManager settingsAndGamesManager) {
			_settingsAndGamesManager = settingsAndGamesManager;

			TargetGame = null;
			GameLocation = string.Empty;
		}
		
		public Game TargetGame { get; private set; }

		public string GameLocation { get; set; }

		public async Task<bool> SaveAsync() {
			if (TargetGame == null) {
				return false;
			}

			TargetGame.FileLocation = GameLocation;
			return await _settingsAndGamesManager.SaveAsync();
		}

		public void SetGameToConfigure(Game game) {
			TargetGame = game;
			GameLocation = TargetGame.FileLocation;
		}
	}
}
