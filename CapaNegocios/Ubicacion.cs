using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaNegocios;

namespace CapaNegocios
{
    
    
    public class Ubicacion { 
        //DATAMEMBERS
        public string nombreUbicacion { get; set; }
        //CONSTRUCTORS
        public Ubicacion()
        {
            
        }
        //METODOS 


        //CREACIÓN DE NUEVOS LUGARES EN LA TABLA
        public bool CrearUbicacion(string nombreUbicacion)
        {
            try
            {
                this.nombreUbicacion = nombreUbicacion;
                Archivo rutas = new Archivo();
                if (File.Exists(rutas.getRutaUbicacion()))
                {
                    StreamWriter writer = new StreamWriter(rutas.getRutaUbicacion(), true);
                    writer.WriteLine(this.nombreUbicacion + "%");
                    writer.Close();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }


        //LECTURA Y DEVOLUCIÓN DE LOS DATOS DEL ARCHIVO UBICACION.TXT
        public List<String> LeerUbicaciones() {
            try
            {
                Archivo archivo = new Archivo();
                List<string> ListaUbicaciones = new List<string>();
                StreamReader reader = new StreamReader(archivo.getRutaUbicacion());
                string[] ArregloUbicaciones;
                string aux = reader.ReadToEnd();
                reader.Close();
                aux = aux.Replace("\r", string.Empty);
                aux = aux.Replace("\n", string.Empty);
                ArregloUbicaciones = aux.Split('%');
               /* foreach( var item in ArregloUbicaciones)
                {
                    ListaUbicaciones.Add(item);

                }*/
                for (int i = 0; i < (ArregloUbicaciones.Length-1); i++)
                {
                    ListaUbicaciones.Add(ArregloUbicaciones[i]);
                }
                return ListaUbicaciones;                
            }   
            catch (Exception es)
            {
                Console.WriteLine("Error");
                return null;
            }        
        
        }
    


        public bool modificarNombre(string NombreNuevo, string NombreAnterior)
        {
            try
            {
                Archivo archivo = new Archivo();
                StreamReader reader = new StreamReader(archivo.getRutaUbicacion());
                string text = reader.ReadToEnd();
                reader.Close();
                text = text.Replace(NombreAnterior, NombreNuevo);
                StreamWriter writer = new StreamWriter(archivo.getRutaUbicacion());
                writer.Write(text);
                writer.Close();
                return true;
            }catch (Exception io)
            {
                Console.WriteLine("Error al modificar el dato");
                return false;
            }
        }



        public bool EliminarRegistro(string NombreUbicacion)
        {
            try
            {
                bool bandEncontrado = false;
                Archivo archivo = new Archivo();               
                StreamReader reader = new StreamReader(archivo.getRutaUbicacion());
                string aux = reader.ReadToEnd();
                reader.Close();              
                StreamWriter writer = new StreamWriter(archivo.getRutaUbicacion(),false);               
                aux = aux.Replace("\r", string.Empty);
                aux = aux.Replace("\n", string.Empty);
                string[] arrAux = aux.Split('%');
                for (int i = 0; i < (arrAux.Length-1) ; i++)
                {
                    if (!arrAux[i].Equals(NombreUbicacion))
                    {
                        writer.WriteLine(arrAux[i] + "%");
                    }
                    else
                    {
                        bandEncontrado = true;
                    }
                } 
                writer.Close();
                if (bandEncontrado)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
                return true;
            }
            catch (Exception io)
            {
                Console.WriteLine("Error al eliminar el dato");
                return false;
            }
            return false;
        }
    
    }
}
