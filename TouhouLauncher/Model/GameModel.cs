using System.Collections.Generic;
using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model {
	public class GameModel {
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
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = Game.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 02",
					Subtitle = "Story of Eastern Wonderland",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1997,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = Game.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 03",
					Subtitle = "Phantasmagoria of Dim. Dream",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1997,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = Game.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 04",
					Subtitle = "Lotus Land Story",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1998,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = Game.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 05",
					Subtitle = "Mystic Square",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 1998,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = Game.GameCategory.MainPC98
				},
				new OfficialGame() {
					Title = "Touhou 06",
					Subtitle = "Embodyment of Scarlet Devil",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2002,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = Game.GameCategory.MainWindows
				},
				new OfficialGame() {
					Title = "Touhou 07",
					Subtitle = "Perfect Cherry Blossom",
					ImageLocation = "",
					AudioLocation = "",
					ReleaseYear = 2003,
					LocalFileLocation = "",
					DownloadableFileLocation = "",
					Category = Game.GameCategory.MainWindows
				}
			};
		}
		public List<Game> FilterGames(Game.GameCategory category) {
			List<Game> games = new List<Game>();
			if (category != Game.GameCategory.FanGame) {
				foreach (var game in _officialGames) {
					if (game.Category == category) {
						games.Add(game);
					}
				}
			}
			else {
				foreach (var game in FanGames) {
					games.Add(game);
				}
			}
			return games;
		}
	}
}
