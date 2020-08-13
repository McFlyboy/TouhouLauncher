using Microsoft.Win32;
using TouhouLauncher.Model.GameInfo;
using TouhouLauncher.Model.Serialization;

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
			Settings.Instance.Save();
		}
		public void LoadGameConfig(Game game) {
			_game = game;
			GameLocation = _game.LocalFileLocation;
		}
	}
}
