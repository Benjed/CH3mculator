using System.Windows.Controls;
using CH3mculator.Shared.Model.Module;

namespace CH3mculator.Module.PubChemViewer
{
    public class PubChemViewer : IModule
    {
        private MainViewModel _viewModel;

        public string ModuleName { get; set; } = "PubChemViewer";

        public PubChemViewer()
        {
            _viewModel = new MainViewModel();
        }

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