using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People
{
    public partial class frmShowPersonDetails : Form
    {
        //private int _PersonID = -1;

        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            //_PersonID = PersonID;
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
    }
}
