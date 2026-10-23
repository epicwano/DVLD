using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People
{
    public partial class frmListPepole : Form
    {
        public frmListPepole()
        {
            InitializeComponent();
        }

        enum enFilterBy {None = 0,PersonID = 1, NationalNo = 2, FirstName = 3, SecondName = 4, ThirdName = 5, LastName = 6,
            CountryName = 7, Gendor = 8, Email = 9, Phone = 10 }

        DataView DV;
        enFilterBy Filter = (enFilterBy)0;
        

        private string FilterdDataView()
        {
            if (mtxtQueryParameter.Text == "")
                return "";
            else if (Filter == (enFilterBy)1)
                return Filter.ToString() + " = " + mtxtQueryParameter.Text;


            return Filter.ToString() + " like '" + mtxtQueryParameter.Text.Trim() + "%'"; 
            

            
        }

        private void _RefreshPeopleList()
        {
            DV = ClsPerson.GetAllPepole().DefaultView;
            dgvListPeople.DataSource = DV;
            lblTotalRecords.Text = dgvListPeople.RowCount.ToString();
        }

        private void _Load()
        {
            _RefreshPeopleList();
            DV.Table.CaseSensitive = false;
            cbFliterBy.SelectedIndex = 0;

            
        }

        private void frmListPepole_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void cbFliterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFliterBy.SelectedIndex == 0)
                mtxtQueryParameter.Visible = false;
            else if (cbFliterBy.SelectedIndex == 1)
            {
                mtxtQueryParameter.Visible = true;
                mtxtQueryParameter.Mask = "000000";
            }
            else
            {
                mtxtQueryParameter.Visible = true;
                mtxtQueryParameter.Mask = "";
            }

            Filter = (enFilterBy)cbFliterBy.SelectedIndex;

        }

        private void mtxtQueryParameter_TextChanged(object sender, EventArgs e)
        {
            DV.RowFilter = FilterdDataView();
            lblTotalRecords.Text = dgvListPeople.RowCount.ToString();
        }

        private void btnCloseManagePeopleForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Srue you want to delete this Person","Confrimtion",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ClsPerson.Delete((int)dgvListPeople.CurrentRow.Cells[0].Value) == true)
                {
                    MessageBox.Show("Person With ID " + (int)dgvListPeople.CurrentRow.Cells[0].Value + "Deleted succssfully");
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Cannot delete this person because he is involve with other things");
                }
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Fauture is not Ready Yet");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Fauture is not Ready Yet");
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson(-1);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson(-1);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
    }
}
