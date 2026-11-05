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
    public partial class frmShowUserDetails : Form
    {

        public int UserID { get; set; }

        public frmShowUserDetails( int userID )
        {
            InitializeComponent();

            UserID = userID;

            ctrlUserInfo1.LoadUserInfo(UserID);
        }

        




    }
}
