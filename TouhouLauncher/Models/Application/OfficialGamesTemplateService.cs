using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public class OfficialGamesTemplateService {
		public virtual OfficialGame[] CreateOfficialGamesFromTemplate() => new OfficialGame[] {
			new(
				title: "Touhou 01: Highly Responsive to Prayers",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH01.png",
				audioLocation: "",
				releaseYear: 1996,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainPC98,
				downloadableFileLocation: "https://moriyashrine.org/files/file/273-touhou-1-highly-responsive-to-prayers/"
			),
			new(
				title: "Touhou 02: Story of Eastern Wonderland",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH02.png",
				audioLocation: "",
				releaseYear: 1997,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainPC98,
				downloadableFileLocation: "https://moriyashrine.org/files/file/274-touhou-2-the-story-of-eastern-wonderland/"
			),
			new(
				title: "Touhou 03: Phantasmagoria of Dim. Dream",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH03.png",
				audioLocation: "",
				releaseYear: 1997,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainPC98,
				downloadableFileLocation: "https://moriyashrine.org/files/file/275-touhou-3-phantasmagoria-of-dimensional-dream/"
			),
			new(
				title: "Touhou 04: Lotus Land Story",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH04.png",
				audioLocation: "",
				releaseYear: 1998,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainPC98,
				downloadableFileLocation: "https://moriyashrine.org/files/file/276-touhou-4-lotus-land-story/"
			),
			new(
				title: "Touhou 05: Mystic Square",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH05.png",
				audioLocation: "",
				releaseYear: 1998,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainPC98,
				downloadableFileLocation: "https://moriyashrine.org/files/file/277-touhou-5-mystic-square/"
			),
			new(
				title: "Touhou 06: Embodyment of Scarlet Devil",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH06.png",
				audioLocation: "",
				releaseYear: 2002,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/13-touhou-6-koumakyou-the-embodiment-of-scarlet-devil/"
			),
			new(
				title: "Touhou 07: Perfect Cherry Blossom",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH07.png",
				audioLocation: "",
				releaseYear: 2003,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/14-touhou-7-youyoumu-perfect-cherry-blossom/"
			),
			new(
				title: "Touhou 07.5: Immaterial and Missing Power",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH07_5.png",
				audioLocation: "",
				releaseYear: 2004,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.FightingGame,
				downloadableFileLocation: "https://moriyashrine.org/files/file/19-touhou-75-suimusou-immaterial-and-missing-power/"
			),
			new(
				title: "Touhou 08: Imperishable Night",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH08.png",
				audioLocation: "",
				releaseYear: 2004,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/20-touhou-8-eiyashou-imperishable-night/"
			),
			new(
				title: "Touhou 09: Phantasmagoria of Flower View",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH09.png",
				audioLocation: "",
				releaseYear: 2005,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/21-touhou-9-kaiedzuka-phantasmagoria-of-flower-view/"
			),
			new(
				title: "Touhou 09.5: Shoot the Bullet",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH09_5.png",
				audioLocation: "",
				releaseYear: 2005,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.SpinOff,
				downloadableFileLocation: "https://moriyashrine.org/files/file/22-touhou-95-bunkachou-shoot-the-bullet/"
			),
			new(
				title: "Touhou 10: Mountain of Faith",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH10.png",
				audioLocation: "",
				releaseYear: 2007,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/23-touhou-10-fuujinroku-mountain-of-faith/"
			),
			new(
				title: "Touhou 10.5: Scarlet Weather Rhapsody",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH10_5.png",
				audioLocation: "",
				releaseYear: 2008,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.FightingGame,
				downloadableFileLocation: "https://moriyashrine.org/files/file/24-touhou-105-hisouten-scarlet-weather-rhapsody/"
			),
			new(
				title: "Touhou 11: Subterranean Animism",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH11.png",
				audioLocation: "",
				releaseYear: 2008,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/25-touhou-11-chireiden-subterranean-animism/"
			),
			new(
				title: "Touhou 12: Undefined Fantastic Object",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH12.png",
				audioLocation: "",
				releaseYear: 2009,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/26-touhou-12-seirensen-undefined-fantastic-object/"
			),
			new(
				title: "Touhou 12.3: Hisoutensoku",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH12_3.png",
				audioLocation: "",
				releaseYear: 2009,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.FightingGame,
				downloadableFileLocation: "https://moriyashrine.org/files/file/27-touhou-123-hisoutensoku-choudokyuu-ginyoru-no-nazo-wo-oe/"
			),
			new(
				title: "Touhou 12.5: Double Spoiler",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH12_5.png",
				audioLocation: "",
				releaseYear: 2010,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.SpinOff,
				downloadableFileLocation: "https://moriyashrine.org/files/file/28-touhou-125-bunkachou-double-spoiler/"
			),
			new(
				title: "Touhou 12.8: Great Fairy Wars",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH12_8.png",
				audioLocation: "",
				releaseYear: 2010,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.SpinOff,
				downloadableFileLocation: "https://moriyashrine.org/files/file/52-touhou-128-sangetsusei-great-fairy-wars/"
			),
			new(
				title: "Touhou 13: Ten Desires",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH13.png",
				audioLocation: "",
				releaseYear: 2011,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/53-touhou-13-touhou-shinreibyou-ten-desires/"
			),
			new(
				title: "Touhou 13.5: Hopeless Masquerade",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH13_5.png",
				audioLocation: "",
				releaseYear: 2013,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.FightingGame,
				downloadableFileLocation: "https://moriyashrine.org/files/file/54-touhou-135-shinkirou-hopeless-masquerade/"
			),
			new(
				title: "Touhou 14: Double Dealing Character",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH14.png",
				audioLocation: "",
				releaseYear: 2013,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/55-touhou-14-kishinjou-double-dealing-character/"
			),
			new(
				title: "Touhou 14.3: Impossible Spell Card",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH14_3.png",
				audioLocation: "",
				releaseYear: 2014,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.SpinOff,
				downloadableFileLocation: "https://moriyashrine.org/files/file/56-touhou-143-danmaku-amanojaku-impossible-spell-card/"
			),
			new(
				title: "Touhou 14.5: Urban Legend in Limbo",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH14_5.png",
				audioLocation: "",
				releaseYear: 2015,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.FightingGame,
				downloadableFileLocation: "https://moriyashrine.org/files/file/57-touhou-145-shinhiroku-urban-legend-in-limbo/"
			),
			new(
				title: "Touhou 15: Legacy of Lunatic Kingdom",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH15.png",
				audioLocation: "",
				releaseYear: 2015,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/58-touhou-15-kanjuden-legacy-of-lunatic-kingdom/"
			),
			new(
				title: "Touhou 15.5: Antinomy of Common Flowers",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH15_5.png",
				audioLocation: "",
				releaseYear: 2017,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.FightingGame,
				downloadableFileLocation: "https://moriyashrine.org/files/file/43-touhou-155-antinomy-of-common-flowers/"
			),
			new(
				title: "Touhou 16: Hidden Star in Four Seasons",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH16.png",
				audioLocation: "",
				releaseYear: 2017,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/44-touhou-16-tenkuushou-hidden-star-in-four-seasons/"
			),
			new(
				title: "Touhou 16.5: Violet Detector",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH16_5.png",
				audioLocation: "",
				releaseYear: 2018,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.SpinOff,
				downloadableFileLocation: "https://moriyashrine.org/files/file/332-touhou-165-violet-detector/"
			),
			new(
				title: "Touhou 17: Wily Beast and Weakest Creature",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH17.png",
				audioLocation: "",
				releaseYear: 2019,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/649-touhou-17-kikeijuu-wily-beast-and-weakest-creature/"
			),
			new(
				title: "Touhou 17.5: Gouyoku Ibun",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH17_5.png",
				audioLocation: "",
				releaseYear: 2021,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.SpinOff,
				downloadableFileLocation: "https://moriyashrine.org/files/file/694-touhou-175-touhou-gouyoku-ibun-~-suibotsushita-chinshuu-jigoku/"
			),
			new(
				title: "Touhou 18: Unconnected Marketeers",
				imageLocation: "..\\..\\Resources\\Images\\OfficialGames\\TH18.png",
				audioLocation: "",
				releaseYear: 2021,
				fileLocation: null,
				includeInRandomGame: true,
				categories: GameCategories.MainWindows,
				downloadableFileLocation: "https://moriyashrine.org/files/file/905-touhou-18-unconnected-marketeers/"
			)
		};
	}
}
