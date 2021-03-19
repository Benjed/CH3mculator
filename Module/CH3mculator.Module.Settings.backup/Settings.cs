using CH3mculator.Shared.Model.Module;
using System;
using System.Windows.Controls;

namespace CH3mculator.Module.Settings
{
    public class Settings : IModule
    {
        public string ModuleName { get; set; } = "Settings";

        public UserControl GetEntryView()
        {
            return new SettingsView(new SettingsViewModel());
        }

        public UserControl GetRibbonView()
        {
            return null;
        }
    }
}
