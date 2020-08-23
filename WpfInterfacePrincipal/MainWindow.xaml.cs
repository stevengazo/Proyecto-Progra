using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
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
        //variables globales para la seleccion de un dato
        private string nombreSeleccionado;
        private string CodigoSeleccionada;
        private string Ubicacionseleccionada;
        private string EstadoSeleccionado;

        //Inicializacion de la interfaz
        public MainWindow()
        {
            InitializeComponent();
            Comprobaciones();
            ActualizarCombobox();
            ActualizaListView();

        }

        /// Metodos de Actulización y limpieza y comprobaciones
        //  LIMPIEZA de los textbox y los Combox 
        //  Esto es aplicale luego de la realización de alguna accion de los botones

        private void limpiarPantalla()
        {
            txtCodigo.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtNombre.Text = string.Empty;
            comboxUbicacion.SelectedItem = null;
        }


        /// <summary>
        /// Metodo para la actualización de los elementos del listview
        /// </summary>
        protected void ActualizaListView()
        {
            Activo activo = new Activo();
            int contador = 0;
            int PosicionObjeto = 0;
            int PosicionLista = 0;
            List<Activo> ListaActivos = new List<Activo>();
            List<string> ListaCadena = new List<string>();
            ListaCadena = activo.LecturaEquipos();
            //Inicia los objetos en la lista
            for (int i = 0; i < (ListaCadena.Count/4); i++)
            {
                ListaActivos.Add(new Activo());               
            }
            //Introduce los datos
            while (PosicionObjeto < ListaActivos.Count)
            {

                contador = 0;
                //Selecciona la posición a asignar de la cadena
                //La variable PosicionLista cambia solamente cuando se asigna un valor
                //Esta funciona para la asignación según la posición en la Lista "ListaCadena" obtenida del txt
                while (contador <= 3)
                {
                    switch (contador)
                    {
                        case 0:
                            ListaActivos[PosicionObjeto].CodigoEquipo = ListaCadena[PosicionLista];
                            PosicionLista++;
                            contador++;
                            break;
                        case 1:
                            ListaActivos[PosicionObjeto].NombreEquipo = ListaCadena[PosicionLista];
                            PosicionLista++;
                            contador++;
                            break;
                        case 2:
                            ListaActivos[PosicionObjeto].EstadoEquipo = ListaCadena[PosicionLista];
                            PosicionLista++;
                            contador++;
                            break;
                        case 3:
                            ListaActivos[PosicionObjeto].UbicacionEquipo = ListaCadena[PosicionLista];
                            PosicionLista++;
                            contador++;
                            break;
                        default:
                            break;
                    }
                }
                PosicionObjeto++;
            }
            listViewActivos.ItemsSource = ListaActivos;
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
        /// COMPROBACIÓN Y CREACIÓN DE ARCHIVOS DE ALMACENADO
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
                Console.WriteLine("Error" + i.Message);
                return false;
            }
        }


        /// <summary>
        /// Metodo de retorno de objeto seleccionado en el ListView
        /// </summary>
        /// <param name="sender">Parametro Sender</param>
        /// <returns></returns>
        private void ItemSeleccionado(object sender)        
        {
            try
            {
                ListView instaciaLstv = (ListView)sender;
                Activo ActivoSeleccionado = (Activo)instaciaLstv.SelectedItem;
                this.nombreSeleccionado = ActivoSeleccionado.NombreEquipo;
                this.EstadoSeleccionado = ActivoSeleccionado.EstadoEquipo;
                this.Ubicacionseleccionada = ActivoSeleccionado.UbicacionEquipo;
                this.CodigoSeleccionada = ActivoSeleccionado.CodigoEquipo;
                //return null;
            /*
             Esto puede presentar problemas al momento de realizar cambios la lista enviada al itemSource de listView
             En desarollo puede presentar problemas. En tiempo de ejecución no muestra ningún problema
             */    
            }catch(NullReferenceException errorItem)
            {
                Console.WriteLine("Error en la función ItemSeleccionado " + errorItem.Message);
                //return null;
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

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiarPantalla();

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            bool bandEstadoTxts = ComprobacionTextBox();
            if (bandEstadoTxts)
            {
                bool bandEstadoInsercion = false;
                Activo activo = new Activo();
                string nombre, codigo, estado, ubicacion;
                nombre = txtNombre.Text;
                codigo = txtCodigo.Text;
                estado = txtEstado.Text;
                ubicacion = comboxUbicacion.Text;
                bandEstadoInsercion = activo.InsertarEquipo(nombre, codigo, estado, ubicacion);
                if(bandEstadoInsercion)
                {
                    MessageBox.Show("Equipo agregado con éxito", "Información", MessageBoxButton.OK);
                    limpiarPantalla();
                }
                else
                {
                    MessageBox.Show("Error al introducir el equipo", "Información", MessageBoxButton.OK);
                }
                ActualizaListView();
            }
            else
            {
                MessageBox.Show("Todos los campos deben encontrarse llenos", "Advertencia", MessageBoxButton.OK);
            }
        }

        private void comboxUbicacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {         
        }

        private void comboxUbicacion_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void comboxUbicacion_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void comboxUbicacion_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ActualizarCombobox();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string Opcion = txtCodigo.Text;
           
            bool banEstado = false;
            Activo activo = new Activo();
            banEstado = activo.EliminarEquipo(Opcion);
            if (banEstado)
            {
                MessageBox.Show("Registro Eliminado con éxito", "Información", MessageBoxButton.OK);
                ActualizaListView();
                limpiarPantalla();
            }
            else
            {
                MessageBox.Show(("El código " + Opcion + " no fue encontrado\nIntentelo de nuevo"), "Error", MessageBoxButton.OK);
            }            
        }

        private void listViewActivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ItemSeleccionado(sender);
                txtCodigo.Text = this.CodigoSeleccionada;
                txtEstado.Text = this.EstadoSeleccionado;
                txtNombre.Text = this.nombreSeleccionado;
                comboxUbicacion.SelectedItem = this.Ubicacionseleccionada;
            }
            catch(Exception error)
            {
                Console.WriteLine("Error " + error.Message);
            }

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Activo activo = new Activo();
            string nombre, codigo, ubicacion, estado;
            nombre = txtNombre.Text;
            codigo = txtCodigo.Text;
            ubicacion = comboxUbicacion.Text;
            estado = txtEstado.Text;
            bool bandModificado = false;
            if( nombre.Equals(null) || codigo.Equals(null) || ubicacion.Equals(null) || estado.Equals(null))
            {
                MessageBox.Show("Verifica que todos los datos esten introducidos", "Error", MessageBoxButton.OK);
            }
            else
            {
                bandModificado= activo.ActualizarEquipo(nombre, codigo, estado, ubicacion);
            }

            if (bandModificado)
            {
                MessageBox.Show("Datos actualizados.");
                limpiarPantalla();
                ActualizaListView();
            }
            else
            {
                MessageBox.Show("No se encontró el codigo", "Error", MessageBoxButton.OK);
            }
        }

        private void btnLimpiar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void comboxUbicacion_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
