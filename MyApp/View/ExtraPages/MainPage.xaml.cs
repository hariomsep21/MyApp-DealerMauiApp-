using MyApp.ViewModel;

namespace MyApp
{
    public partial class MainPage : ContentPage
    {


        public MainPage(CarViewModel carView)
        {
            InitializeComponent();
            BindingContext = carView;

        }

    
    }
}