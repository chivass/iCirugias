using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCirugias.Data.Conexion;

namespace iCirugias.Data
{
    public class Base
    {
        public Base(Connection conn)
        {

        }

        public virtual string getSQLListView(int OidParent)
        {
            return getSQLSelect(OidParent);
        }

        public string getSQLSelect(int Oid)
        {
            Validate();
            return string.Format("SELECT * FROM {0} WHERE OID = {1}", TableName(), Oid);
        }
        private void Validate()
        {
            if (this.TableName() == "NoName")
                throw new NotImplementedException("Debe de implementar la funcion TableName para el tipo " + this.GetType().ToString());
        }
        public virtual string TableName()
        {
            return "NoName";
        }

        public virtual string CrearSqlInsert(List<Campos> CamposInsertar)
        {
           
            Validate();
            string campos = "";
            string valores = "";


            foreach (Campos p in CamposInsertar)
            {
                campos = campos + p.Campo + ",";
                valores = valores + ToSQLValueFormat(p.Valor) + ",";
            }

            campos = campos.Substring(0, campos.Length - 1);
            valores = valores.Substring(0, valores.Length - 1);

            string sql = "INSERT INTO {0} ({1}) VALUES ({2})";
            sql = string.Format(sql, TableName(), campos, valores);

            return sql;
        }
        public virtual string SelectObjetoSql(int oidObjeto)
        {
            Validate();
            return string.Format("SELECT * FROM {0} WHERE OID = {1}", TableName(), oidObjeto);

        }
        public virtual string ActualizarObjetoSql(int OidObjeto, List<Campos> CamposActualizar)
        {
            Validate();
            string cambios = "";

            foreach (Campos p in CamposActualizar)
            {
                cambios = cambios + string.Format("{0} = {1},", p.Campo, ToSQLValueFormat(p.Valor));
            }
            if (cambios.Length > 0)
                cambios = cambios.Substring(0, cambios.Length - 1);

            string sql = "UPDATE {0} SET {1} WHERE Oid = {2}";
            sql = string.Format(sql, TableName(), cambios, OidObjeto);

            return sql;
        }

        public virtual string SelectListaSql()
        {
            return ObtenerStringSelect();
        }

        private string ObtenerStringSelect()
        {
            Validate();
            return string.Format("SELECT * FROM {0}", TableName());
        }
        
        public string ToSQLValueFormat(object obj)
        {
            if (obj == null) return "null";
            string objType = obj.GetType().ToString();
            string strFormat = "null";
            switch (objType)
            {
                case "System.String":
                    strFormat = String.Format("'{0}'", obj);
                    break;
                case "System.Int32":
                    strFormat = obj.ToString();
                    break;
                case "System.Decimal":
                    strFormat = obj.ToString();
                    break;
                case "System.DateTime":
                    strFormat = String.Format("'{0:M/d/yyyy HH:mm:ss}'", obj);
                    break;
                default:
                    break;
            }

            return strFormat;
        }



        
    }
    public class Campos
    {
        public string Campo;
        public object Valor;
    }
}
