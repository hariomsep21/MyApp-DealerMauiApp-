using CommunityToolkit.Maui.Views;
using MyApp.Service;
using MyApp.View.Login;
using MyApp.ViewModel;

namespace MyApp.View.Account;

public partial class LogoutPage : Popup
{
    private readonly PostLoginViewModel postLogin;
    public LogoutPage()
    {
        InitializeComponent();
        postLogin = new PostLoginViewModel(new PostLogInService(new HttpClient()));
    }
    private async void Button_ClickedYes(object sender, EventArgs e)
    {
        try
        {
            if (postLogin != null)
            {
                // Execute the LogoutCommand in the ViewModel
                if (postLogin.LogoutCommand.CanExecute(null))
                {
                    postLogin.LogoutCommand.Execute(null);
                }

                // Additional logic if needed
                //await Shell.Current.Navigation.PopToRootAsync(); // Clears the navigation stack
                //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                //popupmessage.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions more gracefully (e.g., display an error message)
            await Shell.Current.DisplayAlert("Error", $"Logout failed: {ex.Message}", "OK");
        }
    }



    private void Button_Clicked_No(object sender, EventArgs e)
    {
        // Shell.Current.GoToAsync(nameof(ProfileInfo));

        popupmessage.IsVisible = false;
    }
}