using CH3mculator.Shared.Model.Module;
using System.Windows.Controls;

namespace CH3mculator.Module.Calculator
{
    public class Calculator : IModule
    {
        private CalculatorViewModel _viewModel;

        public Calculator(CalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string ModuleName { get; set; } = "CH3mculator";

        public UserControl GetEntryView()
        {
            return new CalculatorView(_viewModel);
        }

        public UserControl GetRibbonView()
        {
            return new RibbonView(_viewModel);
        }
    }
}
