namespace StealthClient
{
    partial class Authenticate
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
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnGetList = new System.Windows.Forms.Button();
            this.lbSessions = new System.Windows.Forms.ListBox();
            this.btnSelectSession = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(76, 12);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(163, 20);
            this.tbUser.TabIndex = 0;
            this.tbUser.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(76, 38);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(163, 20);
            this.tbPass.TabIndex = 1;
            this.tbPass.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 15);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Username:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(14, 41);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(56, 13);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Password:";
            // 
            // btnGetList
            // 
            this.btnGetList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetList.Enabled = false;
            this.btnGetList.Location = new System.Drawing.Point(76, 64);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(163, 24);
            this.btnGetList.TabIndex = 4;
            this.btnGetList.Text = "Get List";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // lbSessions
            // 
            this.lbSessions.FormattingEnabled = true;
            this.lbSessions.Location = new System.Drawing.Point(12, 105);
            this.lbSessions.Name = "lbSessions";
            this.lbSessions.Size = new System.Drawing.Size(227, 173);
            this.lbSessions.TabIndex = 5;
            this.lbSessions.SelectedIndexChanged += new System.EventHandler(this.lbSessions_SelectedIndexChanged);
            // 
            // btnSelectSession
            // 
            this.btnSelectSession.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectSession.Enabled = false;
            this.btnSelectSession.Location = new System.Drawing.Point(12, 284);
            this.btnSelectSession.Name = "btnSelectSession";
            this.btnSelectSession.Size = new System.Drawing.Size(227, 37);
            this.btnSelectSession.TabIndex = 6;
            this.btnSelectSession.Text = "Select Session";
            this.btnSelectSession.UseVisualStyleBackColor = true;
            this.btnSelectSession.Click += new System.EventHandler(this.btnSelectSession_Click);
            // 
            // Authenticate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 333);
            this.Controls.Add(this.btnSelectSession);
            this.Controls.Add(this.lbSessions);
            this.Controls.Add(this.btnGetList);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Authenticate";
            this.Text = "Authenticate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button btnGetList;
        private System.Windows.Forms.ListBox lbSessions;
        private System.Windows.Forms.Button btnSelectSession;
    }
}