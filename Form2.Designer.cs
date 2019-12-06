namespace MBST_Lab_1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SetButton = new System.Windows.Forms.Button();
            this.SetAllButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.low = new System.Windows.Forms.Button();
            this.medium = new System.Windows.Forms.Button();
            this.high = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Privileges";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.checkedListBox1.Items.AddRange(new object[] {
            "ChangeNotify",
            "Security",
            "Backup",
            "Restore",
            "SystemTime",
            "Shutdown",
            "RemoteShutdown",
            "TakeOwnership ",
            "Debug",
            "SystemEnvironment",
            "SystemProfile",
            "ProfileSingleProcess",
            "IncreaseBasePriority",
            "LoadDriver",
            "CreatePagefile",
            "IncreaseQuota",
            "Undock",
            "ManageVolume",
            "Impersonate",
            "CreateGlobal"});
            this.checkedListBox1.Location = new System.Drawing.Point(9, 33);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(162, 360);
            this.checkedListBox1.TabIndex = 1;
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(9, 414);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(75, 23);
            this.SetButton.TabIndex = 2;
            this.SetButton.Text = "set";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // SetAllButton
            // 
            this.SetAllButton.Location = new System.Drawing.Point(100, 414);
            this.SetAllButton.Name = "SetAllButton";
            this.SetAllButton.Size = new System.Drawing.Size(32, 23);
            this.SetAllButton.TabIndex = 9;
            this.SetAllButton.Text = "+";
            this.SetAllButton.UseVisualStyleBackColor = true;
            this.SetAllButton.Click += new System.EventHandler(this.SetAllButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.Location = new System.Drawing.Point(139, 414);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(32, 23);
            this.DeleteAllButton.TabIndex = 10;
            this.DeleteAllButton.Text = "-";
            this.DeleteAllButton.UseVisualStyleBackColor = true;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // low
            // 
            this.low.Location = new System.Drawing.Point(161, 33);
            this.low.Name = "low";
            this.low.Size = new System.Drawing.Size(75, 23);
            this.low.TabIndex = 11;
            this.low.Text = "low";
            this.low.UseVisualStyleBackColor = true;
            this.low.Click += new System.EventHandler(this.Low_Click);
            // 
            // medium
            // 
            this.medium.Location = new System.Drawing.Point(161, 62);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(75, 23);
            this.medium.TabIndex = 12;
            this.medium.Text = "medium";
            this.medium.UseVisualStyleBackColor = true;
            this.medium.Click += new System.EventHandler(this.Medium_Click);
            // 
            // high
            // 
            this.high.Location = new System.Drawing.Point(161, 91);
            this.high.Name = "high";
            this.high.Size = new System.Drawing.Size(75, 23);
            this.high.TabIndex = 13;
            this.high.Text = "high";
            this.high.UseVisualStyleBackColor = true;
            this.high.Click += new System.EventHandler(this.High_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Integrity level";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(247, 447);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.high);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.low);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.SetAllButton);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "#";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.Button SetAllButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.Button low;
        private System.Windows.Forms.Button medium;
        private System.Windows.Forms.Button high;
        private System.Windows.Forms.Label label2;
    }
}