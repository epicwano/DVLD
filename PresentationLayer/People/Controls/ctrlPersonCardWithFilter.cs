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

namespace PresentationLayer.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public ClsPerson SelectedPersonInfo
        {

            get { return ctrlPersonCard1.SelectedPersonInfo; }

        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFIlterBy.SelectedIndex = 0;
            mtxtSelectedPerson.Text = PersonID.ToString();

            FindNow();
        }

        private void FindNow()
        {
            switch (cbFIlterBy.Text)
            {
                case "PersonID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(mtxtSelectedPerson.Text));

                    break;

                case "NationalNo.":
                    ctrlPersonCard1.LoadPersonInfo(mtxtSelectedPerson.Text);
                    break;

                default:
                    break;
            }
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
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
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

        private void mtxtSelectedPerson_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtSelectedPerson.Text))
                errorProvider1.SetError(mtxtSelectedPerson, "This field is required!");
            else
                errorProvider1.SetError(mtxtSelectedPerson, null);


        }
    }




}
