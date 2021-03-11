using CH3mculator.Module.Calculator;
using CH3mculator.Module.PubChemViewer;
using CH3mculator.Module.Settings;
using CH3mculator.Shared.Model.Module;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Input;

namespace CH3mculator.Shell
{
    /// <summary>
    /// Controls basic navigation between program modules
    /// </summary>
    /// <remarks>
    /// Shows the mainview of the PubChemViewer module on default, option for reset
    /// Shows the name of the active module
    /// Closes Navigationdrawer on navigation
    /// </remarks>
    public class ShellViewModel : ViewModelBase
    {
        private bool _isNavigationDrawerOpened;
        public bool IsNavigationDrawerOpened
        {
            get => _isNavigationDrawerOpened;
            set 
            { 
                _isNavigationDrawerOpened = value;
                RaisePropertyChanged();
            }
        }

        private UserControl _shownView;
        public UserControl ShownView
        {
            get => _shownView;
            set 
            { 
                _shownView = value;
                RaisePropertyChanged();
            }
        }

        private string _moduleName;
        public string ModuleName
        {
            get => _moduleName;
            set 
            { 
                _moduleName = value;
                RaisePropertyChanged();
            }
        }

        private UserControl _ribboncontent;
        public UserControl Ribboncontent
        {
            get => _ribboncontent; 
            set 
            { 
                _ribboncontent = value;
                RaisePropertyChanged();
            }
        }

        private Calculator _calculatorInstance;

        public ICommand ShowPubChemViewerCommand { get; set; }
        public ICommand ShowCalculatorCommand { get; set; }
        public ICommand ShowSettingsCommand { get; set; }
        public ICommand ShowInfoCommand { get; set; }

        public ShellViewModel()
        {
            ShowCalculatorCommand = new RelayCommand(() => 
            {
                if (_calculatorInstance == null)
                    _calculatorInstance = new Calculator();
                ShowModule(_calculatorInstance);
            });
            ShowPubChemViewerCommand = new RelayCommand(() => ShowModule(new PubChemViewer()));
            ShowInfoCommand = new RelayCommand(() => ShowModule(new Info()));
            ShowSettingsCommand = new RelayCommand(() => ShowModule(new Settings()));
            ShowCalculatorCommand.Execute(null);
        }

        private void ShowModule(IModule module)
        {
            ShownView = module.GetEntryView();
            Ribboncontent = module.GetRibbonView();
            ModuleName = module.ModuleName;
            IsNavigationDrawerOpened = false;
        }
    }
}