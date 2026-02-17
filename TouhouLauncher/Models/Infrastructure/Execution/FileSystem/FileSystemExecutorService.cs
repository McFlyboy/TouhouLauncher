using System;
using System.Diagnostics;
using System.IO;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Infrastructure.Execution.FileSystem;

public class FileSystemExecutorService : IExecutorService
{
    public virtual Either<ExecutorServiceError, Process> StartExecutable(string executableLocation)
    {
        if (!File.Exists(executableLocation))
            return new ExecutorServiceError.ExecutableDoesNotExistError(executableLocation);

        try
        {
            var process = Process.Start(
                new ProcessStartInfo(executableLocation)
                {
                    UseShellExecute = true
                }
            );

            if (process == null || process.HasExited)
                return new ExecutorServiceError.ProcessExecuteError(executableLocation);

            return process;
        }
        catch (Exception)
        {
            return new ExecutorServiceError.ProcessExecuteError(executableLocation);
        }
    }
}
