namespace ABC_EMS
{
    partial class ManagerDashboard
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
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnParticipant = new System.Windows.Forms.Button();
            this.btnManageusers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEvents
            // 
            this.btnEvents.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvents.Location = new System.Drawing.Point(123, 153);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(189, 40);
            this.btnEvents.TabIndex = 0;
            this.btnEvents.Text = "Add Events";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnParticipant
            // 
            this.btnParticipant.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParticipant.Location = new System.Drawing.Point(400, 149);
            this.btnParticipant.Name = "btnParticipant";
            this.btnParticipant.Size = new System.Drawing.Size(170, 44);
            this.btnParticipant.TabIndex = 1;
            this.btnParticipant.Text = "Participants";
            this.btnParticipant.UseVisualStyleBackColor = true;
            this.btnParticipant.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManageusers
            // 
            this.btnManageusers.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageusers.Location = new System.Drawing.Point(654, 153);
            this.btnManageusers.Name = "btnManageusers";
            this.btnManageusers.Size = new System.Drawing.Size(189, 40);
            this.btnManageusers.TabIndex = 2;
            this.btnManageusers.Text = "Manage Users";
            this.btnManageusers.UseVisualStyleBackColor = true;
            this.btnManageusers.Click += new System.EventHandler(this.btnManageusers_Click);
            // 
            // ManagerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 621);
            this.Controls.Add(this.btnManageusers);
            this.Controls.Add(this.btnParticipant);
            this.Controls.Add(this.btnEvents);
            this.Name = "ManagerDashboard";
            this.Text = "ABC(pvt) ltd - Manager\'s Dashboard";
            this.Load += new System.EventHandler(this.ManagerDashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnParticipant;
        private System.Windows.Forms.Button btnManageusers;
    }
}