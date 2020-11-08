using TouhouLauncher.Models.Application.Settings;

namespace TouhouLauncher.Services.Application.Serialization {
	public interface ISettingsSerializerService {
		public bool Serialize(Settings settings);

		public Settings Deserialize();
	}
}
