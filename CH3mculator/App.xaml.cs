using CH3mculator.Shell;
using CH3mculator.Shell.ErrorHandling;
using System;
using System.Windows;
using System.Windows.Threading;

namespace CH3mculator
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Current.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(HandleUnhandledException);
        }

        private void HandleUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Current.MainWindow.Content = new ErrorView(new ErrorViewModel(e.Exception));
            e.Handled = true;
        }
    }
}
