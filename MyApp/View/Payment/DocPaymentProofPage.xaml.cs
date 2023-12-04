

using MyApp.View.Account;
using MyApp.ViewModel;

namespace MyApp;

public partial class DocPaymentProofPage : ContentPage
{
    public DocPaymentProofPage()
    {
        InitializeComponent();
        BindingContext = new DocViewModel();

    }

    // Define a property to set the image source
    public ImageSource CapturedImageSource
    {
        get { return capturedImage.Source; }
        set
        {
            capturedImage.Source = value;


        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }

    private async void capturedImage_Clicked(object sender, EventArgs e)
    {
      
        // Open the bottom sheet (PaymentProovView)
        var paymentProovView = new PaymentProovView(this);
        await paymentProovView.ShowAsync();

        await Task.Delay(5000);
        plusicon.IsVisible = false;
        await paymentProovView.DismissAsync();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PayAmount));
    }

   
}
