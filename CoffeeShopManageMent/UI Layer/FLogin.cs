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
    public partial class FLogin : Form
    {

        public FLogin()
        {
            InitializeComponent();
        }

        private void Check()
        {
        }

        private void UserBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Check();
        }

        private void PassWordBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Check();
        }

        private void SignUpLabel_Click(object sender, EventArgs e)
        {
            //FStaff.ENASIG = true;
            this.Dispose();
        }

        private void FLoginBut_Click(object sender, EventArgs e)
        {

            if (UserBox.Text.StartsWith("S"))
            {
                FStaff form2 = new FStaff();
                form2.Show();
            }
            else if (UserBox.Text.StartsWith("M"))
            {
                FManager form3 = new FManager();
                form3.Show();
            }
            else if (UserBox.Text.StartsWith("A"))
            {
                FAdmin form4 = new FAdmin();
                form4.Show();
            }
            else
                MessageBox.Show("Not True Account");
        }

        private void ShowPassCheck_Click(object sender, EventArgs e)
        {
            this.PasswordBox.UseSystemPasswordChar = !this.ShowPassCheck.Checked;
        }
    }
}
