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

        ProcessStartInfo startInfo = new(executableLocation);

        string? directoryPath = Path.GetDirectoryName(startInfo.FileName);

        if (directoryPath == null)
            return new ExecutorServiceError.ExecutableDoesNotExistError(executableLocation);

        startInfo.WorkingDirectory = directoryPath;

        try
        {
            var process = Process.Start(startInfo);

            if (process == null || process.HasExited)
                return new ExecutorServiceError.ProcessExecuteError(executableLocation);

            return process;
        }
        catch(Exception)
        {
            return new ExecutorServiceError.ProcessExecuteError(executableLocation);
        }
    }
}
