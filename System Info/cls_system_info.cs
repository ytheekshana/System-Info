using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace System_Info
{
    class cls_system_info
    {
        public static Double Downinitial = 0.0;
        public static Double Upinitial = 0.0;

        public static String GetBatteryInfo(String Batteryinfoname)
        {
            //Code By ytheekshana
            String BatteryFinal = "";
            ManagementObjectSearcher batteryinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Battery");
            foreach (ManagementObject cinfo in batteryinfo.Get())
            {
                BatteryFinal = (cinfo[Batteryinfoname].ToString());
            }
            return BatteryFinal;
        }

        public static String GetAntivirusInfo(String Antivirusinfoname)
        {
            //Code By ytheekshana
            String AntivirusFinal = "";
            ManagementObjectSearcher Antivirusinfo = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            ManagementObjectCollection Antivirusinfodata = Antivirusinfo.Get();
            foreach (ManagementObject AntiVinfo in Antivirusinfodata)
            {
                AntivirusFinal = (AntiVinfo[Antivirusinfoname].ToString());
            }
            return AntivirusFinal;
        }

        public static String GetCPUInfo(String cpuinfoname)
        {
            //Code By ytheekshana
            String CPUFinal = "";
            ManagementObjectSearcher cpuinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject cinfo in cpuinfo.Get())
            {
                CPUFinal = (cinfo[cpuinfoname].ToString());
            }
            return CPUFinal;
        }

        public static String GetMotherboardInfo(String MBinfoname)
        {
            //Code By ytheekshana
            String MboardFinal = "";
            ManagementObjectSearcher Mboardinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject MBinfo in Mboardinfo.Get())
            {
                MboardFinal = (MBinfo[MBinfoname].ToString());
            }
            return MboardFinal;
        }


        public static String GetBiosInfo(String Biosinfoname)
        {
            //Code By ytheekshana
            String BiosFinal = "";
            ManagementObjectSearcher Biosinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Bios");
            foreach (ManagementObject Binfo in Biosinfo.Get())
            {
                BiosFinal = (Binfo[Biosinfoname].ToString());
            }
            return BiosFinal;
        }

        public static String GetPrimaryGPUInfo(String PrimaryGPUinfoname)
        {
            //Code By ytheekshana
            String PrimaryGPUFinal = "";
            ManagementObjectSearcher PrimaryGraphicsinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_videocontroller WHERE DeviceID LIKE 'VideoController1%'");
            foreach (ManagementObject PrimaryGPUinfo in PrimaryGraphicsinfo.Get())
            {
                PrimaryGPUFinal = (PrimaryGPUinfo[PrimaryGPUinfoname].ToString());
            }
            return PrimaryGPUFinal;
        }

        public static String GetSecondaryGPUInfo(String SecondaryGPUinfoname)
        {
            //Code By ytheekshana
            String SecondaryGPUFinal = "";
            ManagementObjectSearcher SecondaryGraphicsinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_videocontroller WHERE DeviceID LIKE 'VideoController2%'");
            foreach (ManagementObject SecondaryGPUinfo in SecondaryGraphicsinfo.Get())
            {
                SecondaryGPUFinal = (SecondaryGPUinfo[SecondaryGPUinfoname].ToString());
            }
            return SecondaryGPUFinal;
        }

        public static String GetOSInfo(String OSinfoname)
        {
            //Code By ytheekshana
            String OSFinal = "";
            ManagementObjectSearcher OSinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject OperatingSinfo in OSinfo.Get())
            {
                OSFinal = (OperatingSinfo[OSinfoname].ToString());
            }
            return OSFinal;
        }

        public static String GetRAMInfo(String RAMinfoname)
        {
            //Code By ytheekshana
            String RAMFinal = "";
            ManagementObjectSearcher RAMinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject PhysicalMemoryinfo in RAMinfo.Get())
            {
                RAMFinal = (PhysicalMemoryinfo[RAMinfoname].ToString());
            }
            return RAMFinal;
        }

        public static String GetRAMArrayInfo(String RAMArrayinfoname)
        {
            //Code By ytheekshana
            String RAMArrayFinal = "";
            ManagementObjectSearcher RAMArrayinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemoryArray");
            foreach (ManagementObject PhysicalMemoryArrayinfo in RAMArrayinfo.Get())
            {
                RAMArrayFinal = (PhysicalMemoryArrayinfo[RAMArrayinfoname].ToString());
            }
            return RAMArrayFinal;
        }

        public static String GetComputerSystemInfo(String OSinfoname)
        {
            //Code By ytheekshana
            String ComputerSystemFinal = "";
            ManagementObjectSearcher ComputerSysteminfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject CSinfo in ComputerSysteminfo.Get())
            {
                ComputerSystemFinal = (CSinfo[OSinfoname].ToString());
            }
            return ComputerSystemFinal;
        }

        public static String GetPrimaryHardInfo(String PrimaryHardinfoname)
        {
            //Code By ytheekshana
            String PrimaryHardFinal = "";
            ManagementObjectSearcher PrimaryHardinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Diskdrive Where DeviceID LIKE '%PHYSICALDRIVE0'");
            foreach (ManagementObject PHinfo in PrimaryHardinfo.Get())
            {
                PrimaryHardFinal = (PHinfo[PrimaryHardinfoname].ToString());
            }
            return PrimaryHardFinal;
        }

        public static String GetSecondaryHardInfo(String SecondaryHardinfoname)
        {
            //Code By ytheekshana
            String SecondaryHardFinal = "";
            ManagementObjectSearcher SecondaryHardinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Diskdrive Where DeviceID LIKE '%PHYSICALDRIVE1'");
            foreach (ManagementObject SHinfo in SecondaryHardinfo.Get())
            {
                SecondaryHardFinal = (SHinfo[SecondaryHardinfoname].ToString());
            }
            return SecondaryHardFinal;
        }

        public static String GetWEIInfo(String WEIinfoname)
        {
            //Code By ytheekshana
            String WEIFinal = "";
            ManagementObjectSearcher WEIinfo = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_WinSAT");
            foreach (ManagementObject WEIndexinfo in WEIinfo.Get())
            {
                WEIFinal = (WEIndexinfo[WEIinfoname].ToString());
            }
            return WEIFinal;
        }

        public static String NetDownSpeed(Double GetDownSpeed)
        {
            //Code By ytheekshana
            String FinalSPDown = "";
            Double dload = GetDownSpeed;
            Double Downsp = dload - Downinitial;
            Downinitial = GetDownSpeed;

            if (Downsp > 1024000000)
            {
                FinalSPDown = (Math.Round(Downsp / 1024000000, 2)).ToString() + " GB/s";
            }
            else if (Downsp > 1024000)
            {
                FinalSPDown = (Math.Round(Downsp / 1024000, 2)).ToString() + " MB/s";
            }
            else if (Downsp > 1024)
            {
                FinalSPDown = (Math.Round(Downsp / 1000, 2)).ToString() + " KB/s";
            }
            else if (Downsp < 1024)
            {
                FinalSPDown = (Convert.ToDouble(Downsp)).ToString() + " B/s";
            }
            return (FinalSPDown);
        }

        public static String NetUpSpeed(Double GetUpSpeed)
        {
            //Code By ytheekshana
            String FinalSPUp = "";
            Double uload = GetUpSpeed;
            Double Upsp = uload - Upinitial;
            Upinitial = GetUpSpeed;

            if (Upsp > 1024000000)
            {
                FinalSPUp = (Math.Round(Upsp / 1024000000, 2)).ToString() + " GB/s";
            }
            else if (Upsp > 1024000)
            {
                FinalSPUp = (Math.Round(Upsp / 1024000, 2)).ToString() + " MB/s";
            }
            else if (Upsp > 1024)
            {
                FinalSPUp = (Math.Round(Upsp / 1000, 2)).ToString() + " KB/s";
            }
            else if (Upsp < 1024)
            {
                FinalSPUp = (Convert.ToDouble(Upsp)).ToString() + " B/s";
            }
            return (FinalSPUp);
        }

        [DllImport("shell32.dll", EntryPoint = "#261", CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetUserTilePath(string username, UInt32 whatever, StringBuilder picpath, int maxLength);

        public static string GetUserTilePath(string username)
        {   // username: use null for current user
            var sb = new StringBuilder(1000);
            GetUserTilePath(username, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }

        public static Image GetUserTile(string username)
        {
            return Image.FromFile(GetUserTilePath(username));
        }
    }
}
