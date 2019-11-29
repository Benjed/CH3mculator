using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace CH3mculator.Shell
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            SetTitleInformation();
        }

        private void SetTitleInformation()
        {
            var assemblyName = Assembly.GetEntryAssembly().GetName();
            Title = string.Concat("CH3mculator - ", assemblyName.Version.ToString());
        }
    }
}