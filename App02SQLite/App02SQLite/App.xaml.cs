using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02SQLite
{
    public partial class App : Application
    {
        public static string UbicacionDB = string.Empty;
        
        //Este constructor no recibe parametros
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
        }

        //Este constructor recibe la ubicacion de nuestra pagina
        public App(string DBlocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            UbicacionDB = DBlocal;
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
