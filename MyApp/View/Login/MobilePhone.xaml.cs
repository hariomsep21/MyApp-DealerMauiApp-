

using MyApp.Service;
using MyApp.ViewModel;

namespace MyApp.View.Login
{
    public partial class MobilePhone : ContentPage
    {
        private readonly PostLoginViewModel _viewModel;
        // private string enteredPhoneNumber;

        public MobilePhone()
        {
            InitializeComponent();
            _viewModel = new PostLoginViewModel(new PostLogInService(new HttpClient())); // Provide necessary dependencies here
            BindingContext = _viewModel;
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var enteredMobileNumber = entryMobileNumber.Text;

                // Validate the length of the mobile number
                if (string.IsNullOrEmpty(enteredMobileNumber) || enteredMobileNumber.Length > 10)
                {
                    // Show error message for invalid mobile number
                    await DisplayAlert("Invalid Mobile Number", "Please enter a valid mobile number (10 digits ).", "OK");
                    return; // Exit the method without proceeding with login
                }

                // Call the ViewModel method to perform the login
                bool loginResult = await _viewModel.PostLoginAsync(enteredMobileNumber);

                if (loginResult)
                {
                    // Navigate to the next page on successful login
                    await Shell.Current.GoToAsync(nameof(EnterOtpPage));
                }
                else
                {
                    // Handle login failure
                    await DisplayAlert("Login Failed", "Invalid Phone Number", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


    }
}
