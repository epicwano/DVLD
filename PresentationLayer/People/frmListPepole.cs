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
    public partial class frmListPepole : Form
    {
        public frmListPepole()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            dgvListPeople.DataSource = ClsPerson.GetAllPepole();
            lblTotalRecords.Text = dgvListPeople.RowCount.ToString();
        }

        private void frmListPepole_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }
    }
}
