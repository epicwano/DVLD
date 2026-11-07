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
    public partial class frmChangeUserPassword : Form
    {

        public clsUser User;

        public int UserID = -1;

        public frmChangeUserPassword( int userID )
        {
            InitializeComponent();

            UserID = userID;

        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {

            User = clsUser.Find(UserID);

            if (User == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserInfo1.LoadUserInfo(User.UserID);



        }

        private void txtCurrentPassword_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(txtCurrentPassword, "Current password is required.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            if (User.Password != txtCurrentPassword.Text)
                errorProvider1.SetError(txtCurrentPassword, "Incorrect Password");
            else
                errorProvider1.SetError(txtCurrentPassword, null);

        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match");
            else
                errorProvider1.SetError(txtConfirmPassword, null);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateChildren())
            {
                MessageBox.Show("Complete all required fields.", "Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User.Password = txtNewPassword.Text;

            if (User.Save())
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtNewPassword_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
            ;
        }
    }   


}
