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
    public partial class ctrlPersonCard : UserControl
    {
       
        public ctrlPersonCard()
        {
            InitializeComponent();
            
        }

        private ClsPerson _Person;

        public void LoadPersonInfo(int PersonID)
        {
            if (PersonID == -1)
                return;

            _Person = ClsPerson.Find(PersonID);

            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            lblNationalNO.Text = _Person.NationalNo;

            if (_Person.Gendor == 0)
                lblGendor.Text = "Male";
            else
                lblGendor.Text = "Female";

            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.Nationality.ToString();

            if (_Person.ImagePath != "")
                pbPersonPicture.Load(_Person.ImagePath);

        }
    }
}
