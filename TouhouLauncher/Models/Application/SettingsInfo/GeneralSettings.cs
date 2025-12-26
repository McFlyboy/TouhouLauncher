namespace TouhouLauncher.Models.Application.SettingsInfo;

public record GeneralSettings
{
    public GeneralSettings(
        bool closeOnGameLaunch,
        bool combineMainCategories
    )
    {
        CloseOnGameLaunch = closeOnGameLaunch;
        CombineMainCategories = combineMainCategories;
    }

    public bool CloseOnGameLaunch { get; set; }

    public bool CombineMainCategories { get; set; }
}
