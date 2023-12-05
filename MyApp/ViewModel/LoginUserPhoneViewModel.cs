using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MyApp.IService;

namespace MyApp.ViewModel
{
    internal class LoginUserPhoneViewModel : ObservableObject
    {
        private readonly ILoginUserPhoneServicecs _loginUserPhoneService;

        private ObservableCollection<LoginUserPhoneDTO> _dueCustomer;

        public ObservableCollection<LoginUserPhoneDTO> DueCustomer
        {
            get => _dueCustomer;
            set
            {
                _dueCustomer = value;
                OnPropertyChanged(nameof(DueCustomer));
            }
        }

        public LoginUserPhoneViewModel(ILoginUserPhoneServicecs loginUserPhoneService)
        {
            _loginUserPhoneService = loginUserPhoneService ?? throw new ArgumentNullException(nameof(loginUserPhoneService));
        }

        // Load data from the API
        public async Task LoadLoginDetails()
        {
            try
            {
                var loginDetails = await _loginUserPhoneService.LoginDetails();

                switch (loginDetails)
                {
                    case IEnumerable<LoginUserPhoneDTO> enumerableLoginDetails:
                        DueCustomer = new ObservableCollection<LoginUserPhoneDTO>(enumerableLoginDetails);
                        // Log successful loading
                        Console.WriteLine("Login details loaded successfully.");
                        break;

                    default:
                        // Handle unexpected type
                        Console.WriteLine($"Unexpected type: {loginDetails?.GetType().FullName}");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework
                Console.WriteLine($"Error loading login details: {ex.Message}");
                throw; // Rethrow the exception for consistency
            }
        }
    }
}
