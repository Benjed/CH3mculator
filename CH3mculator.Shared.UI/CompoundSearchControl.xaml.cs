using CH3mculator.Shared.Logic.Logging;
using CH3mculator.Shared.Logic.Web;
using CH3mculator.Shared.Model.Entity;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CH3mculator.Shared.UI
{
    /// <summary>
    /// Interaction logic for CompoundSearchControl.xaml
    /// </summary>
    public partial class CompoundSearchControl : UserControl
    {
        private CompoundRepository _compoundRepository = new CompoundRepository();

        public CompoundSearchControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ResultCompoundProperty = DependencyProperty.Register(
            nameof(ResultCompound),
            typeof(Compound),
            typeof(CompoundSearchControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Compound ResultCompound
        {
            get { return (Compound)GetValue(ResultCompoundProperty); }
            set { SetValue(ResultCompoundProperty, value); }
        }

        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
            nameof(IsLoading),
            typeof(bool),
            typeof(CompoundSearchControl),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        private async void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IsLoading = true;
                try
                {
                    ResultCompound = await _compoundRepository.GetCompoundAsync(SearchBox.Text);
                    SearchBox.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    Logger.Log.Exception(ex);
                    ResultCompound = null;
                }
                IsLoading = false;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SearchBox.Focus();
        }
    }
}
