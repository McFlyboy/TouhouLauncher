using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using TouhouLauncher.Models.Common.Extensions;
using TouhouLauncher.Views.UserControls.Settings;

namespace TouhouLauncher.ViewModels;

public class SettingsViewModel : ObservableRecipient
{
    private SettingsCategory _category;

    public SettingsViewModel()
    {
        _category = SettingsCategory.GeneralSettings;

        BackCommand = new RelayCommand(
            () => Messenger.Send(new MainViewChangePageMessage("HomePage.xaml"))
        );
    }

    public int CurrentSettingsCategoryIndex
    {
        get => (int)_category;
        set
        {
            _category = (SettingsCategory)value;
            OnPropertyChanged(nameof(CurrentSettingsCategory));
        }
    }

    public UserControl CurrentSettingsCategory => _category switch
    {
        SettingsCategory.GeneralSettings => new GeneralSettings(),
        SettingsCategory.EmulatorSettings => new EmulatorSettings(),
        SettingsCategory.Games => new GamesSettings(),
        _ => new UserControl(),
    };

    public string BuildVersion => $"Version: {FileVersionInfo.GetVersionInfo(Environment.ProcessPath!).ProductVersion!}";

    public ICommand BackCommand { get; }

    private enum SettingsCategory
    {
        GeneralSettings,
        EmulatorSettings,
        Games
    }
}
