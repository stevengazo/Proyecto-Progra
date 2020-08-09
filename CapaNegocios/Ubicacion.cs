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
   
        public string nombreUbicacion { get; set; }

       

        public Ubicacion()
        {
            
        }

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

        public List<String> LeerUbicaciones() {
            try
            {
                Archivo archivo = new Archivo();
                List<string> ListaUbicaciones = new List<string>();
                StreamReader reader = new StreamReader(archivo.getRutaUbicacion());
                string[] ArregloUbicaciones;
                string aux = reader.ReadToEnd();
                aux = aux.Replace("\r", string.Empty);
                aux = aux.Replace("\n", string.Empty);
                ArregloUbicaciones = aux.Split('%');
                foreach( var item in ArregloUbicaciones)
                {
                    ListaUbicaciones.Add(item);

                }
                return ListaUbicaciones;                
            }   
            catch (Exception es)
            {
                Console.WriteLine("Error");
                return null;
            }        
        
        }
    }
}
