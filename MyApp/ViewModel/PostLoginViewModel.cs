// Viewmodel

using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.IService;
using MyApp.Service;

namespace MyApp.ViewModel
{
    public class PostLoginViewModel : ObservableObject
    {
        private readonly IPostLogInService _postLoginService;

        public PostLoginViewModel(IPostLogInService postLoginService)
        {
            _postLoginService = postLoginService ?? throw new ArgumentNullException(nameof(postLoginService));
        }

        public async Task<bool> PostLoginAsync(string mobileNumber)
        {
            try
            {
                // Call the service to check if the phone number is valid and get the token
                bool result = await _postLoginService.PostLoginNumberAsync(mobileNumber);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
