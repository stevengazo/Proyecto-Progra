using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public abstract class AbsActivo
    {

        // METODOS ABSTRACTOS

        /// <summary>
        ///  Inserta equipos en el archivo "Activo.txt"
        /// </summary>
        /// <param name="NombreEquipo">Nombre que presenta el equipo.</param>
        /// <param name="EstadoEquipo">Estado actual del equipo.</param>
        /// <param name="UbicacionEquipo">Ubicación del dispositivo.</param>
        /// <param name="CodigoEquipo">Codigo de identificación del equipo. </param>
        /// <returns>Retorna True si los datos se guardan correctamente. Retorna False si los datos no se guardan</returns>
        /// 
        public abstract bool InsertarEquipo(string NombreEquipo,string CodigoEquipo,  string EstadoEquipo, string UbicacionEquipo);

        //ACTUALIZACION DE DATOS


        /// <summary>
        /// Actualiza la información de equipo seleccionado dentro del "activo.txt"
        /// </summary>
        /// <param name="NombreEquipo">Recibe el nuevo nombre del equipo</param>
        /// <param name="CodigoEquipo">Busca el codigo del equipo a modificar</param>
        /// <param name="EstadoEquipo">Actualiza el estado del equipo</param>
        /// <param name="UbicacionEquipo">Actualliza la información del equipo </param>
        /// <returns>Retorna True si los datos se actulizan correctamente. Retorna False si los datos no se guardan</returns>
        public abstract bool ActualizarEquipo(string NombreEquipo, string CodigoEquipo, string EstadoEquipo, string UbicacionEquipo);

        //ELIMINACION DE DATOS

        /// <summary>
        /// Elimina un registro del archivo "activo.txt"
        /// </summary>
        /// <param name="CodigoEquipo">Codigo del equipo a borrar</param>
        /// <returns>Retorna False si no encuentra el equipo o presenta un error. Retorna True si encuentra el equipo y lo elimina</returns>
        public abstract bool EliminarEquipo(string CodigoEquipo);

        //LECTURA DE DATOS

        /// <summary>
        /// Genera una lista de tipo Cadena de Texto con los datos obtenidos del "activo.txt"
        /// </summary>
        /// <returns> Lista de tipo Entero </returns>
        public abstract List<string> LecturaEquipos();

    
    
    }


}
