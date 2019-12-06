namespace MBST_Lab_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ProcessPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessParent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessPPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessDEPASLR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessDLL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessIntegrityLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessPrivileges = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.file_path = new System.Windows.Forms.TextBox();
            this.check_button = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.FileSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileOvner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileIntegrityLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refresh_button = new System.Windows.Forms.Button();
            this.change_button = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProcessPID,
            this.ProcessName,
            this.ProcessPath,
            this.ProcessParent,
            this.ProcessPPID,
            this.ProcessOwner,
            this.ProcessType,
            this.ProcessDEPASLR,
            this.ProcessDLL,
            this.ProcessIntegrityLevel,
            this.ProcessPrivileges});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(17, 31);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1778, 495);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // ProcessPID
            // 
            this.ProcessPID.Text = "PID";
            this.ProcessPID.Width = 57;
            // 
            // ProcessName
            // 
            this.ProcessName.Text = "Name";
            this.ProcessName.Width = 90;
            // 
            // ProcessPath
            // 
            this.ProcessPath.Text = "Path";
            this.ProcessPath.Width = 144;
            // 
            // ProcessParent
            // 
            this.ProcessParent.Text = "Parent";
            this.ProcessParent.Width = 74;
            // 
            // ProcessPPID
            // 
            this.ProcessPPID.Text = "PPID";
            this.ProcessPPID.Width = 48;
            // 
            // ProcessOwner
            // 
            this.ProcessOwner.Text = "Owner";
            this.ProcessOwner.Width = 73;
            // 
            // ProcessType
            // 
            this.ProcessType.Text = "Type";
            this.ProcessType.Width = 97;
            // 
            // ProcessDEPASLR
            // 
            this.ProcessDEPASLR.Text = "DEP/ASLR";
            this.ProcessDEPASLR.Width = 74;
            // 
            // ProcessDLL
            // 
            this.ProcessDLL.Text = "DLL";
            this.ProcessDLL.Width = 159;
            // 
            // ProcessIntegrityLevel
            // 
            this.ProcessIntegrityLevel.Text = "Integrity Level";
            this.ProcessIntegrityLevel.Width = 79;
            // 
            // ProcessPrivileges
            // 
            this.ProcessPrivileges.Text = "Privileges";
            this.ProcessPrivileges.Width = 456;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Processes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 612);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Check the file:";
            // 
            // file_path
            // 
            this.file_path.Location = new System.Drawing.Point(16, 631);
            this.file_path.Margin = new System.Windows.Forms.Padding(4);
            this.file_path.Name = "file_path";
            this.file_path.Size = new System.Drawing.Size(256, 22);
            this.file_path.TabIndex = 3;
            // 
            // check_button
            // 
            this.check_button.Location = new System.Drawing.Point(16, 663);
            this.check_button.Margin = new System.Windows.Forms.Padding(4);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(100, 28);
            this.check_button.TabIndex = 4;
            this.check_button.Text = "check";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileSID,
            this.FileOvner,
            this.FileIntegrityLevel});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(285, 612);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(751, 79);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // FileSID
            // 
            this.FileSID.Text = "SID";
            this.FileSID.Width = 201;
            // 
            // FileOvner
            // 
            this.FileOvner.Text = "Owner";
            this.FileOvner.Width = 197;
            // 
            // FileIntegrityLevel
            // 
            this.FileIntegrityLevel.Text = "Integrity level";
            this.FileIntegrityLevel.Width = 161;
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(16, 534);
            this.refresh_button.Margin = new System.Windows.Forms.Padding(4);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(100, 28);
            this.refresh_button.TabIndex = 6;
            this.refresh_button.Text = "refresh";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // change_button
            // 
            this.change_button.Location = new System.Drawing.Point(173, 663);
            this.change_button.Margin = new System.Windows.Forms.Padding(4);
            this.change_button.Name = "change_button";
            this.change_button.Size = new System.Drawing.Size(100, 28);
            this.change_button.TabIndex = 7;
            this.change_button.Text = "change";
            this.change_button.UseVisualStyleBackColor = true;
            this.change_button.Click += new System.EventHandler(this.Change_button_Click);
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(1045, 534);
            this.listView3.Margin = new System.Windows.Forms.Padding(4);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(750, 157);
            this.listView3.TabIndex = 8;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Account";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 64;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rights";
            this.columnHeader3.Width = 486;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1001, 540);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "ACL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1806, 706);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.change_button);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.check_button);
            this.Controls.Add(this.file_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ProcessFileExplorer by Kashkarov&Zagalskij";
            this.Load += new System.EventHandler(this.StartProcessExplorer);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ProcessPID;
        private System.Windows.Forms.ColumnHeader ProcessName;
        private System.Windows.Forms.ColumnHeader ProcessPath;
        private System.Windows.Forms.ColumnHeader ProcessParent;
        private System.Windows.Forms.ColumnHeader ProcessPPID;
        private System.Windows.Forms.ColumnHeader ProcessOwner;
        private System.Windows.Forms.ColumnHeader ProcessType;
        private System.Windows.Forms.ColumnHeader ProcessDEPASLR;
        private System.Windows.Forms.ColumnHeader ProcessDLL;
        private System.Windows.Forms.ColumnHeader ProcessIntegrityLevel;
        private System.Windows.Forms.ColumnHeader ProcessPrivileges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox file_path;
        private System.Windows.Forms.Button check_button;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader FileOvner;
        private System.Windows.Forms.ColumnHeader FileIntegrityLevel;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.ColumnHeader FileSID;
        private System.Windows.Forms.Button change_button;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
    }
}

