using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace CH3mculator.Shared.Model.Entity
{
    public class Compound : ObservableObject
    {
        public Compound()
        {
            CalculatePropertiesWherePossibleCommand = new RelayCommand(CalculatePropertiesWherePossible);
        }

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

        private double _amount;
        public double Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                RaisePropertyChanged();
            }
        }

        private double _mass;
        public double Mass
        {
            get => _mass;
            set
            {
                _mass = value;
                RaisePropertyChanged();
            }
        }

        private double _volume;
        public double Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CalculatePropertiesWherePossibleCommand { get; set; }

        public void CalculatePropertiesWherePossible()
        {
            if (Amount != default)
            {
                CalculateMass();
                CalculateVolume();
            }
            else if (Mass != default)
            {
                CalculateVolume();
                CalculateAmount();
            }
            else if (Volume != default)
            {
                Mass = Volume * Density;
                CalculateAmount();
            }
        }

        private void CalculateAmount()
        {
            Amount = Mass / MolecularWeight;
        }

        private void CalculateMass()
        {
            Mass = Amount * MolecularWeight;
        }

        private void CalculateVolume()
        {
            Volume = Mass / Density;
        }
    }
}