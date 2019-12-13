using System.Diagnostics;

namespace TouhouLauncher {
	public class Game {
		public string Name { get; set; }
		public string ImageLocation { get; set; }
		public int ReleaseYear { get; set; }
		public string Location { get; set; }
		public void Launch() {
			Process test = new Process();
			test.StartInfo.FileName = Location;
			test.Start();
		}
	}
}
