using CoffeeShopManageMent.Connects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManageMent.BSLayer
{
    public class BLBill
    {
        public BLBill() { }
        SqlConnection conn = new SqlConnection("Data Source=RIPSine;Initial Catalog=CafeManagementSystemt;Integrated Security=True");
        public void ShowALLBill(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from Bill", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        private void DisplayTotal(string tableId, Label a)
        {
            string connectionString = "Data Source=RIPSine;Initial Catalog=CafeManagementSystemt;Integrated Security=True";
            string queryString = "SELECT Total FROM dbo.fn_CalPriceForTable(@Table_Id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Table_Id", tableId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    a.Text = reader["Total"].ToString();
                }

                reader.Close();
            }
        }
        public void ShowALLBillDetails(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from BillDetails", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void ShowALLCustomer(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from Customer", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void ShowALLItem(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from Item", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void ShowALLLocus(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from Locus", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void ShowALLStaff(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from Staff", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void ShowALLManager(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from Manager", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void ShowALLStaffAccount(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from SAccount", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void ShowALLManagerAccount(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select * from MAccount", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }

        public void InsertBill(string bill_id, string customer_id, string staff_id, string table_id)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertBill", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bill_Id", bill_id);
            cmd.Parameters.AddWithValue("@Customer_Id", customer_id);
            cmd.Parameters.AddWithValue("@Staff_id", staff_id);
            cmd.Parameters.AddWithValue("@Table_Id", table_id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdateBillDetails(string Billid, string Itemid, int Quanlity)
        {
            SqlCommand cmd = new SqlCommand("UpdateBillDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Billid", Billid);
            cmd.Parameters.AddWithValue("@Itemid", Itemid);
            cmd.Parameters.AddWithValue("@Quanlity", Quanlity);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void InsertCustomer(string Customer_Id, string Customer_Name, string PhoneNum, string CustomerType_Id)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertCustomer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Customer_Id", Customer_Id);
            cmd.Parameters.AddWithValue("@Customer_Name", Customer_Name);
            cmd.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            cmd.Parameters.AddWithValue("@CustomerType_Id", CustomerType_Id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdateStaff(string Staff_id, string Staff_Name, string PhoneNum, string Gender, string CustomerType_Id, string ManagerId, string Position)
        {
            SqlCommand cmd = new SqlCommand("[proc_UpdateStaff]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Staff_id", Staff_id);
            cmd.Parameters.AddWithValue("@New_Staff_Name", Staff_Name);
            cmd.Parameters.AddWithValue("@New_PhoneNum", PhoneNum);
            cmd.Parameters.AddWithValue("@New_Gender", Gender);
            cmd.Parameters.AddWithValue("@New_Address", CustomerType_Id);
            cmd.Parameters.AddWithValue("@New_ManagerId", ManagerId);
            cmd.Parameters.AddWithValue("@New_Position", Position);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void DeleteStaff(string Staff_id)
        {
            SqlCommand cmd = new SqlCommand("[proc_DeleteStaff]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Staff_id", Staff_id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void InsertStaff(string Staff_id, string Staff_Name, string PhoneNum, string Gender, string CustomerType_Id, string ManagerId, string Position)
        {
            SqlCommand cmd = new SqlCommand("[proc_InsertStaff]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Staff_id", Staff_id);
            cmd.Parameters.AddWithValue("@Staff_Name", Staff_Name);
            cmd.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Address", CustomerType_Id);
            cmd.Parameters.AddWithValue("@ManagerId", ManagerId);
            cmd.Parameters.AddWithValue("@Position", Position);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void InsertSAccount(string UserName, string Pass, string ManagerId, string posiitionid, string position)
        {
            SqlCommand cmd = new SqlCommand("[proc_InsertSAccount]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Pass", Pass);
            cmd.Parameters.AddWithValue("@Managerid", ManagerId);
            cmd.Parameters.AddWithValue("@posiitionid", posiitionid);
            cmd.Parameters.AddWithValue("@position", position);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void InsertMAccount(string UserName, string Pass, string Managerid, string posiitionid, string position)
        {
            SqlCommand cmd = new SqlCommand("[proc_InsertMAccount]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Pass", Pass);
            cmd.Parameters.AddWithValue("@Managerid", Managerid);
            cmd.Parameters.AddWithValue("@posiitionid", posiitionid);
            cmd.Parameters.AddWithValue("@position", position);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdateSAccount(string UserName, string Pass)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateSAccount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Pass", Pass);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void InsertItem(string Item_Id, string Item_Name, int Price, string ItemType_Id)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Item_Id", Item_Id);
            cmd.Parameters.AddWithValue("@Item_Name", Item_Name);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@ItemType_Id", ItemType_Id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdateBill(string bill_id, string new_customer_id, string new_staff_id, string new_table_id)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateBill", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bill_Id", bill_id);
            cmd.Parameters.AddWithValue("@New_Customer_Id", new_customer_id);
            cmd.Parameters.AddWithValue("@New_Staff_id", new_staff_id);
            cmd.Parameters.AddWithValue("@New_Table_Id", new_table_id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdateItem(string Item_Id, string Item_Name, int Price, string ItemType_Id)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Item_Id", Item_Id);
            cmd.Parameters.AddWithValue("@New_Item_Name", Item_Name);
            cmd.Parameters.AddWithValue("@New_Price", Price);
            cmd.Parameters.AddWithValue("@New_ItemType_Id", ItemType_Id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdateCustomer(string Customer_Id, string Customer_Name, string PhoneNum, string CustomerType_Id)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateCustomer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Customer_Id", Customer_Id);
            cmd.Parameters.AddWithValue("@New_Customer_Name", Customer_Name);
            cmd.Parameters.AddWithValue("@New_PhoneNum", PhoneNum);
            cmd.Parameters.AddWithValue("@New_CustomerType_Id", CustomerType_Id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdatePaidBill(string bill_id)
        {
            SqlCommand cmd = new SqlCommand("[proc_UpdatePaidBill]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bill_Id", bill_id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdatePaidBillfortable(string tablepaid_id)
        {
            SqlCommand cmd = new SqlCommand("[proc_UpdatePaidBillforTable]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tablepaid_id", tablepaid_id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void UpdateTableStatus(string Table_Id, string NewStatus)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateLocus_Status", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Table_Id", Table_Id);
            cmd.Parameters.AddWithValue("@NewStatus", NewStatus);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void DeleteBill(string Bill_ID)
        {
            SqlCommand cmd = new SqlCommand("[proc_DeleteBill]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bill_ID", Bill_ID);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void DeleteCustomer(string Customer_Id)
        {
            SqlCommand cmd = new SqlCommand("proc_DeleteCustomer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Customer_Id", Customer_Id);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void SelectUnpaidBill(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select* from bill where Bill_Status = 'Unpaid'", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void SelectPaidBill(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select* from bill where Bill_Status = 'Paid'", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void CheckPriceTable(DataGridView DataGrid)
        {
            DataTable dtBill = new DataTable();
            dtBill.Clear();
            DBMain db = new DBMain();
            DataSet a = db.ExecuteQueryDataSet("select* from bill where Bill_Status = 'Paid'", CommandType.Text);
            dtBill = a.Tables[0];
            DataGrid.DataSource = dtBill;
        }
        public void Calbillprice(DataGridView DataGrid)
        {
        }
    }
}