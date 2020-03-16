using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model.Serialization {
	[Serializable]
	public class Settings {
		public static Settings Instance {
			get {
				if (_instance == null) {
					_instance = new Settings();
				}
				return _instance;
			}
		}
		[NonSerialized]
		private static Settings _instance;
		[NonSerialized]
		private const string _fileName = "Settings.xml";
		[NonSerialized]
		private static readonly XmlSerializer _serializer = new XmlSerializer(typeof(Settings));

		//DB-settings
		public string[] LocalOfficialGameFileLocations { get; set; }
		public List<FanGame> FanGames { get; set; }

		//General settings
		public bool CloseOnGameLaunch { get; set; }

		private Settings() {
			GameDB gameDB = GameDB.Instance;
			LocalOfficialGameFileLocations = new string[gameDB.OfficialGames.Length];
			FanGames = gameDB.FanGames;
			CloseOnGameLaunch = false;
		}
		public void Save() {
			GameDB gameDB = GameDB.Instance;
			for (int i = 0; i < gameDB.OfficialGames.Length; i++) {
				LocalOfficialGameFileLocations[i] = gameDB.OfficialGames[i].LocalFileLocation;
			}
			FileStream file = File.Create(_fileName);
			_serializer.Serialize(file, this);
			file.Close();
		}
		public static void LoadInstance() {
			if (!File.Exists(_fileName)) {
				return;
			}
			FileStream file = File.OpenRead(_fileName);
			Settings instance = (Settings)_serializer.Deserialize(file);
			file.Close();
			_instance = instance;
			GameDB gameDB = GameDB.Instance;
			int locationSize = Math.Min(gameDB.OfficialGames.Length, _instance.LocalOfficialGameFileLocations.Length);
			for (int i = 0; i < locationSize; i++) {
				gameDB.OfficialGames[i].LocalFileLocation = _instance.LocalOfficialGameFileLocations[i];
			}
			gameDB.FanGames = _instance.FanGames;
		}
	}
}
