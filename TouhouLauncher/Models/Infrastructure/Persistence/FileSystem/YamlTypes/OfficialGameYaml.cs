﻿using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.YamlTypes {
	public record OfficialGameYaml : Yaml {
		public string FileLocation { get; init; }

		public OfficialGame ToDomain(OfficialGame domainTemplate) {
			return new OfficialGame() {
				Title = domainTemplate.Title,
				ReleaseYear = domainTemplate.ReleaseYear,
				AudioLocation = domainTemplate.AudioLocation,
				ImageLocation = domainTemplate.ImageLocation,
				Categories = domainTemplate.Categories,
				DownloadableFileLocation = domainTemplate.DownloadableFileLocation,
				FileLocation = FileLocation
			};
		}
	}

	namespace Extensions {
		public static class OfficialGameExtensionsForOfficialGameYaml {
			public static OfficialGameYaml ToYaml(this OfficialGame domain) {
				return new OfficialGameYaml() {
					FileLocation = domain.FileLocation
				};
			}
		}
	}
}