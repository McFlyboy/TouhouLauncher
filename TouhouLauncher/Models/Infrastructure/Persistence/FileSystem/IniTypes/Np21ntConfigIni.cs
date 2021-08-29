#nullable disable

using IniParser.Model;
using System;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes {
	public record Np21ntConfigIni : Ini {
		public Np21ntConfig ToDomain(Np21ntConfig configDefaults) => new(
			new Np21ntConfig.NekoProject21Section() {
				WindPosX = Data["NekoProject21"]?["WindposX"]?.ParseInt()        ?? configDefaults.NekoProject21.WindPosX,
				WindPosY = Data["NekoProject21"]?["WindposY"]?.ParseInt()        ?? configDefaults.NekoProject21.WindPosY,
				WinSnap  = Data["NekoProject21"]?["Win_Snap"]?.ParseBool()       ?? configDefaults.NekoProject21.WinSnap ,
				FdFolder = Data["NekoProject21"]?["FDfolder"]                    ?? configDefaults.NekoProject21.FdFolder,
				HdFolder = Data["NekoProject21"]?["HDfolder"]                    ?? configDefaults.NekoProject21.HdFolder,
				BMapDir  = Data["NekoProject21"]?["bmap_Dir"]                    ?? configDefaults.NekoProject21.BMapDir ,
				FontFile = Data["NekoProject21"]?["fontfile"]                    ?? configDefaults.NekoProject21.FontFile,
				PcModel  = Data["NekoProject21"]?["pc_model"]                    ?? configDefaults.NekoProject21.PcModel ,
				ClkBase  = Data["NekoProject21"]?["clk_base"]?.ParseInt()        ?? configDefaults.NekoProject21.ClkBase ,
				ClkMult  = Data["NekoProject21"]?["clk_mult"]?.ParseInt()        ?? configDefaults.NekoProject21.ClkMult ,
				DipSwtch = Data["NekoProject21"]?["DIPswtch"]?.ParseDipSwitch3() ?? configDefaults.NekoProject21.DipSwtch,
				MemSwtch = Data["NekoProject21"]?["MEMswtch"]?.ParseDipSwitch8() ?? configDefaults.NekoProject21.MemSwtch,
				ExMemory = Data["NekoProject21"]?["ExMemory"]?.ParseInt()        ?? configDefaults.NekoProject21.ExMemory,
				Hdd1File = Data["NekoProject21"]?["HDD1FILE"]                    ?? configDefaults.NekoProject21.Hdd1File,
				Hdd2File = Data["NekoProject21"]?["HDD2FILE"]                    ?? configDefaults.NekoProject21.Hdd2File,
				Hdd3File = Data["NekoProject21"]?["HDD3FILE"]                    ?? configDefaults.NekoProject21.Hdd3File,
				ScsiHdd0 = Data["NekoProject21"]?["SCSIHDD0"]                    ?? configDefaults.NekoProject21.ScsiHdd0,
				ScsiHdd1 = Data["NekoProject21"]?["SCSIHDD1"]                    ?? configDefaults.NekoProject21.ScsiHdd1,
				ScsiHdd2 = Data["NekoProject21"]?["SCSIHDD2"]                    ?? configDefaults.NekoProject21.ScsiHdd2,
				ScsiHdd3 = Data["NekoProject21"]?["SCSIHDD3"]                    ?? configDefaults.NekoProject21.ScsiHdd3,
				SampleHz = Data["NekoProject21"]?["SampleHz"]?.ParseInt()        ?? configDefaults.NekoProject21.SampleHz,
				LatencyS = Data["NekoProject21"]?["Latencys"]?.ParseInt()        ?? configDefaults.NekoProject21.LatencyS,
				SndBoard = Data["NekoProject21"]?["SNDboard"]?.ParseByte()       ?? configDefaults.NekoProject21.SndBoard,
				BeepVol  = Data["NekoProject21"]?["BEEP_vol"]?.ParseInt()        ?? configDefaults.NekoProject21.BeepVol ,
				Snd14Vol = Data["NekoProject21"]?["SND14vol"]?.ParseBytes()      ?? configDefaults.NekoProject21.Snd14Vol,
				Opt26Brd = Data["NekoProject21"]?["opt26BRD"]?.ParseByte()       ?? configDefaults.NekoProject21.Opt26Brd,
				Opt86Brd = Data["NekoProject21"]?["opt86BRD"]?.ParseByte()       ?? configDefaults.NekoProject21.Opt86Brd,
				OptSpbrd = Data["NekoProject21"]?["optSPBRD"]?.ParseByte()       ?? configDefaults.NekoProject21.OptSpbrd,
				OptSpbvr = Data["NekoProject21"]?["optSPBVR"]?.ParseByte()       ?? configDefaults.NekoProject21.OptSpbvr,
				OptSpbvl = Data["NekoProject21"]?["optSPBVL"]?.ParseInt()        ?? configDefaults.NekoProject21.OptSpbvl,
				OptSpbX  = Data["NekoProject21"]?["optSPB_X"]?.ParseBool()       ?? configDefaults.NekoProject21.OptSpbX ,
				OptMpu98 = Data["NekoProject21"]?["optMPU98"]?.ParseByte()       ?? configDefaults.NekoProject21.OptMpu98,
				VolumeF  = Data["NekoProject21"]?["volume_F"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeF ,
				VolumeS  = Data["NekoProject21"]?["volume_S"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeS ,
				VolumeA  = Data["NekoProject21"]?["volume_A"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeA ,
				VolumeP  = Data["NekoProject21"]?["volume_P"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeP ,
				VolumeR  = Data["NekoProject21"]?["volume_R"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeR ,
				SeekSnd  = Data["NekoProject21"]?["Seek_Snd"]?.ParseBool()       ?? configDefaults.NekoProject21.SeekSnd ,
				SeekVol  = Data["NekoProject21"]?["Seek_Vol"]?.ParseInt()        ?? configDefaults.NekoProject21.SeekVol ,
				BtnRapid = Data["NekoProject21"]?["btnRAPID"]?.ParseBool()       ?? configDefaults.NekoProject21.BtnRapid,
				BtnMode  = Data["NekoProject21"]?["btn_MODE"]?.ParseBool()       ?? configDefaults.NekoProject21.BtnMode ,
				MouseSw  = Data["NekoProject21"]?["Mouse_sw"]?.ParseBool()       ?? configDefaults.NekoProject21.MouseSw ,
				MsRapid  = Data["NekoProject21"]?["MS_RAPID"]?.ParseBool()       ?? configDefaults.NekoProject21.MsRapid ,
				Backgrnd = Data["NekoProject21"]?["backgrnd"]?.ParseInt()        ?? configDefaults.NekoProject21.Backgrnd,
				VramWait = Data["NekoProject21"]?["VRAMwait"]?.ParseBytes()      ?? configDefaults.NekoProject21.VramWait,
				DspClock = Data["NekoProject21"]?["DspClock"]?.ParseInt()        ?? configDefaults.NekoProject21.DspClock,
				DispSync = Data["NekoProject21"]?["DispSync"]?.ParseBool()       ?? configDefaults.NekoProject21.DispSync,
				RealPal  = Data["NekoProject21"]?["Real_Pal"]?.ParseBool()       ?? configDefaults.NekoProject21.RealPal ,
				RPalTim  = Data["NekoProject21"]?["RPal_tim"]?.ParseInt()        ?? configDefaults.NekoProject21.RPalTim ,
				SNoWait  = Data["NekoProject21"]?["s_NOWAIT"]?.ParseBool()       ?? configDefaults.NekoProject21.SNoWait ,
				SkpFrame = Data["NekoProject21"]?["SkpFrame"]?.ParseInt()        ?? configDefaults.NekoProject21.SkpFrame,
				UPd72020 = Data["NekoProject21"]?["uPD72020"]?.ParseBool()       ?? configDefaults.NekoProject21.UPd72020,
				GrcgEgc  = Data["NekoProject21"]?["GRCG_EGC"]?.ParseInt()        ?? configDefaults.NekoProject21.GrcgEgc ,
				Color16B = Data["NekoProject21"]?["color16b"]?.ParseBool()       ?? configDefaults.NekoProject21.Color16B,
				SkipLine = Data["NekoProject21"]?["skipline"]?.ParseBool()       ?? configDefaults.NekoProject21.SkipLine,
				SkpLight = Data["NekoProject21"]?["skplight"]?.ParseInt()        ?? configDefaults.NekoProject21.SkpLight,
				LcdMode  = Data["NekoProject21"]?["LCD_MODE"]?.ParseInt()        ?? configDefaults.NekoProject21.LcdMode ,
				Pc9861E  = Data["NekoProject21"]?["pc9861_e"]?.ParseBool()       ?? configDefaults.NekoProject21.Pc9861E ,
				Pc9861S  = Data["NekoProject21"]?["pc9861_s"]?.ParseBytes()      ?? configDefaults.NekoProject21.Pc9861S ,
				Pc9861J  = Data["NekoProject21"]?["pc9861_j"]?.ParseBytes()      ?? configDefaults.NekoProject21.Pc9861J ,
				Calendar = Data["NekoProject21"]?["calendar"]?.ParseBool()       ?? configDefaults.NekoProject21.Calendar,
				Use144Fd = Data["NekoProject21"]?["USE144FD"]?.ParseBool()       ?? configDefaults.NekoProject21.Use144Fd,
				DrawType = Data["NekoProject21"]?["DrawType"]?.ParseInt()        ?? configDefaults.NekoProject21.DrawType,
				ScrnMul  = Data["NekoProject21"]?["SCRN_MUL"]?.ParseInt()        ?? configDefaults.NekoProject21.ScrnMul ,
				OpnaClk  = Data["NekoProject21"]?["OPNA_CLK"]?.ParseInt()        ?? configDefaults.NekoProject21.OpnaClk ,
				FmgRate  = Data["NekoProject21"]?["FMG_RATE"]?.ParseInt()        ?? configDefaults.NekoProject21.FmgRate ,
				CoffLpf  = Data["NekoProject21"]?["COFF_LPF"]?.ParseBool()       ?? configDefaults.NekoProject21.CoffLpf ,
				MixType  = Data["NekoProject21"]?["MIX_TYPE"]?.ParseBool()       ?? configDefaults.NekoProject21.MixType ,
				VolumeC  = Data["NekoProject21"]?["volume_C"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeC ,
				AaFilter = Data["NekoProject21"]?["AAFILTER"]?.ParseInt()        ?? configDefaults.NekoProject21.AaFilter,
				StFilter = Data["NekoProject21"]?["STFILTER"]?.ParseInt()        ?? configDefaults.NekoProject21.StFilter,
				Priority = Data["NekoProject21"]?["Priority"]?.ParseInt()        ?? configDefaults.NekoProject21.Priority,
				BeepPcm  = Data["NekoProject21"]?["BEEP_PCM"]?.ParseInt()        ?? configDefaults.NekoProject21.BeepPcm ,
				StatName = Data["NekoProject21"]?["StatName"]                    ?? configDefaults.NekoProject21.StatName,
				LpfOrder = Data["NekoProject21"]?["lpforder"]?.ParseInt()        ?? configDefaults.NekoProject21.LpfOrder,
				LpfCutof = Data["NekoProject21"]?["lpfcutof"]?.ParseInt()        ?? configDefaults.NekoProject21.LpfCutof,
				FmWaitA  = Data["NekoProject21"]?["FMWait_A"]?.ParseInt()        ?? configDefaults.NekoProject21.FmWaitA ,
				FmWaitD  = Data["NekoProject21"]?["FMWait_D"]?.ParseInt()        ?? configDefaults.NekoProject21.FmWaitD ,
				MouseSns = Data["NekoProject21"]?["MOUSESNS"]?.ParseInt()        ?? configDefaults.NekoProject21.MouseSns,
				FddWait  = Data["NekoProject21"]?["FDD_Wait"]?.ParseInt()        ?? configDefaults.NekoProject21.FddWait ,
				JoystkId = Data["NekoProject21"]?["JOYSTKID"]?.ParseInt()        ?? configDefaults.NekoProject21.JoystkId,
				CpuSpeed = Data["NekoProject21"]?["CPUSPEED"]?.ParseInt()        ?? configDefaults.NekoProject21.CpuSpeed,
				MVolume  = Data["NekoProject21"]?["M_Volume"]?.ParseInt()        ?? configDefaults.NekoProject21.MVolume ,
				VolumeV  = Data["NekoProject21"]?["volume_V"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeV ,
				F12Copy  = Data["NekoProject21"]?["F12_COPY"]?.ParseInt()        ?? configDefaults.NekoProject21.F12Copy ,
				Joystick = Data["NekoProject21"]?["Joystick"]?.ParseBool()       ?? configDefaults.NekoProject21.Joystick,
				Joy1Btn  = Data["NekoProject21"]?["Joy1_btn"]?.ParseBytes()      ?? configDefaults.NekoProject21.Joy1Btn ,
				ClockNow = Data["NekoProject21"]?["clocknow"]?.ParseInt()        ?? configDefaults.NekoProject21.ClockNow,
				ClockFnt = Data["NekoProject21"]?["clockfnt"]?.ParseInt()        ?? configDefaults.NekoProject21.ClockFnt,
				UseSstp  = Data["NekoProject21"]?["use_sstp"]?.ParseBool()       ?? configDefaults.NekoProject21.UseSstp ,
				SstpPort = Data["NekoProject21"]?["sstpport"]?.ParseInt()        ?? configDefaults.NekoProject21.SstpPort,
				Comfirm  = Data["NekoProject21"]?["comfirm_"]?.ParseBool()       ?? configDefaults.NekoProject21.Comfirm ,
				Shortcut = Data["NekoProject21"]?["shortcut"]?.ParseByte()       ?? configDefaults.NekoProject21.Shortcut,
				Mpu98Map = Data["NekoProject21"]?["mpu98map"]                    ?? configDefaults.NekoProject21.Mpu98Map,
				Mpu98Min = Data["NekoProject21"]?["mpu98min"]                    ?? configDefaults.NekoProject21.Mpu98Min,
				Mpu98Mdl = Data["NekoProject21"]?["mpu98mdl"]                    ?? configDefaults.NekoProject21.Mpu98Mdl,
				Mpu98Den = Data["NekoProject21"]?["mpu98den"]?.ParseInt()        ?? configDefaults.NekoProject21.Mpu98Den,
				Mpu98Def = Data["NekoProject21"]?["mpu98def"]                    ?? configDefaults.NekoProject21.Mpu98Def,
				Com1Port = Data["NekoProject21"]?["com1port"]?.ParseInt()        ?? configDefaults.NekoProject21.Com1Port,
				Com1Para = Data["NekoProject21"]?["com1para"]?.ParseInt()        ?? configDefaults.NekoProject21.Com1Para,
				Com1Bps  = Data["NekoProject21"]?["com1_bps"]?.ParseInt()        ?? configDefaults.NekoProject21.Com1Bps ,
				Com1MMap = Data["NekoProject21"]?["com1mmap"]                    ?? configDefaults.NekoProject21.Com1MMap,
				Com1MMdl = Data["NekoProject21"]?["com1mmdl"]                    ?? configDefaults.NekoProject21.Com1MMdl,
				Com1MDef = Data["NekoProject21"]?["com1mdef"]                    ?? configDefaults.NekoProject21.Com1MDef,
				Com2Port = Data["NekoProject21"]?["com2port"]?.ParseInt()        ?? configDefaults.NekoProject21.Com2Port,
				Com2Para = Data["NekoProject21"]?["com2para"]?.ParseInt()        ?? configDefaults.NekoProject21.Com2Para,
				Com2Bps  = Data["NekoProject21"]?["com2_bps"]?.ParseInt()        ?? configDefaults.NekoProject21.Com2Bps ,
				Com2MMap = Data["NekoProject21"]?["com2mmap"]                    ?? configDefaults.NekoProject21.Com2MMap,
				Com2MMdl = Data["NekoProject21"]?["com2mmdl"]                    ?? configDefaults.NekoProject21.Com2MMdl,
				Com2MDef = Data["NekoProject21"]?["com2mdef"]                    ?? configDefaults.NekoProject21.Com2MDef,
				Com3Port = Data["NekoProject21"]?["com3port"]?.ParseInt()        ?? configDefaults.NekoProject21.Com3Port,
				Com3Para = Data["NekoProject21"]?["com3para"]?.ParseInt()        ?? configDefaults.NekoProject21.Com3Para,
				Com3Bps  = Data["NekoProject21"]?["com3_bps"]?.ParseInt()        ?? configDefaults.NekoProject21.Com3Bps ,
				Com3MMap = Data["NekoProject21"]?["com3mmap"]                    ?? configDefaults.NekoProject21.Com3MMap,
				Com3MMdl = Data["NekoProject21"]?["com3mmdl"]                    ?? configDefaults.NekoProject21.Com3MMdl,
				Com3MDef = Data["NekoProject21"]?["com3mdef"]                    ?? configDefaults.NekoProject21.Com3MDef,
				EResume  = Data["NekoProject21"]?["e_resume"]?.ParseBool()       ?? configDefaults.NekoProject21.EResume ,
				Nousemmx = Data["NekoProject21"]?["nousemmx"]?.ParseBool()       ?? configDefaults.NekoProject21.Nousemmx,
				WindType = Data["NekoProject21"]?["windtype"]?.ParseInt()        ?? configDefaults.NekoProject21.WindType,
				ToolWind = Data["NekoProject21"]?["toolwind"]?.ParseBool()       ?? configDefaults.NekoProject21.ToolWind,
				KeyDispl = Data["NekoProject21"]?["keydispl"]?.ParseBool()       ?? configDefaults.NekoProject21.KeyDispl,
				JastSnd  = Data["NekoProject21"]?["jast_snd"]?.ParseBool()       ?? configDefaults.NekoProject21.JastSnd ,
				UseRomeo = Data["NekoProject21"]?["useromeo"]?.ParseBool()       ?? configDefaults.NekoProject21.UseRomeo,
				ThickFrm = Data["NekoProject21"]?["thickfrm"]?.ParseBool()       ?? configDefaults.NekoProject21.ThickFrm,
				FScrnMod = Data["NekoProject21"]?["fscrnmod"]?.ParseByte()       ?? configDefaults.NekoProject21.FScrnMod,
				SKeyDisp = Data["NekoProject21"]?["skeydisp"]?.ParseBool()       ?? configDefaults.NekoProject21.SKeyDisp,
				Function = Data["NekoProject21"]?["Function"]?.ParseBytes()      ?? configDefaults.NekoProject21.Function,
				DllList  = Data["NekoProject21"]?["Dll_List"]?.ParseInt()        ?? configDefaults.NekoProject21.DllList ,
				FdlFile  = Data["NekoProject21"]?["FDL_FILE"]                    ?? configDefaults.NekoProject21.FdlFile ,
				FdCache  = Data["NekoProject21"]?["FD_CACHE"]?.ParseInt()        ?? configDefaults.NekoProject21.FdCache
			},
			new Np21ntConfig.NP2ToolSection() {
				WindPosX = Data["NP2 tool"]?["WindposX"]?.ParseInt()             ?? configDefaults.NP2Tool.WindPosX,
				WindPosY = Data["NP2 tool"]?["WindposY"]?.ParseInt()             ?? configDefaults.NP2Tool.WindPosY,
				WindType = Data["NP2 tool"]?["WindType"]?.ParseBool()            ?? configDefaults.NP2Tool.WindType,
				SkinFile = Data["NP2 tool"]?["SkinFile"]                         ?? configDefaults.NP2Tool.SkinFile,
				SkinMru0 = Data["NP2 tool"]?["SkinMRU0"]                         ?? configDefaults.NP2Tool.SkinMru0,
				SkinMru1 = Data["NP2 tool"]?["SkinMRU1"]                         ?? configDefaults.NP2Tool.SkinMru1,
				SkinMru2 = Data["NP2 tool"]?["SkinMRU2"]                         ?? configDefaults.NP2Tool.SkinMru2,
				SkinMru3 = Data["NP2 tool"]?["SkinMRU3"]                         ?? configDefaults.NP2Tool.SkinMru3,
				Fd1Name0 = Data["NP2 tool"]?["FD1NAME0"]                         ?? configDefaults.NP2Tool.Fd1Name0,
				Fd1Name1 = Data["NP2 tool"]?["FD1NAME1"]                         ?? configDefaults.NP2Tool.Fd1Name1,
				Fd1Name2 = Data["NP2 tool"]?["FD1NAME2"]                         ?? configDefaults.NP2Tool.Fd1Name2,
				Fd1Name3 = Data["NP2 tool"]?["FD1NAME3"]                         ?? configDefaults.NP2Tool.Fd1Name3,
				Fd1Name4 = Data["NP2 tool"]?["FD1NAME4"]                         ?? configDefaults.NP2Tool.Fd1Name4,
				Fd1Name5 = Data["NP2 tool"]?["FD1NAME5"]                         ?? configDefaults.NP2Tool.Fd1Name5,
				Fd1Name6 = Data["NP2 tool"]?["FD1NAME6"]                         ?? configDefaults.NP2Tool.Fd1Name6,
				Fd1Name7 = Data["NP2 tool"]?["FD1NAME7"]                         ?? configDefaults.NP2Tool.Fd1Name7,
				Fd2Name0 = Data["NP2 tool"]?["FD2NAME0"]                         ?? configDefaults.NP2Tool.Fd2Name0,
				Fd2Name1 = Data["NP2 tool"]?["FD2NAME1"]                         ?? configDefaults.NP2Tool.Fd2Name1,
				Fd2Name2 = Data["NP2 tool"]?["FD2NAME2"]                         ?? configDefaults.NP2Tool.Fd2Name2,
				Fd2Name3 = Data["NP2 tool"]?["FD2NAME3"]                         ?? configDefaults.NP2Tool.Fd2Name3,
				Fd2Name4 = Data["NP2 tool"]?["FD2NAME4"]                         ?? configDefaults.NP2Tool.Fd2Name4,
				Fd2Name5 = Data["NP2 tool"]?["FD2NAME5"]                         ?? configDefaults.NP2Tool.Fd2Name5,
				Fd2Name6 = Data["NP2 tool"]?["FD2NAME6"]                         ?? configDefaults.NP2Tool.Fd2Name6,
				Fd2Name7 = Data["NP2 tool"]?["FD2NAME7"]                         ?? configDefaults.NP2Tool.Fd2Name7
			},
			new Np21ntConfig.KeyDisplaySection() {
				WindPosX = Data["Key Display"]?["WindposX"]?.ParseInt()          ?? configDefaults.KeyDisplay.WindPosX,
				WindPosY = Data["Key Display"]?["WindposY"]?.ParseInt()          ?? configDefaults.KeyDisplay.WindPosY,
				KeyDMode = Data["Key Display"]?["keydmode"]?.ParseInt()          ?? configDefaults.KeyDisplay.KeyDMode,
				WindType = Data["Key Display"]?["windtype"]?.ParseBool()         ?? configDefaults.KeyDisplay.WindType
			},
			new Np21ntConfig.SoftKeyboardSection() {
				WindPosX = Data["Soft Keyboard"]?["WindposX"]?.ParseInt()        ?? configDefaults.SoftKeyboard.WindPosX,
				WindPosY = Data["Soft Keyboard"]?["WindposY"]?.ParseInt()        ?? configDefaults.SoftKeyboard.WindPosY,
				WindType = Data["Soft Keyboard"]?["windtype"]?.ParseBool()       ?? configDefaults.SoftKeyboard.WindType
			},
			new Np21ntConfig.MemoryMapSection() {
				WindPosX = Data["Memory Map"]?["WindposX"]?.ParseInt()           ?? configDefaults.MemoryMap.WindPosX,
				WindPosY = Data["Memory Map"]?["WindposY"]?.ParseInt()           ?? configDefaults.MemoryMap.WindPosY,
				WindType = Data["Memory Map"]?["windtype"]?.ParseBool()          ?? configDefaults.MemoryMap.WindType
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
								new Property("Win_Snap", domain.NekoProject21.WinSnap.ToString().ToLower()),
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
								new Property("SNDboard", domain.NekoProject21.SndBoard.ToHexString()),
								new Property("BEEP_vol", domain.NekoProject21.BeepVol.ToString()),
								new Property("SND14vol", domain.NekoProject21.Snd14Vol.ToHexString()),
								new Property("opt26BRD", domain.NekoProject21.Opt26Brd.ToHexString()),
								new Property("opt86BRD", domain.NekoProject21.Opt86Brd.ToHexString()),
								new Property("optSPBRD", domain.NekoProject21.OptSpbrd.ToHexString()),
								new Property("optSPBVR", domain.NekoProject21.OptSpbvr.ToHexString()),
								new Property("optSPBVL", domain.NekoProject21.OptSpbvl.ToString()),
								new Property("optSPB_X", domain.NekoProject21.OptSpbX.ToString().ToLower()),
								new Property("optMPU98", domain.NekoProject21.OptMpu98.ToHexString()),
								new Property("volume_F", domain.NekoProject21.VolumeF.ToString()),
								new Property("volume_S", domain.NekoProject21.VolumeS.ToString()),
								new Property("volume_A", domain.NekoProject21.VolumeA.ToString()),
								new Property("volume_P", domain.NekoProject21.VolumeP.ToString()),
								new Property("volume_R", domain.NekoProject21.VolumeR.ToString()),
								new Property("Seek_Snd", domain.NekoProject21.SeekSnd.ToString().ToLower()),
								new Property("Seek_Vol", domain.NekoProject21.SeekVol.ToString()),
								new Property("btnRAPID", domain.NekoProject21.BtnRapid.ToString().ToLower()),
								new Property("btn_MODE", domain.NekoProject21.BtnMode.ToString().ToLower()),
								new Property("Mouse_sw", domain.NekoProject21.MouseSw.ToString().ToLower()),
								new Property("MS_RAPID", domain.NekoProject21.MsRapid.ToString().ToLower()),
								new Property("backgrnd", domain.NekoProject21.Backgrnd.ToString()),
								new Property("VRAMwait", domain.NekoProject21.VramWait.ToHexString()),
								new Property("DspClock", domain.NekoProject21.DspClock.ToString()),
								new Property("DispSync", domain.NekoProject21.DispSync.ToString().ToLower()),
								new Property("Real_Pal", domain.NekoProject21.RealPal.ToString().ToLower()),
								new Property("RPal_tim", domain.NekoProject21.RPalTim.ToString()),
								new Property("s_NOWAIT", domain.NekoProject21.SNoWait.ToString().ToLower()),
								new Property("SkpFrame", domain.NekoProject21.SkpFrame.ToString()),
								new Property("uPD72020", domain.NekoProject21.UPd72020.ToString().ToLower()),
								new Property("GRCG_EGC", domain.NekoProject21.GrcgEgc.ToString()),
								new Property("color16b", domain.NekoProject21.Color16B.ToString().ToLower()),
								new Property("skipline", domain.NekoProject21.SkipLine.ToString().ToLower()),
								new Property("skplight", domain.NekoProject21.SkpLight.ToString()),
								new Property("LCD_MODE", domain.NekoProject21.LcdMode.ToString()),
								new Property("pc9861_e", domain.NekoProject21.Pc9861E.ToString().ToLower()),
								new Property("pc9861_s", domain.NekoProject21.Pc9861S.ToHexString()),
								new Property("pc9861_j", domain.NekoProject21.Pc9861J.ToHexString()),
								new Property("calendar", domain.NekoProject21.Calendar.ToString().ToLower()),
								new Property("USE144FD", domain.NekoProject21.Use144Fd.ToString().ToLower()),
								new Property("DrawType", domain.NekoProject21.DrawType.ToString()),
								new Property("SCRN_MUL", domain.NekoProject21.ScrnMul.ToString()),
								new Property("OPNA_CLK", domain.NekoProject21.OpnaClk.ToString()),
								new Property("FMG_RATE", domain.NekoProject21.FmgRate.ToString()),
								new Property("COFF_LPF", domain.NekoProject21.CoffLpf.ToString().ToLower()),
								new Property("MIX_TYPE", domain.NekoProject21.MixType.ToString().ToLower()),
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
								new Property("Joystick", domain.NekoProject21.Joystick.ToString().ToLower()),
								new Property("Joy1_btn", domain.NekoProject21.Joy1Btn.ToHexString()),
								new Property("clocknow", domain.NekoProject21.ClockNow.ToString()),
								new Property("clockfnt", domain.NekoProject21.ClockFnt.ToString()),
								new Property("use_sstp", domain.NekoProject21.UseSstp.ToString().ToLower()),
								new Property("sstpport", domain.NekoProject21.SstpPort.ToString()),
								new Property("comfirm_", domain.NekoProject21.Comfirm.ToString().ToLower()),
								new Property("shortcut", domain.NekoProject21.Shortcut.ToHexString()),
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
								new Property("e_resume", domain.NekoProject21.EResume.ToString().ToLower()),
								new Property("nousemmx", domain.NekoProject21.Nousemmx.ToString().ToLower()),
								new Property("windtype", domain.NekoProject21.WindType.ToString()),
								new Property("toolwind", domain.NekoProject21.ToolWind.ToString().ToLower()),
								new Property("keydispl", domain.NekoProject21.KeyDispl.ToString().ToLower()),
								new Property("jast_snd", domain.NekoProject21.JastSnd.ToString().ToLower()),
								new Property("useromeo", domain.NekoProject21.UseRomeo.ToString().ToLower()),
								new Property("thickfrm", domain.NekoProject21.ThickFrm.ToString().ToLower()),
								new Property("fscrnmod", domain.NekoProject21.FScrnMod.ToHexString()),
								new Property("skeydisp", domain.NekoProject21.SKeyDisp.ToString().ToLower()),
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
								new Property("WindType", domain.NP2Tool.WindType.ToString().ToLower()),
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
								new Property("windtype", domain.KeyDisplay.WindType.ToString().ToLower())
							}
						},
						new Section("Soft Keyboard") {
							Properties = new() {
								new Property("WindposX", domain.SoftKeyboard.WindPosX.ToString()),
								new Property("WindposY", domain.SoftKeyboard.WindPosY.ToString()),
								new Property("windtype", domain.SoftKeyboard.WindType.ToString().ToLower()),
							}
						},
						new Section("Memory Map") {
							Properties = new() {
								new Property("WindposX", domain.MemoryMap.WindPosX.ToString()),
								new Property("WindposY", domain.MemoryMap.WindPosY.ToString()),
								new Property("windtype", domain.MemoryMap.WindType.ToString().ToLower()),
							}
						}
					}
				}
			};

			public static int? ParseInt(this string input) {
				try {
					return int.Parse(input);
				}
				catch (Exception) {
					return null;
				}
			}

			public static bool? ParseBool(this string input) {
				try {
					return bool.Parse(input);
				}
				catch (Exception) {
					return null;
				}
			}

			public static byte? ParseByte(this string input) {
				try {
					return Convert.ToByte(input, 16);
				}
				catch (Exception) {
					return null;
				}
			}

			public static byte[] ParseBytes(this string input) {
				try {
					return input.Split(" ")
						.Select(hexString => (byte)hexString.ParseByte())
						.ToArray();
				}
				catch (Exception) {
					return null;
				}
			}

			public static DipSwitch3 ParseDipSwitch3(this string input) =>
				input.ParseBytes()
					?.Transform(dipSwitchSegments => new DipSwitch3(
						dipSwitchSegments[0],
						dipSwitchSegments[1],
						dipSwitchSegments[2]
					));

			public static DipSwitch8 ParseDipSwitch8(this string input) =>
				input.ParseBytes()
					?.Transform(dipSwitchSegments => new DipSwitch8(
						dipSwitchSegments[0],
						dipSwitchSegments[1],
						dipSwitchSegments[2],
						dipSwitchSegments[3],
						dipSwitchSegments[4],
						dipSwitchSegments[5],
						dipSwitchSegments[6],
						dipSwitchSegments[7]
					));

			public static string ToHexString(this byte value) => value.ToString("x");

			public static string ToHexString(this byte[] bytes) =>
				string.Join(' ', bytes.Select(value => value.ToString("x2")));

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
				).ToString("x2");

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

			private static int ToBinaryValue(this bool value) => value ? 1 : 0;
		}
	}
}
