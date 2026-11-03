using BusinessLayer;
using PresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private bool IsVaildUser()
        {
            if (clsUser.IsUserExists(txtUserName.Text, txtPassword.Text) && clsUser.IsUserActive(txtUserName.Text, txtPassword.Text))
            {
                clsGlobal.CurrentUser = clsUser.Find(txtUserName.Text, txtPassword.Text);
                return true;
            }
            else
                return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (IsVaildUser())
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invaild UserName Or Password","Wrong!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
