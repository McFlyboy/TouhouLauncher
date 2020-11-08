using Microsoft.Win32;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.Settings;
using TouhouLauncher.Services.Application.Serialization;

namespace TouhouLauncher.Models.Application {
	public class GameConfig {
		private readonly GameDB _gameDB;
		private readonly SettingsContainer _settingsContainer;
		private readonly ISettingsSerializerService _settingsSerializerService;

		private Game _game;

		public GameConfig(
			GameDB gameDB,
			SettingsContainer settingsContainer,
			ISettingsSerializerService settingsSerializerService
		) {
			_gameDB = gameDB;
			_settingsContainer = settingsContainer;
			_settingsSerializerService = settingsSerializerService;

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

		public void SaveGameConfig() {
			_game.FileLocation = GameLocation;
			_settingsSerializerService.Serialize(
				new Settings.Settings() {
					OfficialGames = _gameDB.OfficialGames,
					FanGames = _gameDB.FanGames,
					GeneralSettings = _settingsContainer.GeneralSettings
				}
			);
		}

		public void SetGameToConfigure(Game game) {
			_game = game;
			GameLocation = _game.FileLocation;
		}
	}
}
