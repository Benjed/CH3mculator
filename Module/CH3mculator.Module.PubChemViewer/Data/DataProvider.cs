using CH3mculator.Shared.Model.Entity;
using GalaSoft.MvvmLight;

namespace CH3mculator.Module.PubChemViewer.Data
{
    public class DataProvider : ObservableObject
    {
        public const string PLEASE_SEARCH_COMPOUND_PHRASE = "Please enter a searchterm to find a compound!";

        private string _compoundSearchTerm;
        public string CompoundSearchTerm
        {
            get { return _compoundSearchTerm; }
            set
            {
                _compoundSearchTerm = value;
                RaisePropertyChanged();
            }
        }

        private Compound _examinedCompound;
        public Compound ExaminedCompound
        {
            get { return _examinedCompound; }
            set
            {
                _examinedCompound = value;
                RaisePropertyChanged();
            }
        }

        private bool _isCompoundSelected;
        public bool IsCompoundSelected
        {
            get => _isCompoundSelected;
            set
            {
                _isCompoundSelected = value;
                RaisePropertyChanged();
            }
        }

        private string _displayedMessage;
        public string DisplayMessage
        {
            get { return _displayedMessage; }
            set 
            { 
                _displayedMessage = value;
                RaisePropertyChanged();
            }
        }

        public DataProvider()
        {
            IsCompoundSelected = false;
            DisplayMessage = PLEASE_SEARCH_COMPOUND_PHRASE;
        }
    }
}