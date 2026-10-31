using BusinessLayer;
using DVLD.Properties;
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
    public partial class ctrlPersonCard : UserControl
    {

        private ClsPerson _Person;

        private int _PersonID = -1;

        public int PersonID
        {

            get { return _PersonID; }

        }

        public ClsPerson SelectedPersonInfo
        {
            get { return  _Person; }
        }


        public ctrlPersonCard()
        {
            InitializeComponent();
            
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = ClsPerson.Find(PersonID);

            if (_Person == null)
            {

                MessageBox.Show("No Person with National No. = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }
        
        public void LoadPersonInfo(string NationalNO)
        {
            _Person = ClsPerson.Find(NationalNO);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNO.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBrith.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.Nationality).CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();

        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNO.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonPicture.Image = Resources.Male_512;

        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPersonPicture.Image = Resources.Male_512;
            else
                pbPersonPicture.Image = Resources.Female_512;

            if (_Person.ImagePath != "")
                pbPersonPicture.ImageLocation = _Person.ImagePath;

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson(_PersonID);
            frm.ShowDialog();

            LoadPersonInfo(_PersonID);
        }
    }


}
