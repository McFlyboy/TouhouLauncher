using Microsoft.Win32;
using System;
using TouhouLauncher.WpfExtensions.Win32;

namespace TouhouLauncher.WpfExtensions {
	public class OpenFolderDialog : CommonDialog {
		private readonly OpenFolderDialogNative _openFolderDialogNative;

		public OpenFolderDialog() {
			_openFolderDialogNative = new OpenFolderDialogNative();
		}

		public string Title {
			set => _openFolderDialogNative.SetTitle(value);
		}

		public string FolderName {
			get => _openFolderDialogNative.FolderName;
			set => _openFolderDialogNative.FolderName = value;
		}

		public override void Reset() {
			Title = null;
			FolderName = null;
		}

		protected override bool RunDialog(IntPtr hwndOwner) {
			return _openFolderDialogNative.ShowDialog(hwndOwner);
		}
	}
}
