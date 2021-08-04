using CH3mculator.Shared.Model.Module;
using System.Windows.Controls;

namespace CH3mculator.Module.Settings
{
    public class Info : IModule
    {
        public string ModuleName { get; set; } = "Info";

        public UserControl GetEntryView()
        {
            return new InfoView(new InfoViewModel());
        }

        public UserControl GetRibbonView()
        {
            return null;
        }
    }
}
