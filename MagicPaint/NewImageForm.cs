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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagicShifter;

namespace MagicPaint
{
    public partial class NewImageForm : Form
    {
        public MagicBitmap bitmap;

        public NewImageForm()
        {
            InitializeComponent();
        }

        private void NewImageForm_Load(object sender, EventArgs e)
        {
            lstBitsPerPixle.Items.Add(MagicBitmap.BitTypes.Type24bit);
            lstBitsPerPixle.Items.Add(MagicBitmap.BitTypes.Type8bit);
            // Sooooon, soooooon
            // lstBitsPerPixle.Items.Add(MagicBitmap.BitTypes.Type1bit);
            lstBitsPerPixle.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MagicBitmap.BitTypes type = (MagicBitmap.BitTypes)lstBitsPerPixle.SelectedItem;
                bitmap = new MagicBitmap(MagicBitmap.SubType.Bitmap, (int)numWidth.Value, (int)numHeight.Value, type, 0, (int)numDelay.Value);
                Close();
            }
            catch (MagicBitmapException ex)
            {
                MessageBox.Show(String.Format("Couldn't create Magic Bitmap: {0}",ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
