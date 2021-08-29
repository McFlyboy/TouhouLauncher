#nullable disable

using System;
using System.Diagnostics;
using System.IO;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.Models.Infrastructure.Execution.FileSystem {
	public class FileSystemExecutorService : IExecutorService {
		public virtual Process StartExecutable(string executableLocation) {
			if (!File.Exists(executableLocation)) {
				return null;
			}

			var startInfo = new ProcessStartInfo(executableLocation);
			startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);

			try {
				return Process.Start(startInfo);
			}
			catch(Exception) {
				return null;
			}
		}
	}
}
