using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCirugias.Data;
using iCirugias.Data.Conexion;
using iCirugias.Data.Objects;
using System.Web;

namespace iCirugias.Ayuda
{
  public class Utilerias
    {
      public static void Insertar(Type tipo, List<Campos> CamposInsertar)
      {
          Connection conn = new Connection(Session.CONNECTION_STRING);
          Base obj = System.Activator.CreateInstance(tipo, conn) as Base;
          conn.InsertSql(obj, CamposInsertar);
      }
      public static string ObtenerLista(Type tipo)
      {
          Connection conn = new Connection(Session.CONNECTION_STRING);
          Base obj = System.Activator.CreateInstance(tipo, conn) as Base;
          DataTable table = conn.SelectLista(obj);

          string jTable = ToJSON(table);

          conn.Close();

          return jTable;

      }
      private static string ObetenerObjeto(int oidObjeto, Type type)
      {
          Connection conn = new Connection(Session.CONNECTION_STRING);
          Base obj = System.Activator.CreateInstance(type, conn) as Base;
          DataTable table = conn.SelectObjeto(oidObjeto, obj);

          string Objeto = ToJSON(table);

          conn.Close();

          return Objeto;
      }
      private static void ActualizarObjeto(int OidObjeto, Type type, List<Campos> CamposActualizar)
      {
          Connection conn = new Connection(Session.CONNECTION_STRING);
          Base obj = System.Activator.CreateInstance(type, conn) as Base;
          conn.ActualizarObjeto(obj, OidObjeto, CamposActualizar);
      }

      private static string ToJSON(DataTable table)
      {
          System.Web.Script.Serialization.JavaScriptSerializer serializer = new

             System.Web.Script.Serialization.JavaScriptSerializer();
          List<Dictionary<string, object>> rows =
            new List<Dictionary<string, object>>();
          Dictionary<string, object> row = null;

          foreach (DataRow dr in table.Rows)
          {
              row = new Dictionary<string, object>();
              foreach (DataColumn col in table.Columns)
              {
                  if (dr[col] is System.DBNull)
                      row.Add(col.ColumnName.Trim(), "");
                  else
                      row.Add(col.ColumnName.Trim(), dr[col]);
              }
              rows.Add(row);
          }
          return serializer.Serialize(rows);
      }

        public static void insertAfanadora(string Nombre, int Telefono, DateTime FechaNacimiento, string Correo)
        {


            List<Campos> CamposInsertar = new List<Campos>();
           
            CamposInsertar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposInsertar.Add(new Campos() { Campo = "Telefono", Valor = Telefono });
            CamposInsertar.Add(new Campos() { Campo = "FechaNacimiento", Valor = FechaNacimiento });
            CamposInsertar.Add(new Campos() { Campo = "Correo", Valor = Correo });

                Insertar(typeof(Afanadora), CamposInsertar);
             

        }

        public static void insertCirugia(string Nombre, string Especialidad)
        {
            List<Campos> CamposInsertar = new List<Campos>();

            CamposInsertar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposInsertar.Add(new Campos() { Campo = "Especialidad", Valor = Especialidad });
          

           Insertar(typeof(Cirugia), CamposInsertar);
           
        }

        public static void insertEnfermeria(string Nombre, DateTime FechaNacimiento, int Telefono, string Especialidad, string Correo)
        {
            List<Campos> CamposInsertar = new List<Campos>();

            CamposInsertar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposInsertar.Add(new Campos() { Campo = "FechaNacimiento", Valor = FechaNacimiento });
            CamposInsertar.Add(new Campos() { Campo = "Telefono", Valor = Telefono });
            CamposInsertar.Add(new Campos() { Campo = "Especialidad", Valor = Especialidad });
            CamposInsertar.Add(new Campos() { Campo = "Correo", Valor = Correo });


            Insertar(typeof(Enfermeria), CamposInsertar);
            
        }



        public static void insertMedico(string Nombre, DateTime FechaNacimiento, int Telefono, string Especialidad, int Cedula, string Correo)
        {
            List<Campos> CamposInsertar = new List<Campos>();

            CamposInsertar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposInsertar.Add(new Campos() { Campo = "FechaNacimiento", Valor = FechaNacimiento });
            CamposInsertar.Add(new Campos() { Campo = "Telefono", Valor = Telefono });
            CamposInsertar.Add(new Campos() { Campo = "Especialidad", Valor = Especialidad });
            CamposInsertar.Add(new Campos() { Campo = "Cedula", Valor = Cedula });
            CamposInsertar.Add(new Campos() { Campo = "Correo", Valor = Correo });

            Insertar(typeof(Medico), CamposInsertar);
            
        }

        public static void insertQuirofano(string Nombre)
        {
            List<Campos> CamposInsertar = new List<Campos>();

            CamposInsertar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            Insertar(typeof(Quirofano), CamposInsertar);
        }

        public static void insertProgramacion(DateTime FechayHora, string NombrePaciente, DateTime FechaNacimientoPaciente, int Cirugia, int Quirofano, int Cirujano, int Anestesia, int Ayudante1, int Ayudante2, int Ayudante3, int Instrumentista, int Circulante1, int Circulante2, int Afanadora)
        {
            List<Campos> CamposInsertar = new List<Campos>();

            CamposInsertar.Add(new Campos() { Campo = "FechayHora", Valor = FechayHora });
            CamposInsertar.Add(new Campos() { Campo = "NombrePaciente", Valor = NombrePaciente });
            CamposInsertar.Add(new Campos() { Campo = "FechaNacimientoPaciente", Valor = FechaNacimientoPaciente });
            CamposInsertar.Add(new Campos() { Campo = "Cirugia", Valor = Cirugia });
            CamposInsertar.Add(new Campos() { Campo = "Quirofano", Valor = Quirofano });
            CamposInsertar.Add(new Campos() { Campo = "Cirujano", Valor = Cirujano });
            CamposInsertar.Add(new Campos() { Campo = "Anestesia", Valor = Anestesia });
            CamposInsertar.Add(new Campos() { Campo = "Ayudante1", Valor = Ayudante1 });
            CamposInsertar.Add(new Campos() { Campo = "Ayudante2", Valor = Ayudante2 });
            CamposInsertar.Add(new Campos() { Campo = "Ayudante3", Valor = Ayudante3 });
            CamposInsertar.Add(new Campos() { Campo = "Instrumentista", Valor = Instrumentista });
            CamposInsertar.Add(new Campos() { Campo = "Circulante", Valor = Circulante1 });
            CamposInsertar.Add(new Campos() { Campo = "Circulante2", Valor = Circulante2 });
            CamposInsertar.Add(new Campos() { Campo = "Afanadora", Valor = Afanadora });
            Insertar(typeof(Programacion), CamposInsertar);
            
        }

        public static string ObtenerAfanadoras()
        {
            return ObtenerLista(typeof(Afanadora));
        }
        public static string ObtenerEnfermeria()
        {
            return ObtenerLista(typeof(Enfermeria));
        }
        public static string ObtenerMedicos()
        {
            return ObtenerLista(typeof(Medico));
        }
        public static string ObtenerQuirofanos()
        {
            return ObtenerLista(typeof(Quirofano));
        }
        public static string ObtenerCirugias()
        {
            return ObtenerLista(typeof(Cirugia));
        }


        public static string ObtenerAfanadora(int OidAfanadora)
        {
            return ObetenerObjeto(OidAfanadora, typeof(Afanadora));
        }
        public static string ObtenerCirugia(int OidCirugia)
        {
            return ObetenerObjeto(OidCirugia, typeof(Cirugia));
        }
        public static string ObtenerEnfermero(int OidEnfermeria)
        {
            return ObetenerObjeto(OidEnfermeria, typeof(Enfermeria));
        }
        public static string ObtenerMedico(int OidMedico)
        {
            return ObetenerObjeto(OidMedico, typeof(Medico));
        }
        public static string ObtenerQuirofano(int OidQuirofano)
        {
            return ObetenerObjeto(OidQuirofano, typeof(Quirofano));
        }

        public static void ModificarAfanadora(int OidAfanadora, string Nombre, int Telefono, DateTime FechaNacimiento, string Correo)
        {
            List<Campos> CamposActualizar = new List<Campos>();
            CamposActualizar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposActualizar.Add(new Campos() { Campo = "Telefono", Valor = Telefono });
            CamposActualizar.Add(new Campos() { Campo = "FechaNacimiento", Valor = FechaNacimiento });
            CamposActualizar.Add(new Campos() { Campo = "Correo", Valor = Correo });

            ActualizarObjeto(OidAfanadora, typeof(Afanadora), CamposActualizar);
        }
        public static void ModificarCirugia(int OidACirugia, string Nombre, int Especialidad)
        {
            List<Campos> CamposActualizar = new List<Campos>();
            CamposActualizar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposActualizar.Add(new Campos() { Campo = "Especialidad", Valor = Especialidad });


            ActualizarObjeto(OidACirugia, typeof(Cirugia), CamposActualizar);
        }
        public static void ModificarEnfermeria(int OidEnfermeria, string Nombre, DateTime FechaNacimiento, int Telefono, string Especialidad, string Correo)
        {
            List<Campos> CamposActualizar = new List<Campos>();
            CamposActualizar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposActualizar.Add(new Campos() { Campo = "FechaNacimiento", Valor = FechaNacimiento });
            CamposActualizar.Add(new Campos() { Campo = "Telefono", Valor = Telefono });
            CamposActualizar.Add(new Campos() { Campo = "Especialidad", Valor = Especialidad });
            CamposActualizar.Add(new Campos() { Campo = "Correo", Valor = Correo });

            ActualizarObjeto(OidEnfermeria, typeof(Enfermeria), CamposActualizar);
           
        }
        public static void ModificarMedico(int OidMedico, string Nombre, DateTime FechaNacimiento, int Telefono, string Cedula, string Especialidad, string Correo)
        {
            List<Campos> CamposActualizar = new List<Campos>();
            CamposActualizar.Add(new Campos() { Campo = "Nombre", Valor = Nombre });
            CamposActualizar.Add(new Campos() { Campo = "FechaNacimiento", Valor = FechaNacimiento });
            CamposActualizar.Add(new Campos() { Campo = "Telefono", Valor = Telefono });
            CamposActualizar.Add(new Campos() { Campo = "Especialidad", Valor = Especialidad });
            CamposActualizar.Add(new Campos() { Campo = "Correo", Valor = Correo });
            CamposActualizar.Add(new Campos() { Campo = "Cedula", Valor = Cedula });

            ActualizarObjeto(OidMedico, typeof(Medico), CamposActualizar);
        }



















        
    }
}
