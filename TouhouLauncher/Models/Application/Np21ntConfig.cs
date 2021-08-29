#nullable disable

namespace TouhouLauncher.Models.Application {
	public record Np21ntConfig(
		Np21ntConfig.NekoProject21Section NekoProject21,
		Np21ntConfig.NP2ToolSection NP2Tool,
		Np21ntConfig.KeyDisplaySection KeyDisplay,
		Np21ntConfig.SoftKeyboardSection SoftKeyboard,
		Np21ntConfig.MemoryMapSection MemoryMap
	) {
		public record NekoProject21Section {
			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public bool WinSnap { get; set; }

			public string FdFolder { get; set; }

			public string HdFolder { get; set; }

			public string BMapDir { get; set; }

			public string FontFile { get; set; }

			public string PcModel { get; set; }

			public int ClkBase { get; set; }

			public int ClkMult { get; set; }

			public DipSwitch3 DipSwtch { get; set; }

			public DipSwitch8 MemSwtch { get; set; }

			public int ExMemory { get; set; }

			public string Hdd1File { get; set; }

			public string Hdd2File { get; set; }

			public string Hdd3File { get; set; }

			public string ScsiHdd0 { get; set; }

			public string ScsiHdd1 { get; set; }

			public string ScsiHdd2 { get; set; }

			public string ScsiHdd3 { get; set; }

			public int SampleHz { get; set; }

			public int LatencyS { get; set; }

			public byte SndBoard { get; set; }

			public int BeepVol { get; set; }

			public byte[] Snd14Vol { get; set; }

			public byte Opt26Brd { get; set; }

			public byte Opt86Brd { get; set; }

			public byte OptSpbrd { get; set; }

			public byte OptSpbvr { get; set; }

			public int OptSpbvl { get; set; }

			public bool OptSpbX { get; set; }

			public byte OptMpu98 { get; set; }

			public int VolumeF { get; set; }

			public int VolumeS { get; set; }

			public int VolumeA { get; set; }

			public int VolumeP { get; set; }

			public int VolumeR { get; set; }

			public bool SeekSnd { get; set; }

			public int SeekVol { get; set; }

			public bool BtnRapid { get; set; }

			public bool BtnMode { get; set; }

			public bool MouseSw { get; set; }

			public bool MsRapid { get; set; }

			public int Backgrnd { get; set; }

			public byte[] VramWait { get; set; }

			public int DspClock { get; set; }

			public bool DispSync { get; set; }

			public bool RealPal { get; set; }

			public int RPalTim { get; set; }

			public bool SNoWait { get; set; }

			public int SkpFrame { get; set; }

			public bool UPd72020 { get; set; }

			public int GrcgEgc { get; set; }

			public bool Color16B { get; set; }

			public bool SkipLine { get; set; }

			public int SkpLight { get; set; }

			public int LcdMode { get; set; }

			public bool Pc9861E { get; set; }

			public byte[] Pc9861S { get; set; }

			public byte[] Pc9861J { get; set; }

			public bool Calendar { get; set; }

			public bool Use144Fd { get; set; }

			public int DrawType { get; set; }

			public int ScrnMul { get; set; }

			public int OpnaClk { get; set; }

			public int FmgRate { get; set; }

			public bool CoffLpf { get; set; }

			public bool MixType { get; set; }

			public int VolumeC { get; set; }

			public int AaFilter { get; set; }

			public int StFilter { get; set; }

			public int Priority { get; set; }

			public int BeepPcm { get; set; }

			public string StatName { get; set; }

			public int LpfOrder { get; set; }

			public int LpfCutof { get; set; }

			public int FmWaitA { get; set; }

			public int FmWaitD { get; set; }

			public int MouseSns { get; set; }

			public int FddWait { get; set; }

			public int JoystkId { get; set; }

			public int CpuSpeed { get; set; }

			public int MVolume { get; set; }

			public int VolumeV { get; set; }

			public int F12Copy { get; set; }

			public bool Joystick { get; set; }

			public byte[] Joy1Btn { get; set; }

			public int ClockNow { get; set; }

			public int ClockFnt { get; set; }

			public bool UseSstp { get; set; }

			public int SstpPort { get; set; }

			public bool Comfirm { get; set; }

			public byte Shortcut { get; set; }

			public string Mpu98Map { get; set; }

			public string Mpu98Min { get; set; }

			public string Mpu98Mdl { get; set; }

			public int Mpu98Den { get; set; }

			public string Mpu98Def { get; set; }

			public int Com1Port { get; set; }

			public int Com1Para { get; set; }

			public int Com1Bps { get; set; }

			public string Com1MMap { get; set; }

			public string Com1MMdl { get; set; }

			public string Com1MDef { get; set; }

			public int Com2Port { get; set; }

			public int Com2Para { get; set; }

			public int Com2Bps { get; set; }

			public string Com2MMap { get; set; }

			public string Com2MMdl { get; set; }

			public string Com2MDef { get; set; }

			public int Com3Port { get; set; }

			public int Com3Para { get; set; }

			public int Com3Bps { get; set; }

			public string Com3MMap { get; set; }

			public string Com3MMdl { get; set; }

			public string Com3MDef { get; set; }

			public bool EResume { get; set; }

			public bool Nousemmx { get; set; }

			public int WindType { get; set; }

			public bool ToolWind { get; set; }

			public bool KeyDispl { get; set; }

			public bool JastSnd { get; set; }

			public bool UseRomeo { get; set; }

			public bool ThickFrm { get; set; }

			public byte FScrnMod { get; set; }

			public bool SKeyDisp { get; set; }

			public byte[] Function { get; set; }

			public int DllList { get; set; }

			public string FdlFile { get; set; }

			public int FdCache { get; set; }
		}

		public record NP2ToolSection {
			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public bool WindType { get; set; }

			public string SkinFile { get; set; }

			public string SkinMru0 { get; set; }

			public string SkinMru1 { get; set; }

			public string SkinMru2 { get; set; }

			public string SkinMru3 { get; set; }

			public string Fd1Name0 { get; set; }

			public string Fd1Name1 { get; set; }

			public string Fd1Name2 { get; set; }

			public string Fd1Name3 { get; set; }

			public string Fd1Name4 { get; set; }

			public string Fd1Name5 { get; set; }

			public string Fd1Name6 { get; set; }

			public string Fd1Name7 { get; set; }

			public string Fd2Name0 { get; set; }

			public string Fd2Name1 { get; set; }

			public string Fd2Name2 { get; set; }

			public string Fd2Name3 { get; set; }

			public string Fd2Name4 { get; set; }

			public string Fd2Name5 { get; set; }

			public string Fd2Name6 { get; set; }

			public string Fd2Name7 { get; set; }
		}

		public record KeyDisplaySection {
			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public int KeyDMode { get; set; }

			public bool WindType { get; set; }
		}

		public record SoftKeyboardSection {
			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public bool WindType { get; set; }
		}

		public record MemoryMapSection {
			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public bool WindType { get; set; }
		}
	}

	public record DipSwitch {
		public DipSwitch() { }

		public DipSwitch(byte binaryValue) {
			Switch1 = (binaryValue & (1 << 7)) != 0;
			Switch2 = (binaryValue & (1 << 6)) != 0;
			Switch3 = (binaryValue & (1 << 5)) != 0;
			Switch4 = (binaryValue & (1 << 4)) != 0;
			Switch5 = (binaryValue & (1 << 3)) != 0;
			Switch6 = (binaryValue & (1 << 2)) != 0;
			Switch7 = (binaryValue & (1 << 1)) != 0;
			Switch8 = (binaryValue & 1)        != 0;
		}

		public bool Switch1 { get; set; }

		public bool Switch2 { get; set; }

		public bool Switch3 { get; set; }

		public bool Switch4 { get; set; }

		public bool Switch5 { get; set; }

		public bool Switch6 { get; set; }

		public bool Switch7 { get; set; }

		public bool Switch8 { get; set; }
	}

	public record DipSwitch3 {
		public DipSwitch3() { }

		public DipSwitch3(
			byte segment1,
			byte segment2,
			byte segment3
		) {
			Segment1 = new(segment1);
			Segment2 = new(segment2);
			Segment3 = new(segment3);
		}

		public DipSwitch Segment1 { get; set; }

		public DipSwitch Segment2 { get; set; }

		public DipSwitch Segment3 { get; set; }
	}

	public record DipSwitch8 {
		public DipSwitch8() { }

		public DipSwitch8(
			byte binarySegment1,
			byte binarySegment2,
			byte binarySegment3,
			byte binarySegment4,
			byte binarySegment5,
			byte binarySegment6,
			byte binarySegment7,
			byte binarySegment8
		) {
			Segment1 = new(binarySegment1);
			Segment2 = new(binarySegment2);
			Segment3 = new(binarySegment3);
			Segment4 = new(binarySegment4);
			Segment5 = new(binarySegment5);
			Segment6 = new(binarySegment6);
			Segment7 = new(binarySegment7);
			Segment8 = new(binarySegment8);
		}

		public DipSwitch Segment1 { get; set; }

		public DipSwitch Segment2 { get; set; }

		public DipSwitch Segment3 { get; set; }

		public DipSwitch Segment4 { get; set; }

		public DipSwitch Segment5 { get; set; }

		public DipSwitch Segment6 { get; set; }

		public DipSwitch Segment7 { get; set; }

		public DipSwitch Segment8 { get; set; }
	}
}
