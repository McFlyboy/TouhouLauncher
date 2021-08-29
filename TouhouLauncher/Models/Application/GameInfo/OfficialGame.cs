#nullable disable

namespace TouhouLauncher.Models.Application.GameInfo {
	public record OfficialGame : Game {
		public string DownloadableFileLocation { get; init; }
	}
}
