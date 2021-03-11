using CH3mculator.Shared.Model.Entity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CH3mculator.Module.Calculator
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Compounds = new ObservableCollection<Compound>();
            MessageQueue = new SnackbarMessageQueue();
            MessageQueue.IgnoreDuplicate = true;
            RemoveCompoundCommand = new RelayCommand<Compound>(RemoveCompound);
        }

        private ObservableCollection<Compound> _compounds;
        public ObservableCollection<Compound> Compounds
        {
            get => _compounds;
            set
            {
                _compounds = value;
                RaisePropertyChanged();
            }
        }

        private SnackbarMessageQueue _messageQueue;
        public SnackbarMessageQueue MessageQueue
        {
            get { return _messageQueue; }
            set { _messageQueue = value; }
        }


        public Compound NewCompound
        {
            get => null;
            set
            {
                if (value != null && !Compounds.Contains(value))
                {
                    Compounds.Add(value);
                }
                else 
                {
                    MessageQueue.Enqueue("Could not retrieve compound ...did you spell it right?");
                }
            }
        }

        public ICommand RemoveCompoundCommand { get; set; }

        private void RemoveCompound(Compound compound)
        {
            if (Compounds != null && Compounds.Contains(compound))
                Compounds.Remove(compound);
        }
    }
}
