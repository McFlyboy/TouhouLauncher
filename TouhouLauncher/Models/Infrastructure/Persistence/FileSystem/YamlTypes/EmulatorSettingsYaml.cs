#nullable disable

using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record EmulatorSettingsYaml : Yaml {
		public string FolderLocation { get; init; }

		public EmulatorSettings ToDomain() => new(folderLocation: FolderLocation);
	}

	namespace Extensions {
		public static class EmulatorSettingsExtensionsForEmulatorSettingsYaml {
			public static EmulatorSettingsYaml ToYaml(this EmulatorSettings emulatorSettings) => new() {
				FolderLocation = emulatorSettings.FolderLocation
			};
		}
	}
}
