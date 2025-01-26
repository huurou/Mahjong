using Mahjong.Presentation.Controls.ConsoleTextViews.ConsoleTextItems;
using Mahjong.Presentation.Controls.ConsoleTextViews.Logging;
using Mahjong.Presentation.Services;
using System.Windows;

namespace Mahjong.Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(WindowService windowService, MainWindowViewModel viewModel)
    {
        windowService.Register();

        DataContext = viewModel;
        InitializeComponent();

        ConsoleTextViewLogger.LoggingRequested +=
            (s, e) => Application.Current?.Dispatcher.Invoke(
                () => ConsoleTextView.AppendConsoleItem(ConsoleTextItemProvider.Create(e.LogLevel, e.DateTime, e.Message))
            );
    }
}