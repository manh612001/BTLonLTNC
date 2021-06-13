using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BaiTapLon
{
    class ConnectionDB
    {
        public SqlConnection getConnect()
        {
            string str = @"Data Source=DESKTOP-201IC1A\SQLEXPRESS;Initial Catalog=QLyDiemSV;Integrated Security=True";
            return new SqlConnection(str);
        }
        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

       

        public DataSet getDS(String sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public void ExcuteNonQuery(String sql)
        {
            SqlConnection conn = getConnect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.Clone();
            conn.Close();
        }
        
    }
}
