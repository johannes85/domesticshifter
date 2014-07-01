using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MagicShifter;

namespace Test
{
    public partial class Form1 : Form
    {
        private Device device;
        private DeviceFinder devices;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            devices = new DeviceFinder();
            lstSerialDevices.Items.AddRange(devices.GetAllSerialDevices());
        }

        private void btnOpenDevice_Click(object sender, EventArgs e)
        {
            String selectedPort = (String)lstSerialDevices.SelectedItem;
            if (selectedPort != null)
            {
                device = devices.GetByPort(selectedPort);
            }
        }

        private void btnAutodetectDevice_Click(object sender, EventArgs e)
        {
            device = devices.Find();
            lstSerialDevices.SelectedIndex = lstSerialDevices.Items.IndexOf(device.PortName);
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            txtResult.Text += "> ping\r\n";
            String ret = device.RawPing();
            txtResult.Text += "< " + ret + "\r\n";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(txtUploadFile.Text))
                {
                    using (FileStream stream = new FileStream(txtUploadFile.Text, FileMode.Open, FileAccess.Read))
                    {
                        txtResult.Text += "> upload\r\n";
                        String ret = device.RawUpload(1, stream);
                        txtResult.Text += "< " + ret + "\r\n";
                    }
                }
                else
                {
                    MessageBox.Show("File couldn't be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseUploadFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Magic Bitmap|*.magicBitmap";
            openFileDialog1.Multiselect = false;
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                txtUploadFile.Text = openFileDialog1.FileName;
            }
        }
    }
}
