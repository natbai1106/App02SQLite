using System;
using System.Collections.Generic;
using SQLite;
using App02SQLite.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modificar : ContentPage
    {
        private int id;
        private String nombre;
        private String apellido;
        private int edad;
        private String fecha;
        private String correo;
        private String direccion;

        public Modificar()
        {
            InitializeComponent();
        }

        private void Modificar2_Clicked(object sender, EventArgs e)
        {
            
            Int32 cod = Convert.ToInt32(codigo.Text);
            Int32 years = Convert.ToInt32(edadx.Text);
            String date = fechanac.Date.ToString("dd/MM/yyyy");

            id = cod;
            nombre = nombresx.Text;
            apellido = apellidosx.Text;
            edad = years;
            fecha = date;
            correo = emailx.Text;
            direccion = direccionx.Text;

            string x = Convert.ToString(id);

            SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB);
            var modpersonas = connection.Query<Personas>($"UPDATE Personas set " +
                $"Nombres = '" + nombre + "'," +
                $"Apellidos = '" + apellido + "'," +
                $"Edad = '" + edad + "'," +
                $"Fechanac = '" + fecha + "'," +
                $"Correo = '" + correo + "'," +
                $"Direccion = '" + direccion + "'" +
                $"WHERE Id = '" + id + "' ");
            connection.Close();

            DisplayAlert("Aviso", "" + nombre + " " + apellido + " ha sido Modificado exitosamente", "Ok"); 
        }

        private void fechanac_DateSelected(object sender, DateChangedEventArgs e)
        {
            
        }
    }
}