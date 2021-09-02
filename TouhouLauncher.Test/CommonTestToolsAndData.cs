using IniParser.Model;
using System.Collections.Generic;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;
using TouhouLauncher.Models.Infrastructure;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes;

namespace TouhouLauncher.Test {
	public static class CommonTestToolsAndData {
		public static readonly GeneralSettings testGeneralSettings = new(
			closeOnGameLaunch: true,
			combineMainCategories: false
		);

		public static readonly EmulatorSettings testEmulatorSettings = new(
			folderLocation: "C:\\test\\emulator\\location"
		);

		public static readonly OfficialGame testOfficialGame1 = new(
			title: "Test Game 1",
			imageLocation: "",
			audioLocation: "",
			releaseYear: 2000,
			fileLocation: "C:\\test\\location.exe",
			categories: GameCategories.MainWindows,
			downloadableFileLocation: ""
		);

		public static readonly OfficialGame testOfficialGame2 = new(
			title: "Test Game 2",
			imageLocation: "",
			audioLocation: "",
			releaseYear: 2001,
			fileLocation: "",
			categories: GameCategories.MainPC98,
			downloadableFileLocation: ""
		);

		public static readonly OfficialGame testOfficialGame3 = new(
			title: "Test Game 3",
			imageLocation: "",
			audioLocation: "",
			releaseYear: 2002,
			fileLocation: "",
			categories: GameCategories.FightingGame,
			downloadableFileLocation: ""
		);

		public static readonly OfficialGame[] testOfficialGames = new OfficialGame[] {
			testOfficialGame1,
			testOfficialGame2,
			testOfficialGame3
		};

		public static readonly FanGame testFangame1 = new(
			title: "Test Fan Game 1",
			imageLocation: "",
			audioLocation: "",
			releaseYear: 2003,
			fileLocation: ""
		);

		public static readonly FanGame testFangame2 = new(
			title: "Test Fan Game 2",
			imageLocation: "",
			audioLocation: "",
			releaseYear: 2004,
			fileLocation: ""
		);

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

		public static readonly Np21ntConfig testNp21ntConfig = new(
			new Np21ntConfig.NekoProject21Section(
				windPosX: 5,
				windPosY: 5,
				winSnap : true,
				fdFolder: "some text...",
				hdFolder: "some text...",
				bMapDir : "some text...",
				fontFile: "some text...",
				pcModel : "some text...",
				clkBase : 5,
				clkMult : 5,
				dipSwtch: new DipSwitch3(0xab, 0xcd, 0xef),
				memSwtch: new DipSwitch8(0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef),
				exMemory: 5,
				hdd1File: "some text...",
				hdd2File: "some text...",
				hdd3File: "some text...",
				scsiHdd0: "some text...",
				scsiHdd1: "some text...",
				scsiHdd2: "some text...",
				scsiHdd3: "some text...",
				sampleHz: 5,
				latencyS: 5,
				sndBoard: 0x3,
				beepVol : 5,
				snd14Vol: new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab },
				opt26Brd: 0x3,
				opt86Brd: 0x3,
				optSpbrd: 0x3,
				optSpbvr: 0x3,
				optSpbvl: 5,
				optSpbX : true,
				optMpu98: 0x3,
				volumeF : 5,
				volumeS : 5,
				volumeA : 5,
				volumeP : 5,
				volumeR : 5,
				seekSnd : true,
				seekVol : 5,
				btnRapid: true,
				btnMode : true,
				mouseSw : true,
				msRapid : true,
				backgrnd: 5,
				vramWait: new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab },
				dspClock: 5,
				dispSync: true,
				realPal : true,
				rPalTim : 5,
				sNoWait : true,
				skpFrame: 5,
				uPd72020: true,
				grcgEgc : 5,
				color16B: true,
				skipLine: true,
				skpLight: 5,
				lcdMode : 5,
				pc9861E : true,
				pc9861S : new byte[] { 0x01, 0x23, 0x45 },
				pc9861J : new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab },
				calendar: true,
				use144Fd: true,
				drawType: 5,
				scrnMul : 5,
				opnaClk : 5,
				fmgRate : 5,
				coffLpf : true,
				mixType : true,
				volumeC : 5,
				aaFilter: 5,
				stFilter: 5,
				priority: 5,
				beepPcm : 5,
				statName: "some text...",
				lpfOrder: 5,
				lpfCutof: 5,
				fmWaitA : 5,
				fmWaitD : 5,
				mouseSns: 5,
				fddWait : 5,
				joystkId: 5,
				cpuSpeed: 5,
				mVolume : 5,
				volumeV : 5,
				f12Copy : 5,
				joystick: true,
				joy1Btn : new byte[] { 0x01, 0x23, 0x45, 0x67 },
				clockNow: 5,
				clockFnt: 5,
				useSstp : true,
				sstpPort: 5,
				comfirm : true,
				shortcut: 0x3,
				mpu98Map: "some text...",
				mpu98Min: "some text...",
				mpu98Mdl: "some text...",
				mpu98Den: 5,
				mpu98Def: "some text...",
				com1Port: 5,
				com1Para: 5,
				com1Bps : 5,
				com1MMap: "some text...",
				com1MMdl: "some text...",
				com1MDef: "some text...",
				com2Port: 5,
				com2Para: 5,
				com2Bps : 5,
				com2MMap: "some text...",
				com2MMdl: "some text...",
				com2MDef: "some text...",
				com3Port: 5,
				com3Para: 5,
				com3Bps : 5,
				com3MMap: "some text...",
				com3MMdl: "some text...",
				com3MDef: "some text...",
				eResume : true,
				nousemmx: true,
				windType: 5,
				toolWind: true,
				keyDispl: true,
				jastSnd : true,
				useRomeo: true,
				thickFrm: true,
				fScrnMod: 5,
				sKeyDisp: true,
				function: new byte[] {
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x55,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00
				},
				dllList: 5,
				fdlFile: "some text...",
				fdCache: 5
			),
			new Np21ntConfig.NP2ToolSection(
				windPosX: 5,
				windPosY: 5,
				windType: true,
				skinFile: "some text...",
				skinMru0: "some text...",
				skinMru1: "some text...",
				skinMru2: "some text...",
				skinMru3: "some text...",
				fd1Name0: "some text...",
				fd1Name1: "some text...",
				fd1Name2: "some text...",
				fd1Name3: "some text...",
				fd1Name4: "some text...",
				fd1Name5: "some text...",
				fd1Name6: "some text...",
				fd1Name7: "some text...",
				fd2Name0: "some text...",
				fd2Name1: "some text...",
				fd2Name2: "some text...",
				fd2Name3: "some text...",
				fd2Name4: "some text...",
				fd2Name5: "some text...",
				fd2Name6: "some text...",
				fd2Name7: "some text..."
			),
			new Np21ntConfig.KeyDisplaySection(
				windPosX: 5,
				windPosY: 5,
				keyDMode: 5,
				windType: true
			),
			new Np21ntConfig.SoftKeyboardSection(
				windPosX: 5,
				windPosY: 5,
				windType: true
			),
			new Np21ntConfig.MemoryMapSection(
				windPosX: 5,
				windPosY: 5,
				windType: true
			)
		);

		public static readonly Np21ntConfigIni testNp21ntConfigIni = new() {
			Data = new() {
				Sections = new() {
					new Section("NekoProject21") {
						Properties = new() {
							new Property("WindposX", "5"),
							new Property("WindposY", "5"),
							new Property("Win_Snap", "true"),
							new Property("FDfolder", "some text..."),
							new Property("HDfolder", "some text..."),
							new Property("bmap_Dir", "some text..."),
							new Property("fontfile", "some text..."),
							new Property("pc_model", "some text..."),
							new Property("clk_base", "5"),
							new Property("clk_mult", "5"),
							new Property("DIPswtch", "ab cd ef"),
							new Property("MEMswtch", "01 23 45 67 89 ab cd ef"),
							new Property("ExMemory", "5"),
							new Property("HDD1FILE", "some text..."),
							new Property("HDD2FILE", "some text..."),
							new Property("HDD3FILE", "some text..."),
							new Property("SCSIHDD0", "some text..."),
							new Property("SCSIHDD1", "some text..."),
							new Property("SCSIHDD2", "some text..."),
							new Property("SCSIHDD3", "some text..."),
							new Property("SampleHz", "5"),
							new Property("Latencys", "5"),
							new Property("SNDboard", "5"),
							new Property("BEEP_vol", "5"),
							new Property("SND14vol", "01 23 45 67 89 ab"),
							new Property("opt26BRD", "0x3"),
							new Property("opt86BRD", "0x3"),
							new Property("optSPBRD", "0x3"),
							new Property("optSPBVR", "0x3"),
							new Property("optSPBVL", "5"),
							new Property("optSPB_X", "true"),
							new Property("optMPU98", "0x3"),
							new Property("volume_F", "5"),
							new Property("volume_S", "5"),
							new Property("volume_A", "5"),
							new Property("volume_P", "5"),
							new Property("volume_R", "5"),
							new Property("Seek_Snd", "true"),
							new Property("Seek_Vol", "5"),
							new Property("btnRAPID", "true"),
							new Property("btn_MODE", "true"),
							new Property("Mouse_sw", "true"),
							new Property("MS_RAPID", "true"),
							new Property("backgrnd", "5"),
							new Property("VRAMwait", "01 23 45 67 89 ab"),
							new Property("DspClock", "5"),
							new Property("DispSync", "true"),
							new Property("Real_Pal", "true"),
							new Property("RPal_tim", "5"),
							new Property("s_NOWAIT", "true"),
							new Property("SkpFrame", "5"),
							new Property("uPD72020", "true"),
							new Property("GRCG_EGC", "5"),
							new Property("color16b", "true"),
							new Property("skipline", "true"),
							new Property("skplight", "5"),
							new Property("LCD_MODE", "5"),
							new Property("pc9861_e", "true"),
							new Property("pc9861_s", "01 23 45"),
							new Property("pc9861_j", "01 23 45 67 89 ab"),
							new Property("calendar", "true"),
							new Property("USE144FD", "true"),
							new Property("DrawType", "5"),
							new Property("SCRN_MUL", "5"),
							new Property("OPNA_CLK", "5"),
							new Property("FMG_RATE", "5"),
							new Property("COFF_LPF", "true"),
							new Property("MIX_TYPE", "true"),
							new Property("volume_C", "5"),
							new Property("AAFILTER", "5"),
							new Property("STFILTER", "5"),
							new Property("Priority", "5"),
							new Property("BEEP_PCM", "5"),
							new Property("StatName", "some text..."),
							new Property("lpforder", "5"),
							new Property("lpfcutof", "5"),
							new Property("FMWait_A", "5"),
							new Property("FMWait_D", "5"),
							new Property("MOUSESNS", "5"),
							new Property("FDD_Wait", "5"),
							new Property("JOYSTKID", "5"),
							new Property("CPUSPEED", "5"),
							new Property("M_Volume", "5"),
							new Property("volume_V", "5"),
							new Property("F12_COPY", "5"),
							new Property("Joystick", "true"),
							new Property("Joy1_btn", "01 23 45 67"),
							new Property("clocknow", "5"),
							new Property("clockfnt", "5"),
							new Property("use_sstp", "true"),
							new Property("sstpport", "5"),
							new Property("comfirm_", "true"),
							new Property("shortcut", "0x3"),
							new Property("mpu98map", "some text..."),
							new Property("mpu98min", "some text..."),
							new Property("mpu98mdl", "some text..."),
							new Property("mpu98den", "5"),
							new Property("mpu98def", "some text..."),
							new Property("com1port", "5"),
							new Property("com1para", "5"),
							new Property("com1_bps", "5"),
							new Property("com1mmap", "some text..."),
							new Property("com1mmdl", "some text..."),
							new Property("com1mdef", "some text..."),
							new Property("com2port", "5"),
							new Property("com2para", "5"),
							new Property("com2_bps", "5"),
							new Property("com2mmap", "some text..."),
							new Property("com2mmdl", "some text..."),
							new Property("com2mdef", "some text..."),
							new Property("com3port", "5"),
							new Property("com3para", "5"),
							new Property("com3_bps", "5"),
							new Property("com3mmap", "some text..."),
							new Property("com3mmdl", "some text..."),
							new Property("com3mdef", "some text..."),
							new Property("e_resume", "true"),
							new Property("nousemmx", "true"),
							new Property("windtype", "5"),
							new Property("toolwind", "true"),
							new Property("keydispl", "true"),
							new Property("jast_snd", "true"),
							new Property("useromeo", "true"),
							new Property("thickfrm", "true"),
							new Property("fscrnmod", "5"),
							new Property("skeydisp", "true"),
							new Property("Function", "55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 55 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"),
							new Property("Dll_List", "5"),
							new Property("FDL_FILE", "some text..."),
							new Property("FD_CACHE", "5")
						}
					},
					new Section("NP2 tool") {
						Properties = new() {
							new Property("WindposX", "5"),
							new Property("WindposY", "5"),
							new Property("WindType", "true"),
							new Property("SkinFile", "some text..."),
							new Property("SkinMRU0", "some text..."),
							new Property("SkinMRU1", "some text..."),
							new Property("SkinMRU2", "some text..."),
							new Property("SkinMRU3", "some text..."),
							new Property("FD1NAME0", "some text..."),
							new Property("FD1NAME1", "some text..."),
							new Property("FD1NAME2", "some text..."),
							new Property("FD1NAME3", "some text..."),
							new Property("FD1NAME4", "some text..."),
							new Property("FD1NAME5", "some text..."),
							new Property("FD1NAME6", "some text..."),
							new Property("FD1NAME7", "some text..."),
							new Property("FD2NAME0", "some text..."),
							new Property("FD2NAME1", "some text..."),
							new Property("FD2NAME2", "some text..."),
							new Property("FD2NAME3", "some text..."),
							new Property("FD2NAME4", "some text..."),
							new Property("FD2NAME5", "some text..."),
							new Property("FD2NAME6", "some text..."),
							new Property("FD2NAME7", "some text...")
						}
					},
					new Section("Key Display") {
						Properties = new() {
							new Property("WindposX", "5"),
							new Property("WindposY", "5"),
							new Property("keydmode", "5"),
							new Property("windtype", "true")
						}
					},
					new Section("Soft Keyboard") {
						Properties = new() {
							new Property("WindposX", "5"),
							new Property("WindposY", "5"),
							new Property("windtype", "true"),
						}
					},
					new Section("Memory Map") {
						Properties = new() {
							new Property("WindposX", "5"),
							new Property("WindposY", "5"),
							new Property("windtype", "true"),
						}
					}
				}
			}
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
			public string? Text { get; init; }

			public int? Number { get; init; }
		}

		public record YamlTestType : Yaml {
			public string? Text { get; init; }

			public int? Number { get; init; }
		}

		public record IniTestType : Ini;
	}
}
