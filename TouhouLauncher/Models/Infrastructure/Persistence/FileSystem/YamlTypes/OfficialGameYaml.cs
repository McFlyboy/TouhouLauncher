﻿using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record OfficialGameYaml : Yaml {
		public string? FileLocation { get; init; }

		public bool? IncludeInRandomGame { get; init; }

		public OfficialGame ToDomain(OfficialGame domainTemplate) => new(
			title: domainTemplate.Title,
			imageLocation: domainTemplate.ImageLocation,
			audioLocation: domainTemplate.AudioLocation,
			releaseYear: domainTemplate.ReleaseYear,
			fileLocation: FileLocation,
			includeInRandomGame: IncludeInRandomGame ?? domainTemplate.IncludeInRandomGame,
			categories: domainTemplate.Categories,
			downloadableFileLocation: domainTemplate.DownloadableFileLocation
		);
	}

	namespace Extensions {
		public static class OfficialGameExtensionsForOfficialGameYaml {
			public static OfficialGameYaml ToYaml(this OfficialGame domain) => new() {
				FileLocation = domain.FileLocation,
				IncludeInRandomGame = domain.IncludeInRandomGame
			};
		}
	}
}
