using Microsoft.Win32;

namespace TouhouLauncher.Services.Application {
	public class FileBrowserService {
		public string BrowseFiles(string filter) {
			OpenFileDialog fileDialog = new OpenFileDialog {
				Filter = filter
			};
			if (fileDialog.ShowDialog() ?? false) {
				return fileDialog.FileName;
			}
			return string.Empty;
		}
	}
}
