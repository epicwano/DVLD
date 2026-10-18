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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListPeople = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.btnCloseManagePeopleForm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFliterBy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).BeginInit();
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
            this.dgvListPeople.Location = new System.Drawing.Point(12, 295);
            this.dgvListPeople.Name = "dgvListPeople";
            this.dgvListPeople.ReadOnly = true;
            this.dgvListPeople.Size = new System.Drawing.Size(1288, 287);
            this.dgvListPeople.TabIndex = 1;
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
            this.btnCloseManagePeopleForm.Location = new System.Drawing.Point(1037, 588);
            this.btnCloseManagePeopleForm.Name = "btnCloseManagePeopleForm";
            this.btnCloseManagePeopleForm.Size = new System.Drawing.Size(181, 46);
            this.btnCloseManagePeopleForm.TabIndex = 4;
            this.btnCloseManagePeopleForm.Text = "button1";
            this.btnCloseManagePeopleForm.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1053, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 65);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
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
            this.cbFliterBy.Location = new System.Drawing.Point(161, 250);
            this.cbFliterBy.Name = "cbFliterBy";
            this.cbFliterBy.Size = new System.Drawing.Size(200, 21);
            this.cbFliterBy.TabIndex = 7;
            // 
            // frmListPepole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 655);
            this.Controls.Add(this.cbFliterBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCloseManagePeopleForm);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListPeople);
            this.Controls.Add(this.label1);
            this.Name = "frmListPepole";
            this.Text = "frmListPepole";
            this.Load += new System.EventHandler(this.frmListPepole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListPeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Button btnCloseManagePeopleForm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFliterBy;
    }
}