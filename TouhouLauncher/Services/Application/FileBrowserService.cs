using Microsoft.Win32;
using System.Text;

namespace TouhouLauncher.Services.Application {
	public class FileBrowserService {
		public string BrowseFiles(Filter filter = null) {
			OpenFileDialog fileDialog = new OpenFileDialog {
				Filter = filter?.ToString()
			};
			return (fileDialog.ShowDialog() ?? false) ? fileDialog.FileName : string.Empty;
		}

		public class Filter {
			public Filter(params FileType[] fileTypes) {
				FileTypes = fileTypes;
			}

			public FileType[] FileTypes { get; set; }

			public override string ToString() {
				var filter = new StringBuilder();

				for(int i = 0; i < FileTypes.Length; i++) {
					filter.Append(FileTypes[i].ToString());

					if (i != FileTypes.Length - 1) {
						filter.Append("|");
					}
				}

				return filter.ToString();
			}

			public class FileType {
				public FileType(string label, params string[] extensions) {
					Label = label;
					Extensions = extensions;
				}

				public string Label { get; set; }

				public string[] Extensions { get; set; }

				public override string ToString() {
					var fileType = new StringBuilder(Label + "|");

					for(int i = 0; i < Extensions.Length; i++) {
						fileType.Append(Extensions[i]);

						if (i != Extensions.Length - 1) {
							fileType.Append(";");
						}
					}

					return fileType.ToString();
				}
			}
		}
	}
}
