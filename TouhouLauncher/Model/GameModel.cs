using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model {
	public class GameModel {
		public List<OfficialGame> MainPC98Games {
			get {
				return FilterOfficialGames(OfficialGame.GameCategory.MainPC98);
			}
		}
		public List<OfficialGame> MainWindowsGames {
			get {
				return FilterOfficialGames(OfficialGame.GameCategory.MainWindows);
			}
		}
		public List<OfficialGame> FightingGames {
			get {
				return FilterOfficialGames(OfficialGame.GameCategory.FightingGame);
			}
		}
		public List<OfficialGame> SpinOffGames {
			get {
				return FilterOfficialGames(OfficialGame.GameCategory.SpinOff);
			}
		}
		public List<FanGame> FanGames { get; set; }

		private readonly OfficialGame[] _officialGames;
		public GameModel() {
			FanGames = new List<FanGame>();
			_officialGames = new OfficialGame[] {
				new OfficialGame() {
					Title = "Touhou 01",
					Subtitle = "Highly Responsive to Prayers",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1996,
					DownloadableFileLocation = "",
					Category = OfficialGame.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 02",
					Subtitle = "Story of Eastern Wonderland",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1997,
					DownloadableFileLocation = "",
					Category = OfficialGame.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 03",
					Subtitle = "Phantasmagoria of Dim. Dream",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1997,
					DownloadableFileLocation = "",
					Category = OfficialGame.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 04",
					Subtitle = "Lotus Land Story",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1998,
					DownloadableFileLocation = "",
					Category = OfficialGame.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 05",
					Subtitle = "Mystic Square",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1998,
					DownloadableFileLocation = "",
					Category = OfficialGame.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 06",
					Subtitle = "Embodyment of Scarlet Devil",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2002,
					DownloadableFileLocation = "",
					Category = OfficialGame.GameCategory.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 07",
					Subtitle = "Perfect Cherry Blossom",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2003,
					DownloadableFileLocation = "",
					Category = OfficialGame.GameCategory.MainWindows
				}
			};
		}
		private List<OfficialGame> FilterOfficialGames(OfficialGame.GameCategory category) {
			List<OfficialGame> games = new List<OfficialGame>();
			foreach (var game in _officialGames) {
				if (game.Category == category) {
					games.Add(game);
				}
			}
			return games;
		}
	}
}
