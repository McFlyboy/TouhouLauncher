using TouhouLauncher.Models.Application;
using Xunit;

namespace TouhouLauncher.Test.Models.Application;

public class FileSystemBrowserServiceTest
{
    private readonly FileSystemBrowserService _fileSystemBrowserService = new();

    [Fact]
    public void Formats_filter_string_correctly()
    {
        string result = _fileSystemBrowserService.CreateFileFilterString([
            new("Executable files", "*.exe"),
            new("HTML files", "*.htm", "*.html")
        ]);

        Assert.Equal("Executable files|*.exe|HTML files|*.htm;*.html", result);
    }
}
