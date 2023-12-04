using MyApp.ViewModel;

namespace MyApp;

public partial class AuditStatusView : ContentPage
{
	public AuditStatusView(CarViewModel StatusAudit)
	{
		InitializeComponent();
		BindingContext = StatusAudit;
	}

  
}