using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBST_Lab_1
{
   public class Proc_class
    {
        public Process MyProcess;
        public string ProcessOwner;
        public Process ProcessParent;
        public bool Is64Bit;
        public Process_Mitigation_DEP_Policy Dep=new Process_Mitigation_DEP_Policy();
        public Process_Mitigation_Type_Policy ASLR = new Process_Mitigation_Type_Policy();
        public string IntegrityLevel;
    }
}
