using Microsoft.Win32;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.Models.Settings;
using TouhouLauncher.Services.Serialization;

namespace TouhouLauncher.Models {
	public class GameConfigModel {
		private Game _game;
		private readonly GameDB _gameDB;
		private readonly SettingsContainer _settingsContainer;
		private readonly SettingsSerializerService _settingsSerializerService;

		public GameConfigModel(
			GameDB gameDB,
			SettingsContainer settingsContainer,
			SettingsSerializerService settingsSerializerService
		) {
			_game = null;
			_gameDB = gameDB;
			_settingsContainer = settingsContainer;
			_settingsSerializerService = settingsSerializerService;
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
			_settingsSerializerService.SerializeToFile(
				new Settings.Settings() {
					OfficialGames = _gameDB.OfficialGames,
					FanGames = _gameDB.FanGames,
					GeneralSettings = _settingsContainer.GeneralSettings
				}
			);
		}

		public void LoadGameConfig(Game game) {
			_game = game;
			GameLocation = _game.FileLocation;
		}
	}
}
