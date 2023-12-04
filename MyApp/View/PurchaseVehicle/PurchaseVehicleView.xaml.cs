using CommunityToolkit.Maui.Views;
using MyApp.Models;
using MyApp.Service;
using MyApp.View.Account;
using MyApp.View.Login;
using MyApp.ViewModel;

namespace MyApp.View.PurchaseVehicle;

[XamlCompilation(XamlCompilationOptions.Skip)]


public partial class PurchaseVehicleView : ContentPage
{

    private readonly PV_NewCarDealerViewModel _viewModel;
    private readonly PV_OpenMarketViewModel _openviewModel;
    private readonly Agg_DropDownYORegisViewModel _DropDownYORegisViewModel;
    private readonly Agg_DropDownMakeViewModel _DropDownMakeViewModel;
    private readonly Agg_DropDownModelViewModel _DropDownModel;
    private readonly Agg_DropDownVariantViewmodel _DropDownVariantViewmodel;

    public PurchaseVehicleView()
    {
        InitializeComponent();

        // Initialize _viewModel
        _viewModel = new PV_NewCarDealerViewModel(new PV_NewCarDealerService(new HttpClient())); // Provide necessary dependencies here
        BindingContext = _viewModel;

        // Initialize _openviewModel with the correct service
        _openviewModel = new PV_OpenMarketViewModel(new PV_OpenMarketService(new HttpClient())); // Provide necessary dependencies here
        BindingContext = _openviewModel;

        _DropDownYORegisViewModel = new Agg_DropDownYORegisViewModel(new Agg_DropDownYORegisService(new HttpClient()));
        BindingContext = _DropDownYORegisViewModel;

        _DropDownMakeViewModel = new Agg_DropDownMakeViewModel(new Agg_DropDownMakeService(new HttpClient()));
        BindingContext = _DropDownMakeViewModel;

        _DropDownModel = new Agg_DropDownModelViewModel(new Agg_DropDownModelService(new HttpClient()));
        BindingContext = _DropDownModel;

        _DropDownVariantViewmodel = new Agg_DropDownVariantViewmodel(new Agg_DropDownVariantService(new HttpClient()));
        BindingContext = _DropDownVariantViewmodel;



        BindingContext = new VehicleRecordsViewModel();
        SectionB.IsVisible = false;
        Section2.IsVisible = false;
        Section3.IsVisible = false;
        Section11.IsVisible = true;
        Section22.IsVisible = false;


        // Attach event handlers to the buttons
        SignButton1.Clicked += OnSignButtonClicked;
        DownloadButton.Clicked += OnDownloadButtonClicked;
        SignButton.Clicked += Sign_Clicked;
        MarketButton.Clicked += Market_Button_Clicked;
        New_CarButton.Clicked += New_Car_Clicked;
        Vehicle1.Clicked += Vehicle1_Clicked;
        Vehicle2.Clicked += Vehicle2_Clicked;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async Task LoadData()
    {
        await _DropDownYORegisViewModel.LoadYearOfRegDetails();
        await _DropDownMakeViewModel.LoadMakeDetails();
        await _DropDownModel.LoadModelDetails();
        await _DropDownVariantViewmodel.LoadVariantDetails();
    }
    private async Task NewCarDealerButton(object sender, EventArgs e)
    {

    }



    private ImageSource _capturedImageSource;

    public ImageSource CapturedImageSource
    {
        get { return _capturedImageSource; }
        set
        {
            _capturedImageSource = value;
            // Optionally, you can update UI elements here to reflect the new image source.
            // For example, if you have an Image control in your XAML named "capturedImage":
            // capturedImage.Source = value;
        }
    }

    private void Sign_Clicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        Section1.IsVisible = true;
        Section2.IsVisible = false;
        Section3.IsVisible = false;
    }


    private void Market_Button_Clicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        Section2.IsVisible = true;
        Section1.IsVisible = false;
        Section3.IsVisible = false;
    }

    private void New_Car_Clicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        Section3.IsVisible = true;
        Section1.IsVisible = false;
        Section2.IsVisible = false;
    }

    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        SectionC.IsVisible = true;
        SectionB.IsVisible = false;
    }

    private void OnDownloadButtonClicked(object sender, EventArgs e)
    {
        // Show section B and hide section A
        SectionC.IsVisible = false;
        SectionB.IsVisible = true;
    }

    private void Vehicle1_Clicked(object sender, EventArgs e)
    {
        // Show section B and hide section A
        Section11.IsVisible = false;
        Section22.IsVisible = true;
    }
    private void Vehicle2_Clicked(object sender, EventArgs e)
    {
        // Show section B and hide section A
        Section11.IsVisible = false;
        Section22.IsVisible = true;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Get the entered values
            string PurchaseAmount = PurchaseAmountEntry.Text;  // Update variable name and entry name
            string TokenAmount = TokenAmountEntry.Text;  // Update variable name and entry name
            string WithholdAmount = WithholdAmountEntry.Text;  // Update variable name and entry name
            string SellerContactNumber = SellerContactNumberEntry.Text;  // Update variable name and entry name
            string SellerEmailAddress = SellerEmailAddressEntry.Text;  // Update variable name and entry name
            string VehicleNumber = VehicleNumberEntry.Text;  // Update variable name and entry name
            string PaymentProof = paymentproof.Text;  // Update variable name and entry name
            string SellerAdhaar = sellerAdhar.Text;  // Update variable name and entry name
            string SellerPAN = sellerPan.Text;  // Update variable name and entry name
            string PictureOfOriginalRC = picoforgRc.Text;  // Update variable name and entry name
            string OdometerPicture = odoPic.Text;  // Update variable name and entry name
            string VehiclePictureFromFront = vehiclepicFront.Text;  // Update variable name and entry name
            string VehiclePictureFromBack = vehiclepicBack.Text;  // Update variable name and entry name

            // Check if all entered values are not null
            if (!string.IsNullOrEmpty(PurchaseAmount) &&
                !string.IsNullOrEmpty(VehicleNumber))
            {
                // If the entered values are not in the list, create a new DTO and pass it as a parameter to the API
                var newCarDetails = new PV_OpenMarketDTO
                {
                    PurchaseAmount = PurchaseAmount,
                    TokenAmount = TokenAmount,
                    WithholdAmount = WithholdAmount,
                    SellerContactNumber = SellerContactNumber,
                    SellerEmailAddress = SellerEmailAddress,
                    VehicleNumber = VehicleNumber,
                    PaymentProof = PaymentProof,
                    SellerAdhaar = SellerAdhaar,
                    SellerPAN = SellerPAN,
                    PictureOfOriginalRC = PictureOfOriginalRC,
                    OdometerPicture = OdometerPicture,
                    VehiclePictureFromFront = VehiclePictureFromFront,
                    VehiclePictureFromBack = VehiclePictureFromBack
                };

                // Check if the new DTO is not already in the list
                if (!_openviewModel.DueOpenMarket.Any(item =>
                    item.PurchaseAmount == PurchaseAmount &&
                    item.VehicleNumber == VehicleNumber &&
                    item.OdometerPicture == OdometerPicture &&
                    item.VehiclePictureFromFront == VehiclePictureFromFront &&
                    item.VehiclePictureFromBack == VehiclePictureFromBack &&
                    item.PaymentProof == PaymentProof &&
                    item.PictureOfOriginalRC == PictureOfOriginalRC))
                {
                    bool apiSuccess = await _openviewModel.OpenmarketMethod(newCarDetails);

                    if (apiSuccess)
                    {
                        // After sending OTP and successful API response, navigate to the EnterOtpPage
                        PurchaseAmountEntry.Text = string.Empty;
                        TokenAmountEntry.Text = string.Empty;
                        WithholdAmountEntry.Text = string.Empty;
                        SellerContactNumberEntry.Text = string.Empty;
                        SellerEmailAddressEntry.Text = string.Empty;
                        VehicleNumberEntry.Text = string.Empty;
                        paymentproof.Text = string.Empty;
                        sellerAdhar.Text = string.Empty;
                        sellerPan.Text = string.Empty;
                        picoforgRc.Text = string.Empty;
                        odoPic.Text = string.Empty;
                        vehiclepicFront.Text = string.Empty;
                        vehiclepicBack.Text = string.Empty;

                    }
                    else
                    {
                        // Handle the case where the API response is not successful
                        await DisplayAlert("API Error", "Failed to post mobile number.", "OK");
                    }
                }
                else
                {
                    // Handle the case where the entered values are already in the list
                    await DisplayAlert("Invalid Number", "Number Already Used So Login Failed.", "OK");
                }
            }
            else
            {
                // Handle the case where any entered value is null or empty
                await DisplayAlert("Invalid Input", "Please fill in all the fields.", "OK");
            }
        }
        catch (HttpRequestException ex)
        {
            await DisplayAlert("HTTP Request Error", $"HTTP request error: {ex.Message}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }






        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);

    }

    private void Button_Clicked1(object sender, EventArgs e)
    {
        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);

    }
    private void Button_Clicked2(object sender, EventArgs e)
    {
        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);

    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }


    private async void OpenbootomPrice(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            priceimg.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void Openbootomstock(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            stockinimg.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomRc(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            rcimg.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomPaymentProof(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            paymentproof.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomSellerAdhar(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            sellerAdhar.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomSellerPan(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            sellerPan.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomPicOfOrigiRC(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            picoforgRc.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomOdometerPic(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            odoPic.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomVehiclePicFront(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            vehiclepicFront.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomVehiclePicBack(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            vehiclepicBack.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomNCDOdoPic(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            NCDOdoPic.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomNCDVehicleFrontPic(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            NCDFrontPic.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomNCDVehicleBackPic(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            NCDBackPic.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomNCDInvoicePic(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            NCDInvoice.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private async void OpenbootomNCDPicRcPic(object sender, EventArgs e)
    {
        try
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);

            // Show the bottom sheet
            await paymentProovView.ShowAsync();

            // Wait for a delay (if needed)
            await Task.Delay(5000);

            // Dismiss the bottom sheet
            await paymentProovView.DismissAsync();

            await Task.Delay(10000);
            // Access the selected image file name
            string imageName = paymentProovView.SelectedImageFileName;

            // Set the Text property of priceimg to the selected image file name
            NCDRcPic.Text = imageName;
        }
        catch (Exception ex)
        {
            // Handle exceptions if any
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            // Get the entered values
            string PurchaseAmt = PurchaseAmount.Text;
            string VehicleAmt = VehicleNumber.Text;
            string OdoPic = NCDOdoPic.Text;
            string VehiclePFFront = NCDFrontPic.Text;
            string VehiclePFBack = NCDBackPic.Text;
            string Invoicepic = NCDInvoice.Text;
            string picOfOrgi = NCDRcPic.Text;

            // Check if all entered values are not null
            if (!string.IsNullOrEmpty(PurchaseAmt) &&
                !string.IsNullOrEmpty(VehicleAmt))
            {
                // If the entered values are not in the list, create a new DTO and pass it as a parameter to the API
                var newCarDetails = new PV_NewCarDealerDTO
                {

                    PurchaseAmount = PurchaseAmt,
                    VehicleNumber = VehicleAmt,
                    OdometerPicture = OdoPic,
                    VehiclePicFromFront = VehiclePFFront,
                    VehiclePicFromBack = VehiclePFBack,
                    Invoice = Invoicepic,
                    PictOfOrginalRC = picOfOrgi
                };

                // Check if the new DTO is not already in the list
                if (!_viewModel.DueCustomer.Any(item =>
                    item.PurchaseAmount == PurchaseAmt &&
                    item.VehicleNumber == VehicleAmt &&
                    item.OdometerPicture == OdoPic &&
                    item.VehiclePicFromFront == VehiclePFFront &&
                    item.VehiclePicFromBack == VehiclePFBack &&
                    item.Invoice == Invoicepic &&
                    item.PictOfOrginalRC == picOfOrgi))
                {
                    bool apiSuccess = await _viewModel.PostMobileNumberAsync(newCarDetails);

                    if (apiSuccess)
                    {
                        // After sending OTP and successful API response, navigate to the EnterOtpPage
                        PurchaseAmount.Text = string.Empty;
                        VehicleNumber.Text = string.Empty;
                        NCDOdoPic.Text = string.Empty;
                        NCDFrontPic.Text = string.Empty;
                        NCDBackPic.Text = string.Empty;
                        NCDInvoice.Text = string.Empty;
                        NCDRcPic.Text = string.Empty;
                    }
                    else
                    {
                        // Handle the case where the API response is not successful
                        await DisplayAlert("API Error", "Failed to post mobile number.", "OK");
                    }
                }
                else
                {
                    // Handle the case where the entered values are already in the list
                    await DisplayAlert("Invalid Number", "Number Already Used So Login Failed.", "OK");
                }
            }
            else
            {
                // Handle the case where any entered value is null or empty
                await DisplayAlert("Invalid Input", "Please fill in all the fields.", "OK");
            }
        }
        catch (HttpRequestException ex)
        {
            await DisplayAlert("HTTP Request Error", $"HTTP request error: {ex.Message}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }


}