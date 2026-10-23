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

            TimeSpan ts = new TimeSpan(6570, 0, 0, 0);
            dtpDateOfBirth.MaxDate = DateTime.Now - ts;

            rbMale.Select();

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

        private bool _EmailFormat()
        {
            if (txtEmail.Text != "" && (txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com")))
                return true;
            else if (txtEmail.Text == "")
                return true;
            else
                return false;
   
        }

        private bool _Vaildtion(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                ErrorProvider.SetError(textBox, "Requried to fill");
                return true;
            }
            else
            {
                ErrorProvider.SetError(textBox, "");
                return false;
            }

        }

        private bool _IsPersonExsits(string NationalNO)
        {

            if (ClsPerson.isPersonExists(txtNationalNO.Text))
            {
                ErrorProvider.SetError(txtNationalNO, "National Number is used for anthoer person");
                return true;
            }
            else
            {
                ErrorProvider.SetError(txtNationalNO, "");
                return false;
            }

        }

        private bool _AcceptedData()
        {
            bool IsAccepted = true;

            if (_Vaildtion(txtFristName) && _Vaildtion(txtSecondName) && _Vaildtion(txtLastName))
                IsAccepted = false;

            if (_Vaildtion(txtNationalNO) || _IsPersonExsits(txtNationalNO.Text))
                IsAccepted = false;

            if (!_EmailFormat())
                IsAccepted = false;

            if (_Vaildtion(txtPhone) && _Vaildtion(txtAddress))
                IsAccepted = false;

            return IsAccepted; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_AcceptedData())
            {
                MessageBox.Show("Complete the Requried Fields First", "Information", MessageBoxButtons.OK);
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

        private void txt_Validated(object sender, EventArgs e)
        {
            _Vaildtion((TextBox)sender);
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            if (_EmailFormat() == false)
                ErrorProvider.SetError(txtEmail, "Invaild Email Format");
            else
                ErrorProvider.SetError(txtEmail, "");

        }

        private void txtNationalNO_Validated(object sender, EventArgs e)
        {
            _Vaildtion((TextBox)sender);

            _IsPersonExsits(txtNationalNO.Text);

        }
    }
}
