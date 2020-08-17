using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    //Implementación del uso de clases Abstractas y herencia 
    public class Activo : AbsActivo
    {
        /// <summary>
        ///    DATAMEMBERS DE LA CLASE
        ///   
        /// </summary>
        public string NombreEquipo { get; set; }
        public int CodigoEquipo { get; }
        public string EstadoEquipo { get; set; }
        public string UbicacionEquipo { get; set; }


        /// <summary>
        ///    Metodos de la clase utilizados para el CRUD de los datos de los equipos
        /// </summary>
        /// <param name="NombreEquipo">     necesario para manejo del nombre del equipo    </param>
        /// <param name="CodigoEquipo">     necesario para la devolución del equipo en cuestion, esto no es asignable por el usuario ()asignado automaticamente por el sistema</param>
        /// <param name="EstadoEquipo">     necesario para almacenar el estado que presenta el equipo al momento de entregarse</param>
        /// <param name="UbicacionEquipo">  necesario para el almacenaje de la ubicación que presenta el equipo </param>
        /// <returns></returns>
        public override bool ActualizarEquipo(string NombreEquipo, string CodigoEquipo, string EstadoEquipo, string UbicacionEquipo)
        {
            throw new NotImplementedException();    
        }
        public override bool EliminarEquipo(string CodigoEquipo)
        {
            return false; 
        }

        public override bool InsertarEquipo(string NombreEquipo, string EstadoEquipo, string UbicacionEquipo)
        {
            return false;
        }
        public override List<string> LecturaEquipos()
        {
            throw new NotImplementedException();    
        }

    }
}
