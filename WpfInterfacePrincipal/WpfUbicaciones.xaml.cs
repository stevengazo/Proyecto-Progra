﻿using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

        private string opcion;
        public WpfUbicaciones()
        {
            InitializeComponent();
            ActualizarListview();
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
                ActualizarListview();
            }
            catch (NullReferenceException s)
            {
                MessageBox.Show(("Error " + s.Message), "Error");
            }   
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarListview();
        }

        private void listViewUbicacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string seleccion = itemSeleccionado(sender);                
                txtNombreUbicacion.Text = seleccion;
                
            }
            //Esto presenta problemas al momento de realizar cambios y cargarlos al listview 
            //La excepción Null es para resolver esto
            catch(NullReferenceException ia)
            {
                Console.Write("Error item no valido");
            }

        }


        private string itemSeleccionado (object sender)
        {
            try
            {
                ListView instanciaLtv = (ListView)sender;
                Ubicacion ubicacionSelecionada = (Ubicacion)instanciaLtv.SelectedItem;                   
                this.opcion  = ubicacionSelecionada.nombreUbicacion;               
                return ubicacionSelecionada.nombreUbicacion;                      
            }catch (NullReferenceException sd)
            {
                Console.WriteLine("error " + sd.Message );
                return null;
            }                       
        }


     
        private void btnModificarUbicacion_Click(object sender, RoutedEventArgs e)
        {
            Ubicacion ubicacion = new Ubicacion();
            bool estado = false;
            string NombreAnterior = this.opcion;
            string NombreNuevo = txtNombreUbicacion.Text;
            if (NombreNuevo.Equals(string.Empty) || NombreNuevo.Equals(NombreAnterior))
            {
                MessageBox.Show("Digite un nombre valido");
            }
            else
            {
                estado =ubicacion.modificarNombre(NombreNuevo, NombreAnterior);
                if (estado)
                {
                    MessageBox.Show("Modificación con éxito", "Información", MessageBoxButton.OK);

                }
                else
                {
                    MessageBox.Show("Error al modificar el campo", "Error", MessageBoxButton.OK);
                }
            }
            ActualizarListview();
           
        }

        protected void ActualizarListview()
        {
            Ubicacion ubicacion = new Ubicacion();
            List<Ubicacion> ListaUbicaciones = new List<Ubicacion>();
            List<string> listaux = new List<string>();
            listaux = ubicacion.LeerUbicaciones();
            for (int i = 0; i < listaux.Count; i++)
            {
                ListaUbicaciones.Add(new Ubicacion());
                ListaUbicaciones[i].nombreUbicacion = listaux[i];
            }
            listViewUbicacion.ItemsSource = ListaUbicaciones;
            Console.WriteLine("prueba");
        }

        private void btnEliminarUbicacion_Click(object sender, RoutedEventArgs e)
        {
            string opcion = txtNombreUbicacion.Text;
            if (opcion.Equals(string.Empty))
            {
                MessageBox.Show("error digita un sitio");
            }
            else
            {
                MessageBox.Show("Advertencia... Eliminando registro", "Advertencia", MessageBoxButton.OK);
                bool estado = false;
                Ubicacion ubicacion = new Ubicacion();
                estado = ubicacion.EliminarRegistro(txtNombreUbicacion.Text);
                if (estado)
                {
                    MessageBox.Show((opcion + " Eliminado"), "Información", MessageBoxButton.OK);
                    ActualizarListview();
                }
                else
                {
                    MessageBox.Show((opcion + " no encontrado"), "Error", MessageBoxButton.OK);
                }

            }
            ActualizarListview();

        }
    }
}
