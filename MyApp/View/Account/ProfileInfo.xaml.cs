using CommunityToolkit.Maui.Views;
using MyApp.Service;
using MyApp.ViewModel;

namespace MyApp.View.Account;

public partial class ProfileInfo : ContentPage
{
    private readonly AccountInfoViewmodel _viewModel;
    public ProfileInfo()
	{
		InitializeComponent();
        _viewModel = new AccountInfoViewmodel(new AccountInfoService(new HttpClient())); // Provide necessary dependencies here
        BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async Task LoadData()
    {
        await _viewModel.LoadPaymentStatus();
    }
    private void ProfileInfos(object sender, EventArgs e)
    {
      
        Navigation.PushAsync(new ProfileInformationPage());
       // Shell.Current.GoToAsync(nameof(ProfileInformationPage));

    }
    private void TermsInfos(object sender, EventArgs e)
    {
      
        Shell.Current.GoToAsync(nameof(Terms));

    }

    private void CustomerInfo(object sender, EventArgs e)
    {
      
        Shell.Current.GoToAsync(nameof(CustomerSupportViewPage));

    }

    private void Logout(object sender, EventArgs e)
    {
        var popupPage = new LogoutPage(); // Assuming "NewPopup" is the name of your popup page
        Shell.Current.CurrentPage.ShowPopup(popupPage);
    }
}