using MyApp.View.Account;
using MyApp.ViewModel;

namespace MyApp.View.Home;

[XamlCompilation(XamlCompilationOptions.Skip)]
public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomeViewModel();

	}
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }
}