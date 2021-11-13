using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Common.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record FanGameYaml : Yaml {
		public string? Title { get; init; }

		public string? ImageLocation { get; init; }

		public string? AudioLocation { get; init; }

		public int? ReleaseYear { get; init; }

		public string? FileLocation { get; init; }

		public bool? IncludeInRandomGame { get; init; }

		public FanGame? ToDomain() => 
			Title?.Transform(
				title => new FanGame(
					title: title,
					imageLocation: ImageLocation,
					audioLocation: AudioLocation,
					releaseYear: ReleaseYear,
					fileLocation: FileLocation,
					includeInRandomGame: IncludeInRandomGame ?? true
				)
			);
	}

	namespace Extensions {
		public static class FanGameExtensionsForFanGameYaml {
			public static FanGameYaml ToYaml(this FanGame domain) => new() {
				Title = domain.Title,
				ImageLocation = domain.ImageLocation,
				AudioLocation = domain.AudioLocation,
				ReleaseYear = domain.ReleaseYear,
				FileLocation = domain.FileLocation,
				IncludeInRandomGame = domain.IncludeInRandomGame
			};
		}

	}
}
