using App02SQLite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private int id;
        private string nombre;
        private string apellido;
        private int edad;
        private string fecha;
        private string correo;
        private string direccion;

        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB);
            connection.CreateTable<Personas>();
            var listapersonas = connection.Table<Personas>().ToList();
            ListaPersonas.ItemsSource = listapersonas;
            connection.Close();
        }

        async void btnModificar_Clicked(object sender, EventArgs e)
        {
            var persona = new Modificaciones
            {
                Id = id,
                Nombres = nombre,
                Apellidos = apellido,
                Edad = edad,
                Fechanac = fecha,
                Correo = correo,
                Direccion = direccion
            };


            var send2 = new Modificar();
            send2.BindingContext = persona;
            await Navigation.PushAsync(send2);
        }



        private void btnBorrar_Clicked(object sender, EventArgs e)
        {
            string x = Convert.ToString(id);

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            var listapersonas = conexion.Query<Personas>($"Delete FROM Personas WHERE Id = '" + x + "' ");
            conexion.Close();

            DisplayAlert("Aviso", "Se ha eliminado a " + nombre + " de la lista de personas", "Ok");
        }

        private void ListaPersonas_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem as Personas;
            if (selectedCategory != null)
            {
                id = selectedCategory.Id;
                nombre = selectedCategory.Nombres;
                apellido = selectedCategory.Apellidos;
                fecha = selectedCategory.Fechanac;
                edad = selectedCategory.Edad;
                direccion = selectedCategory.Direccion;
                correo = selectedCategory.Correo;
            }
            DisplayAlert("Aviso", "Se ha seleccionado a " + nombre + " de la lista de personas", "Ok");
        }
    }
}