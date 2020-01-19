using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TouhouLauncher.Model.Serialization;

namespace TouhouLauncher.Model.GameInfo {
	public class GameDB {
		public static GameDB Instance {
			get {
				if (_instance == null) {
					_instance = new GameDB();
				}
				return _instance;
			}
		}
		private static GameDB _instance;

		public OfficialGame[] OfficialGames { get; }
		public List<FanGame> FanGames { get; set; }
		private GameDB() {
			OfficialGames = new OfficialGame[] {
				new OfficialGame() {
					Title = "Touhou 01",
					Subtitle = "Highly Responsive to Prayers",
					ImageLocation = "..\\Resources\\Images\\OfficialGames\\TH01.png",
					AudioLocation = "",
					ReleaseYear = 1996,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 02",
					Subtitle = "Story of Eastern Wonderland",
					ImageLocation = "..\\Resources\\Images\\OfficialGames\\TH02.png",
					AudioLocation = "",
					ReleaseYear = 1997,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 03",
					Subtitle = "Phantasmagoria of Dim. Dream",
					ImageLocation = "..\\Resources\\Images\\OfficialGames\\TH03.png",
					AudioLocation = "",
					ReleaseYear = 1997,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 04",
					Subtitle = "Lotus Land Story",
					ImageLocation = "..\\Resources\\Images\\OfficialGames\\TH04.png",
					AudioLocation = "",
					ReleaseYear = 1998,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 05",
					Subtitle = "Mystic Square",
					ImageLocation = "..\\Resources\\Images\\OfficialGames\\TH05.png",
					AudioLocation = "",
					ReleaseYear = 1998,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 06",
					Subtitle = "Embodyment of Scarlet Devil",
					ImageLocation = "..\\Resources\\Images\\OfficialGames\\TH06.png",
					AudioLocation = "",
					ReleaseYear = 2002,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 07",
					Subtitle = "Perfect Cherry Blossom",
					ImageLocation = "..\\Resources\\Images\\OfficialGames\\TH07.png",
					AudioLocation = "",
					ReleaseYear = 2003,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				}
			};
			FanGames = new List<FanGame>();
		}
		public void LoadDBUserContent() {
			XmlSerializer reader = new XmlSerializer(typeof(UserDefinedGameInfo));
			if (!File.Exists("Game-info.xml")) {
				return;
			}
			FileStream file = File.OpenRead("Game-info.xml");
			UserDefinedGameInfo content = (UserDefinedGameInfo)reader.Deserialize(file);
			file.Close();
			FanGames = content.FanGames;
			for (int i = 0; i < OfficialGames.Length; i++) {
				OfficialGames[i].LocalFileLocation = content.LocalOfficialGameFileLocations[i];
			}
		}
		[Serializable()]
		public class UserDefinedGameInfo {
			public string[] LocalOfficialGameFileLocations { get; set; }
			public List<FanGame> FanGames { get; set; }
		}
	}
}
