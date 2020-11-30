using System.IO;
using System;
using Xamarin.Forms;

namespace PizzaConfig
{
    public partial class App : Application
    {
        private static DatabaseService _databaseService;

        public static DatabaseService databaseService
        {
            get
            {
                if (_databaseService == null)
                {
                    _databaseService = new DatabaseService(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "XamarinSQLite.db3"));
                }
                return _databaseService;
            }
        }

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
