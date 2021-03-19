using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace CH3mculator.Shell.ErrorHandling
{
    /// <summary>
    /// Interaktionslogik für ErrorView.xaml
    /// </summary>
    public partial class ErrorView : UserControl
    {
        public ErrorView(ViewModelBase errorViewModel)
        {
            InitializeComponent();
            DataContext = errorViewModel;
        }
    }
}
