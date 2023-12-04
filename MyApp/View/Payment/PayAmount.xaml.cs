using MyApp.View.Account;
using MyApp.View.Home;
using MyApp.ViewModel;

namespace MyApp;

public partial class PayAmount : ContentPage
{
	public PayAmount()
	{
		InitializeComponent();
        BindingContext = new DocViewModel();

    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//HomePage");
    }
}