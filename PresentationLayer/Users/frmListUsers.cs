using BusinessLayer;
using PresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Users
{
    public partial class frmListUsers : Form
    {
        public frmListUsers()
        {
            InitializeComponent();
        }

        private static DataTable _dtAllUsers = clsUser.GetAllUsers();

        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID","PersonID","FullName", "UserName", "IsActive");

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");
            dgvListAllUsers.DataSource = _dtUsers;
            lblTotalUsers.Text = dgvListAllUsers.RowCount.ToString();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dgvListAllUsers.DataSource = _dtUsers;
            lblTotalUsers.Text = dgvListAllUsers.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvListAllUsers.Rows.Count > 0)
            {
                dgvListAllUsers.Columns[0].HeaderText = "User ID";
                dgvListAllUsers.Columns[0].Width = 140;

                dgvListAllUsers.Columns[1].HeaderText = "Person ID";
                dgvListAllUsers.Columns[1].Width = 130;

                dgvListAllUsers.Columns[2].HeaderText = "Full Name";
                dgvListAllUsers.Columns[2].Width = 330;

                dgvListAllUsers.Columns[3].HeaderText = "User Name";
                dgvListAllUsers.Columns[3].Width = 225;

                dgvListAllUsers.Columns[4].HeaderText = "Is Active";
                dgvListAllUsers.Columns[4].Width = 100;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = !(cbFilterBy.Text == "None" || cbFilterBy.Text == "IsActive");
            cbFitlerValueWithIsActive.Visible = (cbFilterBy.Text == "IsActive");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            if (cbFitlerValueWithIsActive.Visible)
                cbFitlerValueWithIsActive.SelectedIndex = 0;


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text.Trim() == "" || cbFilterBy.Text == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblTotalUsers.Text = dgvListAllUsers.RowCount.ToString();
                return;
            }

            if (cbFilterBy.Text == "UserID" || cbFilterBy.Text == "PersonID")
                _dtUsers.DefaultView.RowFilter = $"{cbFilterBy.Text} = '{txtFilterValue.Text.Trim()}'";
            else
                _dtUsers.DefaultView.RowFilter = $"{cbFilterBy.Text} like '{txtFilterValue.Text.Trim()}%'";

            lblTotalUsers.Text = dgvListAllUsers.RowCount.ToString();

        }

        private void cbFitlerValueWithIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbFitlerValueWithIsActive.Text)
            {
                case "ALL":
                    _dtUsers.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    _dtUsers.DefaultView.RowFilter = "IsActive = 1";
                    break;

                case "No":
                    _dtUsers.DefaultView.RowFilter = "IsActive = 0";
                    break;

                default:
                    _dtUsers.DefaultView.RowFilter = "";
                    break;
            }



        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "UserID" || cbFilterBy.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAdddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewOrUpdateUser frm = new frmAddNewOrUpdateUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }
    }
}
