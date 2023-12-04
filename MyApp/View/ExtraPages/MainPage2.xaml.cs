using MyApp.ViewModel;

namespace MyApp;

public partial class MainPage2 : ContentPage
{
    public MainPage2()
    {
    }

    public MainPage2(CarViewModel payment)
	{
		InitializeComponent();
		BindingContext = payment;

    }
}