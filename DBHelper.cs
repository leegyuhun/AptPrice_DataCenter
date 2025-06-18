using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static AptPrice_DataCenter.Const.PrivateConsts;

namespace AptPrice_DataCenter
{
    internal class DBHelper: IDisposable
    {
        private readonly NpgsqlConnection _conn;
        public DBHelper()
        {
            _conn = new NpgsqlConnection(DB_CONNECTION_STRING);
            _conn.Open();
        }

        public DataTable SelectQuery(string Msql, params NpgsqlParameter[] parameters)
        {
            using (var cmd = new NpgsqlCommand(Msql, _conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public int ExecuteQuery(string Msql, params NpgsqlParameter[] parameters)
        {
            using (var cmd = new NpgsqlCommand(Msql, _conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();
            _conn.Dispose();
        }
    }
}
