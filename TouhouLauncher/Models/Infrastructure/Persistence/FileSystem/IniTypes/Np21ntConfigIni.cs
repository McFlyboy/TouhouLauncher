using IniParser.Model;
using System;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes {
	public record Np21ntConfigIni : Ini {
		public Np21ntConfig ToDomain() => new(
			new Np21ntConfig.NekoProject21Section() {
				WindPosX = Data["NekoProject21"]["WindposX"].ParseInt(),
				WindPosY = Data["NekoProject21"]["WindposY"].ParseInt(),
				WinSnap  = Data["NekoProject21"]["Win_Snap"].ParseBool(),
				FdFolder = Data["NekoProject21"]["FDfolder"],
				HdFolder = Data["NekoProject21"]["HDfolder"],
				BMapDir  = Data["NekoProject21"]["bmap_Dir"],
				FontFile = Data["NekoProject21"]["fontfile"],
				PcModel  = Data["NekoProject21"]["pc_model"],
				ClkBase  = Data["NekoProject21"]["clk_base"].ParseInt(),
				ClkMult  = Data["NekoProject21"]["clk_mult"].ParseInt(),
				DipSwtch = Data["NekoProject21"]["DIPswtch"].ParseDipSwitch3(),
				MemSwtch = Data["NekoProject21"]["MEMswtch"].ParseDipSwitch8(),
				ExMemory = Data["NekoProject21"]["ExMemory"].ParseInt(),
				Hdd1File = Data["NekoProject21"]["HDD1FILE"],
				Hdd2File = Data["NekoProject21"]["HDD2FILE"],
				Hdd3File = Data["NekoProject21"]["HDD3FILE"],
				ScsiHdd0 = Data["NekoProject21"]["SCSIHDD0"],
				ScsiHdd1 = Data["NekoProject21"]["SCSIHDD1"],
				ScsiHdd2 = Data["NekoProject21"]["SCSIHDD2"],
				ScsiHdd3 = Data["NekoProject21"]["SCSIHDD3"],
				SampleHz = Data["NekoProject21"]["SampleHz"].ParseInt(),
				LatencyS = Data["NekoProject21"]["Latencys"].ParseInt(),
				SndBoard = Data["NekoProject21"]["SNDboard"].ParseInt(),
				BeepVol  = Data["NekoProject21"]["BEEP_vol"].ParseInt(),
				Snd14Vol = Data["NekoProject21"]["SND14vol"].ParseBytes(),
				Opt26Brd = Data["NekoProject21"]["opt26BRD"].ParseByte(),
				Opt86Brd = Data["NekoProject21"]["opt86BRD"].ParseByte(),
				OptSpbrd = Data["NekoProject21"]["optSPBRD"].ParseByte(),
				OptSpbvr = Data["NekoProject21"]["optSPBVR"].ParseInt(),
				OptSpbvl = Data["NekoProject21"]["optSPBVL"].ParseInt(),
				OptSpbX  = Data["NekoProject21"]["optSPB_X"].ParseBool(),
				OptMpu98 = Data["NekoProject21"]["optMPU98"].ParseInt(),
				VolumeF  = Data["NekoProject21"]["volume_F"].ParseInt(),
				VolumeS  = Data["NekoProject21"]["volume_S"].ParseInt(),
				VolumeA  = Data["NekoProject21"]["volume_A"].ParseInt(),
				VolumeP  = Data["NekoProject21"]["volume_P"].ParseInt(),
				VolumeR  = Data["NekoProject21"]["volume_R"].ParseInt(),
				SeekSnd  = Data["NekoProject21"]["Seek_Snd"].ParseBool(),
				SeekVol  = Data["NekoProject21"]["Seek_Vol"].ParseInt(),
				BtnRapid = Data["NekoProject21"]["btnRAPID"].ParseBool(),
				BtnMode  = Data["NekoProject21"]["btn_MODE"].ParseBool(),
				MouseSw  = Data["NekoProject21"]["Mouse_sw"].ParseBool(),
				MsRapid  = Data["NekoProject21"]["MS_RAPID"].ParseBool(),
				Backgrnd = Data["NekoProject21"]["backgrnd"].ParseInt(),
				VramWait = Data["NekoProject21"]["VRAMwait"].ParseBytes(),
				DspClock = Data["NekoProject21"]["DspClock"].ParseInt(),
				DispSync = Data["NekoProject21"]["DispSync"].ParseBool(),
				RealPal  = Data["NekoProject21"]["Real_Pal"].ParseBool(),
				RPalTim  = Data["NekoProject21"]["RPal_tim"].ParseInt(),
				SNoWait  = Data["NekoProject21"]["s_NOWAIT"].ParseBool(),
				SkpFrame = Data["NekoProject21"]["SkpFrame"].ParseInt(),
				UPd72020 = Data["NekoProject21"]["uPD72020"].ParseBool(),
				GrcgEgc  = Data["NekoProject21"]["GRCG_EGC"].ParseInt(),
				Color16B = Data["NekoProject21"]["color16b"].ParseBool(),
				SkipLine = Data["NekoProject21"]["skipline"].ParseBool(),
				SkpLight = Data["NekoProject21"]["skplight"].ParseInt(),
				LcdMode  = Data["NekoProject21"]["LCD_MODE"].ParseInt(),
				Pc9861E  = Data["NekoProject21"]["pc9861_e"].ParseBool(),
				Pc9861S  = Data["NekoProject21"]["pc9861_s"].ParseBytes(),
				Pc9861J  = Data["NekoProject21"]["pc9861_j"].ParseBytes(),
				Calendar = Data["NekoProject21"]["calendar"].ParseBool(),
				Use144Fd = Data["NekoProject21"]["USE144FD"].ParseBool(),
				DrawType = Data["NekoProject21"]["DrawType"].ParseInt(),
				ScrnMul  = Data["NekoProject21"]["SCRN_MUL"].ParseInt(),
				OpnaClk  = Data["NekoProject21"]["OPNA_CLK"].ParseInt(),
				FmgRate  = Data["NekoProject21"]["FMG_RATE"].ParseInt(),
				CoffLpf  = Data["NekoProject21"]["COFF_LPF"].ParseBool(),
				MixType  = Data["NekoProject21"]["MIX_TYPE"].ParseBool(),
				VolumeC  = Data["NekoProject21"]["volume_C"].ParseInt(),
				AaFilter = Data["NekoProject21"]["AAFILTER"].ParseInt(),
				StFilter = Data["NekoProject21"]["STFILTER"].ParseInt(),
				Priority = Data["NekoProject21"]["Priority"].ParseInt(),
				BeepPcm  = Data["NekoProject21"]["BEEP_PCM"].ParseInt(),
				StatName = Data["NekoProject21"]["StatName"],
				LpfOrder = Data["NekoProject21"]["lpforder"].ParseInt(),
				LpfCutof = Data["NekoProject21"]["lpfcutof"].ParseInt(),
				FmWaitA  = Data["NekoProject21"]["FMWait_A"].ParseInt(),
				FmWaitD  = Data["NekoProject21"]["FMWait_D"].ParseInt(),
				MouseSns = Data["NekoProject21"]["MOUSESNS"].ParseInt(),
				FddWait  = Data["NekoProject21"]["FDD_Wait"].ParseInt(),
				JoystkId = Data["NekoProject21"]["JOYSTKID"].ParseInt(),
				CpuSpeed = Data["NekoProject21"]["CPUSPEED"].ParseInt(),
				MVolume  = Data["NekoProject21"]["M_Volume"].ParseInt(),
				VolumeV  = Data["NekoProject21"]["volume_V"].ParseInt(),
				F12Copy  = Data["NekoProject21"]["F12_COPY"].ParseInt(),
				Joystick = Data["NekoProject21"]["Joystick"].ParseBool(),
				Joy1Btn  = Data["NekoProject21"]["Joy1_btn"].ParseBytes(),
				ClockNow = Data["NekoProject21"]["clocknow"].ParseInt(),
				ClockFnt = Data["NekoProject21"]["clockfnt"].ParseInt(),
				UseSstp  = Data["NekoProject21"]["use_sstp"].ParseBool(),
				SstpPort = Data["NekoProject21"]["sstpport"].ParseInt(),
				Comfirm  = Data["NekoProject21"]["comfirm_"].ParseBool(),
				Shortcut = Data["NekoProject21"]["shortcut"].ParseInt(),
				Mpu98Map = Data["NekoProject21"]["mpu98map"],
				Mpu98Min = Data["NekoProject21"]["mpu98min"],
				Mpu98Mdl = Data["NekoProject21"]["mpu98mdl"],
				Mpu98Den = Data["NekoProject21"]["mpu98den"].ParseInt(),
				Mpu98Def = Data["NekoProject21"]["mpu98def"],
				Com1Port = Data["NekoProject21"]["com1port"].ParseInt(),
				Com1Para = Data["NekoProject21"]["com1para"].ParseInt(),
				Com1Bps  = Data["NekoProject21"]["com1_bps"].ParseInt(),
				Com1MMap = Data["NekoProject21"]["com1mmap"],
				Com1MMdl = Data["NekoProject21"]["com1mmdl"],
				Com1MDef = Data["NekoProject21"]["com1mdef"],
				Com2Port = Data["NekoProject21"]["com2port"].ParseInt(),
				Com2Para = Data["NekoProject21"]["com2para"].ParseInt(),
				Com2Bps  = Data["NekoProject21"]["com2_bps"].ParseInt(),
				Com2MMap = Data["NekoProject21"]["com2mmap"],
				Com2MMdl = Data["NekoProject21"]["com2mmdl"],
				Com2MDef = Data["NekoProject21"]["com2mdef"],
				Com3Port = Data["NekoProject21"]["com3port"].ParseInt(),
				Com3Para = Data["NekoProject21"]["com3para"].ParseInt(),
				Com3Bps  = Data["NekoProject21"]["com3_bps"].ParseInt(),
				Com3MMap = Data["NekoProject21"]["com3mmap"],
				Com3MMdl = Data["NekoProject21"]["com3mmdl"],
				Com3MDef = Data["NekoProject21"]["com3mdef"],
				EResume  = Data["NekoProject21"]["e_resume"].ParseBool(),
				Nousemmx = Data["NekoProject21"]["nousemmx"].ParseBool(),
				WindType = Data["NekoProject21"]["windtype"].ParseInt(),
				ToolWind = Data["NekoProject21"]["toolwind"].ParseBool(),
				KeyDispl = Data["NekoProject21"]["keydispl"].ParseBool(),
				JastSnd  = Data["NekoProject21"]["jast_snd"].ParseBool(),
				UseRomeo = Data["NekoProject21"]["useromeo"].ParseBool(),
				ThickFrm = Data["NekoProject21"]["thickfrm"].ParseBool(),
				FScrnMod = Data["NekoProject21"]["fscrnmod"].ParseInt(),
				SKeyDisp = Data["NekoProject21"]["skeydisp"].ParseBool(),
				Function = Data["NekoProject21"]["Function"].ParseBytes(),
				DllList  = Data["NekoProject21"]["Dll_List"].ParseInt(),
				FdlFile  = Data["NekoProject21"]["FDL_FILE"],
				FdCache  = Data["NekoProject21"]["FD_CACHE"].ParseInt()
			},
			new Np21ntConfig.NP2ToolSection() {
				WindPosX = Data["NP2 tool"]["WindposX"].ParseInt(),
				WindPosY = Data["NP2 tool"]["WindposY"].ParseInt(),
				WindType = Data["NP2 tool"]["WindType"].ParseBool(),
				SkinFile = Data["NP2 tool"]["SkinFile"],
				SkinMru0 = Data["NP2 tool"]["SkinMRU0"],
				SkinMru1 = Data["NP2 tool"]["SkinMRU1"],
				SkinMru2 = Data["NP2 tool"]["SkinMRU2"],
				SkinMru3 = Data["NP2 tool"]["SkinMRU3"],
				Fd1Name0 = Data["NP2 tool"]["FD1NAME0"],
				Fd1Name1 = Data["NP2 tool"]["FD1NAME1"],
				Fd1Name2 = Data["NP2 tool"]["FD1NAME2"],
				Fd1Name3 = Data["NP2 tool"]["FD1NAME3"],
				Fd1Name4 = Data["NP2 tool"]["FD1NAME4"],
				Fd1Name5 = Data["NP2 tool"]["FD1NAME5"],
				Fd1Name6 = Data["NP2 tool"]["FD1NAME6"],
				Fd1Name7 = Data["NP2 tool"]["FD1NAME7"],
				Fd2Name0 = Data["NP2 tool"]["FD2NAME0"],
				Fd2Name1 = Data["NP2 tool"]["FD2NAME1"],
				Fd2Name2 = Data["NP2 tool"]["FD2NAME2"],
				Fd2Name3 = Data["NP2 tool"]["FD2NAME3"],
				Fd2Name4 = Data["NP2 tool"]["FD2NAME4"],
				Fd2Name5 = Data["NP2 tool"]["FD2NAME5"],
				Fd2Name6 = Data["NP2 tool"]["FD2NAME6"],
				Fd2Name7 = Data["NP2 tool"]["FD2NAME7"]
			},
			new Np21ntConfig.KeyDisplaySection() {
				WindPosX = Data["Key Display"]["WindposX"].ParseInt(),
				WindPosY = Data["Key Display"]["WindposY"].ParseInt(),
				KeyDMode = Data["Key Display"]["keydmode"].ParseInt(),
				WindType = Data["Key Display"]["windtype"].ParseBool()
			},
			new Np21ntConfig.SoftKeyboardSection() {
				WindPosX = Data["Soft Keyboard"]["WindposX"].ParseInt(),
				WindPosY = Data["Soft Keyboard"]["WindposY"].ParseInt(),
				WindType = Data["Soft Keyboard"]["windtype"].ParseBool()
			},
			new Np21ntConfig.MemoryMapSection() {
				WindPosX = Data["Memory Map"]["WindposX"].ParseInt(),
				WindPosY = Data["Memory Map"]["WindposY"].ParseInt(),
				WindType = Data["Memory Map"]["windtype"].ParseBool()
			}
		);
	}

	namespace Extensions {
		public static class Np21ntConfigExtensionsForNp21ntConfigIni {
			public static Np21ntConfigIni ToIni(this Np21ntConfig domain) => new() {
				Data = new() {
					Sections = new() {
						new Section("NekoProject21") {
							Properties = new() {
								new Property("WindposX", domain.NekoProject21.WindPosX.ToString()),
								new Property("WindposY", domain.NekoProject21.WindPosY.ToString()),
								new Property("Win_Snap", domain.NekoProject21.WinSnap.ToString()),
								new Property("FDfolder", domain.NekoProject21.FdFolder),
								new Property("HDfolder", domain.NekoProject21.HdFolder),
								new Property("bmap_Dir", domain.NekoProject21.BMapDir),
								new Property("fontfile", domain.NekoProject21.FontFile),
								new Property("pc_model", domain.NekoProject21.PcModel),
								new Property("clk_base", domain.NekoProject21.ClkBase.ToString()),
								new Property("clk_mult", domain.NekoProject21.ClkMult.ToString()),
								new Property("DIPswtch", domain.NekoProject21.DipSwtch.ToHexString()),
								new Property("MEMswtch", domain.NekoProject21.MemSwtch.ToHexString()),
								new Property("ExMemory", domain.NekoProject21.ExMemory.ToString()),
								new Property("HDD1FILE", domain.NekoProject21.Hdd1File),
								new Property("HDD2FILE", domain.NekoProject21.Hdd2File),
								new Property("HDD3FILE", domain.NekoProject21.Hdd3File),
								new Property("SCSIHDD0", domain.NekoProject21.ScsiHdd0),
								new Property("SCSIHDD1", domain.NekoProject21.ScsiHdd1),
								new Property("SCSIHDD2", domain.NekoProject21.ScsiHdd2),
								new Property("SCSIHDD3", domain.NekoProject21.ScsiHdd3),
								new Property("SampleHz", domain.NekoProject21.SampleHz.ToString()),
								new Property("Latencys", domain.NekoProject21.LatencyS.ToString()),
								new Property("SNDboard", domain.NekoProject21.SndBoard.ToString()),
								new Property("BEEP_vol", domain.NekoProject21.BeepVol.ToString()),
								new Property("SND14vol", domain.NekoProject21.Snd14Vol.ToHexString()),
								new Property("opt26BRD", domain.NekoProject21.Opt26Brd.ToHexString()),
								new Property("opt86BRD", domain.NekoProject21.Opt86Brd.ToHexString()),
								new Property("optSPBRD", domain.NekoProject21.OptSpbrd.ToHexString()),
								new Property("optSPBVR", domain.NekoProject21.OptSpbvr.ToString()),
								new Property("optSPBVL", domain.NekoProject21.OptSpbvl.ToString()),
								new Property("optSPB_X", domain.NekoProject21.OptSpbX.ToString()),
								new Property("optMPU98", domain.NekoProject21.OptMpu98.ToString()),
								new Property("volume_F", domain.NekoProject21.VolumeF.ToString()),
								new Property("volume_S", domain.NekoProject21.VolumeS.ToString()),
								new Property("volume_A", domain.NekoProject21.VolumeA.ToString()),
								new Property("volume_P", domain.NekoProject21.VolumeP.ToString()),
								new Property("volume_R", domain.NekoProject21.VolumeR.ToString()),
								new Property("Seek_Snd", domain.NekoProject21.SeekSnd.ToString()),
								new Property("Seek_Vol", domain.NekoProject21.SeekVol.ToString()),
								new Property("btnRAPID", domain.NekoProject21.BtnRapid.ToString()),
								new Property("btn_MODE", domain.NekoProject21.BtnMode.ToString()),
								new Property("Mouse_sw", domain.NekoProject21.MouseSw.ToString()),
								new Property("MS_RAPID", domain.NekoProject21.MsRapid.ToString()),
								new Property("backgrnd", domain.NekoProject21.Backgrnd.ToString()),
								new Property("VRAMwait", domain.NekoProject21.VramWait.ToHexString()),
								new Property("DspClock", domain.NekoProject21.DspClock.ToString()),
								new Property("DispSync", domain.NekoProject21.DispSync.ToString()),
								new Property("Real_Pal", domain.NekoProject21.RealPal.ToString()),
								new Property("RPal_tim", domain.NekoProject21.RPalTim.ToString()),
								new Property("s_NOWAIT", domain.NekoProject21.SNoWait.ToString()),
								new Property("SkpFrame", domain.NekoProject21.SkpFrame.ToString()),
								new Property("uPD72020", domain.NekoProject21.UPd72020.ToString()),
								new Property("GRCG_EGC", domain.NekoProject21.GrcgEgc.ToString()),
								new Property("color16b", domain.NekoProject21.Color16B.ToString()),
								new Property("skipline", domain.NekoProject21.SkipLine.ToString()),
								new Property("skplight", domain.NekoProject21.SkpLight.ToString()),
								new Property("LCD_MODE", domain.NekoProject21.LcdMode.ToString()),
								new Property("pc9861_e", domain.NekoProject21.Pc9861E.ToString()),
								new Property("pc9861_s", domain.NekoProject21.Pc9861S.ToHexString()),
								new Property("pc9861_j", domain.NekoProject21.Pc9861J.ToHexString()),
								new Property("calendar", domain.NekoProject21.Calendar.ToString()),
								new Property("USE144FD", domain.NekoProject21.Use144Fd.ToString()),
								new Property("DrawType", domain.NekoProject21.DrawType.ToString()),
								new Property("SCRN_MUL", domain.NekoProject21.ScrnMul.ToString()),
								new Property("OPNA_CLK", domain.NekoProject21.OpnaClk.ToString()),
								new Property("FMG_RATE", domain.NekoProject21.FmgRate.ToString()),
								new Property("COFF_LPF", domain.NekoProject21.CoffLpf.ToString()),
								new Property("MIX_TYPE", domain.NekoProject21.MixType.ToString()),
								new Property("volume_C", domain.NekoProject21.VolumeC.ToString()),
								new Property("AAFILTER", domain.NekoProject21.AaFilter.ToString()),
								new Property("STFILTER", domain.NekoProject21.StFilter.ToString()),
								new Property("Priority", domain.NekoProject21.Priority.ToString()),
								new Property("BEEP_PCM", domain.NekoProject21.BeepPcm.ToString()),
								new Property("StatName", domain.NekoProject21.StatName),
								new Property("lpforder", domain.NekoProject21.LpfOrder.ToString()),
								new Property("lpfcutof", domain.NekoProject21.LpfCutof.ToString()),
								new Property("FMWait_A", domain.NekoProject21.FmWaitA.ToString()),
								new Property("FMWait_D", domain.NekoProject21.FmWaitD.ToString()),
								new Property("MOUSESNS", domain.NekoProject21.MouseSns.ToString()),
								new Property("FDD_Wait", domain.NekoProject21.FddWait.ToString()),
								new Property("JOYSTKID", domain.NekoProject21.JoystkId.ToString()),
								new Property("CPUSPEED", domain.NekoProject21.CpuSpeed.ToString()),
								new Property("M_Volume", domain.NekoProject21.MVolume.ToString()),
								new Property("volume_V", domain.NekoProject21.VolumeV.ToString()),
								new Property("F12_COPY", domain.NekoProject21.F12Copy.ToString()),
								new Property("Joystick", domain.NekoProject21.Joystick.ToString()),
								new Property("Joy1_btn", domain.NekoProject21.Joy1Btn.ToHexString()),
								new Property("clocknow", domain.NekoProject21.ClockNow.ToString()),
								new Property("clockfnt", domain.NekoProject21.ClockFnt.ToString()),
								new Property("use_sstp", domain.NekoProject21.UseSstp.ToString()),
								new Property("sstpport", domain.NekoProject21.SstpPort.ToString()),
								new Property("comfirm_", domain.NekoProject21.Comfirm.ToString()),
								new Property("shortcut", domain.NekoProject21.Shortcut.ToString()),
								new Property("mpu98map", domain.NekoProject21.Mpu98Map),
								new Property("mpu98min", domain.NekoProject21.Mpu98Min),
								new Property("mpu98mdl", domain.NekoProject21.Mpu98Mdl),
								new Property("mpu98den", domain.NekoProject21.Mpu98Den.ToString()),
								new Property("mpu98def", domain.NekoProject21.Mpu98Def),
								new Property("com1port", domain.NekoProject21.Com1Port.ToString()),
								new Property("com1para", domain.NekoProject21.Com1Para.ToString()),
								new Property("com1_bps", domain.NekoProject21.Com1Bps.ToString()),
								new Property("com1mmap", domain.NekoProject21.Com1MMap),
								new Property("com1mmdl", domain.NekoProject21.Com1MMdl),
								new Property("com1mdef", domain.NekoProject21.Com1MDef),
								new Property("com2port", domain.NekoProject21.Com2Port.ToString()),
								new Property("com2para", domain.NekoProject21.Com2Para.ToString()),
								new Property("com2_bps", domain.NekoProject21.Com2Bps.ToString()),
								new Property("com2mmap", domain.NekoProject21.Com2MMap),
								new Property("com2mmdl", domain.NekoProject21.Com2MMdl),
								new Property("com2mdef", domain.NekoProject21.Com2MDef),
								new Property("com3port", domain.NekoProject21.Com3Port.ToString()),
								new Property("com3para", domain.NekoProject21.Com3Para.ToString()),
								new Property("com3_bps", domain.NekoProject21.Com3Bps.ToString()),
								new Property("com3mmap", domain.NekoProject21.Com3MMap),
								new Property("com3mmdl", domain.NekoProject21.Com3MMdl),
								new Property("com3mdef", domain.NekoProject21.Com3MDef),
								new Property("e_resume", domain.NekoProject21.EResume.ToString()),
								new Property("nousemmx", domain.NekoProject21.Nousemmx.ToString()),
								new Property("windtype", domain.NekoProject21.WindType.ToString()),
								new Property("toolwind", domain.NekoProject21.ToolWind.ToString()),
								new Property("keydispl", domain.NekoProject21.KeyDispl.ToString()),
								new Property("jast_snd", domain.NekoProject21.JastSnd.ToString()),
								new Property("useromeo", domain.NekoProject21.UseRomeo.ToString()),
								new Property("thickfrm", domain.NekoProject21.ThickFrm.ToString()),
								new Property("fscrnmod", domain.NekoProject21.FScrnMod.ToString()),
								new Property("skeydisp", domain.NekoProject21.SKeyDisp.ToString()),
								new Property("Function", domain.NekoProject21.Function.ToHexString()),
								new Property("Dll_List", domain.NekoProject21.DllList.ToString()),
								new Property("FDL_FILE", domain.NekoProject21.FdlFile),
								new Property("FD_CACHE", domain.NekoProject21.FdCache.ToString())
							}
						},
						new Section("NP2 tool") {
							Properties = new() {
								new Property("WindposX", domain.NP2Tool.WindPosX.ToString()),
								new Property("WindposY", domain.NP2Tool.WindPosY.ToString()),
								new Property("WindType", domain.NP2Tool.WindType.ToString()),
								new Property("SkinFile", domain.NP2Tool.SkinFile),
								new Property("SkinMRU0", domain.NP2Tool.SkinMru0),
								new Property("SkinMRU1", domain.NP2Tool.SkinMru1),
								new Property("SkinMRU2", domain.NP2Tool.SkinMru2),
								new Property("SkinMRU3", domain.NP2Tool.SkinMru3),
								new Property("FD1NAME0", domain.NP2Tool.Fd1Name0),
								new Property("FD1NAME1", domain.NP2Tool.Fd1Name1),
								new Property("FD1NAME2", domain.NP2Tool.Fd1Name2),
								new Property("FD1NAME3", domain.NP2Tool.Fd1Name3),
								new Property("FD1NAME4", domain.NP2Tool.Fd1Name4),
								new Property("FD1NAME5", domain.NP2Tool.Fd1Name5),
								new Property("FD1NAME6", domain.NP2Tool.Fd1Name6),
								new Property("FD1NAME7", domain.NP2Tool.Fd1Name7),
								new Property("FD2NAME0", domain.NP2Tool.Fd2Name0),
								new Property("FD2NAME1", domain.NP2Tool.Fd2Name1),
								new Property("FD2NAME2", domain.NP2Tool.Fd2Name2),
								new Property("FD2NAME3", domain.NP2Tool.Fd2Name3),
								new Property("FD2NAME4", domain.NP2Tool.Fd2Name4),
								new Property("FD2NAME5", domain.NP2Tool.Fd2Name5),
								new Property("FD2NAME6", domain.NP2Tool.Fd2Name6),
								new Property("FD2NAME7", domain.NP2Tool.Fd2Name7)
							}
						},
						new Section("Key Display") {
							Properties = new() {
								new Property("WindposX", domain.KeyDisplay.WindPosX.ToString()),
								new Property("WindposY", domain.KeyDisplay.WindPosY.ToString()),
								new Property("keydmode", domain.KeyDisplay.KeyDMode.ToString()),
								new Property("windtype", domain.KeyDisplay.WindType.ToString())
							}
						},
						new Section("Soft Keyboard") {
							Properties = new() {
								new Property("WindposX", domain.SoftKeyboard.WindPosX.ToString()),
								new Property("WindposY", domain.SoftKeyboard.WindPosY.ToString()),
								new Property("windtype", domain.SoftKeyboard.WindType.ToString()),
							}
						},
						new Section("Memory Map") {
							Properties = new() {
								new Property("WindposX", domain.MemoryMap.WindPosX.ToString()),
								new Property("WindposY", domain.MemoryMap.WindPosY.ToString()),
								new Property("windtype", domain.MemoryMap.WindType.ToString()),
							}
						}
					}
				}
			};

			public static int ParseInt(this string input) => int.Parse(input);

			public static bool ParseBool(this string input) => bool.Parse(input);

			public static byte ParseByte(this string input) => Convert.ToByte(input, 16);

			public static byte[] ParseBytes(this string input) =>
				input.Split(" ")
					.Select(hexString => hexString.ParseByte())
					.ToArray();

			public static DipSwitch3 ParseDipSwitch3(this string input) =>
				input.ParseDipSwitches()
					.Transform(dipSwitchSegments => new DipSwitch3() {
						Segment1 = dipSwitchSegments[0],
						Segment2 = dipSwitchSegments[1],
						Segment3 = dipSwitchSegments[2]
					});

			public static DipSwitch8 ParseDipSwitch8(this string input) =>
				input.ParseDipSwitches()
					.Transform(dipSwitchSegments => new DipSwitch8() {
						Segment1 = dipSwitchSegments[0],
						Segment2 = dipSwitchSegments[1],
						Segment3 = dipSwitchSegments[2],
						Segment4 = dipSwitchSegments[3],
						Segment5 = dipSwitchSegments[4],
						Segment6 = dipSwitchSegments[5],
						Segment7 = dipSwitchSegments[6],
						Segment8 = dipSwitchSegments[7]
					});

			public static string ToHexString(this byte value) => value.ToString("x");

			public static string ToHexString(this byte[] bytes) =>
				string.Join(' ', bytes.Select(value => value.ToString("x")));

			public static string ToHexString(this DipSwitch dipSwitch) =>
				(
					(dipSwitch.Switch1.ToBinaryValue() << 7)
				  + (dipSwitch.Switch2.ToBinaryValue() << 6)
				  + (dipSwitch.Switch3.ToBinaryValue() << 5)
				  + (dipSwitch.Switch4.ToBinaryValue() << 4)
				  + (dipSwitch.Switch5.ToBinaryValue() << 3)
				  + (dipSwitch.Switch6.ToBinaryValue() << 2)
				  + (dipSwitch.Switch7.ToBinaryValue() << 1)
				  +  dipSwitch.Switch8.ToBinaryValue()
				).ToString("x");

			public static string ToHexString(this DipSwitch3 dipSwitch) =>
				  dipSwitch.Segment1.ToHexString() + " "
				+ dipSwitch.Segment2.ToHexString() + " "
				+ dipSwitch.Segment3.ToHexString();

			public static string ToHexString(this DipSwitch8 dipSwitch) =>
				  dipSwitch.Segment1.ToHexString() + " "
				+ dipSwitch.Segment2.ToHexString() + " "
				+ dipSwitch.Segment3.ToHexString() + " "
				+ dipSwitch.Segment4.ToHexString() + " "
				+ dipSwitch.Segment5.ToHexString() + " "
				+ dipSwitch.Segment6.ToHexString() + " "
				+ dipSwitch.Segment7.ToHexString() + " "
				+ dipSwitch.Segment8.ToHexString();

			private static DipSwitch[] ParseDipSwitches(this string input) =>
				input.ParseBytes()
					.Select(dipSwitchSegment => new DipSwitch() {
						Switch1 = (dipSwitchSegment & (1 << 7)) != 0,
						Switch2 = (dipSwitchSegment & (1 << 6)) != 0,
						Switch3 = (dipSwitchSegment & (1 << 5)) != 0,
						Switch4 = (dipSwitchSegment & (1 << 4)) != 0,
						Switch5 = (dipSwitchSegment & (1 << 3)) != 0,
						Switch6 = (dipSwitchSegment & (1 << 2)) != 0,
						Switch7 = (dipSwitchSegment & (1 << 1)) != 0,
						Switch8 = (dipSwitchSegment & 1)        != 0
					}).ToArray();

			private static int ToBinaryValue(this bool value) => value ? 1 : 0;
		}
	}
}
