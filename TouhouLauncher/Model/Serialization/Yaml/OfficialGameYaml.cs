using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model.Serialization.Yaml {
	public class OfficialGameYaml {
		public string FileLocation { get; set; }

		public static OfficialGameYaml FromDomain(OfficialGame domain) {
			return new OfficialGameYaml() {
				FileLocation = domain.FileLocation
			};
		}
	}
}
