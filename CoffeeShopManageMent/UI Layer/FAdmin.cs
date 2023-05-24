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
    public partial class FAdmin : Form
    {
        string connectionString = "Data Source=RIPSine;Initial Catalog=CafeManagementSystemt;Integrated Security=True";
        private BLBill Querry = new BLBill();
        string tableId;
        int EnableDelete;
        public FAdmin()
        {
            InitializeComponent();
        }

        private void FAdmin_Load(object sender, EventArgs e)
        {
            Querry.ShowALLBill(dtgvBill);
            Querry.ShowALLBillDetails(dtgvBillDetails);
            Querry.ShowALLCustomer(dtgvCustomer);
            Querry.ShowALLItem(dtgvItem);
            Querry.ShowALLLocus(dtgvLocus);
            Querry.ShowALLStaff(dtgvStaff);
            Querry.ShowALLStaffAccount(dtgvStaffAccount);
            Querry.ShowALLManagerAccount(dtgvMAccount);
            Querry.ShowALLManager(dtgvManager);
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

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            Querry.InsertBill(txtBill_id.Text, txtCustomer_id.Text, txtStaff_id.Text, txtTable_id.Text);
            Querry.ShowALLBill(dtgvBill);
            txtBill_id.Clear();
            txtCustomer_id.Clear();
            txtStaff_id.Clear();
            txtTable_id.Clear();
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete this Bill?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Querry.DeleteBill(txtBill_id.Text);
            }
            Querry.ShowALLBill(dtgvBill);
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

        private void reloadbtn_Click(object sender, EventArgs e)
        {
            Querry.ShowALLBill(dtgvBill);
            Querry.ShowALLBillDetails(dtgvBillDetails);
            Querry.ShowALLCustomer(dtgvCustomer);
            Querry.ShowALLItem(dtgvItem);
            Querry.ShowALLLocus(dtgvLocus);
            Querry.ShowALLStaff(dtgvStaff);
            Querry.ShowALLStaffAccount(dtgvStaffAccount);
            Querry.ShowALLManager(dtgvManager);
            Querry.ShowALLManagerAccount(dtgvStaffAccount);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tableId = textBox3.Text;
            DisplayTotal(tableId, label8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Solve for this bill?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Querry.UpdatePaidBillfortable(textBox3.Text);
            }
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

        private void addbilldetailsbtn_Click(object sender, EventArgs e)
        {
            Querry.UpdateBillDetails(txtbdTable_id.Text, item_id.Text, Convert.ToInt32(qualitytxt.Text));
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
        private void dtgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvItem.Rows[e.RowIndex];
                textBox13.Text = row.Cells[0].Value.ToString();
                textBox12.Text = row.Cells[1].Value.ToString();
                textBox14.Text = row.Cells[2].Value.ToString();
                textBox15.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dtgvBillDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvBillDetails.Rows[e.RowIndex];
                txtbdTable_id.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Querry.InsertItem(textBox13.Text, textBox12.Text, Convert.ToInt32(textBox14.Text), textBox15.Text);
            Querry.ShowALLItem(dtgvItem);
            textBox13.Clear();
            textBox12.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Querry.UpdateItem(textBox13.Text, textBox12.Text, Convert.ToInt32(textBox14.Text), textBox15.Text);
            Querry.ShowALLItem(dtgvItem);
        }

        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvCustomer.Rows[e.RowIndex];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox5.Text = row.Cells[1].Value.ToString();
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();
            }
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

        private void button9_Click(object sender, EventArgs e)
        {
            Querry.DeleteCustomer(textBox2.Text);
            Querry.ShowALLCustomer(dtgvCustomer);
        }

        private void dtgvLocus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvLocus.Rows[e.RowIndex];
                textBox4.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedItem.ToString())
            {
                case "Sitting":
                    Querry.UpdateTableStatus(textBox4.Text, "Sitting");
                    Querry.ShowALLLocus(dtgvLocus);
                    break;
                case "Available":
                    Querry.UpdateTableStatus(textBox4.Text, "Available");
                    Querry.ShowALLLocus(dtgvLocus);
                    break;
                default:
                    break;
            }
        }

        private void dtgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvStaff.Rows[e.RowIndex];
                textBox11.Text = row.Cells[0].Value.ToString();
                textBox10.Text = row.Cells[1].Value.ToString();
                textBox9.Text = row.Cells[2].Value.ToString();
                textBox8.Text = row.Cells[3].Value.ToString();
                textBox21.Text = row.Cells[4].Value.ToString();
                textBox22.Text = row.Cells[5].Value.ToString();
                textBox23.Text = row.Cells[6].Value.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Querry.InsertStaff(textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text, textBox21.Text, textBox22.Text, textBox23.Text);
            Querry.ShowALLStaff(dtgvStaff);
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox22.Clear();
            textBox23.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Querry.UpdateStaff(textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text, textBox21.Text, textBox22.Text, textBox23.Text);
            Querry.ShowALLStaff(dtgvStaff);
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox22.Clear();
            textBox23.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete this Staff and Account?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Querry.DeleteStaff(textBox11.Text);
                Querry.ShowALLStaff(dtgvStaff);
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
                textBox8.Clear();
                textBox22.Clear();
                textBox23.Clear();
            }
        }

        private void dtgvStaffAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvStaffAccount.Rows[e.RowIndex];
                textBox19.Text = row.Cells[0].Value.ToString();
                textBox18.Text = row.Cells[1].Value.ToString();
                textBox17.Text = row.Cells[2].Value.ToString();
                textBox20.Text = row.Cells[3].Value.ToString();
                textBox16.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Querry.InsertSAccount(textBox19.Text, textBox18.Text, textBox17.Text, textBox20.Text, textBox16.Text);
            Querry.ShowALLStaffAccount(dtgvStaffAccount);
            textBox19.Clear();
            textBox18.Clear();
            textBox17.Clear();
            textBox20.Clear();
            textBox16.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Querry.UpdateSAccount(textBox19.Text, textBox18.Text);
            Querry.ShowALLStaffAccount(dtgvStaffAccount);
            textBox19.Clear();
            textBox18.Clear();
            textBox17.Clear();
            textBox20.Clear();
            textBox16.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Querry.InsertMAccount(textBox35.Text, textBox34.Text, textBox33.Text, textBox26.Text, textBox32.Text);
            Querry.ShowALLManagerAccount(dtgvManager);
            textBox35.Clear();
            textBox34.Clear();
            textBox33.Clear();
            textBox26.Clear();
            textBox32.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Querry.InsertMAccount(textBox35.Text, textBox34.Text, textBox26.Text, textBox32.Text, textBox16.Text);
            Querry.ShowALLManagerAccount(dtgvManager);
            textBox35.Clear();
            textBox34.Clear();
            textBox26.Clear();
            textBox32.Clear();
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void dtgvManager_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvManager.Rows[e.RowIndex];
                textBox31.Text = row.Cells[0].Value.ToString();
                textBox30.Text = row.Cells[1].Value.ToString();
                textBox29.Text = row.Cells[2].Value.ToString();
                textBox28.Text = row.Cells[3].Value.ToString();
                textBox27.Text = row.Cells[4].Value.ToString();
                textBox25.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dtgvMAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvMAccount.Rows[e.RowIndex];
                textBox35.Text = row.Cells[0].Value.ToString();
                textBox34.Text = row.Cells[1].Value.ToString();
                textBox33.Text = row.Cells[2].Value.ToString();
                textBox26.Text = row.Cells[3].Value.ToString();
                textBox32.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}