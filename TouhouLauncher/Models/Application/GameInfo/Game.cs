﻿namespace TouhouLauncher.Models.Application.GameInfo {
	public abstract class Game {
		public string Title { get; set; }

		public string Subtitle { get; set; }

		public string FullTitle => Title + Subtitle != null ? $": {Subtitle}" : string.Empty;

		public string ImageLocation { get; set; }

		public string AudioLocation { get; set; }

		public int ReleaseYear { get; set; }

		public string FileLocation { get; set; }
	}
}