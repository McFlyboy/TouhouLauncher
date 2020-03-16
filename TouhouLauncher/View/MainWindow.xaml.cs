using System.Windows;
using System.Windows.Navigation;
using TouhouLauncher.ViewModel;

namespace TouhouLauncher.View {
	public partial class MainWindow : NavigationWindow {
		public MainWindow() {
			InitializeComponent();
		}
		public static void ShowPage(string page) {
			((MainViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Page = page;
		}
	}
}
