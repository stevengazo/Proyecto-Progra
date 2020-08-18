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

        //Inicializacion de la interfaz
        public MainWindow()
        {
            InitializeComponent();
            Comprobaciones();
            ActualizarCombobox();

        }

        /// Metodos de Actulización y limpieza y comprobaciones
        //  LIMPIEZA de los textbox y los Combox 
        //  Esto es aplicable luego de la realización de alguna accion de los botones

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtNombre.Text = string.Empty;
            comboxUbicacion.SelectedItem = string.Empty;

            

        }

        /// <summary>      
        /// ACTUALIZACIÓN COMBOBOX UBICACIONES      
        /// Trae las ubicaciones almacenadas en el archivo ubicacion.txt
        /// </summary>
        
        protected void ActualizarCombobox()
        {
            Ubicacion ubicacion = new Ubicacion();
            List<string> Ubicaciones = ubicacion.LeerUbicaciones();
            comboxUbicacion.ItemsSource = Ubicaciones;
            Console.WriteLine();

            Activo nes = new Activo();
        }
   
        /// <summary>
        /// CONPROBACIÓN Y CREACIÓN DE ARCHIVOS DE ALMACENADO
        /// Verifica la existencia de los archivos en el disco duro en la ruta establecida 
        /// esto se realiza a nivel interno de la clase Archivo
        /// </summary>
        protected void Comprobaciones()
        {
            Archivo archivos = new Archivo();
            bool bandArchivos = archivos.ComprobarArchivos();
            if (!bandArchivos)
            {
                MessageBox.Show("No se encontraron los archivos del programa", "Error");
            }
        }


        /// <summary>
        /// COMPROBACIÓN DE OPCIONES SELECCIONADAS    
        /// Comprueba que los campos se encuentren llenos antes de realizar alguna accion
        /// esto se creó pensando en la creación y actualizacion de los datos
        /// no aplica a borrar un registro
        /// </summary>


        protected bool ComprobacionTextBox()
        {
            try
            {
                string textoCodigo = txtCodigo.Text;
                string textoNombre = txtNombre.Text;
                string textoEstado = txtEstado.Text;
                string comboboxUbicacion = (string)comboxUbicacion.SelectedItem;

                if ( textoCodigo.Equals(string.Empty) || textoNombre.Equals(string.Empty) || (textoEstado.Equals(string.Empty)) )
                {
                    MessageBox.Show("Error, revisa que los campos esten llenos", "Error", MessageBoxButton.OK);
                    return false;                    
                }
                else
                {
                    
                    return true;
                                 
                }                                            
            }
            catch (Exception i)
            {
                return false;
            }
        }

        /// <summary>
        /// /   METODOS COMUNES DE LA INTERFAZ  
        ///     Aqui se encuentran los metodos comunes de la interfaz 
        ///     los cambios más generales se encuentran aqui
        /// </summary>


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
            bool estado = ComprobacionTextBox();
        }

        private void comboxUbicacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {         
        }
    }
}
