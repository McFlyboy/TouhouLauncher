using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model.Serialization {
	[Serializable]
	public sealed class Settings {
		public static Settings Instance { get; set; }

		[NonSerialized]
		private static readonly string _fileName;

		[NonSerialized]
		private static readonly XmlSerializer _serializer;

		static Settings() {
			_fileName = "Settings.xml";
			_serializer = new XmlSerializer(typeof(Settings));
			Instance = LoadInstance() ?? new Settings();
		}

		public static Settings LoadInstance() {
			if (!File.Exists(_fileName)) {
				return null;
			}
			Settings instance = null;
			using (var fileStream = File.Create(_fileName)) {
				instance = (Settings)_serializer.Deserialize(fileStream);
			}
			return instance;
		}

		/* ---------------------------------------------------------------- */
		/* ------------------------- APP SETTINGS ------------------------- */
		/* ---------------------------------------------------------------- */

		// --Storage--
		public string[] LocalOfficialGameLocations { get; set; }
		public List<FanGame> FanGames { get; set; }

		// --General settings--
		public bool CloseOnGameLaunch { get; set; }

		/* ---------------------------------------------------------------- */

		private Settings() {
			LocalOfficialGameLocations = new string[28]; //Amount of games
			FanGames = new List<FanGame>();
			CloseOnGameLaunch = false;
		}

		/* ---------------------------------------------------------------- */
		/* ---------------------------------------------------------------- */

		public void Save() {
			using (var fileStream = File.Create(_fileName)) {
				_serializer.Serialize(fileStream, this);
			}
		}
	}
}
