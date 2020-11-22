using TouhouLauncher.Services.Application;
using Xunit;

namespace TouhouLauncher.Test.Services.Application {
	public class FileBrowserServiceFilterTest {
		private readonly FileBrowserService.Filter _filter;

		public FileBrowserServiceFilterTest() {
			_filter = new FileBrowserService.Filter(
				new FileBrowserService.Filter.FileType("Executable files", "*.exe"),
				new FileBrowserService.Filter.FileType("HTML files", "*.htm", "*.html")
			);
		}

		[Fact]
		public void Formats_filter_string_correctly() {
			Assert.Equal("Executable files|*.exe|HTML files|*.htm;*.html", _filter.ToString());
		}
	}
}
