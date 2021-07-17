namespace TouhouLauncher.Models.Application {
	public record Np21ntConfig(Np21ntConfig.NekoProject21Section NekoProject21) {
		public record NekoProject21Section {
			public string Hdd1File { get; set; }
		}
	}
}
