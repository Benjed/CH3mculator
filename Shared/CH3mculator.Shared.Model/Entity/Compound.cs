using GalaSoft.MvvmLight;

namespace CH3mculator.Shared.Model.Entity
{
    public class Compound : ObservableObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private string _pubChemCid;
        public string PubChemCid
        {
            get => _pubChemCid;
            set
            {
                _pubChemCid = value;
                RaisePropertyChanged();
            }
        }

        private double _molecularWeight;
        public double MolecularWeight 
        { 
            get => _molecularWeight; 
            set 
            { 
                _molecularWeight = value; 
                RaisePropertyChanged(); 
            } 
        }

        private double _density;
        public double Density 
        { 
            get => _density; 
            set 
            { 
                _density = value; 
                RaisePropertyChanged(); 
            } 
        }
    }
}