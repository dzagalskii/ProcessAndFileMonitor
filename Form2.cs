using System;
using System.Diagnostics;
using System.Windows.Forms;
using ProcessPrivileges;
using System.Runtime.InteropServices;

//checkedListBox1.Items[i] = "string";
//checkedListBox1.GetItemChecked(i);
//checkedListBox1.SetItemChecked(i, true);

namespace MBST_Lab_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Process SelectedProcess;
        bool[] temp;

        public void start_check_privileges(string ProcessID)
        {
            GetWorkPrivilegesList();
            SelectedProcess = Process.GetProcessById(Convert.ToInt32(ProcessID));
            Form1 Form1 = new Form1();
            string ProcessPrivileges = Form1.GetProcessPriveleges(SelectedProcess);
            temp = new bool[checkedListBox1.Items.Count];
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (ProcessPrivileges.Contains(checkedListBox1.Items[i].ToString()))
                {
                    checkedListBox1.SetItemChecked(i, true);
                    temp[i] = true;
                }
                else
                    temp[i] = false;
            }
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            { 
                if (checkedListBox1.GetItemChecked(i) == true && temp[i] == false)
                {
                    try { SelectedProcess.EnablePrivilege(AllPrivileges[i]); }
                    catch { }
                }
                else if (checkedListBox1.GetItemChecked(i) == false && temp[i] == true)
                {
                    try { SelectedProcess.DisablePrivilege(AllPrivileges[i]); }
                    catch { }
                }
            }
        }

        Privilege[] AllPrivileges;
        private void GetWorkPrivilegesList()
        {
            AllPrivileges = new Privilege[checkedListBox1.Items.Count];
            AllPrivileges[0] = Privilege.ChangeNotify;
            AllPrivileges[1] = Privilege.Security;
            AllPrivileges[2] = Privilege.Backup;
            AllPrivileges[3] = Privilege.Restore;
            AllPrivileges[4] = Privilege.SystemTime;
            AllPrivileges[5] = Privilege.Shutdown;
            AllPrivileges[6] = Privilege.RemoteShutdown;
            AllPrivileges[7] = Privilege.TakeOwnership;
            AllPrivileges[8] = Privilege.Debug;
            AllPrivileges[9] = Privilege.SystemEnvironment;
            AllPrivileges[10] = Privilege.SystemProfile;
            AllPrivileges[11] = Privilege.ProfileSingleProcess;
            AllPrivileges[12] = Privilege.IncreaseBasePriority;
            AllPrivileges[13] = Privilege.LoadDriver;
            AllPrivileges[14] = Privilege.CreatePageFile;
            AllPrivileges[15] = Privilege.IncreaseQuota;
            AllPrivileges[16] = Privilege.Undock;
            AllPrivileges[17] = Privilege.ManageVolume;
            AllPrivileges[18] = Privilege.Impersonate;
            AllPrivileges[19] = Privilege.CreateGlobal;
        }

        private void SetAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        [DllImport("C:\\Users\\dzaga\\Desktop\\MBST_Lab_1\\Level.dll")]
        public static extern bool SetIntegrityLevel(int privilegeLevel, int ID);

        private void Low_Click(object sender, EventArgs e)
        {
            SetIntegrityLevel(1, SelectedProcess.Id);
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            SetIntegrityLevel(2, SelectedProcess.Id);
        }

        private void High_Click(object sender, EventArgs e)
        {
            SetIntegrityLevel(3, SelectedProcess.Id);
        }
    }
}
