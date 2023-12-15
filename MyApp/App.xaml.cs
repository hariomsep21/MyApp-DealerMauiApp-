using Syncfusion.Licensing;

namespace MyApp
{
    public partial class App : Application
    {
        public App()
        {
            

            InitializeComponent();


            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
            base.OnStart();

            int initialRoute = GetInitialRoute(); // Get the initial route based on your logic

            // Set the initial route of the Shell based on the value
            switch (initialRoute)
            {
                case 1:
                    Shell.Current.GoToAsync("//HomePage");
                    break;
                case 2:
                    Shell.Current.GoToAsync("//LoginPage");
                    break;

            }
        }
        private int GetInitialRoute()
        {
            // Check if the token exists in the secure storage
            bool tokenExists = CheckTokenExists();

            // Return the route based on the token existence
            return tokenExists ? 1 : 2; // For example, 1 for Home (token exists), 2 for Login (token doesn't exist)
        }

        private bool CheckTokenExists()
        {
            // Check if the token exists in the secure storage
            // Implement your logic to check for the token's presence
            // For example:
            string token = SecureStorage.GetAsync("JWTToken").Result;
            return !string.IsNullOrEmpty(token);
        }
    }
}