using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record FanGameYaml : Yaml {
		public string Title { get; init; }

		public string ImageLocation { get; init; }

		public string AudioLocation { get; init; }

		public int ReleaseYear { get; init; }

		public string FileLocation { get; init; }

		public FanGame ToDomain() => new() {
			Title = Title,
			ImageLocation = ImageLocation,
			AudioLocation = AudioLocation,
			ReleaseYear = ReleaseYear,
			FileLocation = FileLocation
		};
	}

	namespace Extensions {
		public static class FanGameExtensionsForFanGameYaml {
			public static FanGameYaml ToYaml(this FanGame domain) => new() {
				Title = domain.Title,
				ImageLocation = domain.ImageLocation,
				AudioLocation = domain.AudioLocation,
				ReleaseYear = domain.ReleaseYear,
				FileLocation = domain.FileLocation
			};
		}

	}
}
