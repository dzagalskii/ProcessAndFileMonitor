using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;
using System.Security.Principal;
using System.IO;
using ProcessPrivileges;
using System.Linq;
using System.Security.AccessControl;

namespace MBST_Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int Process_Query_Information = 0x0400;
        const int Process_WM_Read = 0x0010;

        //для ASLR
        [DllImport("kernel32.dll")]
        public static extern bool GetProcessMitigationPolicy(IntPtr hProcess,
            Process_Mitigation_Policy mitigationPolicy,
            ref Process_Mitigation_DEP_Policy lpBuffer,
            int dwLength);

        //для DEP
        [DllImport("kernel32.dll")]
        public static extern bool GetProcessMitigationPolicy(
            IntPtr hProcess,
            Process_Mitigation_Policy mitigationPolicy,
            ref Process_Mitigation_Type_Policy lpBuffer,
            int dwLength);

        //для 64/32
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process([In] IntPtr process, 
            [Out] out bool wow64Process);

        //64/32
        public static bool Is64Bit(Process process)
        {
            if (!Environment.Is64BitOperatingSystem)
                return false;
            // if this method is not available in your version of .NET, use GetNativeSystemInfo via P/Invoke instead
            bool isWow64;
            if (!IsWow64Process(process.Handle, out isWow64))
                throw new Win32Exception();
            return !isWow64;
        }

        //integrity level процесса
        public static string GetIntegrityLevel(Process process)
        {
            try
            {
                IntPtr hProcess = process.Handle;
                IntPtr hToken;
                if (!OpenProcessToken(hProcess, TokenAccessLevels.MaximumAllowed, out hToken))
                    return "error";
                try
                {
                    uint dwLengthNeeded;
                    if (GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, IntPtr.Zero, 0, out dwLengthNeeded))
                        return "error";
                    uint dwError = (uint)Marshal.GetLastWin32Error();
                    if (dwError == ERROR_INSUFFICIENT_BUFFER)
                    {
                        IntPtr pTIL = Marshal.AllocHGlobal((int)dwLengthNeeded);
                        try
                        {
                            if (!GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTIL, dwLengthNeeded, out dwLengthNeeded))
                                return "error";
                            //
                            TOKEN_MANDATORY_LABEL TIL = (TOKEN_MANDATORY_LABEL)Marshal.PtrToStructure(pTIL, typeof(TOKEN_MANDATORY_LABEL));
                            IntPtr SubAuthorityCount = GetSidSubAuthorityCount(TIL.Label.Sid);
                            IntPtr IntegrityLevelPtr = GetSidSubAuthority(TIL.Label.Sid, Marshal.ReadByte(SubAuthorityCount) - 1);
                            //
                            int dwIntegrityLevel = Marshal.ReadInt32(IntegrityLevelPtr);
                            if(dwIntegrityLevel < SECURITY_MANDATORY_LOW_RID)
                                return "untrusted";
                            else if (dwIntegrityLevel == SECURITY_MANDATORY_LOW_RID)
                                return "low";
                            else if (dwIntegrityLevel >= SECURITY_MANDATORY_MEDIUM_RID &&
                                 dwIntegrityLevel < SECURITY_MANDATORY_HIGH_RID)
                                return "medium";
                            else if (dwIntegrityLevel >= SECURITY_MANDATORY_HIGH_RID &&
                                 dwIntegrityLevel < SECURITY_MANDATORY_SYSTEM_RID)
                                return "high";
                            else if (dwIntegrityLevel >= SECURITY_MANDATORY_SYSTEM_RID)
                                return "system";
                        }
                        finally { Marshal.FreeHGlobal(pTIL); }
                    }
                }
                finally { CloseHandle(hToken); }
                return "";
            }
            catch { return "system"; }
        }

        //получаем 
        public void GetProcessOwnerDepAslr(List<Proc_class> PROCESS_LIST)
        {
            string query = "Select * From Win32_Process";// Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                int returnVal = -1, index = -1;
                try
                {
                    string[] argList = new string[] { string.Empty, string.Empty };
                    index = PROCESS_LIST.FindIndex((p) => { return p.MyProcess.Id.ToString().Equals(obj.Properties["Handle"].Value.ToString()); });
                    returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));

                    if (returnVal == 0 && index > -1)
                    {
                        PROCESS_LIST[index].ProcessOwner = argList[0];
                        PROCESS_LIST[index].Is64Bit = Is64Bit(PROCESS_LIST[index].MyProcess);
                        //информация по DEP
                        bool success = GetProcessMitigationPolicy(PROCESS_LIST[index].MyProcess.Handle, Process_Mitigation_Policy.ProcessDEPPolicy, ref PROCESS_LIST[index].Dep, Marshal.SizeOf(PROCESS_LIST[index].Dep));
                        //информация по ASLR
                        success = GetProcessMitigationPolicy(PROCESS_LIST[index].MyProcess.Handle, Process_Mitigation_Policy.ProcessASLRPolicy, ref PROCESS_LIST[index].ASLR, Marshal.SizeOf(PROCESS_LIST[index].ASLR));
                    }
                }
                catch
                {
                    if (index != -1)
                        PROCESS_LIST.RemoveAt(index);
                }
            }
            return;
        }

        //начало работы формы
        private void StartProcessExplorer(object sender, EventArgs e)
        {
            //получаем все процессы
            Process[] ALL_PROCESSES = Process.GetProcesses();
            List<Proc_class> PROCESS_LIST = new List<Proc_class>();
            //проходимся, заполняем список процессами
            foreach (var P in ALL_PROCESSES)
            {
                try
                {
                    //для рабочего списка
                    var NEW_PROCESS = new Proc_class();
                    NEW_PROCESS.MyProcess = P;
                    NEW_PROCESS.ProcessParent = GetProcessParent(P);
                    NEW_PROCESS.IntegrityLevel = GetIntegrityLevel(P);
                    PROCESS_LIST.Add(NEW_PROCESS);
                }
                catch { }
            }
            /*получаем владельцев процессов*/
            GetProcessOwnerDepAslr(PROCESS_LIST);

            foreach (var P in PROCESS_LIST)
            {
                try
                {
                    ListViewItem item1 = new ListViewItem(P.MyProcess.Id.ToString());
                    listView1.Items.Add(item1);
                    item1.SubItems.Add(P.MyProcess.ProcessName);
                    item1.SubItems.Add(P.MyProcess.MainModule.FileName);
                    item1.SubItems.Add(P.ProcessParent.ProcessName);
                    item1.SubItems.Add(P.ProcessParent.Id.ToString());
                    item1.SubItems.Add(P.ProcessOwner);
                    item1.SubItems.Add(P.Is64Bit ? "x64" : "x86");
                    item1.SubItems.Add(P.Dep.Enable.ToString() + P.ASLR.EnableBottomUpRandomization);
                    
                    string Dlls = "";

                    for (int i = 0; i < P.MyProcess.Modules.Count; i++)
                    {
                        if (P.MyProcess.Modules[i].ModuleName.EndsWith(".dll"))
                            Dlls += P.MyProcess.Modules[i].ModuleName + "; ";

                    }
                    if (Dlls.Length > 0)
                    {
                        Dlls = Dlls.Substring(0, Dlls.Length - 1);
                    }
                    item1.SubItems.Add(Dlls);
                    item1.SubItems.Add(P.IntegrityLevel);
                    item1.SubItems.Add(GetProcessPriveleges(P.MyProcess));
                }
                catch
                { /**/ }
            }
        }

        //действие при тычке на кнопку обновления
        private void refresh_button_Click(object sender, EventArgs e)
        {
            //удаляем и заново запускаем
            listView1.Items.Clear();
            StartProcessExplorer(null, null);
        }

        //действие при тычке на кнопку проверки файла
        private void check_button_Click(object sender, EventArgs e)
        {
            //очищаем таблички от данных
            listView2.Items.Clear();
            listView3.Items.Clear();

            //если строчка с путем пустая, выходим
            if (string.IsNullOrEmpty(file_path.Text))
                return;

            //находим SID и OWNER
            var File_Security = File.GetAccessControl(file_path.Text);
            var SID = File_Security.GetOwner(typeof(SecurityIdentifier));
            var Owner = SID.Translate(typeof(NTAccount));

            //находим уровень целостности
            int IntegrityLevel_File = GetFileIntegrityLevel(file_path.Text);
            string IntegrityLevel_File_str = "";
            if (IntegrityLevel_File == 0)
                IntegrityLevel_File_str = "untrusted";
            else if (IntegrityLevel_File == 1)
                IntegrityLevel_File_str = "low";
            else if (IntegrityLevel_File == 2)
                IntegrityLevel_File_str = "medium";
            else if (IntegrityLevel_File == 3)
                IntegrityLevel_File_str = "high";
            else
                IntegrityLevel_File_str = "system";

            //находим запись ACL
            DirectoryInfo dInfo = new DirectoryInfo(file_path.Text);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            AuthorizationRuleCollection acl = dSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
            foreach (FileSystemAccessRule ace in acl)
            {
                //выводим ACL в отдельную табличку
                ListViewItem item3 = new ListViewItem(ace.IdentityReference.Value.ToString());
                listView3.Items.Add(item3);
                item3.SubItems.Add(ace.AccessControlType.ToString());
                item3.SubItems.Add(ace.FileSystemRights.ToString());
            }
            //выводим все (кроме ACL) в табличку
            ListViewItem item2 = new ListViewItem(SID.ToString());
            listView2.Items.Add(item2);
            item2.SubItems.Add(Owner.ToString());
            item2.SubItems.Add(IntegrityLevel_File_str);
            return;
        }
        
        //получить привилегии процесса по идентификатору
        public string GetProcessPriveleges(Process process)
        {
            string allPriv = "";
            PrivilegeAndAttributesCollection privileges = process.GetPrivileges();
            try
            {
                int maxPrivilegeLength = privileges.Max(privilege => privilege.Privilege.ToString().Length);
                foreach (PrivilegeAndAttributes privilegeAndAttributes in privileges)
                {
                    //получаем привилегию
                    Privilege privilege = privilegeAndAttributes.Privilege;

                    //получаем состояние привилегии
                    PrivilegeState privilegeState = privilegeAndAttributes.PrivilegeState;

                    //если привилегия активна, записываем ее в список
                    if (privilegeState.ToString() == "Enabled")
                        allPriv += privilege + "; ";
                }
            }
            catch { }
            return allPriv;
        }

        //получить родителя процесса по идентификатору
        private Process GetProcessParent(Process process)
        {
            int parentPid = 0, processPid = process.Id;
            uint TH32CS_SNAPPROCESS = 2;
            
            //делаем снимок всех процессов
            IntPtr hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
            if (hSnapshot == IntPtr.Zero)
                return null;
            PROCESSENTRY32 procInfo = new PROCESSENTRY32();
            procInfo.dwSize = (uint)Marshal.SizeOf(typeof(PROCESSENTRY32));

            //читаем первый
            if (Process32First(hSnapshot, ref procInfo) == false)
                return null;

            //проходим по снимку и ищем родителя
            do
            {
                if (processPid == procInfo.th32ProcessID)
                    parentPid = (int)procInfo.th32ParentProcessID;
            }
            while (parentPid == 0 && Process32Next(hSnapshot, ref procInfo));
            if (parentPid > 0)
                return Process.GetProcessById(parentPid);
            else
                return null;
        }

        //действие при тычке на айди процесса
        private void ListView1_SelectedIndexChanged(object sender, MouseEventArgs e)
        {
            //создаем форму2, передаем ей айди процесса, показываем
            Form2 Form2 = new Form2();
            Form2.Show();
            Form2.start_check_privileges(listView1.SelectedItems[0].Text);
            return;
        }

        //действие при тычке на кнопку изменения у файла
        private void Change_button_Click(object sender, EventArgs e)
        {
            //если строчка с путем пуста, выходим
            if (string.IsNullOrEmpty(file_path.Text))
                return;
            //создаем форму3, передаем ей путь, показываем
            Form3 Form3 = new Form3();
            Form3.Tag = file_path.Text;
            Form3.Show();
            return;
        }
        
        /**//**//**//**//**//**//**//**/
        
        const uint ERROR_INSUFFICIENT_BUFFER = 122;
        const long SECURITY_MANDATORY_LOW_RID = 0x00001000L;
        const long SECURITY_MANDATORY_MEDIUM_RID = 0x00002000L;
        const long SECURITY_MANDATORY_HIGH_RID = 0x00003000L;
        const long SECURITY_MANDATORY_SYSTEM_RID = 0x00004000L;
        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups = 2,
            TokenPrivileges = 3,
            TokenOwner = 4,
            TokenPrimaryGroup = 5,
            TokenDefaultDacl = 6,
            TokenSource = 7,
            TokenType = 8,
            TokenImpersonationLevel = 9,
            TokenStatistics = 10,
            TokenRestrictedSids = 11,
            TokenSessionId = 12,
            TokenGroupsAndPrivileges = 13,
            TokenSessionReference = 14,
            TokenSandBoxInert = 15,
            TokenAuditPolicy = 16,
            TokenOrigin = 17,
            TokenElevationType = 18,
            TokenLinkedToken = 19,
            TokenElevation = 20,
            TokenHasRestrictions = 21,
            TokenAccessInformation = 22,
            TokenVirtualizationAllowed = 23,
            TokenVirtualizationEnabled = 24,
            TokenIntegrityLevel = 25,
            TokenUIAccess = 26,
            TokenMandatoryPolicy = 27,
            TokenLogonSid = 28,
            MaxTokenInfoClass = 29
        }

        [StructLayout(LayoutKind.Sequential)]
        struct TOKEN_MANDATORY_LABEL
        {
            public SID_AND_ATTRIBUTES Label;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public int Attributes;
        }

        [DllImport("C:\\Users\\dzaga\\Desktop\\MBST_Lab_1\\IntegrityLevel.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFileIntegrityLevel(string FileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle,
            TokenAccessLevels DesiredAccess,
            out IntPtr TokenHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            uint TokenInformationLength,
            out uint ReturnLength);

        [DllImport("kernel32.dll")]
        static extern IntPtr LocalAlloc(uint uFlags, UIntPtr uBytes);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthority(IntPtr pSid, int nSubAuthority);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthorityCount(IntPtr pSid);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32.dll")]
        private static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll")]
        private static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }
    }
}
