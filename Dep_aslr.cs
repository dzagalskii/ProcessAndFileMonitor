using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MBST_Lab_1
{
    public enum Process_Mitigation_Policy
    {
        ProcessDEPPolicy = 0,
        ProcessASLRPolicy = 1
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct union
    {
        [FieldOffset(0)]
        uint EnableBottomUpRandomization;
        [FieldOffset(0)]
        uint EnableForceRelocateImages;
        [FieldOffset(0)]
        uint EnableHighEntropy;
        [FieldOffset(0)]
        uint DisallowStrippedImages;
        [FieldOffset(0)]
        uint ReservedFlags;
    }

    public struct Process_Mitigation_Type_Policy
    {
        public uint Flags;
        public bool EnableBottomUpRandomization
        {
            get { return (Flags & 1) > 0; }
        }

        public bool EnableForceRelocateImage
        {
            get{ return (Flags & 2) > 0; }
        }

        public bool EnableHighEntropy
        {
            get { return (Flags & 4) > 0; }
        }

        public bool DisallowStrippedImages
        {
            get { return (Flags & 8) > 0; }
        }
    }
    public struct Process_Mitigation_DEP_Policy
    {
        public uint Flags;
        public bool Permanent;
        public bool Enable
        {
            get { return (Flags & 1) > 0; }
        }

        public bool DisableAtlThunkEmulation
        {
            get { return (Flags & 2) > 0; }
        }
    }
}
