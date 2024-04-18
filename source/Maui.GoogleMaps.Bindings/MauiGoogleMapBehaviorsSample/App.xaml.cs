using MauiGoogleMapBehaviorsSample.Pages;

namespace MauiGoogleMapBehaviorsSample
{
    public partial class App : Application
    {
        public App(HomePage homePage)
        {
            InitializeComponent();

            MainPage = homePage;
        }
    }
}