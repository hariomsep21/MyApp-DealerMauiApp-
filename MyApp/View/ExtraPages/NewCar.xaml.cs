using CommunityToolkit.Maui.Views;
using MyApp.View.PurchaseVehicle;

namespace MyApp;

public partial class NewCar : ContentPage
{
	public NewCar()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);
    
    }


}