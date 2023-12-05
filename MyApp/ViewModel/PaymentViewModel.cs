using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyApp.Model;
using MyApp.Services;
using MyApp.View.Payment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyApp.ViewModel
{
    public partial class PaymentViewModel:ObservableObject
    {
        private readonly IStockAuditService _stockAuditService;
        private readonly IPaymnetService _paymentService;

        public PaymentViewModel(IPaymnetService paymentService, IStockAuditService stockAuditService)
        {
           
            _paymentService = paymentService;
            _stockAuditService = stockAuditService;

        }
        [RelayCommand]
        private async Task Pay(PaymentDetailDto selectedPayment)
        {
            try
            {
                var paymentDetails = await _paymentService.GetPaymentDetails(selectedPayment.Id);

                // Navigate to the details page and pass the paymentDetails
                await Shell.Current.GoToAsync($"{nameof(PayAmount)}?paymentDetails={Uri.EscapeDataString(JsonConvert.SerializeObject(paymentDetails))}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private PaymentDetailDto _selectedPayment;

        public PaymentDetailDto SelectedPayment
        {
            get { return _selectedPayment; }
            set
            {
                _selectedPayment = value;
                OnPropertyChanged(nameof(SelectedPayment));
            }
        }
        private ObservableCollection<PaymentDetailDto> _duePayments;
        private ObservableCollection<PaymentDetailDto> _paystatus;

        public ObservableCollection<PaymentDetailDto> DuePayments
        {
            get => _duePayments;
            set
            {
                _duePayments = value;
                OnPropertyChanged(nameof(DuePayments));
            }
        }
        public ObservableCollection<PaymentDetailDto> Paystatus
        {
            get => _paystatus;
            set
            {
                _paystatus = value;
                OnPropertyChanged(nameof(Paystatus));
            }
        }
        public async Task LoadPaymentStatus()
        {
            try
            {
                var paymentStatus = await _paymentService.GetPaymentStatus();
                Paystatus = new ObservableCollection<PaymentDetailDto>(paymentStatus);
                // Handle the payment status as needed (e.g., update UI, process data)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async  Task LoadDuePayments()
        {
            try
            {
                var paymentDtos = await _paymentService.GetDuePayments();
                DuePayments = new ObservableCollection<PaymentDetailDto>(paymentDtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    

        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }




        //home

        private ObservableCollection<PaymentDetailDto> _upcomingPayment;
        public ObservableCollection<PaymentDetailDto> UpcomingPayment
        {
            get => _upcomingPayment;
            set
            {
                _upcomingPayment = value;
                OnPropertyChanged(nameof(UpcomingPayment));
            }
        }
        private ObservableCollection<UpcomingAuditModel> _upcomingAudit;
        public ObservableCollection<UpcomingAuditModel> UpcomingAudit
        {
            get => _upcomingAudit;
            set
            {
                _upcomingAudit = value;
                OnPropertyChanged(nameof(UpcomingAudit));
            }
        }
        public async Task LoadUpcomingAudit()
        {
            try
            {
                var UpcomingDetail = await _stockAuditService.GetUpcomingAudit();
                UpcomingAudit = new ObservableCollection<UpcomingAuditModel>(UpcomingDetail);
                // Handle the payment status as needed (e.g., update UI, process data)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task LoadUpcomingPayment()
        {
            try
            {
                var payDetail = await _paymentService.GetUpcomingPayment();
                UpcomingPayment = new ObservableCollection<PaymentDetailDto>(payDetail);
                // Handle the payment status as needed (e.g., update UI, process data)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
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
        private async Task Payy(PaymentDetailDto selectedPayment)
        {
            try
            {
                var paymentDetails = await _paymentService.GetPaymentDetails(selectedPayment.Id);

                // Navigate to the details page and pass the paymentDetails
                await Shell.Current.GoToAsync($"{nameof(UpcomingPaymentPage)}?paymentDetails={Uri.EscapeDataString(JsonConvert.SerializeObject(paymentDetails))}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        [RelayCommand]
        public async Task ProcurementDetail()
        {
            await Shell.Current.GoToAsync(nameof(ProcurementDetailView));
        }
    }
}
    
