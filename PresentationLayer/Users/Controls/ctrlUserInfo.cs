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

namespace PresentationLayer.Users.Controls
{
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        public clsUser User { get; set; }

        public int UserID { get; set; }

        public void LoadUserInfo(int userID)
        {
            UserID = userID;

            User = clsUser.Find(UserID);

            if (User == null)
            {
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonCard1.LoadPersonInfo(User.UserInfo.PersonID);

            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.UserName;
            lblIsActive.Text = User.IsActive ? "Yes" : "No";

        }


    }
}
