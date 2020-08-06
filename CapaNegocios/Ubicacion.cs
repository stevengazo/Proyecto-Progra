using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    
    
    public class Ubicacion { 
   
        public string NombreUbicacion;

       

        public Ubicacion(string NombreUbicacion)
        {
            NombreUbicacion = NombreUbicacion;
        }
        public Ubicacion()
        {

        }

        public bool CrearUbicacion(string NombreUbicacion)
        {
            try
            {
                this.NombreUbicacion = NombreUbicacion;
                Archivo rutas = new Archivo();
                if (File.Exists(rutas.getRutaUbicacion()))
                {
                    StreamWriter writer = new StreamWriter(rutas.getRutaUbicacion(), true);
                    writer.WriteLine(this.NombreUbicacion + "&");
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

        public List<String> LeerUbicaciones() {
            try
            {
                Archivo archivo = new Archivo();
                StreamReader reader = new StreamReader(archivo.getRutaUbicacion());
                string aux = reader.ReadToEnd();
                aux = aux.Replace("\r\n", string.Empty);                
                String[] Datos = aux.Split('&');
                int tamañoArreglo = Datos.Length;
                Array.Clear(Datos, (Datos.Length-1), 1);
                List<string> ListaUbicaciones = new List<string>();
                foreach (string item in Datos)
                {
                    ListaUbicaciones.Add(item);
                }
                return ListaUbicaciones;
            }   catch(Exception fs)
            {
                return null;
            }           
        
        }
    }
}
