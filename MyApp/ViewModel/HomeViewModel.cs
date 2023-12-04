using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    public partial class HomeViewModel:ObservableObject
    {


        [RelayCommand]
        public async Task PaymentPage()
        {
            await Shell.Current.GoToAsync(nameof(PaymentView));
        }


        [RelayCommand]

        public async Task StockAudit()
        {
            await Shell.Current.GoToAsync(nameof(StockAuditView));
        }

        [RelayCommand]

        public async Task ProcurementDetail()
        {
            await Shell.Current.GoToAsync(nameof(ProcurementDetailView));
        }
    }
}
