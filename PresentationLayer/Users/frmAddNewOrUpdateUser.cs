using BusinessLayer;
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
    public partial class frmAddNewOrUpdateUser : Form
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;
        private int _UserID = -1;
        private clsUser _User;

        public frmAddNewOrUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

        }

        public frmAddNewOrUpdateUser(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _UserID = UserID;

        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                _User = new clsUser();
            } 
            else
                lblTitle.Text = "Update User";


            txtUserName.Text = "";
            txtPassword.Text = "";
            chkIsActive.Checked = false;

            
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            
            if (_User == null)
            {
                MessageBox.Show("User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);

            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;

        }

        private void frmAddNewOrUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void txt_Validated(object sender, EventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {

            if (txtConfirmPassword.Text != txtPassword.Text)
                errorProvider1.SetError(txtConfirmPassword, "It dosen`t Match the Password");
            else
                errorProvider1.SetError(txtConfirmPassword, null);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Complete the Requried Fields First", "Information", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            _User.UserInfo = ClsPerson.Find(ctrlPersonCardWithFilter1.PersonID);

            _User.PersonID = _User.UserInfo.PersonID;

            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;


            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();

                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully", "Confirmtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, Data Wasn`t Save Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void btnMoveToNextTap_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                errorProvider1.SetError(btnSave, "You Must Connect the User to a person");
                return;
            }
            else
                errorProvider1.SetError(btnSave, null);

            tapControl.SelectedTab = tpUserInfo;

        }
    }
}
