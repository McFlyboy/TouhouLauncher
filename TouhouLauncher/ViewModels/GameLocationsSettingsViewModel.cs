using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace TouhouLauncher.ViewModels {
    public class GameLocationsSettingsViewModel : ViewModelBase {
        public GameLocationsSettingsViewModel() {
            GameLocations = new ObservableCollection<GameLocation>();

            GameLocations.Add(new GameLocation() { Name = "Test", Location = string.Empty });
        }

        public ObservableCollection<GameLocation> GameLocations { get; }

        public class GameLocation {
            public string Name { get; init; }

            public string Location { get; set; }
        }
    }
}
