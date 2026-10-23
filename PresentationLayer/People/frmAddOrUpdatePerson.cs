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

namespace PresentationLayer.People
{
    public partial class frmAddOrUpdatePerson : Form
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;
        private int _PersonID = -1;
        private ClsPerson _Person;


        public frmAddOrUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if (PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }

        private void _FillCountriesInComboBox()
        {
            DataTable DTCountries = clsCountry.GetAllCountries();

            foreach (DataRow Row in DTCountries.Rows)
            {

                cbCountries.Items.Add(Row["CountryName"]);

            }

        }

        private void _Load()
        {
            _FillCountriesInComboBox();
            cbCountries.SelectedText = "Yemen";

            if (_Mode == enMode.AddNew)
            {
                lblAddOrUpdatePerson.Text = "Add New Person";
                _Person = new ClsPerson();
                return;
            }

            _Person = ClsPerson.Find(_PersonID);
            lblAddOrUpdatePerson.Text = "Update Person";

            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNO.Text = _Person.NationalNo;

            txtFristName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThridName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNO.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBrith;

            if (_Person.Gendor == 0)
                rbMale.Select();
            else
                rbFemale.Select();

            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;

            cbCountries.SelectedIndex = cbCountries.FindString(clsCountry.Find(_Person.Nationality).CountryName);

            txtAddress.Text = _Person.Address;

            if (_Person.ImagePath != "")
                pbPersonImage.Load(_Person.ImagePath);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Data Saved Successfully", "Confirmtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Error, Data Wasn`t Save Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                


            lblAddOrUpdatePerson.Text = "Update Person";
            _Mode = enMode.Update;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNO.Text = _Person.NationalNo;
        }

        private void frmAddOrUpdatePerson_Load(object sender, EventArgs e)
        {
            _Load();
        }
    }
}
