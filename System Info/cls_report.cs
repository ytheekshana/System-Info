using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace System_Info
{
    class cls_report
    {
        frm_system_info f1 = (frm_system_info)Application.OpenForms["frm_system_info"];

        public void ReportHTML()
        {
            String HTMLReport = "<!DOCTYPE html>" +
        Environment.NewLine + "<head><title>System Information</title>" +
        Environment.NewLine + "<style>html{scroll-behavior:smooth;}h1{margin:0px;background-color:#00aeff;text-align:center;font-family:Verdana;padding: 10px;animation-name:Headinganimation;animation-duration:1.5s;animation-direction:alternate;animation-iteration-count:infinite;}h2{border-radius:10px;font-size: 20px;background-color:black;color:white;padding:5px;}body{font-family:Verdana;}.InfoType{padding-left: 50px;font-weight:bold;padding-bottom:5px;float:left;width:200px;}.InfoContent{padding-bottom:5px;}@keyframes Headinganimation{from{background-color:#00aeff;color:black}to{background-color:Black;color:#00aeff}}h6{text-align:center;}.HeadingList{margin: auto;width: 1220px;}.ListContent{transition:all 0.5s;float:left;padding: 14px 17px 14px 17px;font-size: 20px;font-weight: bold;}a:visited,a:link{color:black;text-decoration:none;}.ListContent:hover{color:white;background-color:black;}@media screen and (max-width: 1220px) {.HeadingList {display:none;}}.TopButton{background-color:#00aeff;box-shadow:2px 2px 2px 2px;width:100px;padding: 5px;border-radius: 5px;font-size: 18px;font-weight: bold;transition:all .5s;margin:auto;}.TopButton:hover{background-color:black;color:white;}</style>" +
        Environment.NewLine + "</head>" +
        Environment.NewLine + "<body>" +
        Environment.NewLine + "<h1 id='Top'>System Information - " + f1.lblcompnamedis.Text + "</h1>" +
        Environment.NewLine + "<div id='General'><h2>General</h2>" +
        Environment.NewLine + "<div class='InfoType'>Computer Name</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblcompnamedis.Text + "</div>" + "<div class='InfoType'>Operating System</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblosnamedis.Text + "</div>" + "<div class='InfoType'>Language</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblsystemlangdis.Text + "</div>" + "<div class='InfoType'>Manufacturer</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblsystemmanufacturerdis.Text + "</div>" + "<div class='InfoType'>Model</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblsystemmodeldis.Text + "</div>" + "<div class='InfoType'>Bios</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblsystembiosdis.Text + "</div>" + "<div class='InfoType'>Processor</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblcpunamedis.Text + "</div>" + "<div class='InfoType'>Memory</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblsystemmemorydis.Text + "</div></div>" +
        Environment.NewLine + "<div id='Memory'><h2>Memory</h2>" +
        Environment.NewLine + "<div class='InfoType'>Installed Memory</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblInstalledmemorydis.Text + "</div>" + "<div class='InfoType'>Memory Type</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblmemorytypedis.Text + "</div>" + "<div class='InfoType'>Slot</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblmemoryslotsdis.Text + "</div></div>" +
        Environment.NewLine + "<div id='CPU'><h2>CPU</h2>" +
        Environment.NewLine + "<div class='InfoType'>CPU Name</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblcpunamedis2.Text + "</div>" + "<div class='InfoType'>Cores</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblcoresdis.Text + "</div>" + "<div class='InfoType'>Threads</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblcputhreadsdis.Text + "</div>" + "<div class='InfoType'>Socket</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblsocketdis.Text + "</div>" + "<div class='InfoType'>Clock Speed</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblclockspeeddis.Text + "</div>" + "<div class='InfoType'>Manufacturer</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblcpumanufacturerdis.Text + "</div>" + "<div class='InfoType'>Revision</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblcpurevisiondis.Text + "</div>" + "<div class='InfoType'>L2 Cache</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lbll2cachesizedis.Text + "</div>" + "<div class='InfoType'>L3 Cache</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lbll3cachesizedis.Text + "</div></div>" +
        Environment.NewLine + "<div id='Motherboard'><h2>Motherboard</h2>" +
        Environment.NewLine + "<div class='InfoType'>Manufacturer</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblmboardmanufacturerdis.Text + "</div>" + "<div class='InfoType'>Model</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblmboardmodeldis.Text + "</div></div>" +
        Environment.NewLine + "<div id='BIOS'><h2>BIOS</h2>" +
        Environment.NewLine + "<div class='InfoType'>Name</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblbiosnamedis.Text + "</div>" + "<div class='InfoType'>Manufacturer</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblbiosmanufacturerdis.Text + "</div>" + "<div class='InfoType'>Version</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblbiosversiondis.Text + "</div>" + "<div class='InfoType'>Release Date</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblbiosreleasedatedis.Text + "</div></div>" +
        Environment.NewLine + "<div id='Graphics'><h2>Graphics</h2>" +
        Environment.NewLine + "<div class='InfoType'>Manufacturer</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblgpumanufacturerdis.Text + "</div>" + "<div class='InfoType'>Name</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblgpunamedis.Text + "</div>" + "<div class='InfoType'>DAC Type</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblgpudactypedis.Text + "</div>" + "<div class='InfoType'>Memory</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblgpumemorydis.Text + "</div>" + "<div class='InfoType'>Resolution</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblgpuresdis.Text + "</div>" + "<div class='InfoType'>Bits per Pixel</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblgpubitdis.Text + "</div>" + "<div class='InfoType'>Refresh Rate</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblgpurratedis.Text + "</div></div>" +
        Environment.NewLine + "<div id='OperatingSystem'><h2>Operating System</h2>" +
        Environment.NewLine + "<div class='InfoType'>Name</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblososnamedis.Text + "</div>" + "<div class='InfoType'>Version</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblosversiondis.Text + "</div>" + "<div class='InfoType'>Service Pack</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblosservicepackdis.Text + "</div>" + "<div class='InfoType'>Build Number</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblosbuildnumberdis.Text + "</div>" + "<div class='InfoType'>Platform</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblosplatformdis.Text + "</div>" + "<div class='InfoType'>Installation Date</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblinstalldatedis.Text + "</div>" + "<div class='InfoType'>Registered User</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblosregistereduserdis.Text + "</div></div>" +
        Environment.NewLine + "<div id='Network'><h2>Rating</h2>" +
        Environment.NewLine + "<div class='InfoType'>Processor</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblWEIProcessordis.Text + "</div>" + "<div class='InfoType'>Memory</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblWEIMemorydis.Text + "</div>" + "<div class='InfoType'>Graphics</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblWEIGraphicsdis.Text + "</div>" + "<div class='InfoType'>Gaming Graphics</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblWEIGamingGraphicsdis.Text + "</div>" + "<div class='InfoType'>Primary Hard Disk</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblWEIDiskdis.Text + "</div>" + "<div class='InfoType'>Rating</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblWEITotal.Text + "</div>" +
        Environment.NewLine + "<div id='Storage'><h2>Storage</h2>" +
        Environment.NewLine + "<div class='InfoType'>Model</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblprimaryHardModeldis.Text + "</div>" + "<div class='InfoType'>Type</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblprimaryharddisktypedis.Text + "</div>" + "<div class='InfoType'>Size</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblprimaryHardsizedis.Text + "</div>" + "<div class='InfoType'>Partitions</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblprimaryHardpartitionsDis.Text + "</div></div>" +
        Environment.NewLine + "<div id='Network'><h2>Network</h2>" +
        Environment.NewLine + "<div class='InfoType'>Name</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.cmbnetworkadapter.SelectedItem.ToString() + "</div>" + "<div class='InfoType'>Interface Type</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblNetworkInterfacetypedis.Text + "</div>" + "<div class='InfoType'>Description</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblnetworkadapterdescriptiondis.Text + "</div>" + "<div class='InfoType'>MAC Address</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblnetworkmacdis.Text + "</div>" + "<div class='InfoType'>DHCP Enabled</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblnetworkdhcpenableddis.Text + "</div>" + "<div class='InfoType'>Speed</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblnetworkspeeddis.Text + "</div>" + "<div class='InfoType'>Status</div>" + "<div class='InfoContent'>:&nbsp&nbsp" + f1.lblnetworkstatusdis.Text + "</div></div>" +

        Environment.NewLine + "<h6>System Info Version " + frm_detect.Version + "<br>" +
        Environment.NewLine + "Created By Yasiru Theekshana</h6>" +
        Environment.NewLine + "<a href='#Top'><div class='TopButton'>Go To Top</div></a>" +
        Environment.NewLine + "</body>" +
        Environment.NewLine + "</html>";


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "HTML Document(*.html)|*.html";
            sfd.Title = "Save " + f1.lblcompnamedis.Text + " Report As";
            sfd.FileName = f1.lblcompnamedis.Text + " Report.html";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, HTMLReport);
                f1.lblrefreshstatus.Text = "Saved Successfully";
            }
            else
            {
                f1.lblrefreshstatus.Text = "Saving Aborted";
            }
        }

        public void ReportText()
        {
            String SystemInfo = "System Information of " + f1.lblcompnamedis.Text +
                Environment.NewLine + "-------------------------------------------------------------------------------------------" +
                Environment.NewLine + "General Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Computer Name \t= " + f1.lblcompnamedis.Text +
                Environment.NewLine + "     Operating System \t= " + f1.lblosnamedis.Text +
                Environment.NewLine + "     Language \t\t= " + f1.lblsystemlangdis.Text +
                Environment.NewLine + "     Manufacture \t= " + f1.lblsystemmanufacturerdis.Text +
                Environment.NewLine + "     Model \t\t= " + f1.lblsystemmodeldis.Text +
                Environment.NewLine + "     Bios \t\t= " + f1.lblsystembiosdis.Text +
                Environment.NewLine + "     Processor \t\t= " + f1.lblcpunamedis.Text +
                Environment.NewLine + "     Memory \t\t= " + f1.lblsystemmemorydis.Text +
                Environment.NewLine +
                Environment.NewLine + "Memory Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Installed Memory \t= " + f1.lblInstalledmemorydis.Text +
                Environment.NewLine + "     Memory Type \t= " + f1.lblmemorytypedis.Text +
                Environment.NewLine + "     Slots \t\t= " + f1.lblmemoryslotsdis.Text +
                Environment.NewLine +
                Environment.NewLine + "CPU Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     CPU Name \t\t= " + f1.lblcpunamedis2.Text +
                Environment.NewLine + "     Cores \t\t= " + f1.lblcoresdis.Text +
                Environment.NewLine + "     Threads \t\t= " + f1.lblcputhreadsdis.Text +
                Environment.NewLine + "     Socket \t\t= " + f1.lblsocketdis.Text +
                Environment.NewLine + "     Clock Speed \t= " + f1.lblclockspeeddis.Text +
                Environment.NewLine + "     Manufacturer \t= " + f1.lblcpumanufacturerdis.Text +
                Environment.NewLine + "     Revision \t\t= " + f1.lblcpurevisiondis.Text +
                Environment.NewLine + "     L2 Cache \t\t= " + f1.lbll2cachesizedis.Text +
                Environment.NewLine + "     L3 Cache \t\t= " + f1.lbll3cachesizedis.Text +
                Environment.NewLine +
                Environment.NewLine + "MotherBoard Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Manufacture \t= " + f1.lblmboardmanufacturerdis.Text +
                Environment.NewLine + "     Model \t\t= " + f1.lblmboardmodeldis.Text +
                Environment.NewLine +
                Environment.NewLine + "BIOS Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Name \t\t= " + f1.lblbiosnamedis.Text +
                Environment.NewLine + "     Manufacturer \t= " + f1.lblbiosmanufacturerdis.Text +
                Environment.NewLine + "     Version \t\t= " + f1.lblbiosversiondis.Text +
                Environment.NewLine + "     Release Date \t= " + f1.lblbiosreleasedatedis.Text +
                Environment.NewLine +
                Environment.NewLine + "Graphics Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Manufacturer \t= " + f1.lblgpumanufacturerdis.Text +
                Environment.NewLine + "     Name \t\t= " + f1.lblgpunamedis.Text +
                Environment.NewLine + "     DAC Type \t\t= " + f1.lblgpudactypedis.Text +
                Environment.NewLine + "     Memory \t\t= " + f1.lblgpumemorydis.Text +
                Environment.NewLine + "     Resolution \t= " + f1.lblgpuresdis.Text +
                Environment.NewLine + "     Bits Per Pixel \t= " + f1.lblgpubitdis.Text +
                Environment.NewLine + "     Refresh Rate \t= " + f1.lblgpurratedis.Text +
                Environment.NewLine +
                Environment.NewLine + "Operating System Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Name \t\t= " + f1.lblososnamedis.Text +
                Environment.NewLine + "     Version \t\t= " + f1.lblosversiondis.Text +
                Environment.NewLine + "     Service Pack \t= " + f1.lblosservicepackdis.Text +
                Environment.NewLine + "     Build Number \t= " + f1.lblosbuildnumberdis.Text +
                Environment.NewLine + "     Platform \t\t= " + f1.lblosplatformdis.Text +
                Environment.NewLine + "     Installation Date \t= " + f1.lblinstalldatedis.Text +
                Environment.NewLine + "     Registered User \t= " + f1.lblosregistereduserdis.Text +
                Environment.NewLine +
                Environment.NewLine + "Rating Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Processor \t\t= " + f1.lblWEIProcessordis.Text +
                Environment.NewLine + "     Memory \t\t= " + f1.lblWEIMemorydis.Text +
                Environment.NewLine + "     Graphics \t\t= " + f1.lblWEIGraphicsdis.Text +
                Environment.NewLine + "     Gaming Graphics \t= " + f1.lblWEIGamingGraphicsdis.Text +
                Environment.NewLine + "     Hard Disk \t\t= " + f1.lblWEIDiskdis.Text +
                Environment.NewLine + "     Rating \t\t= " + f1.lblWEITotal.Text +
                Environment.NewLine +
                Environment.NewLine + "Hard Disk Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Model \t\t= " + f1.lblprimaryHardModeldis.Text +
                Environment.NewLine + "     Type\t\t= " + f1.lblprimaryharddisktypedis.Text +
                Environment.NewLine + "     Size \t\t= " + f1.lblprimaryHardsizedis.Text +
                Environment.NewLine + "     Partitions \t= " + f1.lblprimaryHardpartitionsDis.Text +
                Environment.NewLine + "-------------------------------------------------------------------------------------------" +
                Environment.NewLine + "Network Information" +
                Environment.NewLine + "---------------------------------------------------------------------------" +
                Environment.NewLine + "     Name \t\t= " + f1.cmbnetworkadapter.SelectedItem.ToString() +
                Environment.NewLine + "     Interface Type\t= " + f1.lblNetworkInterfacetypedis.Text +
                Environment.NewLine + "     Description \t= " + f1.lblnetworkadapterdescriptiondis.Text +
                Environment.NewLine + "     MAC Address \t= " + f1.lblnetworkmacdis.Text +
                Environment.NewLine + "     DHCP Enabled \t= " + f1.lblnetworkdhcpenableddis.Text +
                Environment.NewLine + "     Speed \t\t= " + f1.lblnetworkspeeddis.Text +
                Environment.NewLine + "     Status \t\t= " + f1.lblnetworkstatusdis.Text +
                Environment.NewLine + "-------------------------------------------------------------------------------------------" +
                Environment.NewLine + "System Info Version " + frm_detect.Version +
                Environment.NewLine + "Created By Yasiru Theekshana";

            SaveFileDialog fbd = new SaveFileDialog();
            fbd.FileName = f1.lblcompnamedis.Text + " Report.txt";
            fbd.Filter = "Text Files(*.txt)|*.txt";
            fbd.Title = "Save " + f1.lblcompnamedis.Text + " Report As";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fbd.FileName, SystemInfo);
                f1.lblrefreshstatus.Text = "Saved Successfully";
            }
            else
            {
                f1.lblrefreshstatus.Text = "Saving Aborted";
            }
        }
    }
}
