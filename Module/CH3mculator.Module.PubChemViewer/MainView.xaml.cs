using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace CH3mculator.Module.PubChemViewer
{
    /// <summary>
    /// Interaction logic for PubChemViewerMainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(ViewModelBase viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
