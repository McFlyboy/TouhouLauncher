using Microsoft.Win32;
using System.Linq;

namespace TouhouLauncher.Models.Application;

public class FileSystemBrowserService
{
    public string? BrowseFolders(string browserTitle)
    {
        System.Windows.Forms.FolderBrowserDialog folderDialog = new()
        {
            Description = browserTitle,
            UseDescriptionForTitle = true
        };

        return (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            ? folderDialog.SelectedPath
            : null;
    }

    public string? BrowseFiles(string browserTitle, params Filter[] filters)
    {
        OpenFileDialog fileDialog = new()
        {
            Title = browserTitle,
            Filter = CreateFileFilterString(filters),
        };

        return (fileDialog.ShowDialog() ?? false)
            ? fileDialog.FileName
            : null;
    }

    public string CreateFileFilterString(Filter[] filters) =>
        string.Join("|", filters.Select(filter => filter.ToString()));

    public record Filter(string Label, params string[] Extensions)
    {
        public override string ToString() => $"{Label}|{string.Join(";", Extensions)}";
    }
}
