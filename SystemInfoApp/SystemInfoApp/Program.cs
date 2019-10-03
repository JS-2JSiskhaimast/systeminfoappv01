using System;
using System.Management;
using CodePoints;
using System.IO;
using System.Text;

namespace SystemInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementObjectSearcher searcher;
            int c = 0;
 
            while ((c = GetOpt.GetOptions(args, "i:")) != (-1))
            {
                switch ((char)c)
                {
                    case 'i':
                        switch ((String)args[1])
                        {
                            case "serialmainboard":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                                StringBuilder KQ;
                                String Result;
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "SerialNumber", queryObj["SerialNumber"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /* Console.WriteLine(queryObj["SerialNumber"]); */
                                }
                                break;
                            case "computername":
                                KQ = new StringBuilder();
                                KQ.Clear();
                                KQ.AppendFormat("\"{0}\":\"{1}\"", "computername", Environment.MachineName);
                                Result = "{" + KQ + "}";
                                Console.WriteLine(Result);

                                /*Console.WriteLine(Environment.MachineName);*/
                                break;
                            case "accountlogin":
                                KQ = new StringBuilder();
                                KQ.Clear();
                                KQ.AppendFormat("\"{0}\":\"{1}\"", "accountlogin", Environment.UserName);
                                Result = "{" + KQ + "}";
                                Console.WriteLine(Result);

                                /*Console.WriteLine(Environment.UserName);*/
                                break;
                            case "bios":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Name", queryObj["Name"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "SerialNumBer", queryObj["SerialNumber"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Version", queryObj["Version"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "CurrentLanguage", queryObj["CurrentLanguage"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Description", queryObj["Description"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "EmbeddedControllerMajorVersion", queryObj["EmbeddedControllerMajorVersion"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "ReleaseDate", queryObj["ReleaseDate"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Install Date", queryObj["InstallDate"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine("Name:" + queryObj["Name"] + "\n" + "SerialNumBer :" + queryObj["SerialNumber"] + "\n" + "Version: " + queryObj["Version"]
                                            + "\n" + "Caption: " + queryObj["Caption"] + "\n" + "CurrentLanguage: " + queryObj["CurrentLanguage"]
                                            + "\n" + "Description: " + queryObj["Description"] + "\n" + "EmbeddedControllerMajorVersion: " + queryObj["EmbeddedControllerMajorVersion"]
                                            + "\n" + "ReleaseDate: " + queryObj["ReleaseDate"] + "\n" + "Install Date: " + queryObj["InstallDate"]);*/
                                }
                                break;
                            case "network":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "IPAddress", queryObj["IPAddress"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "DNSHostName", queryObj["DNSHostName"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "IPConnectionMetric", queryObj["IPConnectionMetric"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "DefaultTTL", queryObj["DefaultTTL"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Description", queryObj["Description"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "SettingID", queryObj["SettingID"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "MACAddress", queryObj["MACAddress"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "DatabasePath", queryObj["DatabasePath"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine("IPAddress: " + queryObj["IPAddress"] + "\n" + "DNSHostName: " + queryObj["DNSHostName"]
                                         + "\n" + "IPConnectionMetric: " + queryObj["IPConnectionMetric"] + "\n" + "DefaultTTL: " + queryObj["DefaultTTL"]
                                         + "\n" + "Description: " + queryObj["Description"] + "\n" + "SettingID: " + queryObj["SettingID"] + "\n" 
                                         + "MACAddress: " + queryObj["MACAddress"] + "\n" + "Caption: " + queryObj["Caption"] + "\n" + "DatabasePath: " + queryObj["DatabasePath"]);*/

                                }
                                break;
                            case "cpu":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Name", queryObj["Name"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "NumberOfCores", queryObj["NumberOfCores"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "NumberOfLogicalProcessors", queryObj["NumberOfLogicalProcessors"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "ThreadCount", queryObj["ThreadCount"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "AddressWidth", queryObj["AddressWidth"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "ProcessorId", queryObj["ProcessorId"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Role", queryObj["Role"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "SocketDesignation", queryObj["SocketDesignation"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "SystemCreationClassName", queryObj["SystemCreationClassName"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine("Name:" + queryObj["Name"] + "\n"
                                        + "Number of core: " + queryObj["NumberOfCores"] + "\n" + "Number Of LogicalProcessors: " + queryObj["NumberOfLogicalProcessors"]
                                        + "\n" + "ThreadCount: " + queryObj["ThreadCount"] + "\n" + "Caption: " + queryObj["Caption"] + "\n" +
                                        "AddressWidth: " + queryObj["AddressWidth"] + "\n" + "ProcessorId: " + queryObj["ProcessorId"] + "\n"
                                        + "Role: " + queryObj["Role"] + "\n" + "SocketDesignation: " + queryObj["SocketDesignation"] + "\n" +
                                        "SystemCreationClassName: " + queryObj["SystemCreationClassName"]);*/
                                }
                                break;
                            case "main":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "SerialNumber", queryObj["SerialNumber"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Product", queryObj["Product"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "CreationClassName", queryObj["CreationClassName"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Version", queryObj["Version"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine("SerialNumber: " + queryObj["SerialNumber"] + "\n" + "Product: " + queryObj["Product"]
                                        + "\n" + "CreationClassName: " + queryObj["CreationClassName"] + "\n" + "Version: " + queryObj["Version"]);*/
                                }
                                break;
                            case "graphic":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "AdapterCompatibility", queryObj["AdapterCompatibility"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "AdapterRAM", queryObj["AdapterRAM"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "CurrentBitsPerPixel", queryObj["CurrentBitsPerPixel"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "CurrentRefreshRate", queryObj["CurrentRefreshRate"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "CurrentNumberOfColors", queryObj["CurrentNumberOfColors"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Name", queryObj["Name"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "VideoModeDescription", queryObj["VideoModeDescription"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine("AdapterCompatibility: " + queryObj["AdapterCompatibility"] + "\n" +
                                        "AdapterRAM: " + queryObj["AdapterRAM"] + "\n" + "CurrentBitsPerPixel: " + queryObj["CurrentBitsPerPixel"]
                                        + "\n" + "CurrentRefreshRate: " + queryObj["CurrentRefreshRate"] + "\n" +
                                        "CurrentNumberOfColors: " + queryObj["CurrentNumberOfColors"] + "\n" + "Name: " + queryObj["Name"] + "\n" +
                                        "VideoModeDescription: " + queryObj["VideoModeDescription"]);*/
                                }
                                break;
                            case "memory":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Capacity", queryObj["Capacity"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "DataWidth", queryObj["DataWidth"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "MemoryType", queryObj["MemoryType"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "SMBIOSMemoryType", queryObj["SMBIOSMemoryType"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "TotalWidth", queryObj["TotalWidth"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "TypeDetail", queryObj["TypeDetail"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine("Capacity: " + queryObj["Capacity"] + "\n" + "DataWidth: " + queryObj["DataWidth"]
                                        + "\n" + "MemoryType: " + queryObj["MemoryType"] + "\n" + "SMBIOSMemoryType: " + queryObj["SMBIOSMemoryType"]
                                        + "\n" + "TotalWidth: " + queryObj["TotalWidth"] + "\n" + "TypeDetail: " + queryObj["TypeDetail"]);*/
                                }
                                break;
                            case "battery":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Battery");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Name", queryObj["Name"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Status", queryObj["Status"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Availability", queryObj["Availability"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Chemistry", queryObj["Chemistry"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "CreationClassName", queryObj["CreationClassName"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "EstimatedRunTime(ms)", queryObj["EstimatedRunTime"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine("Name: " + queryObj["Name"] + "\n" + "Caption: " + queryObj["Caption"] + "\n" +
                                                   "Status: " + queryObj["Status"] + "\n" + "Availability: " + queryObj["Availability"] + "\n" + "Chemistry: " + queryObj["Chemistry"]
                                                   + "\n" + "CreationClassName: " + queryObj["CreationClassName"] + "\n" + "EstimatedRunTime(ms): " + queryObj["EstimatedRunTime"]);*/
                                }
                                break;
                            case "registry":
                                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Registry");
                                foreach (ManagementObject queryObj in searcher.Get())
                                {
                                    KQ = new StringBuilder();
                                    KQ.Clear();
                                    KQ.AppendFormat("\"{0}\":\"{1}\"", "Caption", queryObj["Caption"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "CurrentSize", queryObj["CurrentSize"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Description", queryObj["Description"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "InstallDate", queryObj["InstallDate"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "MaximumSize", queryObj["MaximumSize"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Name", queryObj["Name"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "ProposedSize", queryObj["ProposedSize"]);
                                    KQ.AppendFormat(",\"{0}\":\"{1}\"", "Status", queryObj["Status"]);
                                    Result = "{" + KQ + "}";
                                    Console.WriteLine(Result);

                                    /*Console.WriteLine(
                                        "CurrentSize: " + queryObj["CurrentSize"] + "\n" + "Description: " + queryObj["Description"]
                                        + "\n" + "InstallDate: " + queryObj["InstallDate"] + "\n" + "MaximumSize: " + queryObj["MaximumSize"]
                                        + "\n" + "Name: " + queryObj["Name"] + "\n" + "ProposedSize: " + queryObj["ProposedSize"]
                                        + "\n" + "Status: " + queryObj["Status"]);*/
                                }
                                break;
                            case "version":
                                string path = @"C:\Users\Admin\Documents\Visual Studio 2015\Projects\edited\SystemInfoApp\SystemInfoApp\bin\Debug\version.txt";
                                if (!File.Exists(path))
                                {
                                    Console.WriteLine("\n*Not found version app.");
                                }
                                else
                                {
                                    string readText = File.ReadAllText(path);
                                    Console.WriteLine("\n*Current version : " + readText);
                                }
                                break;
                            case "?":
                                Console.WriteLine("*serialmainboard  " + "--This argument to show Serial mainboard of pc.");
                                Console.WriteLine("*computername  " + "--This argument to show information Computer name");
                                Console.WriteLine("*accountlogin  " + "--This argument to show information Account login pc.");
                                Console.WriteLine("*bios  " + "--This argument to show information BIOS of pc.");
                                Console.WriteLine("*network  " + "--This argument to show information Network adapter of pc.");
                                Console.WriteLine("*cpu  " + "--This argument to show information Processor of pc.");
                                Console.WriteLine("*main  " + "--This argument to show information BaseBoard of pc.");
                                Console.WriteLine("*graphic  " + "--This argument to show information Video controller of pc.");
                                Console.WriteLine("*memory  " + "--This argument to show information Physical memory ofs pc.");
                                Console.WriteLine("*battery  " + "--This argument to show information Battery of pc.");
                                Console.WriteLine("*registry  " + "--This argument to show information Registry of pc.");
                                Console.WriteLine("*version  " + "This option to show information version app.");
                                break;
                            default:
                                Console.WriteLine("Not found information for argument " + args[1] +" !!!");
                                break;
                        }              
                        break;
                        
                    case '?':
                        Console.WriteLine("-i  " + "This option to show information for argument.");                   
                        break;

                    default:
                        Console.WriteLine("Not found argument option " + c + " !!!");
                        break;
                }
            }
            
        }
    }
}
