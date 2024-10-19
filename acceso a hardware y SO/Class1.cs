//El diseño esta en el otro archivo llamado WindowsFormsApp3.sln


using System;
using System.Collections.Generic;
using System.Diagnostics; 
using System.Management;
using Microsoft.Win32; 

namespace acceso_a_hardware_y_SO
{
    public class Class1
    {
        public string GetHardDriveSerialNumber()
        {
            string serialNumber = string.Empty;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive"))
            {
                foreach (ManagementObject disk in searcher.Get())
                {
                    serialNumber = disk["SerialNumber"].ToString().Trim();
                    break; 
                }
            }

            return serialNumber;
        }

        public int CountDiskDrives()
        {
            int count = 0;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
            {
                count = searcher.Get().Count;
            }

            return count;
        }

        public List<string> GetProcessors()
        {
            List<string> processors = new List<string>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor"))
            {
                foreach (ManagementObject processor in searcher.Get())
                {
                    processors.Add(processor["Name"].ToString());
                }
            }

            return processors;
        }

        public string GetRAM()
        {
            ulong totalMemory = 0;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory"))
            {
                foreach (ManagementObject memory in searcher.Get())
                {
                    totalMemory += Convert.ToUInt64(memory["Capacity"]);
                }
            }

            return $"{totalMemory / (1024 * 1024)} MB"; // Convertir a MB
        }

        public List<string> GetNICs()
        {
            List<string> nics = new List<string>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Description FROM Win32_NetworkAdapter WHERE NetEnabled = true"))
            {
                foreach (ManagementObject nic in searcher.Get())
                {
                    nics.Add(nic["Description"].ToString());
                }
            }

            return nics;
        }

        public List<string> GetPatches()
        {
            List<string> patches = new List<string>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT HotFixID FROM Win32_QuickFixEngineering"))
            {
                foreach (ManagementObject patch in searcher.Get())
                {
                    patches.Add(patch["HotFixID"].ToString());
                }
            }

            return patches;
        }

        // Método para obtener direcciones MAC
        public List<string> GetMacAddresses()
        {
            List<string> macAddresses = new List<string>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT MACAddress FROM Win32_NetworkAdapter WHERE NetEnabled = true"))
            {
                foreach (ManagementObject nic in searcher.Get())
                {
                    var macAddress = nic["MACAddress"];
                    if (macAddress != null)
                    {
                        macAddresses.Add(macAddress.ToString());
                    }
                }
            }

            return macAddresses;
        }

        // Métodos para manejar el registro
        public void CreateKey(string keyPath, string keyName, string value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                key.SetValue(keyName, value);
            }
        }

        public string ReadKey(string keyPath, string keyName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    return key.GetValue(keyName)?.ToString();
                }
            }
            return null;
        }

        public void DeleteKey(string keyPath, string keyName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
            {
                if (key != null)
                {
                    key.DeleteValue(keyName, false);
                }
            }
        }

        public void ModifyKey(string keyPath, string keyName, string newValue)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
            {
                if (key != null)
                {
                    key.SetValue(keyName, newValue);
                }
            }
        }

        // Métodos para manejar procesos
        public List<string> GetActiveProcesses()
        {
            List<string> processes = new List<string>();

            foreach (var process in Process.GetProcesses())
            {
                processes.Add(process.ProcessName);
            }

            return processes;
        }

        public void KillProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                process.Kill();
            }
        }
    }
}



