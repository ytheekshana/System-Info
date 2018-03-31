using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Devices;
using System.Net.NetworkInformation;
using System.Threading;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;

namespace System_Info
{
    public partial class frm_system_info : Form
    {
        public static int batcharging = 0;
        NetworkInterface[] ni;
        Thread cusage;
        Thread[] CPUStressThread;
        List<Thread> StressThreads;
        int cpuusagedis, timercount = 3, a, stressbutton = 1, Stresstrackbarval = 100, icontimecount = 0;
        String Bit;
        DateTime SystemUpTime;
        ulong totalram, freeram, usedram;
        Double average;
        Color batteryuncharge;
        int startLocationX = 540, endLocation = 320, panelstatus = 0;

        public frm_system_info()
        {
            InitializeComponent();
            pb_user.Image = cls_system_info.GetUserTile(Environment.UserName);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public void frm_system_info_Load(object sender, EventArgs e)
        {
            //Code By ytheekshana
            lbl_username.Text = "Hello " + Environment.UserName;
            Color getcolor = Properties.Settings.Default.ThemeColor;
            lblHeader.BackColor = getcolor;
            btnClose.BackColor = getcolor;
            btnMinimize.BackColor = getcolor;
            label13.BackColor = getcolor;
            label14.BackColor = getcolor;
            label15.BackColor = getcolor;
            pb_user.BackColor = getcolor;
            lbl_username.BackColor = getcolor;
            pb_battery.BackColor = getcolor;
            batteryuncharge = getcolor;

            SystemEvents.PowerModeChanged -= new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            ShowBattery();
            lbl_app_version.Text = "Version " + frm_detect.Version + " - March 2018";
            ComputerInfo ci = new ComputerInfo();
            totalram = ci.TotalPhysicalMemory / 1024 / 1024;
            lblInstalledmemorydis.Text = (totalram).ToString() + "MB";
            lblsystemmemorydis.Text = (totalram).ToString() + "MB";
            timer1.Start();
            timer2.Start();
            lblsystemlangdis.Text = System.Globalization.CultureInfo.CurrentUICulture.DisplayName;

            if (System.Environment.Is64BitOperatingSystem == true)
            {
                Bit = "64 Bit";
            }
            else
            {
                Bit = "32 Bit";
            }
            lblosnamedis.Text = ci.OSFullName + " (" + Bit + ")";
            lblcompnamedis.Text = System.Environment.MachineName;

            //Computer System
            //Code By ytheekshana
            lblsystemmanufacturerdis.Text = frm_detect.systemmanufacturerdis;
            lblsystemmodeldis.Text = frm_detect.systemmodeldis;

            //Operating System
            //Code By ytheekshana
            lblososnamedis.Text = ci.OSFullName;
            string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            if (lblososnamedis.Text.Contains("Microsoft Windows 10") || lblososnamedis.Text.Contains("Windows Server 2016"))
            {
                switch (releaseId)
                {
                    case "1507":
                        lblosversiondis.Text = releaseId + " - Initial Release";
                        break;
                    case "1511":
                        lblosversiondis.Text = releaseId + " - November Update";
                        break;
                    case "1607":
                        lblosversiondis.Text = releaseId + " - Anniversary Update";
                        break;
                    case "1703":
                        lblosversiondis.Text = releaseId + " - Creators Update";
                        break;
                    case "1709":
                        lblosversiondis.Text = releaseId + " - Fall Creators Update";
                        break;
                    case "1803":
                        lblosversiondis.Text = releaseId + " - Spring Creators Update";
                        break;
                }
            }
            else
            {
                lblosversiondis.Text = ci.OSVersion;
            }
            lblosplatformdis.Text = ci.OSPlatform;
            lblosbuildnumberdis.Text = frm_detect.osbuildnumberdis;
            if (frm_detect.osantivirusdis == "")
            {
                lblosantivirusdis.Text = "Not Installed";
            }
            else
            {
                lblosantivirusdis.Text = frm_detect.osantivirusdis;
            }
            lblosregistereduserdis.Text = frm_detect.osregistereduserdis;

            lblinstalldatedis.Text = frm_detect.InstallDate.Day.ToString() + " " + frm_detect.InstallDate.ToString("MMMM") + " " + frm_detect.InstallDate.Year.ToString();

            OperatingSystem os = Environment.OSVersion;
            if (os.ServicePack == "")
            {
                lblosservicepackdis.Text = "None";
            }
            else
            {
                lblosservicepackdis.Text = os.ServicePack;
            }

            //CPU
            //Code By ytheekshana
            lblcpunamedis.Text = frm_detect.cpunamedis;
            lblcpunamedis2.Text = frm_detect.cpunamedis2;
            lblcoresdis.Text = System.Environment.ProcessorCount.ToString();
            lblcputhreadsdis.Text = frm_detect.cputhreadsdis;
            lblsocketdis.Text = frm_detect.socketdis;
            lblclockspeeddis.Text = frm_detect.clockspeeddis;
            lblcpumanufacturerdis.Text = frm_detect.cpumanufacturerdis;
            lblcpurevisiondis.Text = frm_detect.cpurevisiondis;
            lbll2cachesizedis.Text = frm_detect.l2cachesizedis + "KB";

            if (Convert.ToInt32(frm_detect.l3cachesizedis) > 100)
            {
                lbll3cachesizedis.Text = (Convert.ToInt32(frm_detect.l3cachesizedis)).ToString() + "KB";
            }
            else
            {
                lbll3cachesizedis.Text = (Convert.ToInt32(frm_detect.l3cachesizedis) * 1024).ToString() + "KB";
            }


            //MotherBoard
            //Code By ytheekshana
            lblmboardmanufacturerdis.Text = frm_detect.mboardmanufacturerdis;
            lblmboardmodeldis.Text = frm_detect.mboardmodeldis;

            //Storage
            //Code By ytheekshana
            lblprimaryHardModeldis.Text = frm_detect.primaryHardModeldis;
            if (frm_detect.primaryHardsizedis != "")
            {
                lblprimaryHardsizedis.Text = (Math.Round((Convert.ToDouble(frm_detect.primaryHardsizedis) / 1024 / 1024 / 1024), 2)).ToString() + " GB";
            }
            lblprimaryHardpartitionsDis.Text = frm_detect.primaryHardpartitionsDis;
            lblprimaryharddisktypedis.Text = frm_detect.primaryharddisktypedis;

            if (String.IsNullOrEmpty(frm_detect.secondaryHardsizedis))
            {
                groupBox11.Visible = false;
            }
            else
            {
                lblsecondaryHardModeldis.Text = frm_detect.secondaryHardModeldis;
                if (frm_detect.secondaryHardsizedis != "")
                {
                    lblsecondaryHardsizedis.Text = (Math.Round((Convert.ToDouble(frm_detect.secondaryHardsizedis) / 1024 / 1024 / 1024), 2)).ToString() + " GB";
                }
                lblsecondaryHardpartitionsDis.Text = frm_detect.secondaryHardpartitionsDis;
                lblsecondaryHarddisktypedis.Text = frm_detect.secondaryHarddisktypedis;
                groupBox11.Visible = true;
            }

            //BIOS
            //Code By ytheekshana
            lblbiosnamedis.Text = frm_detect.biosnamedis;
            lblbiosmanufacturerdis.Text = frm_detect.biosmanufacturerdis;
            lblbiosversiondis.Text = frm_detect.biosversiondis;
            lblsystembiosdis.Text = frm_detect.systembiosdis;
            lblbiosreleasedatedis.Text = frm_detect.Biosreleasedate.Day + " " + frm_detect.Biosreleasedate.ToString("MMMM") + " " + frm_detect.Biosreleasedate.Year;

            //GPU
            //Code By ytheekshana
            if (String.IsNullOrEmpty(frm_detect.secondarygpunamedis))
            {
                cmbgpu.Items.Clear();
                cmbgpu.Items.Add(frm_detect.primarygpunamedis);
                cmbgpu.SelectedItem = frm_detect.primarygpunamedis;
            }
            else
            {
                cmbgpu.Items.Clear();
                cmbgpu.Items.Add(frm_detect.primarygpunamedis);
                cmbgpu.Items.Add(frm_detect.secondarygpunamedis);
                cmbgpu.SelectedItem = frm_detect.primarygpunamedis;
            }

            lblsystemdatetimedis.Text = frm_detect.systemdatetimedis;



            //System Up Time
            //Code By ytheekshana
            SystemUpTime = ManagementDateTimeConverter.ToDateTime(frm_detect.systemuptime);
            int osuptime = Convert.ToInt32(DateTime.Now.Subtract(SystemUpTime).TotalMinutes);
            int uphours = osuptime / 60;
            int upminutes = osuptime % 60;

            if (uphours == 0 && upminutes != 0)
            {
                lblsystemupdis.Text = upminutes.ToString() + " Minutes";
            }
            else if (upminutes == 0 && uphours != 0)
            {
                lblsystemupdis.Text = uphours.ToString() + " Hours";
            }
            else
            {
                lblsystemupdis.Text = uphours.ToString() + " Hours & " + upminutes.ToString() + " Minutes";
            }

            //Memory
            //Code By ytheekshana
            int ramtypeno = Convert.ToInt32(frm_detect.memorytypedis);
            String ramtype;
            switch (ramtypeno)
            {
                case 1: ramtype = "Other"; break;
                case 2: ramtype = "DRAM"; break;
                case 3: ramtype = "Synchronous DRAM"; break;
                case 4: ramtype = "Cache DRAM"; break;
                case 5: ramtype = "EDO"; break;
                case 6: ramtype = "EDRAM"; break;
                case 7: ramtype = "VRAM"; break;
                case 8: ramtype = "SRAM"; break;
                case 9: ramtype = "RAM"; break;
                case 10: ramtype = "ROM"; break;
                case 11: ramtype = "Flash"; break;
                case 12: ramtype = "EEPROM"; break;
                case 13: ramtype = "FEPROM"; break;
                case 14: ramtype = "EPROM"; break;
                case 15: ramtype = "CDRAM"; break;
                case 16: ramtype = "3DRAM"; break;
                case 17: ramtype = "SDRAM"; break;
                case 18: ramtype = "SGRAM"; break;
                case 19: ramtype = "RDRAM"; break;
                case 20: ramtype = "DDR"; break;
                case 21: ramtype = "DDR2"; break;
                case 22: ramtype = "DDR2 FB-DIMM"; break;
                default: if (ramtypeno == 0 || ramtypeno > 22) { ramtype = "DDR3"; } else { ramtype = "Unknown"; } break;
            }
            lblmemorytypedis.Text = ramtype;
            lblmemoryslotsdis.Text = frm_detect.memoryslotsdis;
            //TooTip
            //Code By ytheekshana
            ToolTip gpuname = new ToolTip();
            gpuname.SetToolTip(lblgpunamedis, lblgpunamedis.Text);

            //OS-Storage  Logo
            //Code By ytheekshana
            cls_images mi = new cls_images();
            mi.OSImage(lblososnamedis.Text);
            mi.PrimaryStorageImage(lblprimaryHardModeldis.Text);
            if (frm_detect.secondaryHardsizedis != "")
            {
                mi.SecondaryStorageImage(lblsecondaryHardModeldis.Text);
            }

            //Network
            //Code By ytheekshana
            ni = NetworkInterface.GetAllNetworkInterfaces();
            cmbnetworkadapter.Items.Clear();
            foreach (var adapter in ni)
            {
                if (adapter.Description.ToLower().Contains("tunneling") || adapter.Description.ToLower().Contains("bluetooth") || adapter.Description.ToLower().Contains("loopback") || adapter.Description.ToLower().Contains("isatap")) { }
                else
                {
                    cmbnetworkadapter.Items.Add(adapter.Name);
                }
            }
            if (cmbnetworkadapter.Items.Count > 0)
            {
                cmbnetworkadapter.SelectedIndex = 0;
            }

            //WEI
            lblWEIProcessordis.Text = frm_detect.WEIProcessordis;
            lblWEIMemorydis.Text = frm_detect.WEIMemorydis;
            lblWEIGraphicsdis.Text = frm_detect.WEIGraphicsdis;
            lblWEIGamingGraphicsdis.Text = frm_detect.WEIGamingGraphicsdis;
            lblWEIDiskdis.Text = frm_detect.WEIDiskdis;
            lblWEITotal.Text = frm_detect.WEITotal;
            lblgeneralRatingdis.Text = frm_detect.WEITotal + " - Windows Experience Index";

            //Trackbar
            trackBarStress.Value = 100;
            DisplayWEI();

            //Battery
            if (frm_detect.batteryavailability == "Available")
            {
                String batterychem;
                lblbatteryvoltagedis.Text = frm_detect.batteryvoltagedis;
                switch (frm_detect.batterychemistrydis) {
                    case "1":
                        batterychem = "Other";break;
                    case "2":
                        batterychem = "Unknown"; break;
                    case "3":
                        batterychem = "Lead Acid"; break;
                    case "4":
                        batterychem = "Nickel Cadmium"; break;
                    case "5":
                        batterychem = "Nickel Metal Hydride"; break;
                    case "6":
                        batterychem = "Lithium-ion"; break;
                    case "7":
                        batterychem = "Zinc air"; break;
                    case "8":
                        batterychem = "Lithium Polymer"; break;
                    default:
                        batterychem = "Unkown"; break;
                }
                lblbatterychemistrydis.Text = batterychem;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void ClearTabLabel()
        {
            List<Label> TabLabel = new List<Label> {
            lbltabGeneral,lbltabMemory,lbltabCPU,lbltabMotherBoard,lbltabGraphics,lbltabOS,lbltabStorage,lbltabNetwork,lbltabAbout,lbltabRating
            };
            foreach (Label Checklabel in TabLabel)
            {
                Checklabel.BackColor = Color.FromName("ActiveBorder");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Code By ytheekshana
            SystemUpTime = ManagementDateTimeConverter.ToDateTime(cls_system_info.GetOSInfo("LastBootUpTime"));
            int osuptime = Convert.ToInt32(DateTime.Now.Subtract(SystemUpTime).TotalMinutes);
            int uphours = osuptime / 60;
            int upminutes = osuptime % 60;

            if (uphours == 0 && upminutes != 0)
            {
                lblsystemupdis.Text = upminutes.ToString() + " Minutes";
            }
            else if (upminutes == 0 && uphours != 0)
            {
                lblsystemupdis.Text = uphours.ToString() + " Hours";
            }
            else
            {
                lblsystemupdis.Text = uphours.ToString() + " Hours & " + upminutes.ToString() + " Minutes";
            }
        }

        private void CPUUsage()
        {
            //Code By ytheekshana
            var cpuusage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuusage.NextValue();
            System.Threading.Thread.Sleep(1000);
            cpuusagedis = (int)cpuusage.NextValue();
        }

        private void frm_system_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Code By ytheekshana
            cusage.Abort();
            //Application.Exit();
        }

        private void cmbgpu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Code By ytheekshana
            cls_images mi2 = new cls_images();
            if ((String)cmbgpu.SelectedItem == frm_detect.primarygpunamedis)
            {
                lblgpunamedis.Text = frm_detect.primarygpunamedis;
                lblgpudactypedis.Text = frm_detect.primarygpudactypedis;
                lblgpumemorydis.Text = frm_detect.primarygpumemorydis;

                if (frm_detect.primarygpuresdis != "" && String.IsNullOrEmpty(frm_detect.secondarygpuresdis))
                {
                    lblgpuresdis.Text = frm_detect.primarygpuresdis;
                }
                else if (String.IsNullOrEmpty(frm_detect.primarygpuresdis) && frm_detect.secondarygpuresdis != "")
                {
                    lblgpuresdis.Text = frm_detect.secondarygpuresdis;
                }
                else if (frm_detect.primarygpuresdis != "" && frm_detect.secondarygpuresdis != "")
                {
                    lblgpuresdis.Text = frm_detect.primarygpuresdis;
                }
                else
                {
                    lblgpuresdis.Text = "No Value";
                }


                if (frm_detect.primarygpubitdis != "" && String.IsNullOrEmpty(frm_detect.secondarygpubitdis))
                {
                    lblgpubitdis.Text = frm_detect.primarygpubitdis;
                }
                else if (String.IsNullOrEmpty(frm_detect.primarygpubitdis) && frm_detect.secondarygpubitdis != "")
                {
                    lblgpubitdis.Text = frm_detect.secondarygpubitdis;
                }
                else if (frm_detect.primarygpubitdis != "" && frm_detect.secondarygpubitdis != "")
                {
                    lblgpubitdis.Text = frm_detect.primarygpubitdis;
                }
                else
                {
                    lblgpubitdis.Text = "No Value";
                }

                if (frm_detect.primarygpurratedis != "" && String.IsNullOrEmpty(frm_detect.secondarygpurratedis))
                {
                    lblgpurratedis.Text = frm_detect.primarygpurratedis;
                }
                else if (String.IsNullOrEmpty(frm_detect.primarygpurratedis) && frm_detect.secondarygpurratedis != "")
                {
                    lblgpurratedis.Text = frm_detect.secondarygpurratedis;
                }
                else if (frm_detect.primarygpurratedis != "" && frm_detect.secondarygpurratedis != "")
                {
                    lblgpurratedis.Text = frm_detect.primarygpurratedis;
                }
                else
                {
                    lblgpurratedis.Text = "No Value";
                }

                lblgpumanufacturerdis.Text = frm_detect.primarygpumanufacturerdis;
                mi2.GraphicsImage(lblgpumanufacturerdis.Text);
            }
            else if ((String)cmbgpu.SelectedItem == frm_detect.secondarygpunamedis)
            {
                lblgpunamedis.Text = frm_detect.secondarygpunamedis;
                lblgpudactypedis.Text = frm_detect.secondarygpudactypedis;
                lblgpumemorydis.Text = frm_detect.secondarygpumemorydis;

                if (frm_detect.primarygpuresdis != "" && String.IsNullOrEmpty(frm_detect.secondarygpuresdis))
                {
                    lblgpuresdis.Text = frm_detect.primarygpuresdis;
                }
                else if (String.IsNullOrEmpty(frm_detect.primarygpuresdis) && frm_detect.secondarygpuresdis != "")
                {
                    lblgpuresdis.Text = frm_detect.secondarygpuresdis;
                }
                else if (frm_detect.primarygpuresdis != "" && frm_detect.secondarygpuresdis != "")
                {
                    lblgpuresdis.Text = frm_detect.secondarygpuresdis;
                }
                else
                {
                    lblgpuresdis.Text = "No Value";
                }


                if (frm_detect.primarygpubitdis != "" && String.IsNullOrEmpty(frm_detect.secondarygpubitdis))
                {
                    lblgpubitdis.Text = frm_detect.primarygpubitdis;
                }
                else if (String.IsNullOrEmpty(frm_detect.primarygpubitdis) && frm_detect.secondarygpubitdis != "")
                {
                    lblgpubitdis.Text = frm_detect.secondarygpubitdis;
                }
                else if (frm_detect.primarygpubitdis != "" && frm_detect.secondarygpubitdis != "")
                {
                    lblgpubitdis.Text = frm_detect.primarygpubitdis;
                }
                else
                {
                    lblgpubitdis.Text = "No Value";
                }

                if (frm_detect.primarygpurratedis != "" && String.IsNullOrEmpty(frm_detect.secondarygpurratedis))
                {
                    lblgpurratedis.Text = frm_detect.primarygpurratedis;
                }
                else if (String.IsNullOrEmpty(frm_detect.primarygpurratedis) && frm_detect.secondarygpurratedis != "")
                {
                    lblgpurratedis.Text = frm_detect.secondarygpurratedis;
                }
                else if (frm_detect.primarygpurratedis != "" && frm_detect.secondarygpurratedis != "")
                {
                    lblgpurratedis.Text = frm_detect.primarygpurratedis;
                }
                else
                {
                    lblgpurratedis.Text = "No Value";
                }

                lblgpumanufacturerdis.Text = frm_detect.secondarygpumanufacturerdis;
                mi2.GraphicsImage(lblgpumanufacturerdis.Text);
            }
        }

        private void btnsavereporthtml_Click(object sender, EventArgs e)
        {
            //Code By ytheekshana
            cls_report r = new cls_report();
            r.ReportHTML();
        }

        private void btnsavereporttxt_Click(object sender, EventArgs e)
        {
            //Code By ytheekshana
            cls_report r2 = new cls_report();
            r2.ReportText();
        }

        private void btnrefreshdata_Click(object sender, EventArgs e)
        {
            //Code By ytheekshana
            if (timer5.Enabled == false)
            {
                timer5.Start();
            }
            pb_about.Image = Properties.Resources.ReGif80;
            progressBar1.Visible = true;
            btnrefreshdata.Enabled = false;
            frm_detect d = new frm_detect();
            d.Show();
            d.Opacity = 0;
            d.Visible = false;
        }

        private void btnchangecolor_Click(object sender, EventArgs e)
        {
            ColorDialog ChangeTheme = new ColorDialog();
            ChangeTheme.AnyColor = true;
            if (ChangeTheme.ShowDialog() == DialogResult.OK)
            {
                lblHeader.BackColor = ChangeTheme.Color;
                btnClose.BackColor = ChangeTheme.Color;
                btnMinimize.BackColor = ChangeTheme.Color;
                label13.BackColor = ChangeTheme.Color;
                label14.BackColor = ChangeTheme.Color;
                label15.BackColor = ChangeTheme.Color;
                pb_user.BackColor = ChangeTheme.Color;
                lbl_username.BackColor = ChangeTheme.Color;
                pb_battery.BackColor = ChangeTheme.Color;
                batteryuncharge = ChangeTheme.Color;
                Properties.Settings.Default.ThemeColor = ChangeTheme.Color;
                Properties.Settings.Default.Save();
                ShowBattery();
            }
        }

        private void lblrefreshstatus_TextChanged(object sender, EventArgs e)
        {
            //Code By ytheekshana
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Code By ytheekshana
            timercount -= 1;
            if (timercount == 0)
            {
                lblrefreshstatus.Text = "";
                timer3.Stop();
                timercount = 3;
            }
        }

        private void cmbnetworkadapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Code By ytheekshana
            try
            {
                lblnetworkimage.Image = null;
                lblnetworkadapterdescriptiondis.Text = "";
                lblnetworkbytesreceiveddis.Text = "";
                lblnetworkbytessentdis.Text = "";
                lblnetworkdhcpenableddis.Text = "";
                lblNetworkInterfacetypedis.Text = "";
                lblnetworkmacdis.Text = "";
                lblnetworkspeeddis.Text = "";
                lblnetworkstatusdis.Text = "";

                for (a = 0; a < ni.Length; a++)
                {
                    if ((String)cmbnetworkadapter.SelectedItem == ni[a].Name)
                    {
                        break;
                    }
                }
                lblNetworkInterfacetypedis.Text = ni[a].NetworkInterfaceType.ToString();
                lblnetworkadapterdescriptiondis.Text = ni[a].Description.ToString();

                String networkmacdis = ni[a].GetPhysicalAddress().ToString();
                int l = networkmacdis.Length;
                for (int i = 2; i < l; i = i + 3)
                {
                    networkmacdis = networkmacdis.Insert(i, ":");
                    l = l + 1;
                }
                lblnetworkmacdis.Text = networkmacdis;

                if (ni[a].GetIPProperties().GetIPv4Properties().IsDhcpEnabled == false)
                {
                    lblnetworkdhcpenableddis.Text = "No";
                }
                else if (ni[a].GetIPProperties().GetIPv4Properties().IsDhcpEnabled == true)
                {
                    lblnetworkdhcpenableddis.Text = "Yes";
                }
                lblnetworkspeeddis.Text = (Convert.ToInt32(ni[a].Speed) / 1024 / 1024).ToString() + " Mbps";
                lblnetworkstatusdis.Text = ni[a].OperationalStatus.ToString();

                long networkbytesreceiveddis = ni[a].GetIPv4Statistics().BytesReceived;
                long networkbytessentdis = ni[a].GetIPv4Statistics().BytesSent;
                lblnetworkbytesreceiveddis.Text = String.Format("{0:0,0}", networkbytesreceiveddis) + " bytes";
                lblnetworkbytessentdis.Text = String.Format("{0:0,0}", networkbytessentdis) + " bytes";
                timer4.Stop();
                timer4.Start();

                cls_images mi3 = new cls_images();
                mi3.NetworkImage(lblnetworkadapterdescriptiondis.Text);


                ToolTip networkname = new ToolTip();
                networkname.SetToolTip(lblnetworkadapterdescriptiondis, lblnetworkadapterdescriptiondis.Text);
            }
            catch
            {
                MessageBox.Show("No Information Available", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //Code By ytheekshana
            long networkbytesreceiveddis = ni[a].GetIPv4Statistics().BytesReceived;
            long networkbytessentdis = ni[a].GetIPv4Statistics().BytesSent;
            lblnetworkbytesreceiveddis.Text = String.Format("{0:0,0}", networkbytesreceiveddis) + " bytes";
            lblnetworkbytessentdis.Text = String.Format("{0:0,0}", networkbytessentdis) + " bytes";
            lblnetworkspeeddis.Text = (Convert.ToInt32(ni[a].Speed) / 1024 / 1024).ToString() + " Mbps  :  ↓" + cls_system_info.NetDownSpeed(Convert.ToDouble(ni[a].GetIPv4Statistics().BytesReceived)) + "     ↑" + cls_system_info.NetUpSpeed(Convert.ToDouble(ni[a].GetIPv4Statistics().BytesSent));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Code By ytheekshana
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                ClearTabLabel();
                lbltabGeneral.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                ClearTabLabel();
                lbltabMemory.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                ClearTabLabel();
                lbltabCPU.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                ClearTabLabel();
                lbltabMotherBoard.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[4])
            {
                ClearTabLabel();
                lbltabGraphics.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[5])
            {
                ClearTabLabel();
                lbltabOS.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[6])
            {
                ClearTabLabel();
                lbltabRating.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[7])
            {
                ClearTabLabel();
                lbltabStorage.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[8])
            {
                ClearTabLabel();
                lbltabNetwork.BackColor = Color.FromName("ControlDarkDark");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[9])
            {
                ClearTabLabel();
                lbltabAbout.BackColor = Color.FromName("ControlDarkDark");
            }
        }

        private void CPUStress()
        {
            Stopwatch Scpu = new Stopwatch();
            Scpu.Start();
            while (true)
            {
                if (Scpu.ElapsedMilliseconds > Stresstrackbarval)
                {
                    Thread.Sleep(100 - Stresstrackbarval);
                    Scpu.Reset();
                    Scpu.Start();
                }
            }
        }

        private void btnstress_Click(object sender, EventArgs e)
        {
            if (stressbutton == 1)
            {
                CPUStressThread = new Thread[Environment.ProcessorCount];
                StressThreads = new List<Thread>();

                for (int i = 0; i < CPUStressThread.Length; i++)
                {
                    CPUStressThread[i] = new Thread(new ThreadStart(CPUStress));

                    CPUStressThread[i].IsBackground = true;
                    CPUStressThread[i].Name = "CPU Stress";
                    CPUStressThread[i].Start();
                    StressThreads.Add(CPUStressThread[i]);
                }
                stressbutton = 2;
                btnstress.Text = "Stop";
            }

            else if (stressbutton == 2)
            {
                foreach (Thread StopStressThreads in StressThreads)
                {
                    StopStressThreads.Abort();
                }
                stressbutton = 1;
                btnstress.Text = "Stress CPU";
            }
        }

        private void trackBarStress_Scroll(object sender, EventArgs e)
        {
            Stresstrackbarval = trackBarStress.Value;
            lbltrackbarpercent.Text = trackBarStress.Value.ToString() + "%";
        }

        private void pb_about_Click(object sender, EventArgs e)
        {
            int CurposX = frm_system_info.ActiveForm.Location.X;
            int CurposY = frm_system_info.ActiveForm.Location.Y;
            frm_system_info.ActiveForm.Location = new Point(CurposX + 7, CurposY);
            Thread.Sleep(50);
            frm_system_info.ActiveForm.Location = new Point(CurposX - 7, CurposY);
            Thread.Sleep(50);
            frm_system_info.ActiveForm.Location = new Point(CurposX + 7, CurposY);
            Thread.Sleep(50);
            frm_system_info.ActiveForm.Location = new Point(CurposX - 7, CurposY);
            Thread.Sleep(50);
            frm_system_info.ActiveForm.Location = new Point(CurposX + 7, CurposY);
            Thread.Sleep(50);
            frm_system_info.ActiveForm.Location = new Point(CurposX - 7, CurposY);
            Thread.Sleep(50);
            frm_system_info.ActiveForm.Location = new Point(CurposX, CurposY);
        }

        private void btnrunWEI_Click(object sender, EventArgs e)
        {
            try
            {
                if (timer5.Enabled == false)
                {
                    timer5.Start();
                }
                pb_about.Image = Properties.Resources.ReGif80;
                IntPtr wow64Value = IntPtr.Zero;
                Wow64DisableWow64FsRedirection(ref wow64Value);
                Process RunWMI = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("cmd", "/C WinSAT formal");
                psi.UseShellExecute = true;
                psi.Verb = "runas";
                RunWMI.SynchronizingObject = progressBarWEICheck;
                RunWMI.StartInfo = psi;
                RunWMI.Start();
                Wow64RevertWow64FsRedirection(wow64Value);

                RunWMI.EnableRaisingEvents = true;
                RunWMI.Exited += new EventHandler(WEIAfter);
            }
            catch
            {

            }
        }

        private void WEIAfter(object sender, EventArgs e)
        {
            progressBarWEICheck.Visible = true;
            btnrefreshdata_Click(this, e);
            DisplayWEI();
        }

        private void DisplayWEI()
        {
            if (lblWEITotal.Text == "0")
            {
                btnrunWEI.Visible = true;
                lblWEIRunAgain.Visible = false;
                label5.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                lblWEIProcessor.Visible = false;
                lblWEIMemory.Visible = false;
                lblWEIGraphics.Visible = false;
                lblWEIGamingGraphics.Visible = false;
                lblWEIDisk.Visible = false;
                lblWEIProcessordis.Visible = false;
                lblWEIMemorydis.Visible = false;
                lblWEIGraphicsdis.Visible = false;
                lblWEIGamingGraphicsdis.Visible = false;
                lblWEIDiskdis.Visible = false;
                lblWEITotal.Visible = false;
            }
            else
            {
                btnrunWEI.Visible = false;
                lblWEIRunAgain.Visible = true;
                label5.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                lblWEIProcessor.Visible = true;
                lblWEIMemory.Visible = true;
                lblWEIGraphics.Visible = true;
                lblWEIGamingGraphics.Visible = true;
                lblWEIDisk.Visible = true;
                lblWEIProcessordis.Visible = true;
                lblWEIMemorydis.Visible = true;
                lblWEIGraphicsdis.Visible = true;
                lblWEIGamingGraphicsdis.Visible = true;
                lblWEIDiskdis.Visible = true;
                lblWEITotal.Visible = true;
            }
        }

        private void lblWEIRunAgain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnrunWEI_Click(this, e);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            icontimecount = icontimecount + 1;
            if (icontimecount == 1)
            {
                this.Icon = Properties.Resources.Re1;
            }
            else if (icontimecount == 2)
            {
                this.Icon = Properties.Resources.Re2;
            }
            else if (icontimecount == 3)
            {
                this.Icon = Properties.Resources.Re3;
            }
            else if (icontimecount == 4)
            {
                this.Icon = Properties.Resources.Re4;
            }
            else if (icontimecount == 5)
            {
                this.Icon = Properties.Resources.Re5;
            }
            else if (icontimecount == 6)
            {
                this.Icon = Properties.Resources.Re6;
            }
            else if (icontimecount == 7)
            {
                this.Icon = Properties.Resources.Re7;
            }
            else if (icontimecount == 8)
            {
                this.Icon = Properties.Resources.Re8;
            }
            else if (icontimecount == 9)
            {
                this.Icon = Properties.Resources.Re9;
                icontimecount = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Code By ytheekshana
            lblsystemdatetimedis.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day + " " + DateTime.Now.Year + ", " + DateTime.Now.ToLongTimeString();
            ComputerInfo ci2 = new ComputerInfo();
            freeram = ci2.AvailablePhysicalMemory / 1024 / 1024;
            usedram = totalram - freeram;

            average = (Convert.ToInt32(usedram) * 100) / Convert.ToInt32(totalram);
            if (average > 85)
            {
                circularProgressBarUsedRam.ProgressColor = Color.Red;
                circularProgressBarFreeRam.ProgressColor = Color.Red;
            }
            else
            {
                circularProgressBarUsedRam.ProgressColor = Color.FromName("DeepSkyBlue");
                circularProgressBarFreeRam.ProgressColor = Color.FromName("DeepSkyBlue");
            }

            circularProgressBarFreeRam.Maximum = Convert.ToInt32(totalram);
            circularProgressBarFreeRam.Minimum = 0;
            circularProgressBarFreeRam.Value = Convert.ToInt32(freeram);
            circularProgressBarFreeRam.Text = (100 - average) + "% Free";

            circularProgressBarUsedRam.Maximum = Convert.ToInt32(totalram);
            circularProgressBarUsedRam.Minimum = 1;
            circularProgressBarUsedRam.Value = Convert.ToInt32(usedram);
            circularProgressBarUsedRam.Text = average + "% Used";
            lblusedram.Text = usedram.ToString() + "MB";
            lblfreeram.Text = freeram.ToString() + "MB";

            cusage = new Thread(CPUUsage);
            cusage.IsBackground = true;
            cusage.Start();
            circularProgressBarcpuusage.Value = cpuusagedis;
            circularProgressBarcpuusage.Text = cpuusagedis.ToString() + "%";
            if (circularProgressBarcpuusage.Value > 95)
            {
                circularProgressBarcpuusage.ProgressColor = Color.Red;
            }
            else if (circularProgressBarcpuusage.Value > 75)
            {
                circularProgressBarcpuusage.ProgressColor = Color.DarkOrange;
            }
            else
            {
                circularProgressBarcpuusage.ProgressColor = Color.LimeGreen;
            }
        }

        private void pictureBoxGplus_Click(object sender, EventArgs e)
        {
            Process.Start("https://plus.google.com/+YasiruTheekshana");
        }

        private void pictureBoxFb_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.fb.me/Yasiru.Theekshana");
        }

        private void ShowBattery()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            ToolTip tpbattery = new ToolTip();
            Color batcolor = Color.ForestGreen;
            if (status.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery && status.BatteryChargeStatus != BatteryChargeStatus.Unknown)
            {
                float percent = status.BatteryLifePercent;
                lbl_battery_level.Text = percent.ToString("P0");
                if (status.PowerLineStatus == PowerLineStatus.Online)
                {
                    batcharging = 1;
                    if (percent < 1.0f)
                    {
                        tpbattery.SetToolTip(pb_battery, percent.ToString("P0") + ", Plugged In, Charging");
                        lbl_battery_status.Text = "Charging";
                        lbl_battery_power_source.Text = "Plugged In";
                    }
                    else
                    {
                        tpbattery.SetToolTip(pb_battery, percent.ToString("P0") + ", Plugged In, Battery Full");
                        lbl_battery_status.Text = "Battery Full";
                        lbl_battery_power_source.Text = "Plugged In";
                    }
                }
                else
                {
                    batcharging = 0;
                    if (percent <= 0.07f)
                    {
                        tpbattery.SetToolTip(pb_battery, percent.ToString("P0") + ", Battery Level Critical");
                        lbl_battery_status.Text = "Critically Low";
                        lbl_battery_power_source.Text = "On Battery";
                        batcolor = Color.DarkRed;
                    }
                    else if (percent <= 0.2f)
                    {
                        tpbattery.SetToolTip(pb_battery, percent.ToString("P0") + ", Battery Low, Plug In");
                        lbl_battery_status.Text = "Battery Low";
                        lbl_battery_power_source.Text = "On Battery";
                        batcolor = Color.DarkRed;
                    }
                    else
                    {
                        tpbattery.SetToolTip(pb_battery, percent.ToString("P0") + ", On Battery");
                        lbl_battery_status.Text = "Discharging";
                        lbl_battery_power_source.Text = "On Battery";
                        batcolor = Color.ForestGreen;
                    }
                }
                pb_battery.Image = cls_battery.DrawBattery(percent, pb_battery.ClientSize.Width, pb_battery.ClientSize.Height, Color.Transparent, Color.White, Color.White, batteryuncharge, false);
                pb_battery_panel.Image = cls_battery.DrawBattery2(percent, pb_battery_panel.ClientSize.Width, pb_battery_panel.ClientSize.Height, Color.Transparent, Color.DarkGray, batcolor, Color.Transparent, false);

            }
            else
            {
                pb_battery.Image = Properties.Resources.No_Battery;
                tpbattery.SetToolTip(pb_battery, "Battery Not Detected");
            }
        }

        private void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            if (e.Mode == Microsoft.Win32.PowerModes.StatusChange)
            {
                ShowBattery();
            }
        }

        private void pb_battery_Click(object sender, EventArgs e)
        {
            ShowBattery();
            if (frm_detect.batteryavailability == "Available")
            {
                if (panelstatus == 0)
                {
                    pnl_battery.Visible = true;

                    if (!timer6.Enabled)
                    {
                        timer6.Start();
                    }
                }
                else if (panelstatus == 1)
                {
                    if (!timer6.Enabled)
                    {
                        timer6.Start();
                    }
                }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (panelstatus == 0)
            {
                pnl_battery.Location = new Point(pnl_battery.Location.X - 5, pnl_battery.Location.Y);
                if (pnl_battery.Location.X == endLocation)
                {
                    timer6.Stop();
                    panelstatus = 1;
                }
            }
            else if (panelstatus == 1)
            {
                pnl_battery.Location = new Point(pnl_battery.Location.X + 5, pnl_battery.Location.Y);
                if (pnl_battery.Location.X == startLocationX)
                {
                    timer6.Stop();
                    panelstatus = 0;
                    pnl_battery.Visible = false;
                }
            }
        }
    }
}
