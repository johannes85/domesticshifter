/*
 * DomesticShifter
 * Alternative (Unofficial) Windows Toolset for the MagicShifter: http://magicshifter.net/
 * -------------------------------------------------------------------------------------------
 * 
 * Uploader for Images and Fonts
 *   
 * by DomesticHacks
 * http://www.domestichacks.info/
 * http://www.youtube.com/DomesticHacks
 *
 * Author: Johannes Zinnau (johannes@johnimedia.de)
 * 
 * License:
 * GNU GENERAL PUBLIC LICENSE Version 3
 *
 */

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

namespace Uploader
{
    public partial class UploaderForm : Form
    {
        private String filePath;
        private DeviceFinder devices;
        private MagicBitmap bitmap;
        private Boolean autodetect;

        public Boolean StandaloneWindow
        {
            set
            {
                if (value)
                {
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                    ShowInTaskbar = true;
                    StartPosition = FormStartPosition.CenterScreen;
                    btnCancel.Text = "Quit";
                }
                else
                {
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                    ShowInTaskbar = false;
                    StartPosition = FormStartPosition.CenterParent;
                    btnCancel.Text = "Cancel";
                }
            }
        }

        public UploaderForm(String filePath)
        {
            InitializeComponent();

            this.filePath = filePath;
            this.autodetect = false;
        }

        public UploaderForm(String filePath, Boolean autodetect)
        {
            InitializeComponent();

            this.filePath = filePath;
            this.autodetect = autodetect;
        }

        private void UploaderForm_Load(object sender, EventArgs e)
        {
            try
            {
                devices = new DeviceFinder();
                lstSerialDevices.Items.AddRange(devices.GetAllSerialDevices());

                bitmap = new MagicBitmap(filePath);

                lstFileInfos.Items.Clear();
                AddFileInfoToList("Size", bitmap.FileSize.ToString());
                AddFileInfoToList("Type", bitmap.Type.ToString());
                AddFileInfoToList("Width", bitmap.Width.ToString());
                AddFileInfoToList("Height", bitmap.Height.ToString());
                AddFileInfoToList("BitPerPixel", bitmap.BitPerPixel.GetHashCode().ToString());
                AddFileInfoToList("Frames", bitmap.FramesCount.ToString());
                AddFileInfoToList("DelayMs", bitmap.DelayMs.ToString());
                AddFileInfoToList("FirstChar", bitmap.FirstChar.ToString());

                if (bitmap.Type == MagicBitmap.SubType.Bitmap)
                {
                    picturePreview.Image = bitmap.GetFrame(0);
                    picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
                }

                if (bitmap.Type == MagicBitmap.SubType.Bitmap)
                {
                    numSector.Minimum = 1;
                    numSector.Maximum = 127;
                    numSector.Value = 1;
                }
                else if (bitmap.Type == MagicBitmap.SubType.Font)
                {
                    numSector.Minimum = 128;
                    numSector.Maximum = 255;
                    numSector.Value = 128;
                }

                if (autodetect)
                {
                    autodetectDevice();
                }
            }
            catch (MagicBitmapException ex)
            {
                MessageBox.Show(String.Format("Couldn't read file: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AddFileInfoToList(String key, String value)
        {
            ListViewItem item = new ListViewItem(key);
            item.SubItems.Add(value);
            lstFileInfos.Items.Add(item);
        }

        private void btnAutodetectDevice_Click(object sender, EventArgs e)
        {
            autodetectDevice();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                String selectedPort = (String)lstSerialDevices.SelectedItem;
                if (selectedPort == null)
                {
                    MessageBox.Show("Please select a device", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                using (Device device = devices.GetByPort(selectedPort))
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                        device.RawUpload((int)numSector.Value, stream);
                    } 
                }

                MessageBox.Show("Upload finished", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DeviceException ex)
            {
                MessageBox.Show(String.Format("Device error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Enabled = true;
        }

        private void autodetectDevice()
        {
            Enabled = false;

            try
            {
                lstSerialDevices.Items.Clear();
                lstSerialDevices.Items.AddRange(devices.GetAllSerialDevices());

                using (Device device = devices.Find())
                {
                    lstSerialDevices.SelectedIndex = lstSerialDevices.Items.IndexOf(device.PortName);
                }
            }
            catch (DeviceFinderException)
            {
                MessageBox.Show("Couldn't found device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Enabled = true;
        }

    }
}
