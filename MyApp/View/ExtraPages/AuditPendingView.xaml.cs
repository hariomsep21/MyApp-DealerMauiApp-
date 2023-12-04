using MyApp.ViewModel;

namespace MyApp;

public partial class AuditPendingView : ContentPage
{
	public AuditPendingView(CarViewModel pendingAudit)
	{
		InitializeComponent();
		BindingContext = pendingAudit;

    }
}