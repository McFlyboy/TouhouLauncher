using Microsoft.Win32;
using System;
using TouhouLauncher.Model.GameInfo;
using TouhouLauncher.Model.Serialization;
using TouhouLauncher.Model.Serialization.Yaml;
using TouhouLauncher.Model.Settings;

namespace TouhouLauncher.Model {
	public class GameConfigModel {
		public string GameTitle {
			get {
				return _game == null ? "" : _game.Title + ": " + _game.Subtitle;
			}
		}
		public string GameLocation { get; set; }

		private Game _game;
		public GameConfigModel() {
			GameLocation = "";
			_game = null;
		}
		public void Browse() {
			OpenFileDialog fileDialog = new OpenFileDialog {
				Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*"
			};
			if (!(fileDialog.ShowDialog() ?? false)) {
				return;
			}
			GameLocation = fileDialog.FileName;
		}
		public void SaveGameConfig() {
			_game.LocalFileLocation = GameLocation;
			SettingsSerializerService.Instance.SerializeToFile(
				SettingsYaml.FromDomain(
					Tuple.Create(
						GameDB.Instance.OfficialGames,
						GameDB.Instance.FanGames,
						SettingsManager.Instance.GeneralSettings
					)
				)
			);
		}
		public void LoadGameConfig(Game game) {
			_game = game;
			GameLocation = _game.LocalFileLocation;
		}
	}
}
