using System.Windows.Controls;
using CH3mculator.Shared.Model.Module;

namespace CH3mculator.Module.PubChemViewer
{
    public class PubChemViewer : IModule
    {
        public string ModuleName { get; set; } = "PubChemViewer";

        public UserControl GetEntryView()
        {
            return new PubChemViewerMainView();
        }
    }
}
