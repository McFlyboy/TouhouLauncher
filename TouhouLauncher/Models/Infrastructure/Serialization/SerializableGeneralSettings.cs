using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Models.Infrastructure.Serialization {
	public class SerializableGeneralSettings {
		public bool CloseOnGameLaunch { get; set; }
		public bool CombineMainCategories { get; set; }

		public GeneralSettings ToDomain() {
			return new GeneralSettings() {
				CloseOnGameLaunch = CloseOnGameLaunch,
				CombineMainCategories = CombineMainCategories
			};
		}

		public static SerializableGeneralSettings FromDomain(GeneralSettings domain) {
			return new SerializableGeneralSettings() {
				CloseOnGameLaunch = domain.CloseOnGameLaunch,
				CombineMainCategories = domain.CombineMainCategories
			};
		}
	}
}
