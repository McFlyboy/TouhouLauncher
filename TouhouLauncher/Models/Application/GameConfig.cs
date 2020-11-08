using Microsoft.Win32;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application;

namespace TouhouLauncher.Models.Application {
	public class GameConfig {
		private readonly GameDB _gameDB;
		private readonly SettingsContainer _settingsContainer;
		private readonly ISettingsService _settingsService;

		private Game _game;

		public GameConfig(
			GameDB gameDB,
			SettingsContainer settingsContainer,
			ISettingsService settingsService
		) {
			_gameDB = gameDB;
			_settingsContainer = settingsContainer;
			_settingsService = settingsService;

			_game = null;
			GameLocation = "";
		}

		public string GameTitle => _game != null
			? $"{_game.Title}: {_game.Subtitle}"
			: string.Empty;

		public string GameLocation { get; set; }

		public void Browse() {
			OpenFileDialog fileDialog = new OpenFileDialog {
				Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*"
			};
			if (fileDialog.ShowDialog() ?? false) {
				GameLocation = fileDialog.FileName;
			}
		}

		public void SaveGameLocation() {
			_game.FileLocation = GameLocation;

			_settingsService.Save(
				_gameDB.OfficialGames,
				_gameDB.FanGames,
				_settingsContainer.GeneralSettings
			);
		}

		public void SetGameToConfigure(Game game) {
			_game = game;
			GameLocation = _game.FileLocation;
		}
	}
}
