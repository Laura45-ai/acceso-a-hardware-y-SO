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
    }
}
