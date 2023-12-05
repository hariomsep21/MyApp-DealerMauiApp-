using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    using CommunityToolkit.Maui.Views;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using MyApp.Model;
    using MyApp.Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public partial class CarViewModel : ObservableObject
    {
        private readonly IStockAuditService _stockAuditService;


        public CarViewModel(IStockAuditService stockAuditService)
        {
            _stockAuditService = stockAuditService;
            
        }
        private ObservableCollection<UpcomingAuditModel> _pendingAudit;
        public ObservableCollection<UpcomingAuditModel> PendingAudit
        {
            get => _pendingAudit;
            set
            {
                _pendingAudit = value;
                OnPropertyChanged(nameof(PendingAudit));
            }
        }

        private ObservableCollection<UpcomingAuditModel> _statusAudit;
        public ObservableCollection<UpcomingAuditModel> StatusAudit
        {
            get => _statusAudit;
            set
            {
               _statusAudit = value;
                OnPropertyChanged(nameof(StatusAudit));
            }
        }
        public async Task LoadPendingAudit()
        {
            try
            {
                var PendingDetail = await _stockAuditService.GetPendingAudit();
                PendingAudit = new ObservableCollection<UpcomingAuditModel>(PendingDetail);
                // Handle the payment status as needed (e.g., update UI, process data)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task LoadStatusAudit()
        {
            try
            {
                var StatusStock = await _stockAuditService.GetAuditStatus();
                StatusAudit = new ObservableCollection<UpcomingAuditModel>(StatusStock);
                // Handle the payment status as needed (e.g., update UI, process data)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set => SetProperty(ref _cars, value);
        }
        private string _auditStatus;
        public string AuditStatus
        {
            get => _auditStatus;
            set => SetProperty(ref _auditStatus, value);
        }


        public ObservableCollection<Car> FewCars { get; }
        public ObservableCollection<Car> FewCarsAudit { get; }
        public ObservableCollection<Car> PendingAuditCars
        {
            get
            {
                return new ObservableCollection<Car>(Cars.Where(car => car.PendingAuditDate.HasValue));
            }
        }
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string variant;
        [ObservableProperty]
        public string pendingAuditDate;

        [ObservableProperty]
        public string amountdue;

        private List<string> status;
        public List<string> Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        [ObservableProperty]
        public int purchaseId;

        [ObservableProperty]
        public PaymentHistoryViewModel paymentHistory;


        [ObservableProperty]

        public int? remainingDays;





        // Constructor to initialize the ObservableCollection
        public CarViewModel()
        {
    //        Cars = new ObservableCollection<Car>
    //{
    //    new Car { Name = "Toyota Camry", Variant = "LE", AmountDue = 25000.00M, PurchaseId = 1001, AuditStatus ="Sold", PendingAuditDate = DateTime.Today.AddDays(1) , PaymentHistory = new PaymentHistoryViewModel { Status = "Success" } },
    //    new Car { Name = "Honda Civic", Variant = "EX", AmountDue = 23000.00M, PurchaseId = 1002 ,AuditStatus ="InProcess", PendingAuditDate = DateTime.Today.AddDays(2) ,PaymentHistory = new PaymentHistoryViewModel { Status = "Pending" } },
    //    new Car { Name = "Ford Mustang", Variant = "GT", AmountDue = 45000.00M, PurchaseId = 1003,AuditStatus ="Failed", PendingAuditDate = DateTime.Today.AddDays(3) ,PaymentHistory = new PaymentHistoryViewModel { Status = "Failed", ErrorMessage="If a deduction has been made, the amount will be refunded to the original source."} },
    //    new Car { Name = "Chevrolet Silverado", Variant = "LT", AmountDue = 35000.00M, PurchaseId = 1004 ,AuditStatus ="Failed", PendingAuditDate = DateTime.Today.AddDays(4) },
    //    new Car { Name = "BMW 3 Series", Variant = "330i", AmountDue = 42000.00M, PurchaseId = 1005 ,AuditStatus ="Sold", PendingAuditDate = DateTime.Today.AddDays(5)  },
    //    new Car { Name = "Mercedes-Benz", Variant = "C300", AmountDue = 40000.00M, PurchaseId = 1006,AuditStatus ="InProcess",PendingAuditDate = DateTime.Today.AddDays(5), PaymentHistory = new PaymentHistoryViewModel { Status = "Failed", ErrorMessage="If a deduction has been made, the amount will be refunded to the original source."} },
    //    new Car { Name = "Audi A4", Variant = "Premium", AmountDue = 38000.00M, PurchaseId = 1007 },
    //    new Car { Name = "Nissan Altima", Variant = "SV", AmountDue = 24000.00M, PurchaseId = 1008 },
    //    new Car { Name = "Toyota Camry", Variant = "LE", AmountDue = 25000.00M, PurchaseId = 1001 },
    //    new Car { Name = "Honda Civic", Variant = "EX", AmountDue = 23000.00M, PurchaseId = 1002 },
    //    new Car { Name = "Ford Mustang", Variant = "GT", AmountDue = 45000.00M, PurchaseId = 1003 },
    //    // Add more cars as needed
    //};

    //        FewCarsAudit = new ObservableCollection<Car>(Cars.Where(car => !string.IsNullOrEmpty(car.AuditStatus)));

    //        FewCars = new ObservableCollection<Car>(Cars.Where(car => car.PaymentHistory != null && !string.IsNullOrEmpty(car.PaymentHistory.Status)));
    //        Status = StatusList();
    //    }

    //    private List<string> StatusList()
    //    {
    //        return new List<string>
    //        {
    //            "Sold",
    //    "Khan Cottage, Hostline Road, Ame...",
    //    "Registered Address 2",
    //    "Registered Address 3",
    //    "Unregistered Address"
    //        };
    //    }

    //    [RelayCommand]

    //    public async void ShowPopup(Car selectedCar)
    //    {
    //        if (selectedCar == null)
    //        {
    //          await  Shell.Current.CurrentPage.DisplayAlert("Error", "Car is null!", "OK");
    //        }
    //        else if (selectedCar.SelectedStatus == null)
    //        {
    //           await Shell.Current.CurrentPage.DisplayAlert("Error", "Status is null!", "OK");
    //        }
    //        else
    //        {
    //            if (selectedCar.SelectedStatus == "Sold")
    //            {
    //                var popup = new RepaymentPopup();
    //                Shell.Current.CurrentPage.ShowPopup(popup);
    //                selectedCar.IsVerified = true;
    //            }
    //            else if(selectedCar.SelectedStatus == "Khan Cottage, Hostline Road, Ame..." || selectedCar.SelectedStatus == "Registered Address 2" || selectedCar.SelectedStatus == "Registered Address 3")
    //            {
    //              await  Shell.Current.GoToAsync(nameof(UpdatePictureView));
    //                // Navigate to another page 
                   
    //            }
    //            else if(selectedCar.SelectedStatus == "Unregistered Address" )
    //            {
    //                var verificationViewModel = new VerificationViewModel(selectedCar); // Pass the selected car
    //var verificationDetails = new UnregisteredView { BindingContext = verificationViewModel };
    //await Shell.Current.Navigation.PushAsync(verificationDetails);
                  
    //            }
    //            selectedCar.SelectedStatus = null;
    //        }
        }
        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }

       


        [RelayCommand]
        public async Task PaymentProf()
        {
            await Shell.Current.GoToAsync(nameof(DocPaymentProofPage));
        }

    }
}
