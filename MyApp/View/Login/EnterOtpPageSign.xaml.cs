
using MyApp.Service;
using MyApp.View.Home;
using MyApp.ViewModel;

namespace MyApp.View.Login
{
    public partial class EnterOtpPageSign : ContentPage
    {
        private readonly AccountInfoViewmodel _viewModel;

        public EnterOtpPageSign()
        {
            InitializeComponent();
            _viewModel = new AccountInfoViewmodel(new AccountInfoService(new HttpClient())); // Provide necessary dependencies here
            BindingContext = _viewModel;
            Digit1Entry.Focus();
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

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                // Concatenate the entered OTP digits
                string enteredOTP = $"{Digit1Entry.Text}{Digit2Entry.Text}{Digit3Entry.Text}{Digit4Entry.Text}";

                // Get the OTP from the database; replace with your actual logic
                string dbOTP = GetOtpFromDatabase(); // Adjust this method call based on your actual implementation

                // Compare the entered OTP with the OTP from the database
                if (enteredOTP == dbOTP)
                {
                    // OTP is correct, navigate to the desired page
                    // OTP is correct, navigate to the desired page

             //   await Navigation.PushAsync(new BasicDetailView());
                   await Shell.Current.GoToAsync(nameof(BasicDetailView));

                }
                else
                {
                    Digit1Entry.Text = string.Empty;
                    Digit2Entry.Text = string.Empty;
                    Digit3Entry.Text = string.Empty;
                    Digit4Entry.Text = string.Empty;
                    // OTP is incorrect, display an error message
                    await DisplayAlert("Error", "Invalid OTP. Please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private string GetOtpFromDatabase()
        {
            // Replace this with your actual logic to retrieve OTP from the DuePayments collection
            // I assumed DuePayments is a collection of objects and you need to extract the OTP
            return _viewModel.DuePayments.FirstOrDefault()?.OTP; // Adjust this based on your actual model
        }

        private void OnDigitEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            Entry currentEntry = (Entry)sender;

            if (!string.IsNullOrEmpty(e.NewTextValue) && e.NewTextValue.Length == 1)
            {
                // Move focus to the next Entry when a digit is entered
                switch (currentEntry)
                {
                    case Entry _ when currentEntry == Digit1Entry:
                        Digit2Entry.Focus();
                        break;
                    case Entry _ when currentEntry == Digit2Entry:
                        Digit3Entry.Focus();
                        break;
                    case Entry _ when currentEntry == Digit3Entry:
                        Digit4Entry.Focus();
                        break;
                    case Entry _ when currentEntry == Digit4Entry:
                        // Focus is already on the last Entry; you can perform additional actions here
                        break;
                }
            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await DisplayAlert("Resend", "OTP Sent Successfully. Please try Now.", "OK");
        }

        [Obsolete]
        private void Button_Clicked(object sender, EventArgs e)
        {
            // Navigate to the ProcessPage
            Shell.Current.GoToAsync(nameof(ProcessPage));
        }
    }
}
