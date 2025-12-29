using System.Collections.Generic;
using System.Threading.Tasks;
using TouhouLauncher.Models.Application.GameInfo;
using TouhouLauncher.Models.Application.SettingsInfo;

namespace TouhouLauncher.Models.Application;

public class SettingsAndGamesManager(
    ISettingsAndGamesRepository settingsAndGamesRepository,
    OfficialGamesTemplateService officialGamesTemplateService
)
{
    private SettingsAndGames _settingsAndGames = new(
        GeneralSettings: new(
            closeOnGameLaunch: false,
            combineMainCategories: false
        ),
        EmulatorSettings: new(
            folderLocation: null
        ),
        OfficialGames: [],
        FanGames: []
    );

    public virtual GeneralSettings GeneralSettings => _settingsAndGames.GeneralSettings;

    public virtual EmulatorSettings EmulatorSettings => _settingsAndGames.EmulatorSettings;

    public virtual OfficialGame[] OfficialGames => _settingsAndGames.OfficialGames;

    public virtual List<FanGame> FanGames => _settingsAndGames.FanGames;

    public virtual async Task<SettingsAndGamesSaveError?> SaveAsync() =>
        await settingsAndGamesRepository.SaveAsync(_settingsAndGames);

    public async Task<SettingsAndGamesLoadError?> LoadAsync() =>
        (await settingsAndGamesRepository.LoadAsync())
            .Resolve<SettingsAndGamesLoadError?>(
                error =>
                {
                    _settingsAndGames = new(
                        GeneralSettings: new(
                            closeOnGameLaunch: false,
                            combineMainCategories: false
                        ),
                        EmulatorSettings: new(
                            folderLocation: null
                        ),
                        OfficialGames: officialGamesTemplateService.CreateOfficialGamesFromTemplate(),
                        FanGames: []
                    );

                    return error;
                },
                settingsAndGames =>
                {
                    _settingsAndGames = settingsAndGames;

                    return null;
                }
            );
}
