using GalaSoft.MvvmLight;
using TouhouLauncher.Model;

namespace TouhouLauncher.ViewModel {
	public class MainViewModel : ViewModelBase {
		public string Page {
			get {
				return _mainModel.Page;
			}
		}

		private readonly MainModel _mainModel;
		public MainViewModel() {
			_mainModel = new MainModel();
		}
	}
}
