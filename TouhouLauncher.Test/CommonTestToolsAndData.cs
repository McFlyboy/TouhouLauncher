#nullable disable

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

		public static readonly Np21ntConfig testNp21ntConfig = new(
			new Np21ntConfig.NekoProject21Section() {
				WindPosX = 5,
				WindPosY = 5,
				WinSnap  = true,
				FdFolder = "some text...",
				HdFolder = "some text...",
				BMapDir  = "some text...",
				FontFile = "some text...",
				PcModel  = "some text...",
				ClkBase  = 5,
				ClkMult  = 5,
				DipSwtch = new DipSwitch3 {
					Segment1 = new DipSwitch() {
						Switch1 = true,
						Switch2 = false,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = false,
						Switch7 = true,
						Switch8 = true
					},
					Segment2 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = false,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = false,
						Switch8 = true
					},
					Segment3 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = true,
						Switch8 = true
					}
				},
				MemSwtch = new DipSwitch8 {
					Segment1 = new DipSwitch() {
						Switch1 = false,
						Switch2 = false,
						Switch3 = false,
						Switch4 = false,
						Switch5 = false,
						Switch6 = false,
						Switch7 = false,
						Switch8 = true
					},
					Segment2 = new DipSwitch() {
						Switch1 = false,
						Switch2 = false,
						Switch3 = true,
						Switch4 = false,
						Switch5 = false,
						Switch6 = false,
						Switch7 = true,
						Switch8 = true
					},
					Segment3 = new DipSwitch() {
						Switch1 = false,
						Switch2 = true,
						Switch3 = false,
						Switch4 = false,
						Switch5 = false,
						Switch6 = true,
						Switch7 = false,
						Switch8 = true
					},
					Segment4 = new DipSwitch() {
						Switch1 = false,
						Switch2 = true,
						Switch3 = true,
						Switch4 = false,
						Switch5 = false,
						Switch6 = true,
						Switch7 = true,
						Switch8 = true
					},
					Segment5 = new DipSwitch() {
						Switch1 = true,
						Switch2 = false,
						Switch3 = false,
						Switch4 = false,
						Switch5 = true,
						Switch6 = false,
						Switch7 = false,
						Switch8 = true
					},
					Segment6 = new DipSwitch() {
						Switch1 = true,
						Switch2 = false,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = false,
						Switch7 = true,
						Switch8 = true
					},
					Segment7 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = false,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = false,
						Switch8 = true
					},
					Segment8 = new DipSwitch() {
						Switch1 = true,
						Switch2 = true,
						Switch3 = true,
						Switch4 = false,
						Switch5 = true,
						Switch6 = true,
						Switch7 = true,
						Switch8 = true
					}
				},
				ExMemory = 5,
				Hdd1File = "some text...",
				Hdd2File = "some text...",
				Hdd3File = "some text...",
				ScsiHdd0 = "some text...",
				ScsiHdd1 = "some text...",
				ScsiHdd2 = "some text...",
				ScsiHdd3 = "some text...",
				SampleHz = 5,
				LatencyS = 5,
				SndBoard = 0x3,
				BeepVol  = 5,
				Snd14Vol = new byte[] {
					0x01,
					0x23,
					0x45,
					0x67,
					0x89,
					0xab
				},
				Opt26Brd = 0x3,
				Opt86Brd = 0x3,
				OptSpbrd = 0x3,
				OptSpbvr = 0x3,
				OptSpbvl = 5,
				OptSpbX  = true,
				OptMpu98 = 0x3,
				VolumeF  = 5,
				VolumeS  = 5,
				VolumeA  = 5,
				VolumeP  = 5,
				VolumeR  = 5,
				SeekSnd  = true,
				SeekVol  = 5,
				BtnRapid = true,
				BtnMode  = true,
				MouseSw  = true,
				MsRapid  = true,
				Backgrnd = 5,
				VramWait = new byte[] {
					0x01,
					0x23,
					0x45,
					0x67,
					0x89,
					0xab
				},
				DspClock = 5,
				DispSync = true,
				RealPal  = true,
				RPalTim  = 5,
				SNoWait  = true,
				SkpFrame = 5,
				UPd72020 = true,
				GrcgEgc  = 5,
				Color16B = true,
				SkipLine = true,
				SkpLight = 5,
				LcdMode  = 5,
				Pc9861E  = true,
				Pc9861S  = new byte[] {
					0x01,
					0x23,
					0x45
				},
				Pc9861J  = new byte[] {
					0x01,
					0x23,
					0x45,
					0x67,
					0x89,
					0xab
				},
				Calendar = true,
				Use144Fd = true,
				DrawType = 5,
				ScrnMul  = 5,
				OpnaClk  = 5,
				FmgRate  = 5,
				CoffLpf  = true,
				MixType  = true,
				VolumeC  = 5,
				AaFilter = 5,
				StFilter = 5,
				Priority = 5,
				BeepPcm  = 5,
				StatName = "some text...",
				LpfOrder = 5,
				LpfCutof = 5,
				FmWaitA  = 5,
				FmWaitD  = 5,
				MouseSns = 5,
				FddWait  = 5,
				JoystkId = 5,
				CpuSpeed = 5,
				MVolume  = 5,
				VolumeV  = 5,
				F12Copy  = 5,
				Joystick = true,
				Joy1Btn  = new byte[] {
					0x01,
					0x23,
					0x45,
					0x67
				},
				ClockNow = 5,
				ClockFnt = 5,
				UseSstp  = true,
				SstpPort = 5,
				Comfirm  = true,
				Shortcut = 0x3,
				Mpu98Map = "some text...",
				Mpu98Min = "some text...",
				Mpu98Mdl = "some text...",
				Mpu98Den = 5,
				Mpu98Def = "some text...",
				Com1Port = 5,
				Com1Para = 5,
				Com1Bps  = 5,
				Com1MMap = "some text...",
				Com1MMdl = "some text...",
				Com1MDef = "some text...",
				Com2Port = 5,
				Com2Para = 5,
				Com2Bps  = 5,
				Com2MMap = "some text...",
				Com2MMdl = "some text...",
				Com2MDef = "some text...",
				Com3Port = 5,
				Com3Para = 5,
				Com3Bps  = 5,
				Com3MMap = "some text...",
				Com3MMdl = "some text...",
				Com3MDef = "some text...",
				EResume  = true,
				Nousemmx = true,
				WindType = 5,
				ToolWind = true,
				KeyDispl = true,
				JastSnd  = true,
				UseRomeo = true,
				ThickFrm = true,
				FScrnMod = 5,
				SKeyDisp = true,
				Function = new byte[] {
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
				DllList = 5,
				FdlFile = "some text...",
				FdCache = 5
			},
			new Np21ntConfig.NP2ToolSection() {
				WindPosX = 5,
				WindPosY = 5,
				WindType = true,
				SkinFile = "some text...",
				SkinMru0 = "some text...",
				SkinMru1 = "some text...",
				SkinMru2 = "some text...",
				SkinMru3 = "some text...",
				Fd1Name0 = "some text...",
				Fd1Name1 = "some text...",
				Fd1Name2 = "some text...",
				Fd1Name3 = "some text...",
				Fd1Name4 = "some text...",
				Fd1Name5 = "some text...",
				Fd1Name6 = "some text...",
				Fd1Name7 = "some text...",
				Fd2Name0 = "some text...",
				Fd2Name1 = "some text...",
				Fd2Name2 = "some text...",
				Fd2Name3 = "some text...",
				Fd2Name4 = "some text...",
				Fd2Name5 = "some text...",
				Fd2Name6 = "some text...",
				Fd2Name7 = "some text..."
			},
			new Np21ntConfig.KeyDisplaySection() {
				WindPosX = 5,
				WindPosY = 5,
				KeyDMode = 5,
				WindType = true
			},
			new Np21ntConfig.SoftKeyboardSection() {
				WindPosX = 5,
				WindPosY = 5,
				WindType = true
			},
			new Np21ntConfig.MemoryMapSection() {
				WindPosX = 5,
				WindPosY = 5,
				WindType = true
			}
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
