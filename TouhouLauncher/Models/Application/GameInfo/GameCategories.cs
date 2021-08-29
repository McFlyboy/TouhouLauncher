#nullable disable

using System;

namespace TouhouLauncher.Models.Application.GameInfo {
	[Flags]
	public enum GameCategories {
		None         = 0x00,

		MainPC98     = 0x01,
		MainWindows  = 0x02,
		FightingGame = 0x04,
		SpinOff      = 0x08,
		FanGame      = 0x10,

		MainGame     = MainPC98 | MainWindows
	}
}
