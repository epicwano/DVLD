using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void cbFIlterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFIlterBy.SelectedIndex == 0)
                mtxtSelectedPerson.Mask = "000000";
            else
                mtxtSelectedPerson.Mask = "";

        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {

            if (cbFIlterBy.SelectedText == "PersonID")
                ctrlPersonCard1.LoadPersonInfo(int.Parse(mtxtSelectedPerson.Text));
            else
                ctrlPersonCard1.LoadPersonInfo(mtxtSelectedPerson.Text);


        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson();
            frm.DataBack += _DataBackEvent;
            frm.ShowDialog();
        }

        private void _DataBackEvent(object sender,int PersonID)
        {
            cbFIlterBy.SelectedIndex = 1;
            mtxtSelectedPerson.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }


    }




}
