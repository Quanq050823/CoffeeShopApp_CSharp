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
    public partial class FStaff1 : Form
    {
        //DATA
        private BLBill Querry = new BLBill();
        int EnableDelete;
        public FStaff1()
        {
            InitializeComponent();
        }

        private void FBill_Load(object sender, EventArgs e)
        {
            Querry.ShowALLBill(dtgvBill);
            Querry.ShowALLBillDetails(dtgvBillDetails);
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            Querry.InsertBill(txtBill_id.Text, txtCustomer_id.Text, txtStaff_id.Text, txtTable_id.Text);
            Querry.ShowALLBill(dtgvBill);
        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {
            Querry.UpdateBill(txtBill_id.Text, txtCustomer_id.Text, txtStaff_id.Text, txtTable_id.Text);
            Querry.ShowALLBill(dtgvBill);
        }
        private void dtgvBill_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvBill.SelectedRows.Count > 0)
            {
                btnEditBill.Enabled = true;
                btnDeleteBill.Enabled = true;
            }
            else
            {
                btnEditBill.Enabled = false;
                btnDeleteBill.Enabled = false;
            }
        }

        private void btnDeleteBill_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete this item?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dtgvBill.Rows.RemoveAt(EnableDelete);
            }
        }

        private void dtgvBill_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EnableDelete = e.RowIndex;
        }

        private void dtgvBillDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Querry.SelectUnpaidBill(dtgvBill);
        }
    }
}
