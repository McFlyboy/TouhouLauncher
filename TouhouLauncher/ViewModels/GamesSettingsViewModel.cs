using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.ViewModels;

public class GamesSettingsViewModel : ObservableRecipient
{
    private readonly FileSystemBrowserService _fileSystemBrowserService;
    private readonly SettingsAndGamesManager _settingsAndGamesManager;

    public GamesSettingsViewModel(
        FileSystemBrowserService fileSystemBrowserService,
        SettingsAndGamesManager settingsAndGamesManager
    )
    {
        _fileSystemBrowserService = fileSystemBrowserService;
        _settingsAndGamesManager = settingsAndGamesManager;

        GamesSettings = [];

        foreach (OfficialGame game in _settingsAndGamesManager.OfficialGames)
        {
            GamesSettings.Add(new(_fileSystemBrowserService, _settingsAndGamesManager, game));
        }
    }

    public ObservableCollection<GameSettings> GamesSettings { get; }

    public class GameSettings : ObservableObject
    {
        private readonly FileSystemBrowserService _fileSystemBrowserService;
        private readonly SettingsAndGamesManager _settingsAndGamesManager;
        private readonly OfficialGame _game;

        public GameSettings(
            FileSystemBrowserService fileSystemBrowserService,
            SettingsAndGamesManager settingsAndGamesManager,
            OfficialGame game
        )
        {
            _fileSystemBrowserService = fileSystemBrowserService;
            _settingsAndGamesManager = settingsAndGamesManager;
            _game = game;

            ExternalLinkToGameDownloadCommand = new RelayCommand(
                () => Process.Start(
                    new ProcessStartInfo("cmd", $"/c start {_game.DownloadableFileLocation}")
                    {
                        CreateNoWindow = true
                    }
                )
            );

            BrowseCommand = new RelayCommand(() =>
            {
                var browseResult = BrowseForGame();

                if (browseResult == null)
                    return;

                Location = browseResult;
                OnPropertyChanged(nameof(Location));
            });
        }

        public string Name => _game.Title;

        public string Location
        {
            get => _game.FileLocation ?? string.Empty;
            set
            {
                _game.FileLocation = value;
                _settingsAndGamesManager.SaveAsync()
                    .ContinueWith(async result =>
                    {
                        var error = await result;

                        if (error != null)
                        {
                            MessageBox.Show(error.Message, "Error");
                        }
                    });
            }
        }

        public bool IncludeInRandomGame
        {
            get => _game.IncludeInRandomGame;
            set
            {
                _game.IncludeInRandomGame = value;
                _settingsAndGamesManager.SaveAsync()
                    .ContinueWith(async result =>
                    {
                        var error = await result;

                        if (error != null)
                        {
                            MessageBox.Show(error.Message, "Error");
                        }
                    });
            }
        }

        public ICommand ExternalLinkToGameDownloadCommand { get; }

        public ICommand BrowseCommand { get; }

        private string? BrowseForGame() =>
            _game.Categories.HasFlag(GameCategories.MainPC98)
                ? _fileSystemBrowserService.BrowseFiles(
                    "Select game",
                    new("Hard disk image files", "*.hdi", "*.t98"),
                    new("All files", "*.*")
                )
                : _fileSystemBrowserService.BrowseFiles(
                    "Select game",
                    new("Executable files", "*.exe"),
                    new("All files", "*.*")
                );
    }
}
