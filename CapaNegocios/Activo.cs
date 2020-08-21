using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    //Implementación del uso de clases Abstractas y herencia 
    public class Activo : AbsActivo
    {
        /// <summary>
        ///    Atributos de la clase      
        /// </summary>
        public string NombreEquipo { get; set; }
        public int CodigoEquipo { get; }
        public string EstadoEquipo { get; set; }
        public string UbicacionEquipo { get; set; }
      
        /// METODOS DE LA CLASE UTILIZADOS PARA EL CRUD DE LOS DATOS DE LOS EQUIPOS
        public override bool ActualizarEquipo(string NombreEquipo, string CodigoEquipo, string EstadoEquipo, string UbicacionEquipo)
        {
            throw new NotImplementedException();
        }

       
        public override bool EliminarEquipo(string CodigoEquipo)
        {
            return false; 
        }


        /// <summary>
        /// Metodo para la inserción de datos en el archivo "Activo.txt".
        /// </summary>
        /// <param name="NombreEquipo">Nombre del equipo a agregar</param>
        /// <param name="CodigoEquipo">Codigo o número de serie (Identificador único)</param>
        /// <param name="EstadoEquipo">Estado que presenta el equipo(Dañado o en buen estado)</param>
        /// <param name="UbicacionEquipo">Ubicación que presenta el equipo seleccionado.</param>
        /// <returns>Retorna True si el valor se introduce con éxito. Retorna False si presenta algún error.</returns>
        public override bool InsertarEquipo(string NombreEquipo, string CodigoEquipo,string EstadoEquipo, string UbicacionEquipo)
        {
            try
            {
                Archivo archivo = new Archivo();
                string ruta = archivo.getRutaActivo();
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(CodigoEquipo + "%" + NombreEquipo + "%" + EstadoEquipo + "%" + UbicacionEquipo);
                writer.Close();
                return true;               
            }
            catch (Exception fs)
            {
                Console.WriteLine("Error Metodo InsertarEquipo: " + fs.Message);
                return false;
            }
        }
        public override List<string> LecturaEquipos()
        {
            throw new NotImplementedException();    
        }

    }
}
