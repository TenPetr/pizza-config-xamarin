using Xamarin.Forms;

namespace PizzaConfig
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "SwipeView_Experimental" });

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#4E342E"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
