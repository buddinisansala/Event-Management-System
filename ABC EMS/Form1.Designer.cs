namespace ABC_EMS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAdduser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.aBCDataSet = new ABC_EMS.ABCDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new ABC_EMS.ABCDataSetTableAdapters.UsersTableAdapter();
            this.dgvUserlist = new System.Windows.Forms.DataGridView();
            this.btnLoaduser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aBCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserlist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdduser
            // 
            this.btnAdduser.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdduser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdduser.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdduser.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdduser.Location = new System.Drawing.Point(12, 129);
            this.btnAdduser.Name = "btnAdduser";
            this.btnAdduser.Size = new System.Drawing.Size(262, 46);
            this.btnAdduser.TabIndex = 0;
            this.btnAdduser.Text = "Add User";
            this.btnAdduser.UseVisualStyleBackColor = false;
            this.btnAdduser.Click += new System.EventHandler(this.btnAdduser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMIN PANEL - ABC(pvt) ltd";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoaduser);
            this.groupBox1.Controls.Add(this.dgvUserlist);
            this.groupBox1.Location = new System.Drawing.Point(321, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 475);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 370);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1056, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 63);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // aBCDataSet
            // 
            this.aBCDataSet.DataSetName = "ABCDataSet";
            this.aBCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.aBCDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // dgvUserlist
            // 
            this.dgvUserlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserlist.Location = new System.Drawing.Point(16, 105);
            this.dgvUserlist.Name = "dgvUserlist";
            this.dgvUserlist.RowTemplate.Height = 24;
            this.dgvUserlist.Size = new System.Drawing.Size(794, 350);
            this.dgvUserlist.TabIndex = 1;
            // 
            // btnLoaduser
            // 
            this.btnLoaduser.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaduser.Location = new System.Drawing.Point(16, 21);
            this.btnLoaduser.Name = "btnLoaduser";
            this.btnLoaduser.Size = new System.Drawing.Size(794, 46);
            this.btnLoaduser.TabIndex = 2;
            this.btnLoaduser.Text = "Load / Refresh Users";
            this.btnLoaduser.UseVisualStyleBackColor = true;
            this.btnLoaduser.Click += new System.EventHandler(this.btnLoaduser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdduser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ABC(Pvt) Ltd - Admin Panal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aBCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdduser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button1;
        private ABCDataSet aBCDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private ABCDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.DataGridView dgvUserlist;
        private System.Windows.Forms.Button btnLoaduser;
    }
}

