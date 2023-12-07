using CommunityToolkit.Maui.Views;
using MyApp.View.Login;

namespace MyApp.View.Account;

public partial class LogoutPage : Popup
{
	public LogoutPage()
	{
		InitializeComponent();
	}
    private async void Button_ClickedYes(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopToRootAsync(); // Clears the navigation stack
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        popupmessage.IsVisible = false;
        
    }

    private void Button_Clicked_No(object sender, EventArgs e)
    {
       // Shell.Current.GoToAsync(nameof(ProfileInfo));

        popupmessage.IsVisible = false;
    }
}