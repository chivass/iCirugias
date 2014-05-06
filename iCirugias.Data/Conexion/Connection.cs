using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCirugias.Data.Conexion
{
    public class Connection
    {

        SqlConnection _SQLConn;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
            _SQLConn = new SqlConnection(_connectionString);
            _SQLConn.Open();
        }

        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        List<Base> ObjectsToSave;

        


      

        public void InsertSql(Base obj, List<Campos> CamposInsertar)
        {
            SqlCommand cmd;
            int count = 0;
            string sql = obj.CrearSqlInsert(CamposInsertar);

            try
            {
                cmd = new SqlCommand(sql, _SQLConn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();

            }
            catch { }
        }
        public DataTable SelectLista(Base obj)
        {
            SqlCommand cmd;
            string sql = obj.SelectListaSql();
            DataTable dataTable = null;
            try
            {
                cmd = new SqlCommand(sql, _SQLConn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                dataTable = new DataTable();
                dataTable.Load(dataReader);

            }
            catch
            {
                return null;
            }
            dataTable.TableName = obj.TableName();
            return dataTable;

        }
        public DataTable SelectObjeto(int oidObjeto, Base obj)
        {
            SqlCommand cmd;
            string sql = obj.SelectObjetoSql(oidObjeto);
            DataTable dataTable = null;
            try
            {
                cmd = new SqlCommand(sql, _SQLConn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                dataTable = new DataTable();
                dataTable.Load(dataReader);

            }
            catch
            {
                return null;
            }
            dataTable.TableName = obj.TableName();
            return dataTable;
        }
        public void ActualizarObjeto(Base obj, int OidObjeto, List<Campos> CamposActualizar)
        {
            SqlCommand cmd;
            int count = 0;
            string sql = obj.ActualizarObjetoSql(OidObjeto, CamposActualizar);

            try
            {
                cmd = new SqlCommand(sql, _SQLConn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();

            }
            catch { }
        }


        public void Close()
        {
        }





       
    }
}
