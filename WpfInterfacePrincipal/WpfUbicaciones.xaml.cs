using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapaNegocios;

namespace WpfInterfacePrincipal
{
    /// <summary>
    /// Interaction logic for WpfUbicaciones.xaml
    /// </summary>
    public partial class WpfUbicaciones : Window
    {

        public WpfUbicaciones()
        {
            InitializeComponent();
            MostrarLista();
        }

        private void btnAgregarUbicacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!txtNombreUbicacion.Text.Equals(string.Empty))
                {
                    bool bandUbicacion = false;
                    Ubicacion ubicacion = new Ubicacion();
                    bandUbicacion = ubicacion.CrearUbicacion(txtNombreUbicacion.Text);
                    if (bandUbicacion)
                    {
                        MessageBox.Show("Ubicación agregada");
                        txtNombreUbicacion.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("El campo no puede estar vacio", "Error");
                }
            }
            catch (Exception s)
            {
                MessageBox.Show("Error", "Error");
            }
            MostrarLista();      

        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void listViewUbicacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void MostrarLista()
        {

            Ubicacion ubicacion = new Ubicacion();
            List<Ubicacion> ListaUbicacion = new List<Ubicacion>();
            List<string> ListadeDatos = new List<string>();
            ListadeDatos = ubicacion.LeerUbicaciones();
            for (int i = 0; i <(ListadeDatos.Count); i++)
            {
                ListaUbicacion.Add(new Ubicacion());
                ListaUbicacion[i].NombreUbicacion = ListadeDatos[i];
            }
            listViewUbicacion.ItemsSource = ListadeDatos;

            Console.WriteLine();
        }
    }
}
