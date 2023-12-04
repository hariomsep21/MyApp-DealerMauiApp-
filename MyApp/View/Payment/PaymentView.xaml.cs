using MyApp.View.Account;
using MyApp.ViewModel;

namespace MyApp;

public partial class PaymentView : ContentPage
{
    public PaymentView(CarViewModel carView)
    {
        InitializeComponent();
        BindingContext = carView;
      
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }
}