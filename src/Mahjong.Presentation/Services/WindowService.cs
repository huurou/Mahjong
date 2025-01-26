using CommunityToolkit.Mvvm.Messaging;
using Mahjong.Presentation.Dialogs;
using Mahjong.Presentation.Messages;
using System.Windows;

namespace Mahjong.Presentation.Services;

public class WindowService(IServiceProvider provider)
{
    public void Register()
    {
        WeakReferenceMessenger.Default.Register<ShowAboutDialogRequestMessage>(this, (_, m) => m.Reply(GetWindow<AboutDialog>().ShowDialog()));
    }

    private TWindow GetWindow<TWindow>() where TWindow : Window
    {
        var activeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);
        var window = provider.GetRequiredService<TWindow>();
        if (activeWindow is not null)
        {
            window.Owner = activeWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
        return window;
    }
}
