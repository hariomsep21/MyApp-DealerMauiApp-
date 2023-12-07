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
            // Implement your logic to determine the initial route
            // Example: check a static value, configuration, or any other condition
            // Return 1 for Home, 2 for Login, or any default value as needed
            return 1; // For demonstration purposes, assuming the initial route is Home (1)
        }
    }
}