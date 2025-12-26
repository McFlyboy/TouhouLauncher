namespace TouhouLauncher.Models.Application.SettingsInfo;

public record EmulatorSettings
{
    public EmulatorSettings(string? folderLocation)
    {
        FolderLocation = folderLocation;
    }

    public string? FolderLocation { get; set; }
}
