using BusinessLayer;
using PresentationLayer.Properties;
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
    public partial class frmAddOrUpdatePerson : Form
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;
        private int _PersonID = -1;
        private ClsPerson _Person;


        public frmAddOrUpdatePerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

        }

        public frmAddOrUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;


        }

        private void _FillCountriesInComboBox()
        {
            DataTable DTCountries = clsCountry.GetAllCountries();

            foreach (DataRow Row in DTCountries.Rows)
            {

                cbCountries.Items.Add(Row["CountryName"]);

            }

        }

        private void _ResetDefualtValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblAddOrUpdatePerson.Text = "Add New Person";
                _Person = new ClsPerson();
            }
            else
            {
                lblAddOrUpdatePerson.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;


            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);


            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountries.SelectedIndex = cbCountries.FindString("Saudi Arabia");

            txtFristName.Text = "";
            txtSecondName.Text = "";
            txtThridName.Text = "";
            txtLastName.Text = "";
            txtNationalNO.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";


        }

        private void _LoadData()
        {

            _Person = ClsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNO.Text = _Person.NationalNo;

            txtFristName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThridName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNO.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBrith;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;

            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);

            txtAddress.Text = _Person.Address;

            if (_Person.ImagePath != "")
                pbPersonImage.Load(_Person.ImagePath);

            llRemoveImage.Visible = (_Person.ImagePath != "");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private bool _EmailFormat()
        {
            if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com"))
                return true;
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Complete the Requried Fields First", "Information", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            _Person.NationalNo = txtNationalNO.Text; 

            _Person.FirstName = txtFristName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThridName.Text;
            _Person.LastName = txtLastName.Text;

            if (rbMale.Checked)
                _Person.Gendor = 0;
            else
                _Person.Gendor = 1;

            _Person.DateOfBrith = dtpDateOfBirth.Value;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;

            _Person.Nationality = clsCountry.Find(cbCountries.Text).CountryID;

            _Person.Address = txtAddress.Text;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblAddOrUpdatePerson.Text = "Update Person";


                MessageBox.Show("Data Saved Successfully", "Confirmtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, Data Wasn`t Save Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void frmAddOrUpdatePerson_Load(object sender, EventArgs e)
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
                ErrorProvider.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                ErrorProvider.SetError(Temp, null);
            }
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;


            if (!_EmailFormat())
                ErrorProvider.SetError(txtEmail, "Invaild Email Format");
            else
                ErrorProvider.SetError(txtEmail, "");

        }

        private void txtNationalNO_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNO.Text.Trim()))
            {
                ErrorProvider.SetError(txtNationalNO, "This field is required!");
                return;
            }
            else
            {
                ErrorProvider.SetError(txtNationalNO, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationalNO.Text.Trim() != _Person.NationalNo && ClsPerson.isPersonExists(txtNationalNO.Text.Trim()))
            {
                ErrorProvider.SetError(txtNationalNO, "National Number is used for another person!");
            }
            else
            {
                ErrorProvider.SetError(txtNationalNO, null);
            }
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }
        }
    }
}
