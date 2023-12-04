using MyApp.View.Account;
using MyApp.ViewModel;

namespace MyApp;

public partial class StockAuditView : ContentPage
{
    public StockAuditView(CarViewModel pendingAudit)
    {
        InitializeComponent();
        BindingContext = pendingAudit;
        Application.Current.UserAppTheme = AppTheme.Light;

    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }
}