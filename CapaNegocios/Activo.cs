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
        public override bool ActualizarEquipo(string NombreEquipo, int CodigoEquipo, string EstadoEquipo, string UbicacionEquipo)
        {
            throw new NotImplementedException();
        }

       
        public override bool EliminarEquipo(int CodigoEquipo)
        {
            return false; 
        }

        public override bool InsertarEquipo(string NombreEquipo, string EstadoEquipo, string UbicacionEquipo)
        {
            try
            {
                Archivo archivo = new Archivo();
                string ruta = archivo.getRutaActivo();
                //Lectura de la Numeración actual de la base de datos, si no existe un antecesor, empieza en 0
                //Necesario para realizar una secuencia automatica de numeros (Dato indice[identificador único])               
                StreamReader reader = new StreamReader(ruta);
                string aux = reader.ReadToEnd();
                reader.Close();               
                string[] arraux = aux.Split('%');
                int max = 0;
                int num = 0;
                // (arraux.Length/4)  = me devuelve el numero todal de filas del documento, el documento posee 4 columnas 
                for (int i = 0; i < (arraux.Length/4); i = i+4)
                {
                    //Se busca obtener el numero maximo en la sucesion actual
                    //Se realiza la busqueda de el mayor debido a que no hay una sucesion establecida (al borrar un dato la secuencia se puede alterar)
                    num = Int32.Parse(arraux[i]);
                    if(max < num)
                    {
;                        max = num;
                    }
                    else
                    {

                    }

                }

                //Suma un numero más a la sucesion de datos 
                max = max + 1;
                //Escritura de la base de datos Posterior a la verificación del dato anterior
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(max +"%" + NombreEquipo + "%" + EstadoEquipo + "%" + UbicacionEquipo );
                writer.Close();
                return true;

            }
            catch (Exception fs)
            {
                return false;
            }
            return false;
        }
        public override List<string> LecturaEquipos()
        {
            throw new NotImplementedException();    
        }

    }
}
