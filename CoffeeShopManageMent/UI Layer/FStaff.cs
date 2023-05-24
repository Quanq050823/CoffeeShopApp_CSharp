using CoffeeShopManageMent.BSLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManageMent.UI_Layer
{
    public partial class FStaff : Form
    {
        string connectionString = "Data Source=RIPSine;Initial Catalog=CafeManagementSystemt;Integrated Security=True";
        private BLBill Querry = new BLBill();
        string tableId;
        int EnableDelete;
        public FStaff()
        {
            InitializeComponent();
        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteBill_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {

        }

        private void dtgvBill_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dtgvBill_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void _1_Load(object sender, EventArgs e)
        {
            Querry.ShowALLBill(dtgvBill);
            Querry.ShowALLBillDetails(dtgvBillDetails);
            Querry.ShowALLCustomer(dtgvCustomer);
            Querry.ShowALLItem(dtgvItem);
            Querry.ShowALLLocus(dtgvLocus);
        }

        private void btnAddBill_Click_1(object sender, EventArgs e)
        {
            Querry.InsertBill(txtBill_id.Text, txtCustomer_id.Text, txtStaff_id.Text, txtTable_id.Text);
            Querry.ShowALLBill(dtgvBill);
            txtBill_id.Clear();
            txtCustomer_id.Clear();
            txtStaff_id.Clear();
            txtTable_id.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Querry.SelectUnpaidBill(dtgvBill);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Querry.SelectPaidBill(dtgvBill);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Querry.ShowALLBill(dtgvBill);
        }
        private void DisplayTotal(string tableId, Label a)
        {
            string queryString = "SELECT Total FROM dbo.fn_CalPriceForTable(@Table_Id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Table_Id", tableId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    a.Text = reader["Total"].ToString() + " VNĐ";

                }

                reader.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tableId = textBox3.Text;
            DisplayTotal(tableId, label8);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = textBox3.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT Total FROM BillDetails WHERE Id = @input", connection))
                {
                    command.Parameters.AddWithValue("@input", input);
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        label8.Text = result.ToString();
                    }
                }
            }
        }

        private void addbilldetailsbtn_Click(object sender, EventArgs e)
        {
            Querry.UpdateBillDetails(txtbdTable_id.Text, item_id.Text, Convert.ToInt32(qualitytxt.Text));
            Querry.ShowALLBillDetails(dtgvBillDetails);
        }

        private void reloadbtn_Click(object sender, EventArgs e)
        {
            Querry.ShowALLBill(dtgvBill);
            Querry.ShowALLBillDetails(dtgvBillDetails);
            Querry.ShowALLCustomer(dtgvCustomer);
            Querry.ShowALLItem(dtgvItem);
            Querry.ShowALLLocus(dtgvLocus);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Querry.InsertCustomer(textBox2.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            Querry.ShowALLCustomer(dtgvCustomer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Querry.UpdateCustomer(textBox2.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            Querry.ShowALLCustomer(dtgvCustomer);
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            string phoneNum = textBox24.Text; 
            string query = "SELECT * FROM [dbo].[fn_FindCustomerByPhone]('" + phoneNum + "')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgvCustomer.DataSource = table;
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            string stringtype = textBox1.Text;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Customer Phone":
                    string query = "SELECT * FROM [dbo].[fn_FindBillByCustomerPhone]('" + stringtype + "')";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dtgvBillDetails.DataSource = table;
                    }
                    break;
                case "Table ID":
                    string query2 = "SELECT * FROM [dbo].[fn_FindBillbyTable]('" + stringtype + "')";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(query2, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dtgvBillDetails.DataSource = table;
                    }
                        break;
                case "Staff ID":
                    string query3 = "SELECT * FROM [dbo].[fn_GetBillListByStaff]('" + stringtype + "')";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(query3, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dtgvBillDetails.DataSource = table;
                    }
                    break;
                // add more cases for other phone numbers
                default:
                    break;
            }
        }

        private void dtgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvBill.Rows[e.RowIndex];
                txtBill_id.Text = row.Cells[0].Value.ToString();
                txtCustomer_id.Text = row.Cells[1].Value.ToString();
                txtStaff_id.Text = row.Cells[2].Value.ToString();
                txtTable_id.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dtgvBillDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dtgvBillDetails.Rows[e.RowIndex];
            txtbdTable_id.Text = row.Cells[0].Value.ToString();
            item_id.Text = row.Cells[1].Value.ToString();
            qualitytxt.Text = row.Cells[2].Value.ToString();
        }

        private void dtgvcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dtgvCustomer.Rows[e.RowIndex];
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox5.Text = row.Cells[1].Value.ToString();
            textBox6.Text = row.Cells[2].Value.ToString();
            textBox7.Text = row.Cells[3].Value.ToString();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
