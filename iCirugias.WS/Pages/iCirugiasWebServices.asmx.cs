using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

using iCirugias.Ayuda;



namespace iCirugias.WS.Pages
{
    /// <summary>
    /// Descripción breve de iCirugiasWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class iCirugiasWebServices : System.Web.Services.WebService
    {
        #region WebServiceParaInsertar

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertarAfanadora(string Nombre, int Telefono, DateTime FechaNacimiento, string Correo)
        {
           
            iCirugias.Ayuda.Utilerias.insertAfanadora(Nombre, Telefono, FechaNacimiento, Correo);

            return "1";
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertarCirugia(string Nombre, string Especialidad)
        {

            iCirugias.Ayuda.Utilerias.insertCirugia(Nombre, Especialidad);

            return "1";
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertarEnfermeria(string Nombre, DateTime FechaNacimiento, int Telefono,string Especialidad, string Correo)
        {

            iCirugias.Ayuda.Utilerias.insertEnfermeria(Nombre, FechaNacimiento,Telefono,Especialidad,Correo);

            return "1";
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertarMedico(string Nombre, DateTime FechaNacimiento, int Telefono, string Especialidad, int Cedula, string Correo)
        {

            iCirugias.Ayuda.Utilerias.insertMedico(Nombre, FechaNacimiento, Telefono, Especialidad, Cedula, Correo);

            return "1";
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertarQuirofano(string Nombre)
        {

            iCirugias.Ayuda.Utilerias.insertQuirofano(Nombre);

            return "1";
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertarProgramacion(DateTime FechayHora, string NombrePaciente,DateTime FechaNacimientoPaciente, int Cirugia, int Quirofano, int Cirujano, int Anestesia, int Ayudante1, int Ayudante2, int Ayudante3, int Instrumentista, int Circulante1, int Circulante2, int Afanadora )
        {

            iCirugias.Ayuda.Utilerias.insertProgramacion(FechayHora, NombrePaciente, FechaNacimientoPaciente, Cirugia, Quirofano, Cirujano, Anestesia, Ayudante1, Ayudante2, Ayudante3, Instrumentista, Circulante1, Circulante2, Afanadora);

            return "1";
        }

        #endregion

        #region WebServiceParaObtener


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerAfanadoras()
        {

           string Resultado= iCirugias.Ayuda.Utilerias.ObtenerAfanadoras();

            return Resultado;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerAfanadora(int OidAfanadora)
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerAfanadora(OidAfanadora);

            return Resultado;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerEnfermeria()
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerEnfermeria();

            return Resultado;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerMedicos()
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerMedicos();

            return Resultado;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerQuirofanos()
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerQuirofanos();

            return Resultado;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerCirugias()
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerCirugias();

            return Resultado;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerCirugia(int OidCirugia)
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerCirugia(OidCirugia);

            return Resultado;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerEnfermero(int OidEnfermeria)
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerEnfermero(OidEnfermeria);

            return Resultado;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerMedico(int OidMedico)
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerMedico(OidMedico);

            return Resultado;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObtenerQuirofano(int OidQuirofano)
        {

            string Resultado = iCirugias.Ayuda.Utilerias.ObtenerQuirofano(OidQuirofano);

            return Resultado;
        }

        #endregion

        #region WebServiceParaModificar

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ModificarAfanadora(int OidAfanadora, string Nombre, int Telefono, DateTime FechaNacimiento, string Correo)
        {

             iCirugias.Ayuda.Utilerias.ModificarAfanadora(OidAfanadora,Nombre,Telefono,FechaNacimiento,Correo);

            
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ModificarCirugia(int OidACirugia, string Nombre, int Especialidad)
        {

            iCirugias.Ayuda.Utilerias.ModificarCirugia(OidACirugia, Nombre, Especialidad);


        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ModificarEnfermeria(int OidEnfermeria, string Nombre, DateTime FechaNacimiento, int Telefono, string Especialidad, string Correo)
        {

            iCirugias.Ayuda.Utilerias.ModificarEnfermeria(OidEnfermeria, Nombre, FechaNacimiento, Telefono, Especialidad, Correo);


        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ModificarMedico(int OidMedico, string Nombre, DateTime FechaNacimiento, int Telefono, string Especialidad, string Cedula, string Correo)
        {

            iCirugias.Ayuda.Utilerias.ModificarMedico(OidMedico,Nombre,FechaNacimiento,Telefono,Cedula,Especialidad,Correo);


        }
        #endregion
    }
}
