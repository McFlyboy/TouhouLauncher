using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Models.Application {
	public class GameConfig {
		private readonly SettingsManager _settingsManager;

		private Game _game;

		public GameConfig(SettingsManager settingsManager) {
			_settingsManager = settingsManager;

			_game = null;
			GameLocation = "";
		}

		public string GameTitle => _game != null
			? $"{_game.Title}: {_game.Subtitle}"
			: string.Empty;

		public string GameLocation { get; set; }

		public void SaveGameLocation() {
			_game.FileLocation = GameLocation;
			_settingsManager.Save();
		}

		public void SetGameToConfigure(Game game) {
			_game = game;
			GameLocation = _game.FileLocation;
		}
	}
}
