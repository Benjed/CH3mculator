using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace CH3mculator.Module.PubChemViewer
{
    /// <summary>
    /// Interaction logic for RibbonView.xaml
    /// </summary>
    public partial class RibbonView : UserControl
    {
        public RibbonView(ViewModelBase viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
