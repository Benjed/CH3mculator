using GalaSoft.MvvmLight;
using System.Diagnostics;
using System.Windows.Controls;

namespace CH3mculator.Module.Settings
{
    /// <summary>
    /// Interaction logic for InfoView.xaml
    /// </summary>
    public partial class InfoView : UserControl
    {
        public InfoView(ViewModelBase viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            var process = new Process();
            process.StartInfo.FileName = e.Uri.AbsoluteUri;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }
    }
}
