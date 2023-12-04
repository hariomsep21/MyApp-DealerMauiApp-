namespace MyApp;

public partial class PV_Vehicle : ContentPage
{
	public PV_Vehicle()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
     
        Shell.Current.GoToAsync(nameof(VehicleRecordsView));

    }
}