using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
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

		public OfficialGame[] OfficialGames { get; private set; }
		public List<FanGame> FanGames { get; }
		private GameDB() {
			InitOfficialGames();
			FanGames = Settings.Instance.FanGames;
		}
		public void LaunchGame(string gameLocation, bool exitOnLaunch = false) {
			var startInfo = new ProcessStartInfo(gameLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);
			Process.Start(startInfo);
			if (exitOnLaunch) {
				Application.Current.Shutdown();
			}
		}
		private void InitOfficialGames() {
			OfficialGames = new OfficialGame[28] {
				new OfficialGame() {
					Title = "Touhou 01",
					Subtitle = "Highly Responsive to Prayers",
					ImageLocation = "..\\..\\Resources\\Images\\OfficialGames\\TH01.png",
					AudioLocation = "",
					ReleaseYear = 1996,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 02",
					Subtitle = "Story of Eastern Wonderland",
					ImageLocation = "..\\..\\Resources\\Images\\OfficialGames\\TH02.png",
					AudioLocation = "",
					ReleaseYear = 1997,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 03",
					Subtitle = "Phantasmagoria of Dim. Dream",
					ImageLocation = "..\\..\\Resources\\Images\\OfficialGames\\TH03.png",
					AudioLocation = "",
					ReleaseYear = 1997,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 04",
					Subtitle = "Lotus Land Story",
					ImageLocation = "..\\..\\Resources\\Images\\OfficialGames\\TH04.png",
					AudioLocation = "",
					ReleaseYear = 1998,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 05",
					Subtitle = "Mystic Square",
					ImageLocation = "..\\..\\Resources\\Images\\OfficialGames\\TH05.png",
					AudioLocation = "",
					ReleaseYear = 1998,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 06",
					Subtitle = "Embodyment of Scarlet Devil",
					ImageLocation = "..\\..\\Resources\\Images\\OfficialGames\\TH06.png",
					AudioLocation = "",
					ReleaseYear = 2002,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 07",
					Subtitle = "Perfect Cherry Blossom",
					ImageLocation = "..\\..\\Resources\\Images\\OfficialGames\\TH07.png",
					AudioLocation = "",
					ReleaseYear = 2003,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 07.5",
					Subtitle = "Immaterial and Missing Power",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2004,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.FightingGame
				},
				new OfficialGame() {
					Title = "Touhou 08",
					Subtitle = "Imperishable Night",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2004,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 09",
					Subtitle = "Phantasmagoria of Flower View",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2005,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 09.5",
					Subtitle = "Shoot the Bullet",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2005,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.SpinOff
				},
				new OfficialGame() {
					Title = "Touhou 10",
					Subtitle = "Mountain of Faith",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2007,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 10.5",
					Subtitle = "Scarlet Weather Rhapsody",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2008,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.FightingGame
				},
				new OfficialGame() {
					Title = "Touhou 11",
					Subtitle = "Subterranean Animism",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2008,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 12",
					Subtitle = "Undefined Fantastic Object",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2009,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 12.3",
					Subtitle = "Hisoutensoku",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2009,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.FightingGame
				},
				new OfficialGame() {
					Title = "Touhou 12.5",
					Subtitle = "Double Spoiler",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2010,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.SpinOff
				},
				new OfficialGame() {
					Title = "Touhou 12.8",
					Subtitle = "Great Fairy Wars",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2010,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.SpinOff
				},
				new OfficialGame() {
					Title = "Touhou 13",
					Subtitle = "Ten Desires",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2011,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 13.5",
					Subtitle = "Hopeless Masquerade",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2013,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.FightingGame
				},
				new OfficialGame() {
					Title = "Touhou 14",
					Subtitle = "Double Dealing Character",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2013,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 14.3",
					Subtitle = "Impossible Spell Card",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2014,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.SpinOff
				},
				new OfficialGame() {
					Title = "Touhou 14.5",
					Subtitle = "Urban Legend in Limbo",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2015,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.FightingGame
				},
				new OfficialGame() {
					Title = "Touhou 15",
					Subtitle = "Legacy of Lunatic Kingdom",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2015,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 15.5",
					Subtitle = "Antinomy of Common Flowers",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2017,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.FightingGame
				},
				new OfficialGame() {
					Title = "Touhou 16",
					Subtitle = "Hidden Star in Four Seasons",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2017,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 16.5",
					Subtitle = "Violet Detector",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2018,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.SpinOff
				},
				new OfficialGame() {
					Title = "Touhou 17",
					Subtitle = "Wily Beast and Weakest Creature",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2019,
					DownloadableFileLocation = "",
					Category = OfficialGame.CategoryFlag.MainWindows
				}
			};
			for (int i = 0; i < OfficialGames.Length; i++) {
				OfficialGames[i].Index = i;
			}
		}
	}
}
