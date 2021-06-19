using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using App02SQLite.Model;

namespace App02SQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            Int32 resultado = 0;
            DateTime fecha = fechanac.Date;

            var persona = new Personas()
            {
                Nombres = Convert.ToString(nombres.Text),
                Apellidos = Convert.ToString(apellidos.Text),
                Fechanac = fecha.ToString("dd/MM/yyyy"),
                Edad = Convert.ToInt32(edad.Text),
                Correo = Convert.ToString(email.Text),
                Direccion = Convert.ToString(direccion.Text)
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB))
            {
                connection.CreateTable<Personas>();
                resultado = connection.Insert(persona);

                if (resultado > 0)
                    DisplayAlert("Aviso", "Adicionado", "Ok");
                else
                    DisplayAlert("Aviso", "Error", "Ok");
            }
            nombres.Text = ""; apellidos.Text = ""; edad.Text = ""; email.Text = ""; direccion.Text = "";
        }

        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        private void fechanac_DateSelected(object sender, DateChangedEventArgs e)
        {
           //fecha.Text = fechanac.Date.ToString();
        }
    }
}