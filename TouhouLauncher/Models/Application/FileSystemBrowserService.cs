using Microsoft.Win32;
using System.Linq;
using TouhouLauncher.WpfExtensions;

namespace TouhouLauncher.Models.Application {
	public class FileSystemBrowserService {
		public string BrowseFolders() {
			var folderDialog = new OpenFolderDialog() {
				Title = "Select emulator folder"
			};
			return (folderDialog.ShowDialog() ?? false) ? folderDialog.FolderName : null;
		}

		public string BrowseFiles(params Filter[] filters) {
			var fileDialog = new OpenFileDialog() {
				Title = "Select game",
				Filter = CreateFileFilterString(filters),
			};
			return (fileDialog.ShowDialog() ?? false) ? fileDialog.FileName : null;
		}

		public string CreateFileFilterString(Filter[] filters) {
			return string.Join("|", filters.Select(filter => filter.ToString()));
		}

		public record Filter(
			string Label,
			params string[] Extensions
		) {
			public override string ToString() {
				return $"{Label}|{string.Join(";", Extensions)}";
			}
		}
	}
}
