using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Mahjong.Model;
using Mahjong.Model.Configs;
using Mahjong.Presentation.Messages;

namespace Mahjong.Presentation;

public partial class MainWindowViewModel(ApplicationService appService, ILogger<MainWindowViewModel> logger) : ObservableObject
{
    [ObservableProperty]
    private string title = AppInfo.Name;

    [RelayCommand]
    public void Loaded()
    {
        logger.LogInformation("MainWindow Loaded");
    }

    [RelayCommand]
    public void ShowAboutDialog()
    {
        WeakReferenceMessenger.Default.Send<ShowAboutDialogRequestMessage>();
    }
}
