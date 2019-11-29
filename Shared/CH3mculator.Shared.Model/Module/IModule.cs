using System.Windows.Controls;

namespace CH3mculator.Shared.Model.Module
{
    public interface IModule
    {
        string ModuleName { get; set; }
        UserControl GetEntryView();
    }
}
