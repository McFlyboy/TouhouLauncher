using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouhouLauncher.Models;

namespace TouhouLauncher.ViewModels {
	public class GamePickerViewModel : ViewModelBase {
		private readonly GamePickerModel _gamePickerModel;

		public GamePickerViewModel(GamePickerModel gamePickerModel) {
			_gamePickerModel = gamePickerModel;

			GameButtonList = new ObservableCollection<GameButton>();
			for (int i = 0; i < _gamePickerModel.GameList.Count; i++) {
				GameButtonList.Add(new GameButton(i, this));
			}
		}

		public ObservableCollection<GameButton> GameButtonList { get; }

		public class GameButton {
			private readonly int _id;
			private readonly GamePickerViewModel _parent;

			public GameButton(int id, GamePickerViewModel parent) {
				_id = id;
				_parent = parent;

				GameCommand = new RelayCommand(() => {
					//_parent._gamePickerModel.LaunchGame(_id);
				});
			}

			public string GameName =>
				_parent._gamePickerModel.GameList[_id].Title +
				(!_parent._gamePickerModel.GameList[_id].Subtitle.Equals(string.Empty) ? ":\n" : string.Empty) +
				_parent._gamePickerModel.GameList[_id].Subtitle;
			public string GameImage => _parent._gamePickerModel.GameList[_id].ImageLocation;
			public string GameReleaseYear => "Release: " + _parent._gamePickerModel.GameList[_id].ReleaseYear;
			public ICommand GameCommand { get; }
		}
	}
}
