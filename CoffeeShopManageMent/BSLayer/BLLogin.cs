using CoffeeShopManageMent.Connects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManageMent.DataLayers
{
    public class BLLogin
    {
        string err;
        public BLLogin()
        {

        }
        public bool Check(string User, string Pass)
        {
            if (string.IsNullOrEmpty(Pass) || string.IsNullOrEmpty(User))
                return false;
            string sql = $"exec proc_CheckSAccount '','','0115132332','01'";
            DBMain db = new DBMain();
            DataSet a = new DataSet();
            try
            {
                a = db.ExecuteQueryDataSet(sql, CommandType.Text);
            }
            catch
            {
            }
            if (a.Tables.Count == 0)
                return false;
            if (a.Tables[0].Rows.Count != 1)
                return false;

            return true;
        }
        public bool Check(string User)
        {
            if (string.IsNullOrEmpty(User))
                return false;
            string sql = $"select * from NguoiDung where User_Name = '{User}'";
            DBMain db = new DBMain();
            DataSet a = new DataSet();
            try
            {
                a = db.ExecuteQueryDataSet(sql, CommandType.Text);
            }
            catch
            {
            }
            if (a.Tables.Count == 0)
                return false;
            if (a.Tables[0].Rows.Count != 1)
                return false;
            return true;
        }
        public bool ADD(string User, string Pass, string Name, string Addr)
        {
            DBMain db = new DBMain();
            if (string.IsNullOrEmpty(Pass) || string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Name))
                return false;
            if (string.IsNullOrEmpty(Addr))
                Addr = "";
            string sql = $"INSERT INTO NguoiDung (Ho_Ten,User_Name,Password,Dia_Chi,Admin) Values ('{Name}','{User}','{Pass}','{Addr}','False')";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref err);
        }
    }
}
