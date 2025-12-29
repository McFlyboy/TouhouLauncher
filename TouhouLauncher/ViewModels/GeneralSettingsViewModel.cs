using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels;

public class GeneralSettingsViewModel(SettingsAndGamesManager settingsAndGamesManager) : ObservableRecipient
{
    public bool CloseOnGameLaunchChecked
    {
        get => settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch;
        set
        {
            settingsAndGamesManager.GeneralSettings.CloseOnGameLaunch = value;
            SaveSettings();
        }
    }

    public bool CombineMainCategoriesChecked
    {
        get => settingsAndGamesManager.GeneralSettings.CombineMainCategories;
        set
        {
            settingsAndGamesManager.GeneralSettings.CombineMainCategories = value;
            SaveSettings();

            Messenger.Send(new HomeViewRebuildHeadersMessage());
        }
    }

    private void SaveSettings()
    {
        settingsAndGamesManager.SaveAsync()
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
