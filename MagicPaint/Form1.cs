/*
 * DomesticShifter
 * Alternative (Unofficial) Windows Toolset for the MagicShifter: http://magicshifter.net/
 * -------------------------------------------------------------------------------------------
 * 
 * MagicPaint
 * Magic Bitmap Editor
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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagicShifter;
using Uploader;

namespace MagicPaint
{
    public partial class Form1 : Form
    {
        private MagicBitmap bitmap;
        private int currentFrame;
        private Boolean frameChanged;

        private Boolean FrameChanged
        {
            get
            {
                return frameChanged;
            }

            set
            {
                frameChanged = value;

                if (frameChanged)
                {
                    btnSaveFrame.Enabled = true;
                }
                else
                {
                    btnSaveFrame.Enabled = false;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnUploadToDevice.Enabled = false;
            btnSave.Enabled = false;
            btnSaveAs.Enabled = false;
            pnlFrames.Enabled = false;

            SetCurrentColor(Color.White);
            SetCurrentTool(MagicPixler.Tool.Brush);
            magicPixler1.OnColorChoose += magicPixler1_OnColorChoose;
            magicPixler1.OnChanged += magicPixler1_OnChanged;

            SetZoomLevel(trackZoom.Value);
            FrameChanged = false;
        }

        void magicPixler1_OnChanged(object sender, EventArgs e)
        {
            FrameChanged = true;
        }

        void magicPixler1_OnColorChoose(object sender, Color e)
        {
            SetCurrentColor(e);
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            
        }

        private void btnToolColorPicker_Click(object sender, EventArgs e)
        {
            SetCurrentTool(MagicPixler.Tool.ColorPicker); 
        }

        private void btnToolBrush_Click_1(object sender, EventArgs e)
        {
            SetCurrentTool(MagicPixler.Tool.Brush); 
        }

        private void pnlCurrentColor_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            DialogResult res = colorDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                SetCurrentColor(colorDialog1.Color);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewImageForm form = new NewImageForm();
            form.ShowDialog(this);
            if (form.bitmap != null)
            {
                bitmap = form.bitmap;
                currentFrame = 0;
                RefreshGui();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Magic Bitmap|*.magicBitmap|Magic Font|*.magicFont";
            openFileDialog1.Multiselect = false;
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                bitmap = new MagicBitmap(openFileDialog1.FileName);
                currentFrame = 0;
                RefreshGui();
            }
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Import Image";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Image File(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialog1.Multiselect = false;
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap sourceImage = new Bitmap(openFileDialog1.FileName);
                int targetHeight = sourceImage.Height > 16 ? 16 : sourceImage.Height;
                MagicBitmap newBitmap = new MagicBitmap(MagicBitmap.SubType.Bitmap, sourceImage.Width, targetHeight, MagicBitmap.BitTypes.Type24bit, 0, 100);

                FrameDimension dimension = new FrameDimension(sourceImage.FrameDimensionsList[0]);
                for (int frame = 0; frame < sourceImage.GetFrameCount(dimension); frame++)
                {
                    sourceImage.SelectActiveFrame(dimension, frame);
                    Bitmap newFrame = new Bitmap(newBitmap.Width, newBitmap.Height);
                    using (Graphics g = Graphics.FromImage(newFrame))
                    {
                        g.DrawImage(sourceImage, 0, 0);
                    }
                    newBitmap.AddFrame(newFrame);
                }

                newBitmap.RemoveFrame(0);
                bitmap = newBitmap;
                currentFrame = 0;
                RefreshGui();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSaveFrame_Click(sender, e);
            bitmap.Save();
            RefreshGui();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = bitmap.Type == MagicBitmap.SubType.Font ? "*.magicFont" : "*.magicBitmap";
            saveFileDialog1.Filter = "Magic Bitmap(*.magicBitmap)|*.magicBitmap|Magic Font(*.magicFont)|*.magicFont";
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                btnSaveFrame_Click(sender, e);
                bitmap.Save(saveFileDialog1.FileName);
                RefreshGui();
            }
        }

        private void btnUploadToDevice_Click(object sender, EventArgs e)
        {
            UploaderForm form = new UploaderForm(bitmap.FilePath, true);
            form.StandaloneWindow = false;
            form.ShowDialog(this);
        }

        private void trackZoom_Scroll(object sender, EventArgs e)
        {
            SetZoomLevel(trackZoom.Value);
        }

        private void trackFrames_Scroll(object sender, EventArgs e)
        {
            SetCurrentFrameNumberUser(trackFrames.Value);
        }

        private void btnPreviousFrame_Click(object sender, EventArgs e)
        {
            if (currentFrame > 0)
            {
                SetCurrentFrameNumberUser(currentFrame - 1);
            }
        }

        private void btnNextFrame_Click(object sender, EventArgs e)
        {
            if (currentFrame < bitmap.RealFramesCount - 1)
            {
                SetCurrentFrameNumberUser(currentFrame + 1);
            }
        }

        private void btnSaveFrame_Click(object sender, EventArgs e)
        {
            SaveCurrentFrame();
        }

        private void btnResetFrame_Click(object sender, EventArgs e)
        {
            SetCurrentFrameNumber(currentFrame);
        }

        private void btnAddFrame_Click(object sender, EventArgs e)
        {
            SetCurrentFrameNumberUser(currentFrame); // Trigger message box if frame isn't saved
            bitmap.AddFrame(bitmap.GenerateBlankFrame());
            RefreshGui();
            SetCurrentFrameNumber(bitmap.RealFramesCount - 1);
        }

        private void btnAddFrameFromImage_Click(object sender, EventArgs e)
        {
            SetCurrentFrameNumberUser(currentFrame); // Trigger message box if frame isn't saved
            openFileDialog1.Title = "Import Image as Frame";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Image File(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialog1.Multiselect = false;
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap newImage = new Bitmap(openFileDialog1.FileName);
                Bitmap newFrame = new Bitmap(bitmap.Width, bitmap.Height);
                using (Graphics g = Graphics.FromImage(newFrame)) {
                    g.DrawImage(newImage, 0, 0);
                }
                bitmap.AddFrame(newFrame);
                RefreshGui();
                SetCurrentFrameNumber(bitmap.RealFramesCount - 1);
            }
        }

        private void btnRemoveFrame_Click(object sender, EventArgs e)
        {
            try
            {
                bitmap.RemoveFrame(currentFrame);
                if (currentFrame >= bitmap.RealFramesCount)
                {
                    currentFrame = bitmap.RealFramesCount - 1;
                }
                RefreshGui();
            }
            catch (MagicBitmapException ex)
            {
                MessageBox.Show(String.Format("Couldnt remove frame ({0})", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void RefreshGui()
        {
            trackFrames.Minimum = 0;
            trackFrames.Maximum = bitmap.RealFramesCount - 1;
            SetCurrentFrameNumber(currentFrame);

            lstFileInfos.Items.Clear();
            AddFileInfoToList("Size", bitmap.FileSize.ToString());
            AddFileInfoToList("Type", bitmap.Type.ToString());
            AddFileInfoToList("Width", bitmap.Width.ToString());
            AddFileInfoToList("Height", bitmap.Height.ToString());
            AddFileInfoToList("BitPerPixel", bitmap.BitPerPixel.GetHashCode().ToString());
            AddFileInfoToList("Frames", bitmap.FramesCount.ToString());
            AddFileInfoToList("DelayMs", bitmap.DelayMs.ToString());
            AddFileInfoToList("FirstChar", bitmap.FirstChar.ToString());

            btnUploadToDevice.Enabled = bitmap.FilePath != null;
            btnSave.Enabled = bitmap.FilePath != null;
            btnSaveAs.Enabled = true;
            pnlFrames.Enabled = true;
        }

        private void SetCurrentTool(MagicPixler.Tool tool)
        {
            btnToolBrush.Enabled = true;
            btnToolColorPicker.Enabled = true;
            switch (tool)
            {
                case MagicPixler.Tool.Brush:
                    btnToolBrush.Enabled = false;
                    break;
                case MagicPixler.Tool.ColorPicker:
                    btnToolColorPicker.Enabled = false;
                    break;
            }
            magicPixler1.CurrentTool = tool;
        }

        private void AddFileInfoToList(String key, String value)
        {
            ListViewItem item = new ListViewItem(key);
            item.SubItems.Add(value);
            lstFileInfos.Items.Add(item);
        }

        private void SaveCurrentFrame()
        {
            Bitmap changedImage = magicPixler1.GetImage();
            bitmap.ReplaceFrame(currentFrame, changedImage);
            SetCurrentFrameNumber(currentFrame);
        }

        private void SetCurrentFrameNumberUser(int frameNumber)
        {
            if (FrameChanged)
            {
                DialogResult res = MessageBox.Show("The current frame has been changed.\nDo you want to save the frame?", "Frame changed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveCurrentFrame();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                    default:
                        return;
                }
            }
            SetCurrentFrameNumber(frameNumber);
        }
        

        private void SetCurrentFrameNumber(int frameNumber)
        {
            currentFrame = frameNumber;
            trackFrames.Value = currentFrame;
            lblFrameNumber.Text = currentFrame.ToString();
            magicPixler1.LoadImage(bitmap.GetFrame(currentFrame));
            FrameChanged = false;
        }

        private void SetCurrentColor(Color color)
        {
            pnlCurrentColor.BackColor = color;
            magicPixler1.CurrentColor = color;
        }

        private void SetZoomLevel(int percent)
        {
            magicPixler1.PixelSize = (int)Math.Round(1.0 / 100.0 * percent, 0);
        }
    }
}
