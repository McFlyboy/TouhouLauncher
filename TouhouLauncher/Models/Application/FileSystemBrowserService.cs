#nullable disable

using Microsoft.Win32;
using System.Linq;

namespace TouhouLauncher.Models.Application {
	public class FileSystemBrowserService {
		public string BrowseFolders() {
			var folderDialog = new System.Windows.Forms.FolderBrowserDialog() {
				Description = "Select emulator folder",
				UseDescriptionForTitle = true
			};

			return (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) ? folderDialog.SelectedPath : null;
		}

		public string BrowseFiles(params Filter[] filters) {
			var fileDialog = new OpenFileDialog() {
				Title = "Select game",
				Filter = CreateFileFilterString(filters),
			};

			return (fileDialog.ShowDialog() ?? false) ? fileDialog.FileName : null;
		}

		public string CreateFileFilterString(Filter[] filters) =>
			string.Join("|", filters.Select(filter => filter.ToString()));

		public record Filter(
			string Label,
			params string[] Extensions
		) {
			public override string ToString() => $"{Label}|{string.Join(";", Extensions)}";
		}
	}
}
