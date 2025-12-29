using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels;

public class FanGameEditorViewModel : ObservableRecipient
{
    private readonly FanGameEditingService _fanGameEditingService;
    private readonly FileSystemBrowserService _fileSystemBrowserService;

    public FanGameEditorViewModel(
        FanGameEditingService fanGameEditingService,
        FileSystemBrowserService fileSystemBrowserService
    )
    {
        _fanGameEditingService = fanGameEditingService;
        _fileSystemBrowserService = fileSystemBrowserService;

        BrowseCommand = new RelayCommand(() =>
        {
            var browseResult = _fileSystemBrowserService.BrowseFiles(
                "Select game",
                new("Executable files", "*.exe"),
                new("All files", "*.*")
            );

            if (browseResult == null)
                return;

            GameLocation = browseResult;
            OnPropertyChanged(nameof(GameLocation));
        });

        BrowseImageCommand = new RelayCommand(() =>
        {
            var browseResult = _fileSystemBrowserService.BrowseFiles(
                "Select cover image",
                new("Image files", "*.png", "*.jpg"),
                new("All files", "*.*")
            );

            if (browseResult == null)
                return;

            CoverImageLocation = browseResult;
            OnPropertyChanged(nameof(CoverImageLocation));
        });

        DeleteCommand = new RelayCommand(async () =>
        {
            var error = await _fanGameEditingService.DeleteFanGame();

            if (error != null)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }

            Messenger.Send(new GamePickerUpdateGamesMessage());
            Messenger.Send(new MainViewChangePageMessage("HomePage.xaml"));
        });

        SaveCommand = new RelayCommand(async () =>
        {
            var error = await _fanGameEditingService.SaveAsync();

            if (error != null)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }

            Messenger.Send(new GamePickerUpdateGamesMessage());
            Messenger.Send(new MainViewChangePageMessage("HomePage.xaml"));
        });

        CancelCommand = new RelayCommand(
            () => Messenger.Send(new MainViewChangePageMessage("HomePage.xaml"))
        );
    }

    public string PageTitle => _fanGameEditingService.TargetFanGame == null
        ? "New fan game"
        : "Edit fan game";

    public string GameTitle
    {
        get => _fanGameEditingService.GameTitle;
        set => _fanGameEditingService.GameTitle = value;
    }

    public string YearOfRelease
    {
        get => _fanGameEditingService.YearOfRelease?.ToString() ?? "";
        set
        {
            try
            {
                _fanGameEditingService.YearOfRelease = int.Parse(value);
            }
            catch (Exception)
            {
                _fanGameEditingService.YearOfRelease = null;
            }
        }
    }

    public string GameLocation
    {
        get => _fanGameEditingService.GameLocation;
        set => _fanGameEditingService.GameLocation = value;
    }

    public string CoverImageLocation
    {
        get => _fanGameEditingService.CoverImageLocation ?? string.Empty;
        set => _fanGameEditingService.CoverImageLocation = value.Length > 0 ? value : null;
    }

    public bool IncludeInRandomGame
    {
        get => _fanGameEditingService.IncludeInRandomGame;
        set => _fanGameEditingService.IncludeInRandomGame = value;
    }

    public Visibility DeleteButtonVisibility => _fanGameEditingService.TargetFanGame == null
        ? Visibility.Collapsed
        : Visibility.Visible;

    public ICommand BrowseCommand { get; }

    public ICommand BrowseImageCommand { get; }

    public ICommand DeleteCommand { get; }

    public ICommand SaveCommand { get; }

    public ICommand CancelCommand { get; }
}
