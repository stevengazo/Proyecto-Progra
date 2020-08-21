using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Archivo //creación y gestión de archivo
    {

        //Atributos del usuario 
        private string RutaDirectorio = "C:\\Softnow";
        private string BaseDatosUbicacion = "\\Ubicacion.txt";
        private string BaseDatosActivos = "\\Activos.txt";
        
        /// <summary>
        /// Retorna la ruta absoluta del archivo Ubicacion.txt
        /// </summary>
        /// <returns>Retorno de String</returns>
        public string getRutaUbicacion()
        {
            return this.RutaDirectorio + this.BaseDatosUbicacion;
        }

        /// <summary>
        /// Retorna la ruta absoluta del archivo Activo.txt
        /// </summary>
        /// <returns>Retorno de String</returns>
        public string getRutaActivo()
        {
            return this.RutaDirectorio + this.BaseDatosActivos;
        }


        /// <summary>
        /// Comprueba las rutas absolutas, si no se encuentran. Llama a las funciones para crear
        /// los archivos .txt y los directorios.
        /// </summary>
        /// <returns>Retorno booleanos. si los datos se crean o ya existen, retorna vendadero, en caso contrario retorna False.</returns>
        public bool ComprobarArchivos()
        {
            // Banderas de comprobación del directorio y los archivos
            bool bandDirectorio = false;
            bool bandActivo = false;
            bool bandUbicacion = false;
            try
            {
                if (!Directory.Exists(RutaDirectorio))
                {
                    bandDirectorio = CrearDirectorio();
                }
                else
                {
                    bandDirectorio = true;
                }
                if (!File.Exists(this.RutaDirectorio + this.BaseDatosActivos))
                {
                    bandActivo = CrearActivo();

                }
                else
                {
                    bandActivo = true;
                }
                if (!File.Exists(this.RutaDirectorio + this.BaseDatosUbicacion))
                {
                    bandUbicacion = CrearUbicacion();
                }
                else
                {
                    bandUbicacion = true;
                }

                if (bandActivo && bandDirectorio && bandUbicacion)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception fdf)
            {
                Console.WriteLine("Error en el metodo CompararArchivos. " + fdf.Message);
                return false;
            }


        }

        /// <summary>
        /// Comprueba la existencia del directorio y lo crea si no existe.
        /// </summary>
        /// <returns> Retorna True si lo crea con éxito. Retorna False sino lo crea. </returns>
        public bool CrearDirectorio()
        {
            try
            {
                if (!Directory.Exists(this.RutaDirectorio))
                {
                    Directory.CreateDirectory(this.RutaDirectorio);
                    return true;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception es)
            {
                Console.WriteLine("Error en método CrearDirectorio. " + es.Message);
                return false;
            }
        }


        /// <summary>
        ///  Comprueba la existencia del archivo activo.txt y lo crea si no existe.
        /// </summary>
        /// <returns> Retorna True si lo crea con éxito. Retorna False sino lo crea. </returns>
        public bool CrearActivo()
        {
            try
            {
                if (!File.Exists(this.RutaDirectorio + this.BaseDatosActivos))
                {
                    File.Create(this.RutaDirectorio + this.BaseDatosActivos);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception fs)
            {
                Console.WriteLine("Error en el método CrearActivo. " + fs.Message);
                return false;
            }
        }


        /// <summary>
        ///  Comprueba la existencia del archivo Ubicacion.txt y lo crea si no existe.
        /// </summary>
        /// <returns> Retorna True si lo crea con éxito. Retorna False sino lo crea. </returns>
        public bool CrearUbicacion()
        {
            try
            {
                if (!File.Exists(this.RutaDirectorio + this.BaseDatosUbicacion))
                {
                    File.Create(this.RutaDirectorio + this.BaseDatosUbicacion);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception wfs)
            {
                Console.WriteLine("Error en el metodo CrearUbicacion. " + wfs.Message);
                return false;
            }
        }
    }
}
