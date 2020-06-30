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
        private CompoundRepository _compoundRepository = new CompoundRepository();

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ExecuteSearchCommand { get; set; }
        public ICommand OpenPubChemLinkCommand { get; set; }

        public MainViewModel()
        {
            IsLoading = false;
            DataProvider = new DataProvider();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ExecuteSearchCommand = new RelayCommand(ExecuteSearch);
            OpenPubChemLinkCommand = new RelayCommand(OpenPubChemLink);
        }

        private async void ExecuteSearch()
        {
            IsLoading = true;
            try
            {
                DataProvider.ExaminedCompound = await _compoundRepository.GetCompoundAsync(_dataProvider.CompoundSearchTerm);
                DataProvider.IsCompoundSelected = true;
            }
            catch (Exception ex)
            {
                DataProvider.IsCompoundSelected = false;
                DataProvider.DisplayMessage = string.Concat("Could not retrieve compound", Environment.NewLine, " ...did you spell it right?");
                Logger.Log.Exception(ex);
            }
            IsLoading = false;
        }

        private void OpenPubChemLink()
        {
            Process.Start("https://pubchem.ncbi.nlm.nih.gov/compound/" + DataProvider.ExaminedCompound.PubChemCid);
        }
    }
}