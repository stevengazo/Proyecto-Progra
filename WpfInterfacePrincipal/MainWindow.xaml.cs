using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaNegocios;
namespace WpfInterfacePrincipal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Comprobaciones();
        }
        protected void Comprobaciones()
        {
            Archivo archivos = new Archivo();
            bool bandArchivos = archivos.ComprobarArchivos();
            if (!bandArchivos)
            {
                MessageBox.Show("No se encontraron los archivos del programa", "Error");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemUbicacion_Click(object sender, RoutedEventArgs e)
        {
            WpfUbicaciones wpfUbicacion = new WpfUbicaciones();
            wpfUbicacion.Show();
        }

        private void MenuItemSalida_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtNombre.Text = string.Empty;
            comboxUbicacion.SelectedItem = string.Empty;
        }
    }
}
