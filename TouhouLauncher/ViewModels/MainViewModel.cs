using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels;

public class MainViewModel : ObservableRecipient
{
    private string _page;

    public MainViewModel(SettingsAndGamesManager settingsAndGamesManager)
    {
        Messenger.Register<MainViewModel, MainViewChangePageMessage>(this, static (r, m) => r.ChangePage(m.Page));

        _page = "HomePage.xaml";

        _ = settingsAndGamesManager.LoadAsync();
    }

    public string Page => "Pages/" + _page;

    private void ChangePage(string page)
    {
        _page = page;
        OnPropertyChanged(nameof(Page));
    }
}

public record MainViewChangePageMessage(string Page);
