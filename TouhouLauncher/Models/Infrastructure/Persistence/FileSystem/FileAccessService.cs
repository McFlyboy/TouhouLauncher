using System;
using System.IO;
using System.Threading.Tasks;
using TouhouLauncher.Models.Common;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Models.Infrastructure.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem {
	public class FileAccessService {
		public virtual async Task<Either<FileReadError, string>> ReadFileToStringAsync(string path) {
			try {
				return await File.ReadAllTextAsync(path);
			}
			catch (Exception) {
				return new FileReadError(path);
			};
		}

		public virtual async Task<FileWriteError?> WriteFileFromStringAsync(string path, string? content) {
			try {
				Directory.CreateDirectory(
					Path.GetDirectoryName(path).Transform(
						directory => string.IsNullOrEmpty(directory)
							? $"{Environment.CurrentDirectory}\\{directory}"
							: directory
					)
				);

				await File.WriteAllTextAsync(path, content);
				return null;
			}
			catch (Exception) {
				return new FileWriteError(path);
			}
		}

		public virtual async Task<Either<TouhouLauncherError, TYaml>> ReadFileToYamlAsync<TYaml>(string path) where TYaml : Yaml, new() =>
			(await ReadFileToStringAsync(path))
				.ResolveToEither(
					error => error,
					content => content.ToYamlObject<TYaml>()
						.SelectLeft(error => (TouhouLauncherError)error)
				);

		public virtual async Task<FileWriteError?> WriteFileFromYamlAsync<TYaml>(string path, TYaml? content) where TYaml : Yaml, new() =>
			await WriteFileFromStringAsync(path, content?.ToYamlString());

		public virtual async Task<Either<FileReadError, TIni>> ReadFileToIniAsync<TIni>(string path) where TIni : Ini, new() =>
			(await ReadFileToStringAsync(path))
				.SelectRight(content => content.ToIniObject<TIni>());

		public virtual async Task<FileWriteError?> WriteFileFromIniAsync<TIni>(string path, TIni? content) where TIni : Ini, new() =>
			await WriteFileFromStringAsync(path, content?.ToIniString());
	}

	public record FileReadError(string FilePath) : TouhouLauncherError {
		public override string Message => $"Could not read the file: {FilePath}";
	}

	public record FileWriteError(string FilePath) : TouhouLauncherError {
		public override string Message => $"Could not write content to file: {FilePath}";
	}
}
