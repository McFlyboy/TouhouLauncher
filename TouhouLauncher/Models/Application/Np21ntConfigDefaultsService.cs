﻿#nullable disable

namespace TouhouLauncher.Models.Application {
	public class Np21ntConfigDefaultsService {
		public virtual Np21ntConfig CreateNp21ntConfigDefaults() => new(
			new Np21ntConfig.NekoProject21Section() {
				WindPosX = 0,
				WindPosY = 0,
				WinSnap  = true,
				FdFolder = "",
				HdFolder = "",
				BMapDir  = "",
				FontFile = "",
				PcModel  = "VX",
				ClkBase  = 2457600,
				ClkMult  = 48,
				DipSwtch = new(0x3e, 0xf3, 0x7b),
				MemSwtch = new(0x48, 0x05, 0x04, 0x00, 0x01, 0x00, 0x00, 0x6e),
				ExMemory = 13,
				Hdd1File = "",
				Hdd2File = "",
				Hdd3File = "",
				ScsiHdd0 = "",
				ScsiHdd1 = "",
				ScsiHdd2 = "",
				ScsiHdd3 = "",
				SampleHz = 44100,
				LatencyS = 100,
				SndBoard = 0x4,
				BeepVol  = 3,
				Snd14Vol = new byte[] { 0x0c, 0x0c, 0x08, 0x06, 0x03, 0x0c },
				Opt26Brd = 0xd1,
				Opt86Brd = 0x7f,
				OptSpbrd = 0xd1,
				OptSpbvr = 0x0,
				OptSpbvl = 0,
				OptSpbX  = true,
				OptMpu98 = 0x82,
				VolumeF  = 40,
				VolumeS  = 28,
				VolumeA  = 40,
				VolumeP  = 40,
				VolumeR  = 40,
				SeekSnd  = true,
				SeekVol  = 80,
				BtnRapid = false,
				BtnMode  = false,
				MouseSw  = false,
				MsRapid  = false,
				Backgrnd = 0,
				VramWait = new byte[] { 0x01, 0x01, 0x06, 0x01, 0x08, 0x01 },
				DspClock = 0,
				DispSync = true,
				RealPal  = false,
				RPalTim  = 32,
				SNoWait  = false,
				SkpFrame = 1,
				UPd72020 = false,
				GrcgEgc  = 2,
				Color16B = true,
				SkipLine = true,
				SkpLight = 255,
				LcdMode  = 0,
				Pc9861E  = false,
				Pc9861S  = new byte[] { 0x17, 0x04, 0x1f },
				Pc9861J  = new byte[] { 0x0c, 0x0c, 0x02, 0x10, 0x3f, 0x3f },
				Calendar = false,
				Use144Fd = false,
				DrawType = 0,
				ScrnMul  = 8,
				OpnaClk  = 7987200,
				FmgRate  = 55466,
				CoffLpf  = true,
				MixType  = true,
				VolumeC  = 40,
				AaFilter = 0,
				StFilter = 0,
				Priority = 1,
				BeepPcm  = 0,
				StatName = "",
				LpfOrder = 0,
				LpfCutof = 8000,
				FmWaitA  = 0,
				FmWaitD  = 0,
				MouseSns = 64,
				FddWait  = 100,
				JoystkId = 0,
				CpuSpeed = 100,
				MVolume  = 100,
				VolumeV  = 40,
				F12Copy  = 0,
				Joystick = true,
				Joy1Btn  = new byte[] { 0x01, 0x02, 0x02, 0x01 },
				ClockNow = 0,
				ClockFnt = 0,
				UseSstp  = false,
				SstpPort = 9801,
				Comfirm  = false,
				Shortcut = 0x1,
				Mpu98Map = "",
				Mpu98Min = "",
				Mpu98Mdl = "",
				Mpu98Den = 0,
				Mpu98Def = "",
				Com1Port = 0,
				Com1Para = 62,
				Com1Bps  = 19200,
				Com1MMap = "",
				Com1MMdl = "",
				Com1MDef = "",
				Com2Port = 0,
				Com2Para = 62,
				Com2Bps  = 19200,
				Com2MMap = "",
				Com2MMdl = "",
				Com2MDef = "",
				Com3Port = 0,
				Com3Para = 62,
				Com3Bps  = 19200,
				Com3MMap = "",
				Com3MMdl = "",
				Com3MDef = "",
				EResume  = false,
				Nousemmx = false,
				WindType = 0,
				ToolWind = false,
				KeyDispl = false,
				JastSnd  = false,
				UseRomeo = false,
				ThickFrm = false,
				FScrnMod = 0xe,
				SKeyDisp = false,
				Function = new byte[] {
					0x00,
					0x5d,
					0x3c,
					0x9e,
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
				DllList  = 0,
				FdlFile  = "",
				FdCache  = 0
			},
			new Np21ntConfig.NP2ToolSection() {
				WindPosX = -2147483648,
				WindPosY = -2147483648,
				WindType = true,
				SkinFile = "",
				SkinMru0 = "",
				SkinMru1 = "",
				SkinMru2 = "",
				SkinMru3 = "",
				Fd1Name0 = "",
				Fd1Name1 = "",
				Fd1Name2 = "",
				Fd1Name3 = "",
				Fd1Name4 = "",
				Fd1Name5 = "",
				Fd1Name6 = "",
				Fd1Name7 = "",
				Fd2Name0 = "",
				Fd2Name1 = "",
				Fd2Name2 = "",
				Fd2Name3 = "",
				Fd2Name4 = "",
				Fd2Name5 = "",
				Fd2Name6 = "",
				Fd2Name7 = ""
			},
			new Np21ntConfig.KeyDisplaySection() {
				WindPosX = -2147483648,
				WindPosY = -2147483648,
				KeyDMode = 0,
				WindType = false
			},
			new Np21ntConfig.SoftKeyboardSection() {
				WindPosX = -2147483648,
				WindPosY = -2147483648,
				WindType = false
			},
			new Np21ntConfig.MemoryMapSection() {
				WindPosX = -2147483648,
				WindPosY = -2147483648,
				WindType = false
			}
		);
	}
}
