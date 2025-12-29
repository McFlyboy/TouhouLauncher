namespace TouhouLauncher.Models.Application;

public record Np21ntConfig(
    Np21ntConfig.NekoProject21Section NekoProject21,
    Np21ntConfig.NP2ToolSection NP2Tool,
    Np21ntConfig.KeyDisplaySection KeyDisplay,
    Np21ntConfig.SoftKeyboardSection SoftKeyboard,
    Np21ntConfig.MemoryMapSection MemoryMap
)
{
    public record NekoProject21Section(
        int WindPosX,
        int WindPosY,
        bool WinSnap,
        string FdFolder,
        string HdFolder,
        string BMapDir,
        string FontFile,
        string PcModel,
        int ClkBase,
        int ClkMult,
        DipSwitch3 DipSwtch,
        DipSwitch8 MemSwtch,
        int ExMemory,
        string Hdd1File,
        string Hdd2File,
        string Hdd3File,
        string ScsiHdd0,
        string ScsiHdd1,
        string ScsiHdd2,
        string ScsiHdd3,
        int SampleHz,
        int LatencyS,
        byte SndBoard,
        int BeepVol,
        byte[] Snd14Vol,
        byte Opt26Brd,
        byte Opt86Brd,
        byte OptSpbrd,
        byte OptSpbvr,
        int OptSpbvl,
        bool OptSpbX,
        byte OptMpu98,
        int VolumeF,
        int VolumeS,
        int VolumeA,
        int VolumeP,
        int VolumeR,
        bool SeekSnd,
        int SeekVol,
        bool BtnRapid,
        bool BtnMode,
        bool MouseSw,
        bool MsRapid,
        int Backgrnd,
        byte[] VramWait,
        int DspClock,
        bool DispSync,
        bool RealPal,
        int RPalTim,
        bool SNoWait,
        int SkpFrame,
        bool UPd72020,
        int GrcgEgc,
        bool Color16B,
        bool SkipLine,
        int SkpLight,
        int LcdMode,
        bool Pc9861E,
        byte[] Pc9861S,
        byte[] Pc9861J,
        bool Calendar,
        bool Use144Fd,
        int DrawType,
        int ScrnMul,
        int OpnaClk,
        int FmgRate,
        bool CoffLpf,
        bool MixType,
        int VolumeC,
        int AaFilter,
        int StFilter,
        int Priority,
        int BeepPcm,
        string StatName,
        int LpfOrder,
        int LpfCutof,
        int FmWaitA,
        int FmWaitD,
        int MouseSns,
        int FddWait,
        int JoystkId,
        int CpuSpeed,
        int MVolume,
        int VolumeV,
        int F12Copy,
        bool Joystick,
        byte[] Joy1Btn,
        int ClockNow,
        int ClockFnt,
        bool UseSstp,
        int SstpPort,
        bool Comfirm,
        byte Shortcut,
        string Mpu98Map,
        string Mpu98Min,
        string Mpu98Mdl,
        int Mpu98Den,
        string Mpu98Def,
        int Com1Port,
        int Com1Para,
        int Com1Bps,
        string Com1MMap,
        string Com1MMdl,
        string Com1MDef,
        int Com2Port,
        int Com2Para,
        int Com2Bps,
        string Com2MMap,
        string Com2MMdl,
        string Com2MDef,
        int Com3Port,
        int Com3Para,
        int Com3Bps,
        string Com3MMap,
        string Com3MMdl,
        string Com3MDef,
        bool EResume,
        bool Nousemmx,
        int WindType,
        bool ToolWind,
        bool KeyDispl,
        bool JastSnd,
        bool UseRomeo,
        bool ThickFrm,
        byte FScrnMod,
        bool SKeyDisp,
        byte[] Function,
        int DllList,
        string FdlFile,
        int FdCache
    );

    public record NP2ToolSection(
        int WindPosX,
        int WindPosY,
        bool WindType,
        string SkinFile,
        string SkinMru0,
        string SkinMru1,
        string SkinMru2,
        string SkinMru3,
        string Fd1Name0,
        string Fd1Name1,
        string Fd1Name2,
        string Fd1Name3,
        string Fd1Name4,
        string Fd1Name5,
        string Fd1Name6,
        string Fd1Name7,
        string Fd2Name0,
        string Fd2Name1,
        string Fd2Name2,
        string Fd2Name3,
        string Fd2Name4,
        string Fd2Name5,
        string Fd2Name6,
        string Fd2Name7
    );

    public record KeyDisplaySection(
        int WindPosX,
        int WindPosY,
        int KeyDMode,
        bool WindType
    );

    public record SoftKeyboardSection(
        int WindPosX,
        int WindPosY,
        bool WindType
    );

    public record MemoryMapSection(
        int WindPosX,
        int WindPosY,
        bool WindType
    );
}

public record DipSwitch
{
    public DipSwitch(byte binaryValue)
    {
        Switch1 = (binaryValue & (1 << 7)) != 0;
        Switch2 = (binaryValue & (1 << 6)) != 0;
        Switch3 = (binaryValue & (1 << 5)) != 0;
        Switch4 = (binaryValue & (1 << 4)) != 0;
        Switch5 = (binaryValue & (1 << 3)) != 0;
        Switch6 = (binaryValue & (1 << 2)) != 0;
        Switch7 = (binaryValue & (1 << 1)) != 0;
        Switch8 = (binaryValue & 1)        != 0;
    }

    public bool Switch1 { get; init; }

    public bool Switch2 { get; init; }

    public bool Switch3 { get; init; }

    public bool Switch4 { get; init; }

    public bool Switch5 { get; init; }

    public bool Switch6 { get; init; }

    public bool Switch7 { get; init; }

    public bool Switch8 { get; init; }
}

public record DipSwitch3
{
    public DipSwitch3(
        byte segment1,
        byte segment2,
        byte segment3
    )
    {
        Segment1 = new(segment1);
        Segment2 = new(segment2);
        Segment3 = new(segment3);
    }

    public DipSwitch Segment1 { get; init; }

    public DipSwitch Segment2 { get; init; }

    public DipSwitch Segment3 { get; init; }
}

public record DipSwitch8
{
    public DipSwitch8(
        byte binarySegment1,
        byte binarySegment2,
        byte binarySegment3,
        byte binarySegment4,
        byte binarySegment5,
        byte binarySegment6,
        byte binarySegment7,
        byte binarySegment8
    )
    {
        Segment1 = new(binarySegment1);
        Segment2 = new(binarySegment2);
        Segment3 = new(binarySegment3);
        Segment4 = new(binarySegment4);
        Segment5 = new(binarySegment5);
        Segment6 = new(binarySegment6);
        Segment7 = new(binarySegment7);
        Segment8 = new(binarySegment8);
    }

    public DipSwitch Segment1 { get; init; }

    public DipSwitch Segment2 { get; init; }

    public DipSwitch Segment3 { get; init; }

    public DipSwitch Segment4 { get; init; }

    public DipSwitch Segment5 { get; init; }

    public DipSwitch Segment6 { get; init; }

    public DipSwitch Segment7 { get; init; }

    public DipSwitch Segment8 { get; init; }
}
