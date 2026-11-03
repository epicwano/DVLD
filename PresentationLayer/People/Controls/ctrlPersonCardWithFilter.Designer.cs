namespace PresentationLayer.People.Controls
{
    partial class ctrlPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctrlPersonCard1 = new PresentationLayer.People.Controls.ctrlPersonCard();
            this.gbFilterPerson = new System.Windows.Forms.GroupBox();
            this.mtxtSelectedPerson = new System.Windows.Forms.MaskedTextBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.cbFIlterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilterPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 129);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(780, 323);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // gbFilterPerson
            // 
            this.gbFilterPerson.Controls.Add(this.mtxtSelectedPerson);
            this.gbFilterPerson.Controls.Add(this.btnAddNewPerson);
            this.gbFilterPerson.Controls.Add(this.btnFindPerson);
            this.gbFilterPerson.Controls.Add(this.cbFIlterBy);
            this.gbFilterPerson.Controls.Add(this.label1);
            this.gbFilterPerson.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbFilterPerson.Location = new System.Drawing.Point(12, 23);
            this.gbFilterPerson.Name = "gbFilterPerson";
            this.gbFilterPerson.Size = new System.Drawing.Size(757, 88);
            this.gbFilterPerson.TabIndex = 1;
            this.gbFilterPerson.TabStop = false;
            this.gbFilterPerson.Text = "Filter";
            // 
            // mtxtSelectedPerson
            // 
            this.mtxtSelectedPerson.Location = new System.Drawing.Point(339, 41);
            this.mtxtSelectedPerson.Mask = "000000";
            this.mtxtSelectedPerson.Name = "mtxtSelectedPerson";
            this.mtxtSelectedPerson.Size = new System.Drawing.Size(221, 27);
            this.mtxtSelectedPerson.TabIndex = 5;
            this.mtxtSelectedPerson.ValidatingType = typeof(int);
            this.mtxtSelectedPerson.Validated += new System.EventHandler(this.mtxtSelectedPerson_Validated);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Location = new System.Drawing.Point(686, 33);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(56, 41);
            this.btnAddNewPerson.TabIndex = 4;
            this.btnAddNewPerson.Text = "Add";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Location = new System.Drawing.Point(606, 33);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(56, 41);
            this.btnFindPerson.TabIndex = 3;
            this.btnFindPerson.Text = "find";
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // cbFIlterBy
            // 
            this.cbFIlterBy.FormattingEnabled = true;
            this.cbFIlterBy.Items.AddRange(new object[] {
            "PersonID",
            "NationalNO"});
            this.cbFIlterBy.Location = new System.Drawing.Point(151, 41);
            this.cbFIlterBy.Name = "cbFIlterBy";
            this.cbFIlterBy.Size = new System.Drawing.Size(157, 27);
            this.cbFIlterBy.TabIndex = 1;
            this.cbFIlterBy.SelectedIndexChanged += new System.EventHandler(this.cbFIlterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilterPerson);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(772, 468);
            this.gbFilterPerson.ResumeLayout(false);
            this.gbFilterPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gbFilterPerson;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.ComboBox cbFIlterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtSelectedPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
