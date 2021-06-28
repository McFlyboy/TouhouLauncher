#include "pch.h"

#include "OpenFolderDialogNative.hpp"

using namespace msclr::interop;

namespace TouhouLauncher::WpfExtensions::Win32 {
	OpenFolderDialogNative::OpenFolderDialogNative() {
		const auto result = CoInitializeEx(NULL, COINIT_APARTMENTTHREADED | COINIT_DISABLE_OLE1DDE);

		if (FAILED(result)) {
			return;
		}

		IFileOpenDialog* pFileOpen = nullptr;

		const auto dialogCreationResult = CoCreateInstance(
			CLSID_FileOpenDialog,
			NULL,
			CLSCTX_ALL,
			IID_IFileOpenDialog,
			reinterpret_cast<void**>(&pFileOpen)
		);

		if (FAILED(dialogCreationResult)) {
			CoUninitialize();
			return;
		}

		pFileOpen->SetOptions(FOS_PICKFOLDERS);

		m_folderDialog = pFileOpen;
	}

	OpenFolderDialogNative::!OpenFolderDialogNative() {
		if (m_folderDialog == nullptr) {
			return;
		}

		m_folderDialog->Release();

		CoUninitialize();
	}

	OpenFolderDialogNative::~OpenFolderDialogNative() {
		OpenFolderDialogNative::!OpenFolderDialogNative();
	}

	void OpenFolderDialogNative::SetTitle(System::String^ title) {
		if (m_folderDialog == nullptr) {
			return;
		}

		const auto context = gcnew marshal_context();

		m_folderDialog->SetTitle(context->marshal_as<const wchar_t*>(title));
	}

	System::Boolean OpenFolderDialogNative::ShowDialog(System::IntPtr hwndOwner) {
		if (m_folderDialog == nullptr) {
			return false;
		}

		const auto hr = m_folderDialog->Show((HWND)marshal_as<HANDLE>(hwndOwner));

		if (FAILED(hr)) {
			return false;
		}

		IShellItem* pItem;

		const auto hr2 = m_folderDialog->GetResult(&pItem);

		if (FAILED(hr2)) {
			return false;
		}

		System::Boolean result = false;

		PWSTR pszFilePath;

		const auto hr3 = pItem->GetDisplayName(SIGDN_FILESYSPATH, &pszFilePath);

		if (SUCCEEDED(hr3)) {
			auto folderPath = marshal_as<System::String^>(pszFilePath);

			if (folderPath->Length > 0) {
				FolderName = folderPath;
				result = true;
			}

			CoTaskMemFree(pszFilePath);
		}

		pItem->Release();

		return result;
	}
}
