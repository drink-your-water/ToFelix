namespace OpenMe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

<<<<<<< HEAD
            MainPage = new AppShell();
=======
            MainPage = new NavigationPage(new MainPage());
>>>>>>> 7638ee5 (Completed Main page and started 2nd page.)
        }
    }
}
