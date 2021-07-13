using IniParser.Model;
using System.Collections.Generic;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;
using TouhouLauncher.Models.Infrastructure;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes;

namespace TouhouLauncher.Test {
	public static class CommonTestToolsAndData {
		public static readonly GeneralSettings testGeneralSettings = new() {
			CloseOnGameLaunch = true,
			CombineMainCategories = false
		};

		public static readonly EmulatorSettings testEmulatorSettings = new() {
			FolderLocation = "C:\\test\\emulator\\location"
		};

		public static readonly OfficialGame testOfficialGame1 = new() {
			Title = "Test Game 1",
			ImageLocation = "",
			AudioLocation = "",
			ReleaseYear = 2000,
			Categories = GameCategories.MainWindows,
			DownloadableFileLocation = "",
			FileLocation = "C:\\test\\location.exe"
		};

		public static readonly OfficialGame testOfficialGame2 = new() {
			Title = "Test Game 2",
			ImageLocation = "",
			AudioLocation = "",
			ReleaseYear = 2001,
			Categories = GameCategories.MainPC98,
			DownloadableFileLocation = "",
			FileLocation = ""
		};

		public static readonly OfficialGame testOfficialGame3 = new() {
			Title = "Test Game 3",
			ImageLocation = "",
			AudioLocation = "",
			ReleaseYear = 2002,
			Categories = GameCategories.FightingGame,
			DownloadableFileLocation = "",
			FileLocation = ""
		};

		public static readonly OfficialGame[] testOfficialGames = new OfficialGame[] {
			testOfficialGame1,
			testOfficialGame2,
			testOfficialGame3
		};

		public static readonly FanGame testFangame1 = new() {
			Title = "Test Fan Game 1",
			ImageLocation = "",
			AudioLocation = "",
			ReleaseYear = 2003,
			FileLocation = ""
		};

		public static readonly FanGame testFangame2 = new() {
			Title = "Test Fan Game 2",
			ImageLocation = "",
			AudioLocation = "",
			ReleaseYear = 2004,
			FileLocation = ""
		};

		public static readonly List<FanGame> testFanGames = new() {
			testFangame1,
			testFangame2
		};

		public static readonly SettingsAndGames testSettingsAndGames = new(
			GeneralSettings: testGeneralSettings,
			EmulatorSettings: testEmulatorSettings,
			OfficialGames: testOfficialGames,
			FanGames: testFanGames
		);

		public static readonly GeneralSettingsYaml testGeneralSettingsYaml = new() {
			CloseOnGameLaunch = true,
			CombineMainCategories = false
		};

		public static readonly EmulatorSettingsYaml testEmulatorSettingsYaml = new() {
			FolderLocation = "C:\\test\\emulator\\location"
		};

		public static readonly OfficialGameYaml testOfficialGameYaml1 = new() {
			FileLocation = "C:\\test\\location.exe"
		};

		public static readonly OfficialGameYaml testOfficialGameYaml2 = new() {
			FileLocation = ""
		};

		public static readonly OfficialGameYaml testOfficialGameYaml3 = new() {
			FileLocation = ""
		};

		public static readonly OfficialGameYaml[] testOfficialGameYamls = new OfficialGameYaml[] {
			testOfficialGameYaml1,
			testOfficialGameYaml2,
			testOfficialGameYaml3
		};

		public static readonly FanGameYaml testFanGameYaml1 = new() {
			Title = "Test Fan Game 1",
			ImageLocation = "",
			AudioLocation = "",
			ReleaseYear = 2003,
			FileLocation = ""
		};

		public static readonly FanGameYaml testFanGameYaml2 = new() {
			Title = "Test Fan Game 2",
			ImageLocation = "",
			AudioLocation = "",
			ReleaseYear = 2004,
			FileLocation = ""
		};

		public static readonly List<FanGameYaml> testFanGameYamls = new() {
			testFanGameYaml1,
			testFanGameYaml2
		};

		public static readonly SettingsAndGamesYaml testSettingsAndGamesYaml = new() {
			GeneralSettings = testGeneralSettingsYaml,
			EmulatorSettings = testEmulatorSettingsYaml,
			OfficialGames = testOfficialGameYamls,
			FanGames = testFanGameYamls
		};

		public static readonly YamlTestType yamlTestTypeObject = new() {
			Text = "Test",
			Number = 3
		};

		public static readonly string yamlTestTypeObjectAsString = $"text: Test{LineBreak}number: 3{LineBreak}";

		public static readonly IniTestType iniTestTypeObject = new() {
			Data = new() {
				Sections = new() {
					new Section("Test") {
						Properties = new() {
							new Property("text", "Hello"),
							new Property("number", "3")
						}
					},
					new Section("More test") {
						Properties = new() {
							new Property("is_test", "true")
						}
					}
				}
			}
		};

		public static readonly string iniTestTypeObjectAsString =
			$"[Test]{LineBreak}text=Hello{LineBreak}number=3{LineBreak}[More test]{LineBreak}is_test=true";

		public static string LineBreak => "\r\n";

		public record SimpleType {
			public string Text { get; init; }

			public int Number { get; init; }
		}

		public record YamlTestType : Yaml {
			public string Text { get; init; }

			public int Number { get; init; }
		}

		public record IniTestType : Ini;
	}
}
