using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Serialization {
	public class SerializableOfficialGame {
		public string FileLocation { get; set; }

		public static SerializableOfficialGame FromDomain(OfficialGame domain) {
			return new SerializableOfficialGame() {
				FileLocation = domain.FileLocation
			};
		}
	}
}
