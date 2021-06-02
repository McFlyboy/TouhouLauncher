using Microsoft.Win32;
using System.Linq;

namespace TouhouLauncher.Models.Application {
	public class FileBrowserService {
		public string BrowseFiles(params Filter[] filters) {
			var fileDialog = new OpenFileDialog {
				Filter = CreateFilterString(filters)
			};
			return (fileDialog.ShowDialog() ?? false) ? fileDialog.FileName : string.Empty;
		}

		public string CreateFilterString(Filter[] filters) {
			return string.Join("|", filters.Select(filter => filter.ToString()));
		}

		public record Filter(string Label, params string[] Extensions) {
			public override string ToString() {
				return $"{Label}|{string.Join(";", Extensions)}";
			}
		}
	}
}
