using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Serialization {
	public class SerializableFanGame {
		public string Title { get; set; }

		public string Subtitle { get; set; }

		public string ImageLocation { get; set; }

		public string AudioLocation { get; set; }

		public int ReleaseYear { get; set; }

		public string LocalFileLocation { get; set; }

		public FanGame ToDomain() {
			return new FanGame() {
				Title = Title,
				Subtitle = Subtitle,
				ImageLocation = ImageLocation,
				AudioLocation = AudioLocation,
				ReleaseYear = ReleaseYear,
				FileLocation = LocalFileLocation
			};
		}

		public static SerializableFanGame FromDomain(FanGame domain) {
			return new SerializableFanGame() {
				Title = domain.Title,
				Subtitle = domain.Subtitle,
				ImageLocation = domain.ImageLocation,
				AudioLocation = domain.AudioLocation,
				ReleaseYear = domain.ReleaseYear,
				LocalFileLocation = domain.FileLocation
			};
		}
	}
}
