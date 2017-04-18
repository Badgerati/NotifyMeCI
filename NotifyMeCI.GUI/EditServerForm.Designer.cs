namespace NotifyMeCI.GUI
{
    partial class EditServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditServerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ServerTypeDdl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerNameTxt = new System.Windows.Forms.TextBox();
            this.ServerUrlTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ServerPollNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerApiTokenTxt = new System.Windows.Forms.TextBox();
            this.ServerApiTokenLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ServerEnabledChk = new System.Windows.Forms.CheckBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ServerDurThreshNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPollNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerDurThreshNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type:";
            // 
            // ServerTypeDdl
            // 
            this.ServerTypeDdl.BackColor = System.Drawing.SystemColors.Window;
            this.ServerTypeDdl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTypeDdl.FormattingEnabled = true;
            this.ServerTypeDdl.Items.AddRange(new object[] {
            "Jenkins",
            "AppVeyor",
            "TravisCI"});
            this.ServerTypeDdl.Location = new System.Drawing.Point(119, 6);
            this.ServerTypeDdl.Name = "ServerTypeDdl";
            this.ServerTypeDdl.Size = new System.Drawing.Size(106, 21);
            this.ServerTypeDdl.TabIndex = 1;
            this.ServerTypeDdl.SelectedIndexChanged += new System.EventHandler(this.ServerTypeDdl_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // ServerNameTxt
            // 
            this.ServerNameTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServerNameTxt.Location = new System.Drawing.Point(119, 40);
            this.ServerNameTxt.Name = "ServerNameTxt";
            this.ServerNameTxt.Size = new System.Drawing.Size(226, 20);
            this.ServerNameTxt.TabIndex = 3;
            // 
            // ServerUrlTxt
            // 
            this.ServerUrlTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServerUrlTxt.Location = new System.Drawing.Point(119, 75);
            this.ServerUrlTxt.Name = "ServerUrlTxt";
            this.ServerUrlTxt.Size = new System.Drawing.Size(226, 20);
            this.ServerUrlTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "URL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Poll:";
            // 
            // ServerPollNum
            // 
            this.ServerPollNum.Location = new System.Drawing.Point(119, 111);
            this.ServerPollNum.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ServerPollNum.Name = "ServerPollNum";
            this.ServerPollNum.Size = new System.Drawing.Size(58, 20);
            this.ServerPollNum.TabIndex = 7;
            this.ServerPollNum.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seconds";
            // 
            // ServerApiTokenTxt
            // 
            this.ServerApiTokenTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServerApiTokenTxt.Location = new System.Drawing.Point(119, 183);
            this.ServerApiTokenTxt.Name = "ServerApiTokenTxt";
            this.ServerApiTokenTxt.Size = new System.Drawing.Size(226, 20);
            this.ServerApiTokenTxt.TabIndex = 10;
            // 
            // ServerApiTokenLbl
            // 
            this.ServerApiTokenLbl.AutoSize = true;
            this.ServerApiTokenLbl.Location = new System.Drawing.Point(12, 186);
            this.ServerApiTokenLbl.Name = "ServerApiTokenLbl";
            this.ServerApiTokenLbl.Size = new System.Drawing.Size(78, 13);
            this.ServerApiTokenLbl.TabIndex = 9;
            this.ServerApiTokenLbl.Text = "Authentication:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Enabled:";
            // 
            // ServerEnabledChk
            // 
            this.ServerEnabledChk.AutoSize = true;
            this.ServerEnabledChk.Location = new System.Drawing.Point(119, 219);
            this.ServerEnabledChk.Name = "ServerEnabledChk";
            this.ServerEnabledChk.Size = new System.Drawing.Size(15, 14);
            this.ServerEnabledChk.TabIndex = 12;
            this.ServerEnabledChk.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(250, 246);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 15;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(130, 246);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 14;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(8, 246);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 13;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Minutes (0 is off)";
            // 
            // ServerDurThreshNum
            // 
            this.ServerDurThreshNum.Location = new System.Drawing.Point(119, 147);
            this.ServerDurThreshNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ServerDurThreshNum.Name = "ServerDurThreshNum";
            this.ServerDurThreshNum.Size = new System.Drawing.Size(58, 20);
            this.ServerDurThreshNum.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Duration Threshold:";
            // 
            // EditServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 279);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ServerDurThreshNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ServerEnabledChk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ServerApiTokenTxt);
            this.Controls.Add(this.ServerApiTokenLbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ServerPollNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ServerUrlTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ServerNameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerTypeDdl);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(369, 318);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(369, 318);
            this.Name = "EditServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Server";
            ((System.ComponentModel.ISupportInitialize)(this.ServerPollNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerDurThreshNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ServerTypeDdl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerNameTxt;
        private System.Windows.Forms.TextBox ServerUrlTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ServerPollNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ServerApiTokenTxt;
        private System.Windows.Forms.Label ServerApiTokenLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ServerEnabledChk;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ServerDurThreshNum;
        private System.Windows.Forms.Label label8;
    }
}