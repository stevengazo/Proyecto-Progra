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
        // Atributos de la clase 

        protected string nombreUbicacion { get; set; }
        //Constructores de la clase 
        public Ubicacion()
        {
            
        }

        //  METODOS DE LA CLASE (USADOS POR LA CAPA INTERFAZ)

        /// <summary>
        /// Crea un nuevo elemento en el archivo Ubicacion.txt
        /// </summary>
        /// <param name="nombreUbicacion">Nombre de la ubicación a añadir</param>
        /// <returns>Retorna True si el dato es guardado con éxito. Retorna False si presenta algún error</returns>
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


        /// <summary>
        /// Lee y filtra las ubicaciones almacenadas en el archivo Ubicacion.txt
        /// </summary>
        /// <returns>Retorna una lista de tipo cadena de caracteres, retorna Null si presenta algún error </returns>
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
    

        /// <summary>
        ///  Busca y modifica algún elemento previamente guardado
        /// </summary>
        /// <param name="NombreNuevo">Nombre con el cual se va a modificar</param>
        /// <param name="NombreAnterior">Nombre anterior con el cual se guardo anteriormente (tiene que se el dato exacto)</param>
        /// <returns>Retorna True si modifica la ubicación con éxito. Retorna False si hay problemas </returns>
        public bool modificarNombre(string NombreNuevo, string NombreAnterior)
        {
            try
            {
                //Lee los datos, reemplaza si lo encuentra y lo reescribe en los datos en el Ubicacion.txt
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


        /// <summary>
        /// Elimina un lugar previamente registrado en el archivo Ubicacion.txt
        /// </summary>
        /// <param name="NombreUbicacion">Nombre del lugar a modificar</param>
        /// <returns>Retorna True si la ubicación es eliminada con éxito. Retorna False si presenta problemas.</returns>
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
                //limpia la cadena, separa y los pasa a un arreglo
                aux = aux.Replace("\r", string.Empty);
                aux = aux.Replace("\n", string.Empty);
                string[] arrAux = aux.Split('%');
                //Recorre los datos del arreglo y si tiene una coincidencia con el dato suministrado, no lo agrega 
                //Reescribe los datos del archivo saltando el dato suministrado
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
                //Si encuentra el dato retorna true
                //Sino lo encuentra retorna false
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
