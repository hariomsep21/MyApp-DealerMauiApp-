
using Microsoft.Maui.Controls;
using MyApp.ViewModel;

namespace MyApp
{
    public partial class VehicleRecordsView : ContentPage
    {
        private VehicleRecordsViewModel viewModel;

        public VehicleRecordsView()
        {
            InitializeComponent();
            viewModel = new VehicleRecordsViewModel();
            BindingContext = viewModel;
        }
    }
}
