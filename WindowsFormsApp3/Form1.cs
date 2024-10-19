//Laura Cristina Colorado Sánchez

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using acceso_a_hardware_y_SO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 Class1 = new Class1();
            string serialNumber =   Class1.GetHardDriveSerialNumber();
            MessageBox.Show($"Número de serie del disco duro: {serialNumber}", "Información del Disco");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 Class1 = new Class1();
            int driveCount = Class1.CountDiskDrives();
            MessageBox.Show($"Cantidad de unidades de disco: {driveCount}", "Información de Discos");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1(); 
            var processors = class1.GetProcessors();
            var ram = class1.GetRAM();
            var nics = class1.GetNICs();
            var patches = class1.GetPatches();

            string inventory = "Inventario del Sistema:\n\n";

            inventory += "Procesadores:\n";
            foreach (var processor in processors)
            {
                inventory += $"- {processor}\n";
            }

            inventory += $"\nRAM Total: {ram}\n\n";

            inventory += "NICs:\n";
            foreach (var nic in nics)
            {
                inventory += $"- {nic}\n";
            }

            inventory += "\nParches Instalados:\n";
            foreach (var patch in patches)
            {
                inventory += $"- {patch}\n";
            }

            MessageBox.Show(inventory, "Inventario General del Sistema");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            var macAddresses = class1.GetMacAddresses();

            string macList = "Direcciones MAC:\n";
            foreach (var mac in macAddresses)
            {
                macList += $"- {mac}\n";
            }

            MessageBox.Show(macList, "Direcciones MAC del Sistema");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1(); // Crear instancia de Class1

            string keyPath = @"Software\MiAplicacion"; // Ruta de la clave
            string keyName = "MiClave"; // Nombre de la clave
            string keyValue = "ValorPorDefecto"; // Valor por defecto

            // Crear clave
            class1.CreateKey(keyPath, keyName, keyValue);
            MessageBox.Show("Clave creada.");

            // Leer clave
            string readValue = class1.ReadKey(keyPath, keyName);
            MessageBox.Show($"Valor leído: {readValue}");

            // Modificar clave
            string newValue = "NuevoValor";
            class1.ModifyKey(keyPath, keyName, newValue);
            MessageBox.Show("Clave modificada.");

            // Borrar clave
            class1.DeleteKey(keyPath, keyName);
            MessageBox.Show("Clave borrada.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1(); // Crear instancia de Class1

            // Obtener procesos activos
            var activeProcesses = class1.GetActiveProcesses();
            string processList = "Procesos Activos:\n" + string.Join("\n", activeProcesses);
            MessageBox.Show(processList, "Lista de Procesos");

            // Matar un proceso (por ejemplo, "notepad" como demostración)
            string processToKill = "notepad"; 
            class1.KillProcess(processToKill);
            MessageBox.Show($"Proceso '{processToKill}' (si existía) ha sido terminado.");
        }
    }
}
