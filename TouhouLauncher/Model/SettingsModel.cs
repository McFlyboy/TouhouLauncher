using System.Windows;
using TouhouLauncher.View;

namespace TouhouLauncher.Model {
	public class SettingsModel {
		public void CloseSettings() {
			((MainWindow)Application.Current.MainWindow).ShowPage("HomePage.xaml");
		}
	}
}
