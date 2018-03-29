using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System_Info
{
    class cls_images
    {
        frm_system_info f1 = (frm_system_info)Application.OpenForms["frm_system_info"];
        public void PrimaryStorageImage(String Model)
        {
            if (Model.ToLower().Contains("wdc") || Model.ToLower().Contains("western digital") || Model.ToLower().Contains("wd ") || Model.ToLower().Contains("westerndigital"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.WDC;
            }
            else if (Model.ToLower().Contains("hitachi"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Hitachi;
            }
            else if (Model.ToLower().Contains("maxtor"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Maxtor;
            }
            else if (Model.ToLower().Contains("samsung"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Samsung;
            }
            else if (Model.ToLower().Contains("toshiba"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Toshiba;
            }
            else if (Model.ToLower().Contains("seagate"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Seagate;
            }
            else if (Model.ToLower().Contains("fujitsu"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Fujitsu;
            }
            else if (Model.ToLower().Contains("kingston"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Kingston;
            }
            else if (Model.ToLower().Contains("sandisk"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Sandisk;
            }
            else if (Model.ToLower().Contains("sony"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Sony;
            }
            else if (Model.ToLower().Contains("transcend"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Transcend;
            }
            else if (Model.ToLower().Contains("adata"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Adata;
            }
            else if (Model.ToLower().Contains("corsair"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Corsair;
            }
            else if (Model.ToLower().Contains("patriot"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Patriot;
            }
            else if (Model.ToLower().Contains("dell"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Dell;
            }
            else if (Model.ToLower().Contains("hp"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.HP;
            }
            else if (Model.ToLower().Contains("liteon"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Liteon;
            }
            else if (Model.ToLower().Contains("crucial"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Crucial;
            }
            else if (Model.ToLower().Contains("intel"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Intel;
            }
            else if (Model.ToLower().Contains("micron"))
            {
                f1.lblprimaryhardimage.Image = Properties.Resources.Micron;
            }
            else
            {
                f1.lblprimaryhardimage.Image = null;
            }
        }

        public void SecondaryStorageImage(String Model)
        {
            if (Model.ToLower().Contains("wdc") || Model.ToLower().Contains("western digital") || Model.ToLower().Contains("wd ") || Model.ToLower().Contains("westerndigital"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.WDC;
            }
            else if (Model.ToLower().Contains("hitachi"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Hitachi;
            }
            else if (Model.ToLower().Contains("maxtor"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Maxtor;
            }
            else if (Model.ToLower().Contains("samsung"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Samsung;
            }
            else if (Model.ToLower().Contains("toshiba"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Toshiba;
            }
            else if (Model.ToLower().Contains("seagate"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Seagate;
            }
            else if (Model.ToLower().Contains("fujitsu"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Fujitsu;
            }
            else if (Model.ToLower().Contains("kingston"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Kingston;
            }
            else if (Model.ToLower().Contains("sandisk"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Sandisk;
            }
            else if (Model.ToLower().Contains("sony"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Sony;
            }
            else if (Model.ToLower().Contains("transcend"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Transcend;
            }
            else if (Model.ToLower().Contains("adata"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Adata;
            }
            else if (Model.ToLower().Contains("corsair"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Corsair;
            }
            else if (Model.ToLower().Contains("patriot"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Patriot;
            }
            else if (Model.ToLower().Contains("dell"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Dell;
            }
            else if (Model.ToLower().Contains("hp"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.HP;
            }
            else if (Model.ToLower().Contains("liteon"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Liteon;
            }
            else if (Model.ToLower().Contains("crucial"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Crucial;
            }
            else if (Model.ToLower().Contains("intel"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Intel;
            }
            else if (Model.ToLower().Contains("micron"))
            {
                f1.lblsecondaryhardimage.Image = Properties.Resources.Micron;
            }
            else
            {
                f1.lblsecondaryhardimage.Image = null;
            }
        }

        public void OSImage(String OSName)
        {
            if (OSName.Contains("Microsoft Windows Vista"))
            {
                f1.lblosimage.Image = Properties.Resources.WinVista;
            }
            else if (OSName.Contains("Microsoft Windows 7") || OSName.Contains("Windows Server 2008"))
            {
                f1.lblosimage.Image = Properties.Resources.Win7;
            }
            else if (OSName.Contains("Microsoft Windows 8") || OSName.Contains("Microsoft Windows 8.1") || OSName.Contains("Windows Server 2012"))
            {
                f1.lblosimage.Image = Properties.Resources.Win8;
            }
            else if (OSName.Contains("Microsoft Windows 10") || OSName.Contains("Windows Server 2016"))
            {
                f1.lblosimage.Image = Properties.Resources.Win10;
            }
        }

        public void GraphicsImage(String AdapterName)
        {
            if (AdapterName.Contains("NVIDIA") || AdapterName.ToLower().Contains("nvidia"))
            {
                f1.lblgpuimage.Image = Properties.Resources.NVidia;
            }
            else if (AdapterName.Contains("Intel Corporation") || AdapterName.ToLower().Contains("intel"))
            {
                f1.lblgpuimage.Image = Properties.Resources.Intel_Graphics;
            }
            else if (AdapterName.Contains("Advanced Micro Devices, Inc.") || AdapterName.Contains("AMD") || AdapterName.Contains("ATI"))
            {
                f1.lblgpuimage.Image = Properties.Resources.AMD;
            }
            else
            {
                f1.lblgpuimage.Image = null;
            }
        }
        public void NetworkImage(String Description)
        {
            if (Description.ToLower().Contains("realtek"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Realtek;
            }
            else if (Description.ToLower().Contains("3com"))
            {
                f1.lblnetworkimage.Image = Properties.Resources._3Com;
            }
            else if (Description.ToLower().Contains("asus"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Asus;
            }
            else if (Description.ToLower().Contains("atheros"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Atheros;
            }
            else if (Description.ToLower().Contains("belkin"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Belkin;
            }
            else if (Description.ToLower().Contains("intel"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Intel;
            }
            else if (Description.ToLower().Contains("broadcom"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Broadcom;
            }
            else if (Description.ToLower().Contains("cisco"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Cisco;
            }
            else if (Description.ToLower().Contains("d-link"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Dlink;
            }
            else if (Description.ToLower().Contains("gigabyte"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Gigabyte;
            }
            else if (Description.ToLower().Contains("linksys"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Linksys;
            }
            else if (Description.ToLower().Contains("ralink"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.Ralink;
            }
            else if (Description.ToLower().Contains("tp-link"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.TPLink;
            }
            else if (Description.ToLower().Contains("virtualbox"))
            {
                f1.lblnetworkimage.Image = Properties.Resources.VirtualBox;
            }
        }
    }
}
