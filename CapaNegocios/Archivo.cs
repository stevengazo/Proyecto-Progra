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
        private string RutaDirectorio = "C:\\Softnow";
        private string BaseDatosUbicacion = "\\Ubicacion.txt";
        private string BaseDatosActivos = "\\Activos.txt";
        
        public string getRutaUbicacion()
        {
            return this.RutaDirectorio + this.BaseDatosUbicacion;
        }
        public string getRutaActivo()
        {
            return this.RutaDirectorio + this.BaseDatosActivos;
        }

        public bool ComprobarArchivos()
        {
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
                return false;
            }


        }


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
                return false;
            }
        }

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
                return false;
            }
        }

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
            catch (Exception fs)
            {
                return false;
            }
        }
    }
}
