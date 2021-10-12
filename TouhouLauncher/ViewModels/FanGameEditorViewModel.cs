using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.ViewModels {
	public class FanGameEditorViewModel : ViewModelBase {
		private readonly FanGameEditingService _fanGameEditingService;
		private readonly FileSystemBrowserService _fileSystemBrowserService;

		public FanGameEditorViewModel(
			FanGameEditingService fanGameEditingService,
			FileSystemBrowserService fileSystemBrowserService
		) {
			_fanGameEditingService = fanGameEditingService;
			_fileSystemBrowserService = fileSystemBrowserService;

			BrowseCommand = new RelayCommand(() => {
				var browseResult = _fileSystemBrowserService.BrowseFiles(
					new("Executable files", "*.exe"),
					new("All files", "*.*")
				);

				if (browseResult == null) {
					return;
				}

				GameLocation = browseResult;
				RaisePropertyChanged(nameof(GameLocation));
			});

			SaveCommand = new RelayCommand(async () => {
				var error = await _fanGameEditingService.SaveAsync();

				if (error != null) {
					MessageBox.Show(error.Message, "Error");
					return;
				}

				MessengerInstance.Send("HomePage.xaml", MainViewModel.ChangePageMessageToken);
			});

			CancelCommand = new RelayCommand(
				() => MessengerInstance.Send("HomePage.xaml", MainViewModel.ChangePageMessageToken)
			);
		}

		public string GameTitle {
			get => _fanGameEditingService.GameTitle;
			set => _fanGameEditingService.GameTitle = value;
		}

		public string YearOfRelease {
			get => _fanGameEditingService.YearOfRelease;
			set => _fanGameEditingService.YearOfRelease = value;
		}

		public string GameLocation {
			get => _fanGameEditingService.GameLocation;
			set => _fanGameEditingService.GameLocation = value;
		}

		public string CoverImageLocation {
			get => _fanGameEditingService.CoverImageLocation;
			set => _fanGameEditingService.CoverImageLocation = value;
		}

		public ICommand BrowseCommand { get; }

		public ICommand SaveCommand { get; }

		public ICommand CancelCommand { get; }
	}
}
