using System.Diagnostics;

namespace TouhouLauncher.Models.Application {
	public interface IExecutorService {
		public Process? StartExecutable(string executableLocation);
	}
}
