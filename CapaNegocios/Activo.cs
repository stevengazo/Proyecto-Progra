using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
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
        public string CodigoEquipo { get; set; }
        public string EstadoEquipo { get; set; }
        public string UbicacionEquipo { get; set; }
      
        /// METODOS DE LA CLASE UTILIZADOS PARA EL CRUD DE LOS DATOS DE LOS EQUIPOS
        public override bool ActualizarEquipo(string NombreEquipo, string CodigoEquipo, string EstadoEquipo, string UbicacionEquipo)
        {
            try
            {
                bool bandModificado = false;
                bool banEncontrado = false;
                int index=0;
                List<string> vs = LecturaEquipos();
                for (int i = 0; i < vs.Count; i++)
                {
                    if (vs[i].Equals(CodigoEquipo))
                    {
                        banEncontrado = true;
                        index = i;
                        break;
                    }
                }
                if (banEncontrado)
                {
                    vs[index] = CodigoEquipo;
                    vs[index + 1] = NombreEquipo;
                    vs[index + 2] = EstadoEquipo;
                    vs[index + 3] = UbicacionEquipo;
                    bandModificado = true;
                }
                if (bandModificado)
                {
                    Archivo archivo = new Archivo();
                    StreamWriter writer = new StreamWriter(archivo.getRutaActivo());
                    int posicionFila = 0;
                    int posicionReal = 0;
                    int PosicionRegistro = 0;
                    while (PosicionRegistro < (vs.Count / 4))
                    {
                        PosicionRegistro = PosicionRegistro + 1;
                        posicionFila = 0;
                        while (posicionFila <= 3)
                        {
                            writer.Write(vs[posicionReal] + "%");
                            posicionFila = posicionFila + 1;
                            posicionReal = posicionReal + 1;
                        }
                        writer.WriteLine();
                    }
                    writer.Close();
                }
                return true;
            }catch(Exception es)
            {
                Console.WriteLine("error en metodo actualizar. Error: " + es.Message);
                return false;
            }
        }

        /// <summary>
        /// Elimina un Activo de la base de datos "Activos.txt"
        /// </summary>
        /// <param name="CodigoEquipo">Codigo para la identificación del Activo</param>
        /// <returns>Retorna True si el Activo es eliminado. Retorna False si no es encontrado o presenta algún problema en la ejecución.</returns>
        public override bool EliminarEquipo(string CodigoEquipo)
        {
            try
            {
                bool bandEncontrado = false;
                int Posicioncontador = 0;
                List<string> listaLugares = LecturaEquipos();
                List<string> NuevaLista = new List<string>();
                for (int i = 0; i < listaLugares.Count; i++)
                {
                    if (listaLugares[i].Equals(CodigoEquipo))
                    {
                        Posicioncontador = i;                        
                        bandEncontrado = true;
                        break;
                    }
                }
                for (int i = 0; i < (listaLugares.Count); i++)
                {
                    if (i == Posicioncontador)
                    {
                        bandEncontrado = true;
                    }
                    else if(i == (Posicioncontador+1))
                    {
                        bandEncontrado = true;
                    }
                    else if (i == (Posicioncontador + 2))
                    {
                        bandEncontrado = true;
                    }
                    else if (i == (Posicioncontador + 3))                    
                    {
                        bandEncontrado = true;
                    }
                    else
                    {
                        NuevaLista.Add(listaLugares[i]);
                    }
                }
                Archivo archivo = new Archivo();
                StreamWriter writer = new StreamWriter(archivo.getRutaActivo());
                int posicionFila = 0;
                int posicionReal = 0;
                int PosicionRegistro = 0;
                while(PosicionRegistro < (NuevaLista.Count/4))
                {
                    PosicionRegistro = PosicionRegistro + 1;
                    posicionFila = 0;
                    while (posicionFila <=3)
                    {
                        writer.Write(NuevaLista[posicionReal] + "%" );
                        posicionFila = posicionFila + 1;
                        posicionReal = posicionReal +1;
                    }                   
                    writer.WriteLine();                   
                }
                writer.Close();


                if (bandEncontrado)
                {
                    return true;
                }
                else
                {
                    return false;
                }                            
            }
            catch (Exception efs)
            {
                Console.WriteLine("Error en metodo eliminar activo " + efs.Message);
                return false;
            }
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
                writer.WriteLine(CodigoEquipo + "%" + NombreEquipo + "%" + EstadoEquipo + "%" + UbicacionEquipo+"%");
                writer.Close();
                return true;               
            }
            catch (Exception fs)
            {
                Console.WriteLine("Error Metodo InsertarEquipo: " + fs.Message);
                return false;
            }
        }


        /// <summary>
        /// Lectura del archivo "Activo.txt"
        /// </summary>
        /// <returns>Retorno de una lista con los datos en el string </returns>
        public override List<string> LecturaEquipos()
        {
            try
            {

                Archivo archivo = new Archivo();
                string ruta = archivo.getRutaActivo();
                StreamReader reader = new StreamReader(ruta);
                string aux = reader.ReadToEnd();
                reader.Close();
                aux = aux.Replace("\r", string.Empty);
                aux = aux.Replace("\n", string.Empty);
                string[] ArregloActivos = aux.Split('%');
                List<string> listaActivos= new List<string>();
                for (int i = 0; i < (ArregloActivos.Length-1) ; i++)
                {
                    listaActivos.Add(ArregloActivos[i]);
                }
                return listaActivos;

            }
            catch (Exception error)
            {
                Console.WriteLine("Error: " + error.Message);
                return null;
            }            
        }

    }
}
