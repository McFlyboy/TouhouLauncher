#pragma once

#include "pch.h"

namespace TouhouLauncher::WpfExtensions::Win32 {
	public ref class OpenFolderDialogNative {
	private:
		IFileOpenDialog* m_folderDialog = nullptr;

	public:
		OpenFolderDialogNative();
		!OpenFolderDialogNative();
		~OpenFolderDialogNative();

		property System::String^ FolderName;

		void SetTitle(System::String^ title);

		System::Boolean ShowDialog(System::IntPtr hwndOwner);
	};
}
