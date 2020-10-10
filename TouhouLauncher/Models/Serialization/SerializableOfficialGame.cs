using TouhouLauncher.Models.GameInfo;

namespace TouhouLauncher.Models.Serialization {
	public class SerializableOfficialGame {
		public string FileLocation { get; set; }

		public static SerializableOfficialGame FromDomain(OfficialGame domain) {
			return new SerializableOfficialGame() {
				FileLocation = domain.FileLocation
			};
		}
	}
}
