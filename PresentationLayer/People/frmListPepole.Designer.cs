namespace PresentationLayer.People
{
    partial class frmListPepole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListPeople = new System.Windows.Forms.DataGridView();
            this.cmsControlPerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.btnCloseManagePeopleForm = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFliterBy = new System.Windows.Forms.ComboBox();
            this.mtxtQueryParameter = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).BeginInit();
            this.cmsControlPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 55F);
            this.label1.Location = new System.Drawing.Point(358, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage People";
            // 
            // dgvListPeople
            // 
            this.dgvListPeople.AllowUserToAddRows = false;
            this.dgvListPeople.AllowUserToDeleteRows = false;
            this.dgvListPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPeople.ContextMenuStrip = this.cmsControlPerson;
            this.dgvListPeople.Location = new System.Drawing.Point(12, 295);
            this.dgvListPeople.Name = "dgvListPeople";
            this.dgvListPeople.ReadOnly = true;
            this.dgvListPeople.Size = new System.Drawing.Size(1288, 287);
            this.dgvListPeople.TabIndex = 1;
            // 
            // cmsControlPerson
            // 
            this.cmsControlPerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewPersonToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.phoneCallToolStripMenuItem});
            this.cmsControlPerson.Name = "cmsControlPerson";
            this.cmsControlPerson.Size = new System.Drawing.Size(181, 158);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addNewPersonToolStripMenuItem.Text = "Add New Person";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.phoneCallToolStripMenuItem.Text = "Phone Call";
            this.phoneCallToolStripMenuItem.Click += new System.EventHandler(this.phoneCallToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.Location = new System.Drawing.Point(47, 610);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Records : ";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblTotalRecords.Location = new System.Drawing.Point(152, 610);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(28, 24);
            this.lblTotalRecords.TabIndex = 3;
            this.lblTotalRecords.Text = "??";
            // 
            // btnCloseManagePeopleForm
            // 
            this.btnCloseManagePeopleForm.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnCloseManagePeopleForm.Location = new System.Drawing.Point(1037, 588);
            this.btnCloseManagePeopleForm.Name = "btnCloseManagePeopleForm";
            this.btnCloseManagePeopleForm.Size = new System.Drawing.Size(181, 46);
            this.btnCloseManagePeopleForm.TabIndex = 4;
            this.btnCloseManagePeopleForm.Text = "Close";
            this.btnCloseManagePeopleForm.UseVisualStyleBackColor = true;
            this.btnCloseManagePeopleForm.Click += new System.EventHandler(this.btnCloseManagePeopleForm_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnAddNewPerson.Location = new System.Drawing.Point(1037, 206);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(132, 65);
            this.btnAddNewPerson.TabIndex = 5;
            this.btnAddNewPerson.Text = "Add";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label4.Location = new System.Drawing.Point(47, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Filter By  : ";
            // 
            // cbFliterBy
            // 
            this.cbFliterBy.FormattingEnabled = true;
            this.cbFliterBy.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "National NO.",
            "First Name",
            "Second Name",
            "Thrid Name",
            "Last Name",
            "Nationality",
            "Gendor",
            "Email",
            "Phone"});
            this.cbFliterBy.Location = new System.Drawing.Point(161, 250);
            this.cbFliterBy.Name = "cbFliterBy";
            this.cbFliterBy.Size = new System.Drawing.Size(200, 21);
            this.cbFliterBy.TabIndex = 7;
            this.cbFliterBy.SelectedIndexChanged += new System.EventHandler(this.cbFliterBy_SelectedIndexChanged);
            // 
            // mtxtQueryParameter
            // 
            this.mtxtQueryParameter.Location = new System.Drawing.Point(390, 250);
            this.mtxtQueryParameter.Name = "mtxtQueryParameter";
            this.mtxtQueryParameter.Size = new System.Drawing.Size(222, 20);
            this.mtxtQueryParameter.TabIndex = 9;
            this.mtxtQueryParameter.Visible = false;
            this.mtxtQueryParameter.TextChanged += new System.EventHandler(this.mtxtQueryParameter_TextChanged);
            // 
            // frmListPepole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 655);
            this.Controls.Add(this.mtxtQueryParameter);
            this.Controls.Add(this.cbFliterBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.btnCloseManagePeopleForm);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListPeople);
            this.Controls.Add(this.label1);
            this.Name = "frmListPepole";
            this.Text = "frmListPepole";
            this.Load += new System.EventHandler(this.frmListPepole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).EndInit();
            this.cmsControlPerson.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListPeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Button btnCloseManagePeopleForm;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFliterBy;
        private System.Windows.Forms.MaskedTextBox mtxtQueryParameter;
        private System.Windows.Forms.ContextMenuStrip cmsControlPerson;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
    }
}