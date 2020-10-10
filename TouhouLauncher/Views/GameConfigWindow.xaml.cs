using System.Windows;
using TouhouLauncher.Models.GameInfo;
using TouhouLauncher.ViewModels;

namespace TouhouLauncher.Views {
	public partial class GameConfigWindow : Window {
		public GameConfigWindow(Game game) {
			InitializeComponent();
			((GameConfigViewModel)DataContext).LoadGameConfig(game);
		}
	}
}
