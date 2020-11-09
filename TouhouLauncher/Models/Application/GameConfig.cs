using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Models.Application {
	public class GameConfig {
		private readonly SettingsManager _settingsManager;

		public GameConfig(SettingsManager settingsManager) {
			_settingsManager = settingsManager;

			Game = null;
			GameLocation = "";
		}
		
		public Game Game { get; private set; }

		public string GameLocation { get; set; }

		public void Save() {
			Game.FileLocation = GameLocation;
			_settingsManager.Save();
		}

		public void SetGameToConfigure(Game game) {
			Game = game;
			GameLocation = Game.FileLocation;
		}
	}
}
