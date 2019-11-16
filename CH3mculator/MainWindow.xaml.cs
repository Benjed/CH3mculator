using MahApps.Metro.Controls;
using System.Reflection;
using System.Windows.Controls;

namespace CH3mculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTitleInformation();
        }

        private void SetTitleInformation()
        {
            var assemblyName = Assembly.GetEntryAssembly().GetName();
            TitleCharacterCasing = CharacterCasing.Normal;
            Title = string.Concat("CH3mculator - ", assemblyName.Version.ToString());
        }
    }
}