using Microsoft.VisualBasic.Devices;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace System_Info
{
    public partial class frm_detect : Form
    {
        public frm_detect()
        {
            InitializeComponent();
        }

        ComputerInfo ci = new ComputerInfo();
        public static DateTime InstallDate, Biosreleasedate;
        public static String systemmanufacturerdis, systemmodeldis, osbuildnumberdis, osregistereduserdis, cpunamedis, cpunamedis2, cputhreadsdis,
                socketdis, clockspeeddis, cpumanufacturerdis, cpurevisiondis, l2cachesizedis, l3cachesizedis, mboardmanufacturerdis,
                mboardmodeldis, biosnamedis, biosmanufacturerdis, biosversiondis, systembiosdis, primarygpunamedis, primarygpudactypedis, primarygpumemorydis,
                primarygpuresdis, primarygpubitdis, primarygpurratedis, primarygpumanufacturerdis, systemdatetimedis, systemuptime, cpupowermngmentdis, primaryHardModeldis,
                primaryHardsizedis, primaryHardpartitionsDis, secondaryHardModeldis, secondaryHardsizedis, secondaryHardpartitionsDis, secondarygpunamedis,
                secondarygpudactypedis, secondarygpumemorydis, secondarygpumanufacturerdis, secondarygpurratedis, secondarygpubitdis, secondarygpuresdis,
                memorytypedis, memoryslotsdis, primaryharddisktypedis, secondaryHarddisktypedis, InternetStatus, WEIProcessordis, WEIMemorydis, WEIGraphicsdis,
                WEIGamingGraphicsdis, WEIDiskdis, WEITotal, osantivirusdis, batteryvoltagedis, batterychemistrydis, batteryavailability;
        public static String Version = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();

        frm_system_info f1 = new frm_system_info();

        private void frm_detect_Load(object sender, EventArgs e)
        {
            Color getcolor = Properties.Settings.Default.ThemeColor;
            label1.BackColor = getcolor;
            label3.BackColor = getcolor;
            label4.BackColor = getcolor;
            label2.BackColor = getcolor;

            if (System.Environment.Is64BitOperatingSystem == true)
            {
                lblappinfo.Text = "System Info " + Version + " x64";
            }
            else
            {
                lblappinfo.Text = "System Info " + Version + " x32";
            }
        }

        private void frm_detect_Shown(object sender, EventArgs e)
        {
            bgw_detect.RunWorkerAsync();
        }

        private void frm_detect_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgw_detect.Dispose();
            bgw_detect.CancelAsync();
        }

        private void bgw_detect_DoWork(object sender, DoWorkEventArgs e)
        {
            //Computer System
            systemmanufacturerdis = cls_system_info.GetComputerSystemInfo("Manufacturer");
            systemmodeldis = cls_system_info.GetComputerSystemInfo("Model");
            bgw_detect.ReportProgress(11, "Operating System");
            Thread.Sleep(800);

            //Operating System
            osbuildnumberdis = cls_system_info.GetOSInfo("BuildNumber");
            osregistereduserdis = cls_system_info.GetOSInfo("RegisteredUser");
            InstallDate = ManagementDateTimeConverter.ToDateTime(cls_system_info.GetOSInfo("InstallDate"));
            systemuptime = cls_system_info.GetOSInfo("LastBootUpTime");
            osantivirusdis = cls_system_info.GetAntivirusInfo("displayname");
            bgw_detect.ReportProgress(22, "Memory");
            Thread.Sleep(800);

            //Memory
            memorytypedis = cls_system_info.GetRAMInfo("MemoryType");
            memoryslotsdis = cls_system_info.GetRAMArrayInfo("MemoryDevices");
            bgw_detect.ReportProgress(33, "Processor");

            //CPU
            cpunamedis = cls_system_info.GetCPUInfo("Name");
            cpunamedis2 = cls_system_info.GetCPUInfo("Name");
            cputhreadsdis = cls_system_info.GetCPUInfo("NumberOfLogicalProcessors");
            socketdis = cls_system_info.GetCPUInfo("SocketDesignation");
            clockspeeddis = cls_system_info.GetCPUInfo("MaxClockSpeed") + "MHz";
            cpumanufacturerdis = cls_system_info.GetCPUInfo("Manufacturer");

            l2cachesizedis = cls_system_info.GetCPUInfo("L2CacheSize");
            l3cachesizedis = cls_system_info.GetCPUInfo("L3CacheSize");
            if (ci.OSFullName.ToLower().Contains("microsoft windows 10"))
            {
                cpurevisiondis = "None";
            }
            else
            {
                cpurevisiondis = cls_system_info.GetCPUInfo("Revision");
            }

            bgw_detect.ReportProgress(44, "MotherBoard");
            Thread.Sleep(800);


            //MotherBoard
            mboardmanufacturerdis = cls_system_info.GetMotherboardInfo("Manufacturer");
            mboardmodeldis = cls_system_info.GetMotherboardInfo("Product");
            bgw_detect.ReportProgress(55, "BIOS");
            Thread.Sleep(800);

            //BIOS
            biosnamedis = cls_system_info.GetBiosInfo("Name");
            biosmanufacturerdis = cls_system_info.GetBiosInfo("Manufacturer");
            biosversiondis = cls_system_info.GetBiosInfo("SMBIOSBIOSVersion");
            systembiosdis = cls_system_info.GetBiosInfo("Name");
            Biosreleasedate = ManagementDateTimeConverter.ToDateTime(cls_system_info.GetBiosInfo("ReleaseDate"));
            bgw_detect.ReportProgress(66, "Windows Experience Index");
            Thread.Sleep(800);

            //WEI
            WEIProcessordis = cls_system_info.GetWEIInfo("CPUScore");
            WEIMemorydis = cls_system_info.GetWEIInfo("MemoryScore");
            WEIGraphicsdis = cls_system_info.GetWEIInfo("GraphicsScore");
            WEIGamingGraphicsdis = cls_system_info.GetWEIInfo("D3DScore");
            WEIDiskdis = cls_system_info.GetWEIInfo("DiskScore");
            WEITotal = cls_system_info.GetWEIInfo("WinSPRLevel");
            bgw_detect.ReportProgress(77, "Storage");

            //Storage
            //Hard#1
            if (cls_system_info.GetPrimaryHardInfo("Model") != "")
            {
                primaryHardModeldis = cls_system_info.GetPrimaryHardInfo("Model");
            }
            else
            {
                primaryHardModeldis = "";
            }
            if (cls_system_info.GetPrimaryHardInfo("Size") != "")
            {
                primaryHardsizedis = cls_system_info.GetPrimaryHardInfo("Size");
            }
            else
            {
                primaryHardsizedis = "";
            }
            if (cls_system_info.GetPrimaryHardInfo("Partitions") != "")
            {
                primaryHardpartitionsDis = cls_system_info.GetPrimaryHardInfo("Partitions");
            }
            else
            {
                primaryHardpartitionsDis = "";
            }
            if (cls_system_info.GetPrimaryHardInfo("MediaType") != "")
            {
                primaryharddisktypedis = cls_system_info.GetPrimaryHardInfo("MediaType");
            }
            else
            {
                primaryharddisktypedis = "Unknown";
            }

            //Hard#2
            if (cls_system_info.GetSecondaryHardInfo("Model") != "")
            {
                secondaryHardModeldis = cls_system_info.GetSecondaryHardInfo("Model");
            }
            else
            {
                secondaryHardModeldis = "";
            }
            if (cls_system_info.GetSecondaryHardInfo("Size") != "")
            {
                secondaryHardsizedis = cls_system_info.GetSecondaryHardInfo("Size");
            }
            else
            {
                secondaryHardsizedis = "";
            }
            if (cls_system_info.GetSecondaryHardInfo("Partitions") != "")
            {
                secondaryHardpartitionsDis = cls_system_info.GetSecondaryHardInfo("Partitions");
            }
            else
            {
                secondaryHardpartitionsDis = "";
            }
            if (cls_system_info.GetSecondaryHardInfo("MediaType") != "")
            {
                secondaryHarddisktypedis = cls_system_info.GetSecondaryHardInfo("MediaType");
            }
            else
            {
                secondaryHarddisktypedis = "Unknown";
            }
            bgw_detect.ReportProgress(88, "Graphics");
            Thread.Sleep(800);

            //Graphics
            primarygpunamedis = cls_system_info.GetPrimaryGPUInfo("Caption");
            secondarygpunamedis = cls_system_info.GetSecondaryGPUInfo("Caption");

            //GPU
            if (String.IsNullOrEmpty(secondarygpunamedis))
            {
                //GPUPrimary
                primarygpudactypedis = cls_system_info.GetPrimaryGPUInfo("AdapterDACType");
                primarygpumemorydis = (Convert.ToInt64(cls_system_info.GetPrimaryGPUInfo("AdapterRAM")) / 1024 / 1024).ToString() + "MB";
                if (cls_system_info.GetPrimaryGPUInfo("CurrentHorizontalResolution") != "" && cls_system_info.GetPrimaryGPUInfo("CurrentVerticalResolution") != "")
                {
                    primarygpuresdis = cls_system_info.GetPrimaryGPUInfo("CurrentHorizontalResolution") + " x " + cls_system_info.GetPrimaryGPUInfo("CurrentVerticalResolution");
                }
                else
                {
                    primarygpuresdis = "";
                }
                if (cls_system_info.GetPrimaryGPUInfo("CurrentBitsPerPixel") != "")
                {
                    primarygpubitdis = cls_system_info.GetPrimaryGPUInfo("CurrentBitsPerPixel") + " bit";
                }
                else
                {
                    primarygpubitdis = "";
                }
                if (cls_system_info.GetPrimaryGPUInfo("CurrentRefreshRate") != "")
                {
                    primarygpurratedis = cls_system_info.GetPrimaryGPUInfo("CurrentRefreshRate") + " Hertz";
                }
                else
                {
                    primarygpurratedis = "";
                }
                primarygpumanufacturerdis = cls_system_info.GetPrimaryGPUInfo("AdapterCompatibility");
            }
            else
            {
                //GPUSecondary
                secondarygpudactypedis = cls_system_info.GetSecondaryGPUInfo("AdapterDACType");
                secondarygpumemorydis = (Convert.ToInt64(cls_system_info.GetSecondaryGPUInfo("AdapterRAM")) / 1024 / 1024).ToString() + "MB";
                secondarygpumanufacturerdis = cls_system_info.GetSecondaryGPUInfo("AdapterCompatibility");
                if (cls_system_info.GetSecondaryGPUInfo("CurrentHorizontalResolution") != "" && cls_system_info.GetSecondaryGPUInfo("CurrentVerticalResolution") != "")
                {
                    secondarygpuresdis = cls_system_info.GetSecondaryGPUInfo("CurrentHorizontalResolution") + " x " + cls_system_info.GetSecondaryGPUInfo("CurrentVerticalResolution");
                }
                else
                {
                    secondarygpuresdis = "";
                }
                if (cls_system_info.GetSecondaryGPUInfo("CurrentBitsPerPixel") != "")
                {
                    secondarygpubitdis = cls_system_info.GetSecondaryGPUInfo("CurrentBitsPerPixel") + " bit";
                }
                else
                {
                    secondarygpubitdis = "";
                }
                if (cls_system_info.GetSecondaryGPUInfo("CurrentRefreshRate") != "")
                {
                    secondarygpurratedis = cls_system_info.GetSecondaryGPUInfo("CurrentRefreshRate") + " Hertz";
                }
                else
                {
                    secondarygpurratedis = "";
                }

                //GPUPrimary
                primarygpumanufacturerdis = cls_system_info.GetPrimaryGPUInfo("AdapterCompatibility");
                primarygpudactypedis = cls_system_info.GetPrimaryGPUInfo("AdapterDACType");
                primarygpumemorydis = (Convert.ToInt64(cls_system_info.GetPrimaryGPUInfo("AdapterRAM")) / 1024 / 1024).ToString() + "MB";
                if (cls_system_info.GetPrimaryGPUInfo("CurrentHorizontalResolution") != "" && cls_system_info.GetPrimaryGPUInfo("CurrentVerticalResolution") != "")
                {
                    primarygpuresdis = cls_system_info.GetPrimaryGPUInfo("CurrentHorizontalResolution") + " x " + cls_system_info.GetPrimaryGPUInfo("CurrentVerticalResolution");
                }
                else
                {
                    primarygpuresdis = "";
                }
                if (cls_system_info.GetPrimaryGPUInfo("CurrentBitsPerPixel") != "")
                {
                    primarygpubitdis = cls_system_info.GetPrimaryGPUInfo("CurrentBitsPerPixel") + " bit";
                }
                else
                {
                    primarygpubitdis = "";
                }
                if (cls_system_info.GetPrimaryGPUInfo("CurrentRefreshRate") != "")
                {
                    primarygpurratedis = cls_system_info.GetPrimaryGPUInfo("CurrentRefreshRate") + " Hertz";
                }
                else
                {
                    primarygpurratedis = "";
                }
            }

            //Computer Battery
            PowerStatus status = SystemInformation.PowerStatus;
            if (status.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery && status.BatteryChargeStatus != BatteryChargeStatus.Unknown)
            {               
                batteryvoltagedis = cls_system_info.GetBatteryInfo("DesignVoltage")!= String.Empty ? cls_system_info.GetBatteryInfo("DesignVoltage")+"mV" : "Unknown";
                batterychemistrydis = cls_system_info.GetBatteryInfo("Chemistry") != String.Empty ? cls_system_info.GetBatteryInfo("Chemistry") + "mWh" : "2";
                batteryavailability = "Available";
            }
            bgw_detect.ReportProgress(100, "Detection Completed");
            Thread.Sleep(1000);

            systemdatetimedis = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day + " " + DateTime.Now.Year + ", " + DateTime.Now.ToLongTimeString();
        }

        private void bgw_detect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (((frm_system_info)Application.OpenForms["frm_system_info"]) == null)
            {
                f1.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                if ((Application.OpenForms["frm_system_info"]) != null)
                {
                    (Application.OpenForms["frm_system_info"] as frm_system_info).frm_system_info_Load(this, null);
                    (Application.OpenForms["frm_system_info"] as frm_system_info).btnrefreshdata.Enabled = true;
                    (Application.OpenForms["frm_system_info"] as frm_system_info).progressBar1.Visible = false;
                    (Application.OpenForms["frm_system_info"] as frm_system_info).progressBarWEICheck.Visible = false;
                    (Application.OpenForms["frm_system_info"] as frm_system_info).lblrefreshstatus.Text = "Refreshed Successfully";
                    (Application.OpenForms["frm_system_info"] as frm_system_info).btnrefreshdata.Text = "Refresh Data";
                    (Application.OpenForms["frm_system_info"] as frm_system_info).timer5.Stop();
                    (Application.OpenForms["frm_system_info"] as frm_system_info).Icon = Properties.Resources.Icon1;
                    (Application.OpenForms["frm_system_info"] as frm_system_info).pb_about.Image = Properties.Resources.Icon;
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                    (Application.OpenForms["frm_system_info"] as frm_system_info).lblHeader.Text = "System Info";
                }
            }
        }

        private void bgw_detect_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (((frm_system_info)Application.OpenForms["frm_system_info"]) == null)
            {
                progressBar1.Value = e.ProgressPercentage;
                lblprogressinfo.Text = e.ProgressPercentage.ToString() + "% - " + e.UserState.ToString();
            }
            else
            {
                if ((System.Windows.Forms.Application.OpenForms["frm_system_info"]) != null)
                {
                    (System.Windows.Forms.Application.OpenForms["frm_system_info"] as frm_system_info).progressBar1.Value = e.ProgressPercentage;
                    try
                    {
                        TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100);
                    }
                    catch
                    {

                    }
                    (Application.OpenForms["frm_system_info"] as frm_system_info).progressBarWEICheck.Value = e.ProgressPercentage;
                    (Application.OpenForms["frm_system_info"] as frm_system_info).btnrefreshdata.Text = e.ProgressPercentage + "%";
                    (Application.OpenForms["frm_system_info"] as frm_system_info).lblHeader.Text = e.ProgressPercentage + "% - System Info";
                }
            }
        }
    }
}