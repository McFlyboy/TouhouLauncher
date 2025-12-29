using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TouhouLauncher.Models.Application;
using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.ViewModels;

public class HomeViewModel : ObservableRecipient
{
    private readonly GamePickerViewModel _gamePickerViewModel;
    private readonly ActiveGameCategory _activeGameCategory;
    private readonly GameCategoryService _gameCategoryService;
    private readonly LaunchRandomGameService _launchRandomGameService;
    private readonly FanGameEditingService _fanGameEditingService;

    public HomeViewModel(
        GamePickerViewModel gamePickerViewModel,
        ActiveGameCategory activeGameCategory,
        GameCategoryService gameCategoryService,
        LaunchRandomGameService launchRandomGameService,
        FanGameEditingService fanGameEditingService
    )
    {
        _gamePickerViewModel = gamePickerViewModel;
        _activeGameCategory = activeGameCategory;
        _gameCategoryService = gameCategoryService;
        _launchRandomGameService = launchRandomGameService;
        _fanGameEditingService = fanGameEditingService;

        Messenger.Register<HomeViewModel, HomeViewRebuildHeadersMessage>(this, static (r, m) => r.RebuildHeaders());

        HeaderList = [];

        List<GameCategories> gameCategoryList = _gameCategoryService.CreateGameCategoryList();

        foreach (var category in gameCategoryList)
        {
            HeaderList.Add(new CategoryHeaderButton(category, this));
        }

        HeaderList.Add(CreateRandomGameHeader());

        OpenSettingsCommand = new RelayCommand(
            () => Messenger.Send(new MainViewChangePageMessage("SettingsPage.xaml"))
        );

        CreateNewFanGameCommand = new RelayCommand(() =>
        {
            _fanGameEditingService.SetFanGameToEdit(null);

            Messenger.Send(new MainViewChangePageMessage("FanGameEditorPage.xaml"));
        });

        NewFanGameVisibility = Visibility.Hidden;
    }

    public ObservableCollection<HeaderButton> HeaderList { get; }

    public string HeaderPadding => $"{(HeaderList.Count > 5 ? 10 : 30)} 0";

    public ICommand OpenSettingsCommand { get; }

    public ICommand CreateNewFanGameCommand { get; }

    public Visibility NewFanGameVisibility { get; private set; }

    private HeaderButton CreateRandomGameHeader() => new(
        name: "LAUNCH\nRANDOM GAME",
        colorCode: "#4284C4",
        colorHoverCode: "#5395D5",
        action: LaunchRandomGame
    );

    private void RebuildHeaders()
    {
        List<GameCategories> gameCategoryList = _gameCategoryService.CreateGameCategoryList();

        HeaderList.Clear();

        foreach (var category in gameCategoryList)
        {
            HeaderList.Add(new CategoryHeaderButton(category, this));
        }

        HeaderList.Add(CreateRandomGameHeader());

        if (
            _activeGameCategory.CurrentCategory.HasFlag(GameCategories.MainPC98)
            || _activeGameCategory.CurrentCategory.HasFlag(GameCategories.MainWindows)
        )
        {
            SetCurrentCategory(_gameCategoryService.GetDefaultGameCategory());
        }
    }

    private void SetCurrentCategory(GameCategories categoryFlags)
    {
        _activeGameCategory.CurrentCategory = categoryFlags;

        _gamePickerViewModel.UpdateGames();

        foreach (var button in HeaderList)
        {
            if (button is CategoryHeaderButton categoryHeaderButton)
                categoryHeaderButton.UpdateCategoryHeaderButton();
        }
    }

    private async void LaunchRandomGame()
    {
        var error = await _launchRandomGameService.LaunchRandomGame();

        if (error != null)
        {
            MessageBox.Show(error.Message, "Error");
        }
    }

    public class HeaderButton : ObservableObject
    {
        public HeaderButton(
            string name = "",
            string desc = "",
            string colorCode = "",
            string colorHoverCode = "",
            Action? action = null
        )
        {
            HeaderName = name;
            HeaderDesc = desc;
            HeaderColor = colorCode;
            HeaderHoverColor = colorHoverCode;
            HeaderCommand = action != null ? new RelayCommand(action) : new RelayCommand(() => { });
        }

        public string HeaderName { get; protected set; }

        public string HeaderDesc { get; protected set; }

        public int HeaderDescHeight => HeaderDesc.Length != 0 ? 15 : 0;

        public virtual string HeaderColor { get; }

        public virtual string HeaderHoverColor { get; }

        public string HeaderTextColor => "#FFFFFF";

        public virtual bool HeaderEnabled => true;

        public ICommand HeaderCommand { get; protected set; }
    }

    public class CategoryHeaderButton : HeaderButton
    {
        private readonly GameCategories _categories;
        private readonly HomeViewModel _parent;

        public CategoryHeaderButton(
            GameCategories categories,
            HomeViewModel parent
        ) : base()
        {
            _categories = categories;
            _parent = parent;
            switch (_categories)
            {
                case GameCategories.MainPC98:
                    HeaderName = "MAIN GAMES";
                    HeaderDesc = "(PC-98)";
                    break;

                case GameCategories.MainWindows:
                    HeaderName = "MAIN GAMES";
                    HeaderDesc = "(WINDOWS)";
                    break;

                case GameCategories.MainGame:
                    HeaderName = "MAIN GAMES";
                    break;

                case GameCategories.FightingGame:
                    HeaderName = "FIGHTING\nGAMES";
                    break;

                case GameCategories.SpinOff:
                    HeaderName = "SPIN-OFFS";
                    break;

                case GameCategories.FanGame:
                    HeaderName = "FAN GAMES";
                    break;

                default:
                    HeaderName = "UNKNOWN\nCATEGORY";
                    break;
            }
            HeaderCommand = new RelayCommand(() =>
            {
                _parent.SetCurrentCategory(_categories);

                _parent.NewFanGameVisibility = _categories.HasFlag(GameCategories.FanGame)
                    ? Visibility.Visible
                    : Visibility.Hidden;

                _parent.OnPropertyChanged(nameof(_parent.NewFanGameVisibility));
            });
        }

        public void UpdateCategoryHeaderButton()
        {
            OnPropertyChanged(nameof(HeaderColor));
            OnPropertyChanged(nameof(HeaderHoverColor));
            OnPropertyChanged(nameof(HeaderEnabled));
        }

        public override string HeaderColor =>
            _categories == _parent._activeGameCategory.CurrentCategory ? "#694F77" : "#342E30";

        public override string HeaderHoverColor => "#453F41";

        public override bool HeaderEnabled =>
            _categories != _parent._activeGameCategory.CurrentCategory;
    }
}

public record HomeViewRebuildHeadersMessage();
