using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace CH3mculator.Module.Calculator
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class CalculatorView : UserControl
    {
        public CalculatorView(ViewModelBase viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
