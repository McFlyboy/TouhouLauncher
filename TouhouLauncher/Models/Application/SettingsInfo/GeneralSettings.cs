#nullable disable

namespace TouhouLauncher.Models.Application.SettingsInfo {
	public record GeneralSettings {
		public bool CloseOnGameLaunch { get; set; }

		public bool CombineMainCategories { get; set; }
	}
}
