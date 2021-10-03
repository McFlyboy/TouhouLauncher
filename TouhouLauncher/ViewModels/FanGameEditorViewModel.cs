using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace TouhouLauncher.ViewModels {
	public class FanGameEditorViewModel : ViewModelBase {
		public FanGameEditorViewModel() {
			CancelCommand = new RelayCommand(
				() => MessengerInstance.Send("HomePage.xaml", MainViewModel.ChangePageMessageToken)
			);
		}

		public ICommand CancelCommand { get; }
	}
}
