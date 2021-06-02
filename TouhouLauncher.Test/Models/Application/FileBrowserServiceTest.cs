using TouhouLauncher.Models.Application;
using Xunit;
using static TouhouLauncher.Models.Application.FileBrowserService;

namespace TouhouLauncher.Test.Models.Application {
	public class FileBrowserServiceTest {
		private readonly FileBrowserService _fileBrowserService = new();

		[Fact]
		public void Formats_filter_string_correctly() {
			var result = _fileBrowserService.CreateFilterString(new Filter[] {
				new("Executable files", "*.exe"),
				new("HTML files", "*.htm", "*.html")
			});

			Assert.Equal("Executable files|*.exe|HTML files|*.htm;*.html", result);
		}
	}
}
