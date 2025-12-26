namespace TouhouLauncher.Models.Application.GameInfo;

public record OfficialGame : Game
{
    public OfficialGame(
        string title,
        string? imageLocation,
        string? audioLocation,
        int? releaseYear,
        string? fileLocation,
        bool includeInRandomGame,
        GameCategories categories,
        string downloadableFileLocation
    ) : base(
        title: title,
        imageLocation: imageLocation,
        audioLocation: audioLocation,
        releaseYear: releaseYear,
        fileLocation: fileLocation,
        includeInRandomGame: includeInRandomGame,
        categories: categories
    )
    {
        DownloadableFileLocation = downloadableFileLocation;
    }

    public string DownloadableFileLocation { get; init; }
}
