using CH3mculator.Module.PubChemViewer.Data;
using CH3mculator.Shared.Logic.Logging;
using CH3mculator.Shared.Logic.Web;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace CH3mculator.Module.PubChemViewer
{
    /// <summary>
    /// Logic for interaction with PubChemViewer module
    /// </summary>
    /// <remarks>
    /// Shows name, density and molecular weight for a compound
    /// The Compound is selected using the searchbar in the ribbon
    /// If no compound is selected, it displays a text instead
    /// </remarks>
    public class MainViewModel : ViewModelBase
    {
        private DataProvider _dataProvider;
        public DataProvider DataProvider
        {
            get => _dataProvider; 
            set 
            {
                _dataProvider = value;
                RaisePropertyChanged();
            }
        }

        public ICommand OpenPubChemLinkCommand { get; set; }

        public MainViewModel()
        {
            DataProvider = new DataProvider();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            OpenPubChemLinkCommand = new RelayCommand(OpenPubChemLink);
        }

        private void OpenPubChemLink()
        {
            Process.Start("https://pubchem.ncbi.nlm.nih.gov/compound/" + DataProvider.ExaminedCompound.PubChemCid);
        }
    }
}