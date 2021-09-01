using IniParser.Model;
using System;
using System.Linq;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes {
	public record Np21ntConfigIni : Ini {
		public Np21ntConfig ToDomain(Np21ntConfig configDefaults) => new(
			new Np21ntConfig.NekoProject21Section(
				windPosX: Data["NekoProject21"]?["WindposX"]?.ParseInt()        ?? configDefaults.NekoProject21.WindPosX,
				windPosY: Data["NekoProject21"]?["WindposY"]?.ParseInt()        ?? configDefaults.NekoProject21.WindPosY,
				winSnap : Data["NekoProject21"]?["Win_Snap"]?.ParseBool()       ?? configDefaults.NekoProject21.WinSnap ,
				fdFolder: Data["NekoProject21"]?["FDfolder"]                    ?? configDefaults.NekoProject21.FdFolder,
				hdFolder: Data["NekoProject21"]?["HDfolder"]                    ?? configDefaults.NekoProject21.HdFolder,
				bMapDir : Data["NekoProject21"]?["bmap_Dir"]                    ?? configDefaults.NekoProject21.BMapDir ,
				fontFile: Data["NekoProject21"]?["fontfile"]                    ?? configDefaults.NekoProject21.FontFile,
				pcModel : Data["NekoProject21"]?["pc_model"]                    ?? configDefaults.NekoProject21.PcModel ,
				clkBase : Data["NekoProject21"]?["clk_base"]?.ParseInt()        ?? configDefaults.NekoProject21.ClkBase ,
				clkMult : Data["NekoProject21"]?["clk_mult"]?.ParseInt()        ?? configDefaults.NekoProject21.ClkMult ,
				dipSwtch: Data["NekoProject21"]?["DIPswtch"]?.ParseDipSwitch3() ?? configDefaults.NekoProject21.DipSwtch,
				memSwtch: Data["NekoProject21"]?["MEMswtch"]?.ParseDipSwitch8() ?? configDefaults.NekoProject21.MemSwtch,
				exMemory: Data["NekoProject21"]?["ExMemory"]?.ParseInt()        ?? configDefaults.NekoProject21.ExMemory,
				hdd1File: Data["NekoProject21"]?["HDD1FILE"]                    ?? configDefaults.NekoProject21.Hdd1File,
				hdd2File: Data["NekoProject21"]?["HDD2FILE"]                    ?? configDefaults.NekoProject21.Hdd2File,
				hdd3File: Data["NekoProject21"]?["HDD3FILE"]                    ?? configDefaults.NekoProject21.Hdd3File,
				scsiHdd0: Data["NekoProject21"]?["SCSIHDD0"]                    ?? configDefaults.NekoProject21.ScsiHdd0,
				scsiHdd1: Data["NekoProject21"]?["SCSIHDD1"]                    ?? configDefaults.NekoProject21.ScsiHdd1,
				scsiHdd2: Data["NekoProject21"]?["SCSIHDD2"]                    ?? configDefaults.NekoProject21.ScsiHdd2,
				scsiHdd3: Data["NekoProject21"]?["SCSIHDD3"]                    ?? configDefaults.NekoProject21.ScsiHdd3,
				sampleHz: Data["NekoProject21"]?["SampleHz"]?.ParseInt()        ?? configDefaults.NekoProject21.SampleHz,
				latencyS: Data["NekoProject21"]?["Latencys"]?.ParseInt()        ?? configDefaults.NekoProject21.LatencyS,
				sndBoard: Data["NekoProject21"]?["SNDboard"]?.ParseByte()       ?? configDefaults.NekoProject21.SndBoard,
				beepVol : Data["NekoProject21"]?["BEEP_vol"]?.ParseInt()        ?? configDefaults.NekoProject21.BeepVol ,
				snd14Vol: Data["NekoProject21"]?["SND14vol"]?.ParseBytes()      ?? configDefaults.NekoProject21.Snd14Vol,
				opt26Brd: Data["NekoProject21"]?["opt26BRD"]?.ParseByte()       ?? configDefaults.NekoProject21.Opt26Brd,
				opt86Brd: Data["NekoProject21"]?["opt86BRD"]?.ParseByte()       ?? configDefaults.NekoProject21.Opt86Brd,
				optSpbrd: Data["NekoProject21"]?["optSPBRD"]?.ParseByte()       ?? configDefaults.NekoProject21.OptSpbrd,
				optSpbvr: Data["NekoProject21"]?["optSPBVR"]?.ParseByte()       ?? configDefaults.NekoProject21.OptSpbvr,
				optSpbvl: Data["NekoProject21"]?["optSPBVL"]?.ParseInt()        ?? configDefaults.NekoProject21.OptSpbvl,
				optSpbX : Data["NekoProject21"]?["optSPB_X"]?.ParseBool()       ?? configDefaults.NekoProject21.OptSpbX ,
				optMpu98: Data["NekoProject21"]?["optMPU98"]?.ParseByte()       ?? configDefaults.NekoProject21.OptMpu98,
				volumeF : Data["NekoProject21"]?["volume_F"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeF ,
				volumeS : Data["NekoProject21"]?["volume_S"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeS ,
				volumeA : Data["NekoProject21"]?["volume_A"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeA ,
				volumeP : Data["NekoProject21"]?["volume_P"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeP ,
				volumeR : Data["NekoProject21"]?["volume_R"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeR ,
				seekSnd : Data["NekoProject21"]?["Seek_Snd"]?.ParseBool()       ?? configDefaults.NekoProject21.SeekSnd ,
				seekVol : Data["NekoProject21"]?["Seek_Vol"]?.ParseInt()        ?? configDefaults.NekoProject21.SeekVol ,
				btnRapid: Data["NekoProject21"]?["btnRAPID"]?.ParseBool()       ?? configDefaults.NekoProject21.BtnRapid,
				btnMode : Data["NekoProject21"]?["btn_MODE"]?.ParseBool()       ?? configDefaults.NekoProject21.BtnMode ,
				mouseSw : Data["NekoProject21"]?["Mouse_sw"]?.ParseBool()       ?? configDefaults.NekoProject21.MouseSw ,
				msRapid : Data["NekoProject21"]?["MS_RAPID"]?.ParseBool()       ?? configDefaults.NekoProject21.MsRapid ,
				backgrnd: Data["NekoProject21"]?["backgrnd"]?.ParseInt()        ?? configDefaults.NekoProject21.Backgrnd,
				vramWait: Data["NekoProject21"]?["VRAMwait"]?.ParseBytes()      ?? configDefaults.NekoProject21.VramWait,
				dspClock: Data["NekoProject21"]?["DspClock"]?.ParseInt()        ?? configDefaults.NekoProject21.DspClock,
				dispSync: Data["NekoProject21"]?["DispSync"]?.ParseBool()       ?? configDefaults.NekoProject21.DispSync,
				realPal : Data["NekoProject21"]?["Real_Pal"]?.ParseBool()       ?? configDefaults.NekoProject21.RealPal ,
				rPalTim : Data["NekoProject21"]?["RPal_tim"]?.ParseInt()        ?? configDefaults.NekoProject21.RPalTim ,
				sNoWait : Data["NekoProject21"]?["s_NOWAIT"]?.ParseBool()       ?? configDefaults.NekoProject21.SNoWait ,
				skpFrame: Data["NekoProject21"]?["SkpFrame"]?.ParseInt()        ?? configDefaults.NekoProject21.SkpFrame,
				uPd72020: Data["NekoProject21"]?["uPD72020"]?.ParseBool()       ?? configDefaults.NekoProject21.UPd72020,
				grcgEgc : Data["NekoProject21"]?["GRCG_EGC"]?.ParseInt()        ?? configDefaults.NekoProject21.GrcgEgc ,
				color16B: Data["NekoProject21"]?["color16b"]?.ParseBool()       ?? configDefaults.NekoProject21.Color16B,
				skipLine: Data["NekoProject21"]?["skipline"]?.ParseBool()       ?? configDefaults.NekoProject21.SkipLine,
				skpLight: Data["NekoProject21"]?["skplight"]?.ParseInt()        ?? configDefaults.NekoProject21.SkpLight,
				lcdMode : Data["NekoProject21"]?["LCD_MODE"]?.ParseInt()        ?? configDefaults.NekoProject21.LcdMode ,
				pc9861E : Data["NekoProject21"]?["pc9861_e"]?.ParseBool()       ?? configDefaults.NekoProject21.Pc9861E ,
				pc9861S : Data["NekoProject21"]?["pc9861_s"]?.ParseBytes()      ?? configDefaults.NekoProject21.Pc9861S ,
				pc9861J : Data["NekoProject21"]?["pc9861_j"]?.ParseBytes()      ?? configDefaults.NekoProject21.Pc9861J ,
				calendar: Data["NekoProject21"]?["calendar"]?.ParseBool()       ?? configDefaults.NekoProject21.Calendar,
				use144Fd: Data["NekoProject21"]?["USE144FD"]?.ParseBool()       ?? configDefaults.NekoProject21.Use144Fd,
				drawType: Data["NekoProject21"]?["DrawType"]?.ParseInt()        ?? configDefaults.NekoProject21.DrawType,
				scrnMul : Data["NekoProject21"]?["SCRN_MUL"]?.ParseInt()        ?? configDefaults.NekoProject21.ScrnMul ,
				opnaClk : Data["NekoProject21"]?["OPNA_CLK"]?.ParseInt()        ?? configDefaults.NekoProject21.OpnaClk ,
				fmgRate : Data["NekoProject21"]?["FMG_RATE"]?.ParseInt()        ?? configDefaults.NekoProject21.FmgRate ,
				coffLpf : Data["NekoProject21"]?["COFF_LPF"]?.ParseBool()       ?? configDefaults.NekoProject21.CoffLpf ,
				mixType : Data["NekoProject21"]?["MIX_TYPE"]?.ParseBool()       ?? configDefaults.NekoProject21.MixType ,
				volumeC : Data["NekoProject21"]?["volume_C"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeC ,
				aaFilter: Data["NekoProject21"]?["AAFILTER"]?.ParseInt()        ?? configDefaults.NekoProject21.AaFilter,
				stFilter: Data["NekoProject21"]?["STFILTER"]?.ParseInt()        ?? configDefaults.NekoProject21.StFilter,
				priority: Data["NekoProject21"]?["Priority"]?.ParseInt()        ?? configDefaults.NekoProject21.Priority,
				beepPcm : Data["NekoProject21"]?["BEEP_PCM"]?.ParseInt()        ?? configDefaults.NekoProject21.BeepPcm ,
				statName: Data["NekoProject21"]?["StatName"]                    ?? configDefaults.NekoProject21.StatName,
				lpfOrder: Data["NekoProject21"]?["lpforder"]?.ParseInt()        ?? configDefaults.NekoProject21.LpfOrder,
				lpfCutof: Data["NekoProject21"]?["lpfcutof"]?.ParseInt()        ?? configDefaults.NekoProject21.LpfCutof,
				fmWaitA : Data["NekoProject21"]?["FMWait_A"]?.ParseInt()        ?? configDefaults.NekoProject21.FmWaitA ,
				fmWaitD : Data["NekoProject21"]?["FMWait_D"]?.ParseInt()        ?? configDefaults.NekoProject21.FmWaitD ,
				mouseSns: Data["NekoProject21"]?["MOUSESNS"]?.ParseInt()        ?? configDefaults.NekoProject21.MouseSns,
				fddWait : Data["NekoProject21"]?["FDD_Wait"]?.ParseInt()        ?? configDefaults.NekoProject21.FddWait ,
				joystkId: Data["NekoProject21"]?["JOYSTKID"]?.ParseInt()        ?? configDefaults.NekoProject21.JoystkId,
				cpuSpeed: Data["NekoProject21"]?["CPUSPEED"]?.ParseInt()        ?? configDefaults.NekoProject21.CpuSpeed,
				mVolume : Data["NekoProject21"]?["M_Volume"]?.ParseInt()        ?? configDefaults.NekoProject21.MVolume ,
				volumeV : Data["NekoProject21"]?["volume_V"]?.ParseInt()        ?? configDefaults.NekoProject21.VolumeV ,
				f12Copy : Data["NekoProject21"]?["F12_COPY"]?.ParseInt()        ?? configDefaults.NekoProject21.F12Copy ,
				joystick: Data["NekoProject21"]?["Joystick"]?.ParseBool()       ?? configDefaults.NekoProject21.Joystick,
				joy1Btn : Data["NekoProject21"]?["Joy1_btn"]?.ParseBytes()      ?? configDefaults.NekoProject21.Joy1Btn ,
				clockNow: Data["NekoProject21"]?["clocknow"]?.ParseInt()        ?? configDefaults.NekoProject21.ClockNow,
				clockFnt: Data["NekoProject21"]?["clockfnt"]?.ParseInt()        ?? configDefaults.NekoProject21.ClockFnt,
				useSstp : Data["NekoProject21"]?["use_sstp"]?.ParseBool()       ?? configDefaults.NekoProject21.UseSstp ,
				sstpPort: Data["NekoProject21"]?["sstpport"]?.ParseInt()        ?? configDefaults.NekoProject21.SstpPort,
				comfirm : Data["NekoProject21"]?["comfirm_"]?.ParseBool()       ?? configDefaults.NekoProject21.Comfirm ,
				shortcut: Data["NekoProject21"]?["shortcut"]?.ParseByte()       ?? configDefaults.NekoProject21.Shortcut,
				mpu98Map: Data["NekoProject21"]?["mpu98map"]                    ?? configDefaults.NekoProject21.Mpu98Map,
				mpu98Min: Data["NekoProject21"]?["mpu98min"]                    ?? configDefaults.NekoProject21.Mpu98Min,
				mpu98Mdl: Data["NekoProject21"]?["mpu98mdl"]                    ?? configDefaults.NekoProject21.Mpu98Mdl,
				mpu98Den: Data["NekoProject21"]?["mpu98den"]?.ParseInt()        ?? configDefaults.NekoProject21.Mpu98Den,
				mpu98Def: Data["NekoProject21"]?["mpu98def"]                    ?? configDefaults.NekoProject21.Mpu98Def,
				com1Port: Data["NekoProject21"]?["com1port"]?.ParseInt()        ?? configDefaults.NekoProject21.Com1Port,
				com1Para: Data["NekoProject21"]?["com1para"]?.ParseInt()        ?? configDefaults.NekoProject21.Com1Para,
				com1Bps : Data["NekoProject21"]?["com1_bps"]?.ParseInt()        ?? configDefaults.NekoProject21.Com1Bps ,
				com1MMap: Data["NekoProject21"]?["com1mmap"]                    ?? configDefaults.NekoProject21.Com1MMap,
				com1MMdl: Data["NekoProject21"]?["com1mmdl"]                    ?? configDefaults.NekoProject21.Com1MMdl,
				com1MDef: Data["NekoProject21"]?["com1mdef"]                    ?? configDefaults.NekoProject21.Com1MDef,
				com2Port: Data["NekoProject21"]?["com2port"]?.ParseInt()        ?? configDefaults.NekoProject21.Com2Port,
				com2Para: Data["NekoProject21"]?["com2para"]?.ParseInt()        ?? configDefaults.NekoProject21.Com2Para,
				com2Bps : Data["NekoProject21"]?["com2_bps"]?.ParseInt()        ?? configDefaults.NekoProject21.Com2Bps ,
				com2MMap: Data["NekoProject21"]?["com2mmap"]                    ?? configDefaults.NekoProject21.Com2MMap,
				com2MMdl: Data["NekoProject21"]?["com2mmdl"]                    ?? configDefaults.NekoProject21.Com2MMdl,
				com2MDef: Data["NekoProject21"]?["com2mdef"]                    ?? configDefaults.NekoProject21.Com2MDef,
				com3Port: Data["NekoProject21"]?["com3port"]?.ParseInt()        ?? configDefaults.NekoProject21.Com3Port,
				com3Para: Data["NekoProject21"]?["com3para"]?.ParseInt()        ?? configDefaults.NekoProject21.Com3Para,
				com3Bps : Data["NekoProject21"]?["com3_bps"]?.ParseInt()        ?? configDefaults.NekoProject21.Com3Bps ,
				com3MMap: Data["NekoProject21"]?["com3mmap"]                    ?? configDefaults.NekoProject21.Com3MMap,
				com3MMdl: Data["NekoProject21"]?["com3mmdl"]                    ?? configDefaults.NekoProject21.Com3MMdl,
				com3MDef: Data["NekoProject21"]?["com3mdef"]                    ?? configDefaults.NekoProject21.Com3MDef,
				eResume : Data["NekoProject21"]?["e_resume"]?.ParseBool()       ?? configDefaults.NekoProject21.EResume ,
				nousemmx: Data["NekoProject21"]?["nousemmx"]?.ParseBool()       ?? configDefaults.NekoProject21.Nousemmx,
				windType: Data["NekoProject21"]?["windtype"]?.ParseInt()        ?? configDefaults.NekoProject21.WindType,
				toolWind: Data["NekoProject21"]?["toolwind"]?.ParseBool()       ?? configDefaults.NekoProject21.ToolWind,
				keyDispl: Data["NekoProject21"]?["keydispl"]?.ParseBool()       ?? configDefaults.NekoProject21.KeyDispl,
				jastSnd : Data["NekoProject21"]?["jast_snd"]?.ParseBool()       ?? configDefaults.NekoProject21.JastSnd ,
				useRomeo: Data["NekoProject21"]?["useromeo"]?.ParseBool()       ?? configDefaults.NekoProject21.UseRomeo,
				thickFrm: Data["NekoProject21"]?["thickfrm"]?.ParseBool()       ?? configDefaults.NekoProject21.ThickFrm,
				fScrnMod: Data["NekoProject21"]?["fscrnmod"]?.ParseByte()       ?? configDefaults.NekoProject21.FScrnMod,
				sKeyDisp: Data["NekoProject21"]?["skeydisp"]?.ParseBool()       ?? configDefaults.NekoProject21.SKeyDisp,
				function: Data["NekoProject21"]?["Function"]?.ParseBytes()      ?? configDefaults.NekoProject21.Function,
				dllList : Data["NekoProject21"]?["Dll_List"]?.ParseInt()        ?? configDefaults.NekoProject21.DllList ,
				fdlFile : Data["NekoProject21"]?["FDL_FILE"]                    ?? configDefaults.NekoProject21.FdlFile ,
				fdCache : Data["NekoProject21"]?["FD_CACHE"]?.ParseInt()        ?? configDefaults.NekoProject21.FdCache
			),
			new Np21ntConfig.NP2ToolSection(
				windPosX: Data["NP2 tool"]?["WindposX"]?.ParseInt()             ?? configDefaults.NP2Tool.WindPosX,
				windPosY: Data["NP2 tool"]?["WindposY"]?.ParseInt()             ?? configDefaults.NP2Tool.WindPosY,
				windType: Data["NP2 tool"]?["WindType"]?.ParseBool()            ?? configDefaults.NP2Tool.WindType,
				skinFile: Data["NP2 tool"]?["SkinFile"]                         ?? configDefaults.NP2Tool.SkinFile,
				skinMru0: Data["NP2 tool"]?["SkinMRU0"]                         ?? configDefaults.NP2Tool.SkinMru0,
				skinMru1: Data["NP2 tool"]?["SkinMRU1"]                         ?? configDefaults.NP2Tool.SkinMru1,
				skinMru2: Data["NP2 tool"]?["SkinMRU2"]                         ?? configDefaults.NP2Tool.SkinMru2,
				skinMru3: Data["NP2 tool"]?["SkinMRU3"]                         ?? configDefaults.NP2Tool.SkinMru3,
				fd1Name0: Data["NP2 tool"]?["FD1NAME0"]                         ?? configDefaults.NP2Tool.Fd1Name0,
				fd1Name1: Data["NP2 tool"]?["FD1NAME1"]                         ?? configDefaults.NP2Tool.Fd1Name1,
				fd1Name2: Data["NP2 tool"]?["FD1NAME2"]                         ?? configDefaults.NP2Tool.Fd1Name2,
				fd1Name3: Data["NP2 tool"]?["FD1NAME3"]                         ?? configDefaults.NP2Tool.Fd1Name3,
				fd1Name4: Data["NP2 tool"]?["FD1NAME4"]                         ?? configDefaults.NP2Tool.Fd1Name4,
				fd1Name5: Data["NP2 tool"]?["FD1NAME5"]                         ?? configDefaults.NP2Tool.Fd1Name5,
				fd1Name6: Data["NP2 tool"]?["FD1NAME6"]                         ?? configDefaults.NP2Tool.Fd1Name6,
				fd1Name7: Data["NP2 tool"]?["FD1NAME7"]                         ?? configDefaults.NP2Tool.Fd1Name7,
				fd2Name0: Data["NP2 tool"]?["FD2NAME0"]                         ?? configDefaults.NP2Tool.Fd2Name0,
				fd2Name1: Data["NP2 tool"]?["FD2NAME1"]                         ?? configDefaults.NP2Tool.Fd2Name1,
				fd2Name2: Data["NP2 tool"]?["FD2NAME2"]                         ?? configDefaults.NP2Tool.Fd2Name2,
				fd2Name3: Data["NP2 tool"]?["FD2NAME3"]                         ?? configDefaults.NP2Tool.Fd2Name3,
				fd2Name4: Data["NP2 tool"]?["FD2NAME4"]                         ?? configDefaults.NP2Tool.Fd2Name4,
				fd2Name5: Data["NP2 tool"]?["FD2NAME5"]                         ?? configDefaults.NP2Tool.Fd2Name5,
				fd2Name6: Data["NP2 tool"]?["FD2NAME6"]                         ?? configDefaults.NP2Tool.Fd2Name6,
				fd2Name7: Data["NP2 tool"]?["FD2NAME7"]                         ?? configDefaults.NP2Tool.Fd2Name7
			),
			new Np21ntConfig.KeyDisplaySection(
				windPosX: Data["Key Display"]?["WindposX"]?.ParseInt()          ?? configDefaults.KeyDisplay.WindPosX,
				windPosY: Data["Key Display"]?["WindposY"]?.ParseInt()          ?? configDefaults.KeyDisplay.WindPosY,
				keyDMode: Data["Key Display"]?["keydmode"]?.ParseInt()          ?? configDefaults.KeyDisplay.KeyDMode,
				windType: Data["Key Display"]?["windtype"]?.ParseBool()         ?? configDefaults.KeyDisplay.WindType
			),
			new Np21ntConfig.SoftKeyboardSection(
				windPosX: Data["Soft Keyboard"]?["WindposX"]?.ParseInt()        ?? configDefaults.SoftKeyboard.WindPosX,
				windPosY: Data["Soft Keyboard"]?["WindposY"]?.ParseInt()        ?? configDefaults.SoftKeyboard.WindPosY,
				windType: Data["Soft Keyboard"]?["windtype"]?.ParseBool()       ?? configDefaults.SoftKeyboard.WindType
			),
			new Np21ntConfig.MemoryMapSection(
				windPosX: Data["Memory Map"]?["WindposX"]?.ParseInt()           ?? configDefaults.MemoryMap.WindPosX,
				windPosY: Data["Memory Map"]?["WindposY"]?.ParseInt()           ?? configDefaults.MemoryMap.WindPosY,
				windType: Data["Memory Map"]?["windtype"]?.ParseBool()          ?? configDefaults.MemoryMap.WindType
			)
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

			public static byte[]? ParseBytes(this string input) {
				try {
					return input.Split(" ")
						.Select(hexString => (byte)hexString.ParseByte()!)
						.ToArray();
				}
				catch (Exception) {
					return null;
				}
			}

			public static DipSwitch3? ParseDipSwitch3(this string input) =>
				input.ParseBytes()
					?.Transform(dipSwitchSegments => new DipSwitch3(
						dipSwitchSegments.ElementAtOrDefault(0),
						dipSwitchSegments.ElementAtOrDefault(1),
						dipSwitchSegments.ElementAtOrDefault(2)
					));

			public static DipSwitch8? ParseDipSwitch8(this string input) =>
				input.ParseBytes()
					?.Transform(dipSwitchSegments => new DipSwitch8(
						dipSwitchSegments.ElementAtOrDefault(0),
						dipSwitchSegments.ElementAtOrDefault(1),
						dipSwitchSegments.ElementAtOrDefault(2),
						dipSwitchSegments.ElementAtOrDefault(3),
						dipSwitchSegments.ElementAtOrDefault(4),
						dipSwitchSegments.ElementAtOrDefault(5),
						dipSwitchSegments.ElementAtOrDefault(6),
						dipSwitchSegments.ElementAtOrDefault(7)
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
