
using Microsoft.Maui.Controls;
using MyApp.Service;
using MyApp.IService;
using MyApp.ViewModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.View.Login
{
    // BasicDetailView.xaml.cs
    public partial class BasicDetailView : ContentPage
    {
        private readonly BasicDetailsViewModel _viewModel;

        public BasicDetailView(BasicDetailsViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            BindingContext = _viewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string Username = Entername.Text;
                string mail = EmailId.Text;

                var UserDetailsPost = new BasicDetailsDTO
                {
                    UserName = Username,
                    UserEmail = mail,
                    
                };

                bool apiSuccess = await _viewModel.PostUserDetailsAsync(UserDetailsPost);
                if (apiSuccess)
                {
                    await DisplayAlert("SignUp", "SignUp details Completed", "OK");
                    await Shell.Current.GoToAsync(("//LoginPage"));
                }
                else
                {
                    await DisplayAlert("API Error", "Failed to post mobile number.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("HTTP Request Error", $"HTTP request error: {ex.Message}", "OK");
            }
        }
    }

}
