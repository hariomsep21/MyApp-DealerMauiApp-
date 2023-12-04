using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;

namespace MyApp.ViewModel
{
    internal class SignUpViewModel : ObservableObject
    {
        private readonly ISignUpService _signUpService;

        private ObservableCollection<SignUpDTO> _dueCustomer;

        public ObservableCollection<SignUpDTO> DueCustomer
        {
            get => _dueCustomer;
            set
            {
                _dueCustomer = value;
                OnPropertyChanged(nameof(DueCustomer));
            }
        }

        public SignUpViewModel(ISignUpService signUpService)
        {
            _signUpService = signUpService ?? throw new ArgumentNullException(nameof(signUpService));
        }

        // Load data from the API
        public async Task LoadLoginDetailsAsync()
        {
            try
            {
                var loginDetails = await _signUpService.GetMobileNumberAsync();

                switch (loginDetails)
                {
                    case IEnumerable<SignUpDTO> enumerableLoginDetails:
                        // Check if conversion is necessary, otherwise use the original collection
                        DueCustomer = new ObservableCollection<SignUpDTO>(enumerableLoginDetails);
                        // Log successful loading
                        Debug.WriteLine("Login details loaded successfully.");
                        break;


                    default:
                        // Handle unexpected type
                        Debug.WriteLine($"Unexpected type: {loginDetails?.GetType().FullName}");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework or Debug.WriteLine
                Debug.WriteLine($"Error loading login details: {ex.Message}");
                // Rethrow the exception for consistency
                throw;
            }
        }

        // Post mobile number to the API
        public async Task<bool> PostMobileNumberAsync(string mobileNumber)
        {
            try
            {
                return await _signUpService.PostMobileNumberAsync(mobileNumber);
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework or Debug.WriteLine
                Debug.WriteLine($"Error posting mobile number: {ex.Message}");
                // Rethrow the exception for consistency
                throw;
            }
        }
    }
}
