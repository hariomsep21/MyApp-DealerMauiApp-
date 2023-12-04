using CommunityToolkit.Maui.Views;
using MyApp.View.PurchaseVehicle;

namespace MyApp;

public partial class OpenMarket : ContentPage
{
	public OpenMarket()
	{
		InitializeComponent();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);

    }
}