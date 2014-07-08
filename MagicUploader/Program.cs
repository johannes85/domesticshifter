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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Uploader;

namespace MagicUploader
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                try
                {
                    String filePath = args[0];
                    if (!File.Exists(filePath))
                    {
                        throw new IOException(String.Format("Could not found File ({0})", filePath));
                    }

                    UploaderForm form = new UploaderForm(filePath, true);
                    form.StandaloneWindow = true;
                    form.Text = "MagicUploader";
                    Application.Run(form);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(String.Format("File access error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}
