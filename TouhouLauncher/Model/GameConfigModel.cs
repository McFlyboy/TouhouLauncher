using Microsoft.Win32;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model {
	public class GameConfigModel {
		public string GameTitle {
			get {
				if (_game == null) {
					return "";
				}
				return _game.Title + ": " + _game.Subtitle;
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
			fileDialog.ShowDialog();
			if (fileDialog.FileName.Length == 0) {
				return;
			}
			GameLocation = fileDialog.FileName;
		}
		public void SaveGameConfig() {
			_game.LocalFileLocation = GameLocation;
			GameDB.Instance.SaveDBUserContent();
		}
		public void LoadGameConfig(Game game) {
			_game = game;
			GameLocation = _game.LocalFileLocation;
		}
	}
}
