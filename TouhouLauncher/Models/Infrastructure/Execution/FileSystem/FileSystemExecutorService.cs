using System;
using System.Diagnostics;
using System.IO;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.Models.Infrastructure.Execution.FileSystem {
	public class FileSystemExecutorService : IExecutorService {
		public virtual Process? StartExecutable(string executableLocation) {
			if (!File.Exists(executableLocation)) {
				return null;
			}

			ProcessStartInfo startInfo = new(executableLocation);

			string? directoryPath = Path.GetDirectoryName(startInfo.FileName);

			if (directoryPath == null) {
				return null;
			}

			startInfo.WorkingDirectory = directoryPath;

			try {
				return Process.Start(startInfo);
			}
			catch(Exception) {
				return null;
			}
		}
	}
}
