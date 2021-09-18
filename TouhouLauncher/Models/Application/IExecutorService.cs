using System.Diagnostics;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application {
	public interface IExecutorService {
		public Either<ExecutorServiceError, Process> StartExecutable(string executableLocation);
	}

	public abstract record ExecutorServiceError : TouhouLauncherError {
		public record ProcessExecuteError(string ExecutableLocation) : ExecutorServiceError {
			public override string Message => $"Unable to start executable: {ExecutableLocation}";
		}

		public record ExecutableDoesNotExistError(string ExecutableLocation) : ExecutorServiceError {
			public override string Message => $"Could not find the executable: {ExecutableLocation}";
		}
	}
}
