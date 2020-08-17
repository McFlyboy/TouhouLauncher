using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model.Serialization.Yaml {
	public class OfficialGameYaml {
		public string LocalFileLocation { get; set; }

		public static OfficialGameYaml FromDomain(OfficialGame domain) {
			return new OfficialGameYaml() {
				LocalFileLocation = domain.LocalFileLocation
			};
		}
	}
}
