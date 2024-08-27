using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegers
{
    public class DataBaseHelper
    {
        

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        public DataBaseHelper(string _stringConn)
        {
            string ConStr = ConfigurationManager.ConnectionStrings[_stringConn].ConnectionString;
            conn = new SqlConnection(ConStr);
            cmd = conn.CreateCommand();
        }

        public void Close()
        {
            conn.Close();
        }

        public void Open()
        {
            conn.Open();
        }

        public bool ExecuteNoNQuery(string _command, Dictionary<string, object> _dictio = null)
        {

            cmd.CommandText = _command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            if (_dictio != null && _dictio.Count > 0)
            {
                foreach (var keyValuePair in _dictio)
                {
                    SqlParameter par = new SqlParameter();
                    par.ParameterName = keyValuePair.Key;
                    par.Value = keyValuePair.Value;
                    cmd.Parameters.Add(par);
                }
            }

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            return false;
        }

        public DataSet ExecuteQuery(string _command, Dictionary<string, object> _dictio = null)
        {
            DataSet ds = new DataSet();
            cmd.CommandText = _command;
            cmd.CommandType = CommandType.StoredProcedure;
            if (_dictio != null && _dictio.Count > 0)
            {
                foreach (var keyValuePair in _dictio)
                {
                    SqlParameter par = new SqlParameter();
                    par.ParameterName = keyValuePair.Key;
                    par.Value = keyValuePair.Value;
                    cmd.Parameters.Add(par);
                }
            }
            adapter = new SqlDataAdapter(cmd);

            adapter.Fill(ds);


            return ds;
        }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }

        ~DataBaseHelper()
        {
            Close();
        }
    }
}

