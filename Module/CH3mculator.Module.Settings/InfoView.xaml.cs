using GalaSoft.MvvmLight;
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
    }
}
