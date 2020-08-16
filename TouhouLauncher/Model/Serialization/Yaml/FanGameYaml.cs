using TouhouLauncher.Model.GameInfo;

namespace TouhouLauncher.Model.Serialization.Yaml {
	public class FanGameYaml {
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
				LocalFileLocation = LocalFileLocation
			};
		}
	}
}
