using CH3mculator.Shared.Model.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CH3mculator.Module.Calculator
{
    public class Calculator : IModule
    {
        private MainViewModel _viewModel = new MainViewModel();

        public string ModuleName { get; set; } = "CH3mculator";

        public UserControl GetEntryView()
        {
            return new MainView(_viewModel);
        }

        public UserControl GetRibbonView()
        {
            return new RibbonView(_viewModel);
        }
    }
}
