using System.IO;

namespace TouhouLauncher.Models.Application {
	public class PathExistanceService {
		public virtual bool PathExists(string? path) {
			return File.Exists(path);
		}
	}
}
