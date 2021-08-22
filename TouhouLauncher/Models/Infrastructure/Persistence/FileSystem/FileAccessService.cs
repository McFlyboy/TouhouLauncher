using System;
using System.IO;
using System.Threading.Tasks;
using TouhouLauncher.Models.Infrastructure.Extensions;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem {
	public class FileAccessService {
		public virtual async Task<string> ReadFileToStringAsync(string path) {
			try {
				return await File.ReadAllTextAsync(path);
			}
			catch(Exception) {
				return null;
			};
		}

		public virtual async Task<bool> WriteFileFromStringAsync(string path, string content) {
			try {
				await File.WriteAllTextAsync(path, content);
				return true;
			}
			catch(Exception) {
				return false;
			}
		}

		public virtual async Task<TYaml> ReadFileToYamlAsync<TYaml>(string path) where TYaml : Yaml =>
			(await ReadFileToStringAsync(path)).ToYamlObject<TYaml>();

		public virtual async Task<bool> WriteFileFromYamlAsync<TYaml>(string path, TYaml content) where TYaml : Yaml =>
			await WriteFileFromStringAsync(path, content?.ToYamlString());

		public virtual async Task<TIni> ReadFileToIniAsync<TIni>(string path) where TIni : Ini, new() =>
			(await ReadFileToStringAsync(path)).ToIniObject<TIni>();

		public virtual async Task<bool> WriteFileFromIniAsync<TIni>(string path, TIni content) where TIni : Ini, new() =>
			await WriteFileFromStringAsync(path, content?.ToIniString());
	}
}
