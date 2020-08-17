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

        //INSECION DE DATOS
        public abstract bool InsertarEquipo(string NombreEquipo, string EstadoEquipo, string UbicacionEquipo);
        
        //ACTUALIZACION DE DATOS
        public abstract bool ActualizarEquipo(string NombreEquipo, string CodigoEquipo, string EstadoEquipo, string UbicacionEquipo);

        //ELIMINACION DE DATOS
        public abstract bool EliminarEquipo(string CodigoEquipo);

        //LECTURA DE DATOS
        public abstract List<string> LecturaEquipos();

    
    
    }


}
