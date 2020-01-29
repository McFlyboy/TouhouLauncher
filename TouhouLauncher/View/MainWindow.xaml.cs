using System.Windows.Navigation;
using TouhouLauncher.ViewModel;

namespace TouhouLauncher.View {
	public partial class MainWindow : NavigationWindow {
		public MainWindow() {
			InitializeComponent();
		}
		public void SwitchPage() {
			((MainViewModel)DataContext).SwitchPage();
		}
	}
}
