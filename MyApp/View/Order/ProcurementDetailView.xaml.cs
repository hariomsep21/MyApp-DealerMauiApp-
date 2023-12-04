using MyApp.View.Account;

namespace MyApp;

public partial class ProcurementDetailView : ContentPage
{
	public ProcurementDetailView()
	{
   
        InitializeComponent();

    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }
}