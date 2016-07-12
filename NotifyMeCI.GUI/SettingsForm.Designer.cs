namespace NotifyMeCI.GUI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.MinimizeChkBox = new System.Windows.Forms.CheckBox();
            this.AbortedEqualsFailedChkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(256, 77);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 0;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(175, 77);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 1;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // MinimizeChkBox
            // 
            this.MinimizeChkBox.AutoSize = true;
            this.MinimizeChkBox.Location = new System.Drawing.Point(12, 12);
            this.MinimizeChkBox.Name = "MinimizeChkBox";
            this.MinimizeChkBox.Size = new System.Drawing.Size(252, 17);
            this.MinimizeChkBox.TabIndex = 2;
            this.MinimizeChkBox.Text = "Minimize application to System Tray on start-up?";
            this.MinimizeChkBox.UseVisualStyleBackColor = true;
            this.MinimizeChkBox.CheckedChanged += new System.EventHandler(this.MinimizeChkBox_CheckedChanged);
            // 
            // AbortedEqualsFailedChkBox
            // 
            this.AbortedEqualsFailedChkBox.AutoSize = true;
            this.AbortedEqualsFailedChkBox.Location = new System.Drawing.Point(12, 35);
            this.AbortedEqualsFailedChkBox.Name = "AbortedEqualsFailedChkBox";
            this.AbortedEqualsFailedChkBox.Size = new System.Drawing.Size(168, 17);
            this.AbortedEqualsFailedChkBox.TabIndex = 3;
            this.AbortedEqualsFailedChkBox.Text = "Treat aborted builds as failed?";
            this.AbortedEqualsFailedChkBox.UseVisualStyleBackColor = true;
            this.AbortedEqualsFailedChkBox.CheckedChanged += new System.EventHandler(this.AbortedEqualsFailedChkBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 112);
            this.Controls.Add(this.AbortedEqualsFailedChkBox);
            this.Controls.Add(this.MinimizeChkBox);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(359, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(359, 150);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.CheckBox MinimizeChkBox;
        private System.Windows.Forms.CheckBox AbortedEqualsFailedChkBox;
    }
}