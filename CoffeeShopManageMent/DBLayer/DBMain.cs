using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopManageMent.BSLayer;

namespace CoffeeShopManageMent.Connects
{
    class DBMain
    {
        string connectionString = "Data Source=RIPSine;Initial Catalog=CafeManagementSystemt;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter dAdapt = null;
        public DBMain()
        {
            connection = new SqlConnection(connectionString);
            command = connection.CreateCommand();
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            command.CommandText = strSQL;
            command.CommandType = ct;
            dAdapt = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dAdapt.Fill(ds);
            return ds;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool f = false;
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            command.CommandText = strSQL;
            command.CommandType = ct;
            try
            {
                command.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return f;
        }

        public object MyExecuteScalar(string strSQL, CommandType ct, ref string error)
        {
            object f = new object();
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            command.CommandText = strSQL;
            command.CommandType = ct;

            try
            {
                f = command.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return f;

        }
    }
    
}
