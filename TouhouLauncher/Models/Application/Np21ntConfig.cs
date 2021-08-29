namespace TouhouLauncher.Models.Application {
	public record Np21ntConfig(
		Np21ntConfig.NekoProject21Section NekoProject21,
		Np21ntConfig.NP2ToolSection NP2Tool,
		Np21ntConfig.KeyDisplaySection KeyDisplay,
		Np21ntConfig.SoftKeyboardSection SoftKeyboard,
		Np21ntConfig.MemoryMapSection MemoryMap
	) {
		public record NekoProject21Section {
			public NekoProject21Section(
				int windPosX,
				int windPosY,
				bool winSnap,
				string fdFolder,
				string hdFolder,
				string bMapDir,
				string fontFile,
				string pcModel,
				int clkBase,
				int clkMult,
				DipSwitch3 dipSwtch,
				DipSwitch8 memSwtch,
				int exMemory,
				string hdd1File,
				string hdd2File,
				string hdd3File,
				string scsiHdd0,
				string scsiHdd1,
				string scsiHdd2,
				string scsiHdd3,
				int sampleHz,
				int latencyS,
				byte sndBoard,
				int beepVol,
				byte[] snd14Vol,
				byte opt26Brd,
				byte opt86Brd,
				byte optSpbrd,
				byte optSpbvr,
				int optSpbvl,
				bool optSpbX,
				byte optMpu98,
				int volumeF,
				int volumeS,
				int volumeA,
				int volumeP,
				int volumeR,
				bool seekSnd,
				int seekVol,
				bool btnRapid,
				bool btnMode,
				bool mouseSw,
				bool msRapid,
				int backgrnd,
				byte[] vramWait,
				int dspClock,
				bool dispSync,
				bool realPal,
				int rPalTim,
				bool sNoWait,
				int skpFrame,
				bool uPd72020,
				int grcgEgc,
				bool color16B,
				bool skipLine,
				int skpLight,
				int lcdMode,
				bool pc9861E,
				byte[] pc9861S,
				byte[] pc9861J,
				bool calendar,
				bool use144Fd,
				int drawType,
				int scrnMul,
				int opnaClk,
				int fmgRate,
				bool coffLpf,
				bool mixType,
				int volumeC,
				int aaFilter,
				int stFilter,
				int priority,
				int beepPcm,
				string statName,
				int lpfOrder,
				int lpfCutof,
				int fmWaitA,
				int fmWaitD,
				int mouseSns,
				int fddWait,
				int joystkId,
				int cpuSpeed,
				int mVolume,
				int volumeV,
				int f12Copy,
				bool joystick,
				byte[] joy1Btn,
				int clockNow,
				int clockFnt,
				bool useSstp,
				int sstpPort,
				bool comfirm,
				byte shortcut,
				string mpu98Map,
				string mpu98Min,
				string mpu98Mdl,
				int mpu98Den,
				string mpu98Def,
				int com1Port,
				int com1Para,
				int com1Bps,
				string com1MMap,
				string com1MMdl,
				string com1MDef,
				int com2Port,
				int com2Para,
				int com2Bps,
				string com2MMap,
				string com2MMdl,
				string com2MDef,
				int com3Port,
				int com3Para,
				int com3Bps,
				string com3MMap,
				string com3MMdl,
				string com3MDef,
				bool eResume,
				bool nousemmx,
				int windType,
				bool toolWind,
				bool keyDispl,
				bool jastSnd,
				bool useRomeo,
				bool thickFrm,
				byte fScrnMod,
				bool sKeyDisp,
				byte[] function,
				int dllList,
				string fdlFile,
				int fdCache
			) {
				WindPosX = windPosX;
				WindPosY = windPosY;
				WinSnap  = winSnap;
				FdFolder = fdFolder;
				HdFolder = hdFolder;
				BMapDir  = bMapDir;
				FontFile = fontFile;
				PcModel  = pcModel;
				ClkBase  = clkBase;
				ClkMult  = clkMult;
				DipSwtch = dipSwtch;
				MemSwtch = memSwtch;
				ExMemory = exMemory;
				Hdd1File = hdd1File;
				Hdd2File = hdd2File;
				Hdd3File = hdd3File;
				ScsiHdd0 = scsiHdd0;
				ScsiHdd1 = scsiHdd1;
				ScsiHdd2 = scsiHdd2;
				ScsiHdd3 = scsiHdd3;
				SampleHz = sampleHz;
				LatencyS = latencyS;
				SndBoard = sndBoard;
				BeepVol  = beepVol;
				Snd14Vol = snd14Vol;
				Opt26Brd = opt26Brd;
				Opt86Brd = opt86Brd;
				OptSpbrd = optSpbrd;
				OptSpbvr = optSpbvr;
				OptSpbvl = optSpbvl;
				OptSpbX  = optSpbX ;
				OptMpu98 = optMpu98;
				VolumeF  = volumeF;
				VolumeS  = volumeS;
				VolumeA  = volumeA;
				VolumeP  = volumeP;
				VolumeR  = volumeR;
				SeekSnd  = seekSnd;
				SeekVol  = seekVol;
				BtnRapid = btnRapid;
				BtnMode  = btnMode;
				MouseSw  = mouseSw;
				MsRapid  = msRapid;
				Backgrnd = backgrnd;
				VramWait = vramWait;
				DspClock = dspClock;
				DispSync = dispSync;
				RealPal  = realPal;
				RPalTim  = rPalTim;
				SNoWait  = sNoWait;
				SkpFrame = skpFrame;
				UPd72020 = uPd72020;
				GrcgEgc  = grcgEgc;
				Color16B = color16B;
				SkipLine = skipLine;
				SkpLight = skpLight;
				LcdMode  = lcdMode;
				Pc9861E  = pc9861E;
				Pc9861S  = pc9861S;
				Pc9861J  = pc9861J;
				Calendar = calendar;
				Use144Fd = use144Fd;
				DrawType = drawType;
				ScrnMul  = scrnMul;
				OpnaClk  = opnaClk;
				FmgRate  = fmgRate;
				CoffLpf  = coffLpf;
				MixType  = mixType;
				VolumeC  = volumeC;
				AaFilter = aaFilter;
				StFilter = stFilter;
				Priority = priority;
				BeepPcm  = beepPcm;
				StatName = statName;
				LpfOrder = lpfOrder;
				LpfCutof = lpfCutof;
				FmWaitA  = fmWaitA;
				FmWaitD  = fmWaitD;
				MouseSns = mouseSns;
				FddWait  = fddWait;
				JoystkId = joystkId;
				CpuSpeed = cpuSpeed;
				MVolume  = mVolume;
				VolumeV  = volumeV;
				F12Copy  = f12Copy;
				Joystick = joystick;
				Joy1Btn  = joy1Btn;
				ClockNow = clockNow;
				ClockFnt = clockFnt;
				UseSstp  = useSstp;
				SstpPort = sstpPort;
				Comfirm  = comfirm;
				Shortcut = shortcut;
				Mpu98Map = mpu98Map;
				Mpu98Min = mpu98Min;
				Mpu98Mdl = mpu98Mdl;
				Mpu98Den = mpu98Den;
				Mpu98Def = mpu98Def;
				Com1Port = com1Port;
				Com1Para = com1Para;
				Com1Bps  = com1Bps;
				Com1MMap = com1MMap;
				Com1MMdl = com1MMdl;
				Com1MDef = com1MDef;
				Com2Port = com2Port;
				Com2Para = com2Para;
				Com2Bps  = com2Bps;
				Com2MMap = com2MMap;
				Com2MMdl = com2MMdl;
				Com2MDef = com2MDef;
				Com3Port = com3Port;
				Com3Para = com3Para;
				Com3Bps  = com3Bps;
				Com3MMap = com3MMap;
				Com3MMdl = com3MMdl;
				Com3MDef = com3MDef;
				EResume  = eResume;
				Nousemmx = nousemmx;
				WindType = windType;
				ToolWind = toolWind;
				KeyDispl = keyDispl;
				JastSnd  = jastSnd;
				UseRomeo = useRomeo;
				ThickFrm = thickFrm;
				FScrnMod = fScrnMod;
				SKeyDisp = sKeyDisp;
				Function = function;
				DllList  = dllList;
				FdlFile  = fdlFile;
				FdCache  = fdCache;
			}

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
			public NP2ToolSection(
				int windPosX,
				int windPosY,
				bool windType,
				string skinFile,
				string skinMru0,
				string skinMru1,
				string skinMru2,
				string skinMru3,
				string fd1Name0,
				string fd1Name1,
				string fd1Name2,
				string fd1Name3,
				string fd1Name4,
				string fd1Name5,
				string fd1Name6,
				string fd1Name7,
				string fd2Name0,
				string fd2Name1,
				string fd2Name2,
				string fd2Name3,
				string fd2Name4,
				string fd2Name5,
				string fd2Name6,
				string fd2Name7
			) {
				WindPosX = windPosX;
				WindPosY = windPosY;
				WindType = windType;
				SkinFile = skinFile;
				SkinMru0 = skinMru0;
				SkinMru1 = skinMru1;
				SkinMru2 = skinMru2;
				SkinMru3 = skinMru3;
				Fd1Name0 = fd1Name0;
				Fd1Name1 = fd1Name1;
				Fd1Name2 = fd1Name2;
				Fd1Name3 = fd1Name3;
				Fd1Name4 = fd1Name4;
				Fd1Name5 = fd1Name5;
				Fd1Name6 = fd1Name6;
				Fd1Name7 = fd1Name7;
				Fd2Name0 = fd2Name0;
				Fd2Name1 = fd2Name1;
				Fd2Name2 = fd2Name2;
				Fd2Name3 = fd2Name3;
				Fd2Name4 = fd2Name4;
				Fd2Name5 = fd2Name5;
				Fd2Name6 = fd2Name6;
				Fd2Name7 = fd2Name7;
			}

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
			public KeyDisplaySection(
				int windPosX,
				int windPosY,
				int keyDMode,
				bool windType
			) {
				WindPosX = windPosX;
				WindPosY = windPosY;
				KeyDMode = keyDMode;
				WindType = windType;
			}

			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public int KeyDMode { get; set; }

			public bool WindType { get; set; }
		}

		public record SoftKeyboardSection {
			public SoftKeyboardSection(
				int windPosX,
				int windPosY,
				bool windType
			) {
				WindPosX = windPosX;
				WindPosY = windPosY;
				WindType = windType;
			}

			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public bool WindType { get; set; }
		}

		public record MemoryMapSection {
			public MemoryMapSection(
				int windPosX,
				int windPosY,
				bool windType
			) {
				WindPosX = windPosX;
				WindPosY = windPosY;
				WindType = windType;
			}

			public int WindPosX { get; set; }

			public int WindPosY { get; set; }

			public bool WindType { get; set; }
		}
	}

	public record DipSwitch {
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
