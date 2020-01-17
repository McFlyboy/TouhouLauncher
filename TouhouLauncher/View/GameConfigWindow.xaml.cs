using System.Windows;
using TouhouLauncher.Model.GameInfo;
using TouhouLauncher.ViewModel;

namespace TouhouLauncher.View {
	public partial class GameConfigWindow : Window {
		public GameConfigWindow(Game game) {
			InitializeComponent();
			((GameConfigViewModel)DataContext).LoadGameConfig(game);
		}
	}
}
