


namespace MyApp
{
    public partial class PV_Apply : ContentPage
    {
        public PV_Apply()
        {
            InitializeComponent();
            //  Shell.SetTabBarIsVisible(this, false);
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

        private async void capturedImage_Clicked(object sender, EventArgs e)
        {
            // Open the bottom sheet (PaymentProovView)
            var paymentProovView = new PaymentProovView(this);
            await paymentProovView.ShowAsync();
            await Task.Delay(10000);
            await paymentProovView.DismissAsync();
        }
    }
}
