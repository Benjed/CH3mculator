using CH3mculator.Shared.Logic.Logging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace CH3mculator.Shell.ErrorHandling
{
    public class ErrorViewModel : ViewModelBase
    {
        public ICommand QuitApplicationCommand { get; set; }
        public ICommand RestartApplicationCommand { get; set; }
        public ICommand ReportIssueCommand { get; set; }

        private string _exceptionText;
        public string ExceptionText
        {
            get => _exceptionText;
            set
            {
                _exceptionText = value;
                RaisePropertyChanged();
            }
        }

        public ErrorViewModel(Exception exception)
        {
            LogUnhandledException(exception);

            QuitApplicationCommand = new RelayCommand(QuitApplication);
            RestartApplicationCommand = new RelayCommand(RestartApplication);
            ReportIssueCommand = new RelayCommand(ReportIssue);
        }

        private void LogUnhandledException(Exception exception)
        {
            ExceptionText = ExceptionMessageBuilder.BuildExceptionMessage(exception);
            Logger.Log.Exception(ExceptionText);
        }

        private void ReportIssue()
        {
            Process.Start("https://github.com/Benjed/CH3mculator/issues/new");
        }

        private void QuitApplication()
        {
            Application.Current.MainWindow.Close();
        }

        private void RestartApplication()
        {
            Process.Start(Assembly.GetExecutingAssembly().Location);
            QuitApplication();
        }
    }
}
