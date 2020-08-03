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

        }
    }
}
