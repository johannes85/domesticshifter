namespace MagicPaint
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.btnImportFile = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.btnUploadToDevice = new System.Windows.Forms.ToolStripButton();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.trackFrames = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstFileInfos = new System.Windows.Forms.ListView();
            this.key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFrames = new System.Windows.Forms.GroupBox();
            this.btnAddFrameFromImage = new System.Windows.Forms.Button();
            this.btnRemoveFrame = new System.Windows.Forms.Button();
            this.btnAddFrame = new System.Windows.Forms.Button();
            this.btnResetFrame = new System.Windows.Forms.Button();
            this.btnSaveFrame = new System.Windows.Forms.Button();
            this.lblFrameNumber = new System.Windows.Forms.Label();
            this.btnNextFrame = new System.Windows.Forms.Button();
            this.btnPreviousFrame = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnToolFill = new System.Windows.Forms.Button();
            this.pnlCurrentColor = new System.Windows.Forms.PictureBox();
            this.btnToolColorPicker = new System.Windows.Forms.Button();
            this.btnToolBrush = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.palette1 = new MagicPaint.Palette();
            this.magicPixler1 = new MagicPaint.MagicPixler();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackFrames)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlFrames.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCurrentColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpenFile,
            this.btnImportFile,
            this.btnSave,
            this.btnSaveAs,
            this.btnUploadToDevice,
            this.btnAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.Image = global::MagicPaint.Properties.Resources.newdoc;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(51, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(56, 22);
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnImportFile
            // 
            this.btnImportFile.Image = ((System.Drawing.Image)(resources.GetObject("btnImportFile.Image")));
            this.btnImportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(99, 22);
            this.btnImportFile.Text = "Import Image";
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(76, 22);
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnUploadToDevice
            // 
            this.btnUploadToDevice.Image = global::MagicPaint.Properties.Resources.device;
            this.btnUploadToDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUploadToDevice.Name = "btnUploadToDevice";
            this.btnUploadToDevice.Size = new System.Drawing.Size(120, 22);
            this.btnUploadToDevice.Text = "Upload To Device";
            this.btnUploadToDevice.Click += new System.EventHandler(this.btnUploadToDevice_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = global::MagicPaint.Properties.Resources.help_about;
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(60, 22);
            this.btnAbout.Text = "About";
            this.btnAbout.Visible = false;
            // 
            // trackFrames
            // 
            this.trackFrames.Location = new System.Drawing.Point(6, 48);
            this.trackFrames.Name = "trackFrames";
            this.trackFrames.Size = new System.Drawing.Size(188, 45);
            this.trackFrames.TabIndex = 2;
            this.trackFrames.Scroll += new System.EventHandler(this.trackFrames_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lstFileInfos);
            this.groupBox1.Location = new System.Drawing.Point(812, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 181);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Infos";
            // 
            // lstFileInfos
            // 
            this.lstFileInfos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.key,
            this.value});
            this.lstFileInfos.Location = new System.Drawing.Point(7, 20);
            this.lstFileInfos.Name = "lstFileInfos";
            this.lstFileInfos.Size = new System.Drawing.Size(187, 155);
            this.lstFileInfos.TabIndex = 0;
            this.lstFileInfos.UseCompatibleStateImageBehavior = false;
            this.lstFileInfos.View = System.Windows.Forms.View.Details;
            // 
            // key
            // 
            this.key.Text = "Key";
            this.key.Width = 74;
            // 
            // value
            // 
            this.value.Text = "Value";
            // 
            // pnlFrames
            // 
            this.pnlFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFrames.Controls.Add(this.btnAddFrameFromImage);
            this.pnlFrames.Controls.Add(this.btnRemoveFrame);
            this.pnlFrames.Controls.Add(this.btnAddFrame);
            this.pnlFrames.Controls.Add(this.btnResetFrame);
            this.pnlFrames.Controls.Add(this.btnSaveFrame);
            this.pnlFrames.Controls.Add(this.lblFrameNumber);
            this.pnlFrames.Controls.Add(this.btnNextFrame);
            this.pnlFrames.Controls.Add(this.btnPreviousFrame);
            this.pnlFrames.Controls.Add(this.trackFrames);
            this.pnlFrames.Location = new System.Drawing.Point(812, 389);
            this.pnlFrames.Name = "pnlFrames";
            this.pnlFrames.Size = new System.Drawing.Size(200, 120);
            this.pnlFrames.TabIndex = 4;
            this.pnlFrames.TabStop = false;
            this.pnlFrames.Text = "Frames";
            // 
            // btnAddFrameFromImage
            // 
            this.btnAddFrameFromImage.Image = global::MagicPaint.Properties.Resources.imageadd;
            this.btnAddFrameFromImage.Location = new System.Drawing.Point(71, 88);
            this.btnAddFrameFromImage.Name = "btnAddFrameFromImage";
            this.btnAddFrameFromImage.Size = new System.Drawing.Size(26, 26);
            this.btnAddFrameFromImage.TabIndex = 12;
            this.btnAddFrameFromImage.UseVisualStyleBackColor = true;
            this.btnAddFrameFromImage.Click += new System.EventHandler(this.btnAddFrameFromImage_Click);
            // 
            // btnRemoveFrame
            // 
            this.btnRemoveFrame.Image = global::MagicPaint.Properties.Resources.removepage;
            this.btnRemoveFrame.Location = new System.Drawing.Point(39, 88);
            this.btnRemoveFrame.Name = "btnRemoveFrame";
            this.btnRemoveFrame.Size = new System.Drawing.Size(26, 26);
            this.btnRemoveFrame.TabIndex = 11;
            this.btnRemoveFrame.UseVisualStyleBackColor = true;
            this.btnRemoveFrame.Click += new System.EventHandler(this.btnRemoveFrame_Click);
            // 
            // btnAddFrame
            // 
            this.btnAddFrame.Image = global::MagicPaint.Properties.Resources.newpage;
            this.btnAddFrame.Location = new System.Drawing.Point(7, 88);
            this.btnAddFrame.Name = "btnAddFrame";
            this.btnAddFrame.Size = new System.Drawing.Size(26, 26);
            this.btnAddFrame.TabIndex = 10;
            this.btnAddFrame.UseVisualStyleBackColor = true;
            this.btnAddFrame.Click += new System.EventHandler(this.btnAddFrame_Click);
            // 
            // btnResetFrame
            // 
            this.btnResetFrame.Image = global::MagicPaint.Properties.Resources.undo;
            this.btnResetFrame.Location = new System.Drawing.Point(168, 88);
            this.btnResetFrame.Name = "btnResetFrame";
            this.btnResetFrame.Size = new System.Drawing.Size(26, 26);
            this.btnResetFrame.TabIndex = 9;
            this.btnResetFrame.UseVisualStyleBackColor = true;
            this.btnResetFrame.Click += new System.EventHandler(this.btnResetFrame_Click);
            // 
            // btnSaveFrame
            // 
            this.btnSaveFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveFrame.Image")));
            this.btnSaveFrame.Location = new System.Drawing.Point(136, 88);
            this.btnSaveFrame.Name = "btnSaveFrame";
            this.btnSaveFrame.Size = new System.Drawing.Size(26, 26);
            this.btnSaveFrame.TabIndex = 8;
            this.btnSaveFrame.UseVisualStyleBackColor = true;
            this.btnSaveFrame.Click += new System.EventHandler(this.btnSaveFrame_Click);
            // 
            // lblFrameNumber
            // 
            this.lblFrameNumber.Location = new System.Drawing.Point(47, 19);
            this.lblFrameNumber.Name = "lblFrameNumber";
            this.lblFrameNumber.Size = new System.Drawing.Size(106, 23);
            this.lblFrameNumber.TabIndex = 7;
            this.lblFrameNumber.Text = "0";
            this.lblFrameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextFrame
            // 
            this.btnNextFrame.Image = global::MagicPaint.Properties.Resources.arrow_right;
            this.btnNextFrame.Location = new System.Drawing.Point(159, 19);
            this.btnNextFrame.Name = "btnNextFrame";
            this.btnNextFrame.Size = new System.Drawing.Size(35, 23);
            this.btnNextFrame.TabIndex = 6;
            this.btnNextFrame.UseVisualStyleBackColor = true;
            this.btnNextFrame.Click += new System.EventHandler(this.btnNextFrame_Click);
            // 
            // btnPreviousFrame
            // 
            this.btnPreviousFrame.Image = global::MagicPaint.Properties.Resources.arrow_left;
            this.btnPreviousFrame.Location = new System.Drawing.Point(6, 19);
            this.btnPreviousFrame.Name = "btnPreviousFrame";
            this.btnPreviousFrame.Size = new System.Drawing.Size(35, 23);
            this.btnPreviousFrame.TabIndex = 5;
            this.btnPreviousFrame.UseVisualStyleBackColor = true;
            this.btnPreviousFrame.Click += new System.EventHandler(this.btnPreviousFrame_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnToolFill);
            this.panel1.Controls.Add(this.pnlCurrentColor);
            this.panel1.Controls.Add(this.btnToolColorPicker);
            this.panel1.Controls.Add(this.btnToolBrush);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(46, 604);
            this.panel1.TabIndex = 6;
            // 
            // btnToolFill
            // 
            this.btnToolFill.Image = global::MagicPaint.Properties.Resources.fill_color;
            this.btnToolFill.Location = new System.Drawing.Point(3, 95);
            this.btnToolFill.Name = "btnToolFill";
            this.btnToolFill.Size = new System.Drawing.Size(40, 40);
            this.btnToolFill.TabIndex = 3;
            this.btnToolFill.UseVisualStyleBackColor = true;
            this.btnToolFill.Click += new System.EventHandler(this.btnToolFill_Click);
            // 
            // pnlCurrentColor
            // 
            this.pnlCurrentColor.BackColor = System.Drawing.Color.White;
            this.pnlCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCurrentColor.Location = new System.Drawing.Point(3, 141);
            this.pnlCurrentColor.Name = "pnlCurrentColor";
            this.pnlCurrentColor.Size = new System.Drawing.Size(40, 40);
            this.pnlCurrentColor.TabIndex = 2;
            this.pnlCurrentColor.TabStop = false;
            this.pnlCurrentColor.Click += new System.EventHandler(this.pnlCurrentColor_Click);
            // 
            // btnToolColorPicker
            // 
            this.btnToolColorPicker.Image = global::MagicPaint.Properties.Resources.color_picker;
            this.btnToolColorPicker.Location = new System.Drawing.Point(3, 49);
            this.btnToolColorPicker.Name = "btnToolColorPicker";
            this.btnToolColorPicker.Size = new System.Drawing.Size(40, 40);
            this.btnToolColorPicker.TabIndex = 1;
            this.btnToolColorPicker.UseVisualStyleBackColor = true;
            this.btnToolColorPicker.Click += new System.EventHandler(this.btnToolColorPicker_Click);
            // 
            // btnToolBrush
            // 
            this.btnToolBrush.BackColor = System.Drawing.SystemColors.Control;
            this.btnToolBrush.Image = global::MagicPaint.Properties.Resources.draw_brush;
            this.btnToolBrush.Location = new System.Drawing.Point(3, 3);
            this.btnToolBrush.Name = "btnToolBrush";
            this.btnToolBrush.Size = new System.Drawing.Size(40, 40);
            this.btnToolBrush.TabIndex = 0;
            this.btnToolBrush.UseVisualStyleBackColor = false;
            this.btnToolBrush.Click += new System.EventHandler(this.btnToolBrush_Click_1);
            // 
            // trackZoom
            // 
            this.trackZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackZoom.Location = new System.Drawing.Point(74, 590);
            this.trackZoom.Maximum = 3000;
            this.trackZoom.Minimum = 100;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(732, 45);
            this.trackZoom.TabIndex = 8;
            this.trackZoom.TickFrequency = 10;
            this.trackZoom.Value = 1600;
            this.trackZoom.Scroll += new System.EventHandler(this.trackZoom_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.palette1);
            this.groupBox2.Location = new System.Drawing.Point(812, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 168);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Palette";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 598);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // palette1
            // 
            this.palette1.BackColor = System.Drawing.Color.White;
            this.palette1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("palette1.BackgroundImage")));
            this.palette1.Location = new System.Drawing.Point(7, 19);
            this.palette1.Name = "palette1";
            this.palette1.Size = new System.Drawing.Size(187, 143);
            this.palette1.TabIndex = 0;
            this.palette1.Type = MagicPaint.Palette.ColorType.Type24bit;
            // 
            // magicPixler1
            // 
            this.magicPixler1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.magicPixler1.BackColor = System.Drawing.Color.White;
            this.magicPixler1.CurrentColor = System.Drawing.Color.Black;
            this.magicPixler1.CurrentTool = MagicPaint.MagicPixler.Tool.Brush;
            this.magicPixler1.EditEnabled = true;
            this.magicPixler1.Location = new System.Drawing.Point(49, 28);
            this.magicPixler1.Name = "magicPixler1";
            this.magicPixler1.PixelSize = 16;
            this.magicPixler1.Size = new System.Drawing.Size(757, 556);
            this.magicPixler1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 629);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.magicPixler1);
            this.Controls.Add(this.pnlFrames);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "Form1";
            this.Text = "MagicPaint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackFrames)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlFrames.ResumeLayout(false);
            this.pnlFrames.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCurrentColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TrackBar trackFrames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox pnlFrames;
        private System.Windows.Forms.Label lblFrameNumber;
        private System.Windows.Forms.Button btnNextFrame;
        private System.Windows.Forms.Button btnPreviousFrame;
        private System.Windows.Forms.ToolStripButton btnOpenFile;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnImportFile;
        private MagicPixler magicPixler1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView lstFileInfos;
        private System.Windows.Forms.ColumnHeader key;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnToolColorPicker;
        private System.Windows.Forms.Button btnToolBrush;
        private System.Windows.Forms.PictureBox pnlCurrentColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnSaveFrame;
        private System.Windows.Forms.Button btnResetFrame;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton btnUploadToDevice;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnRemoveFrame;
        private System.Windows.Forms.Button btnAddFrame;
        private System.Windows.Forms.Button btnAddFrameFromImage;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.GroupBox groupBox2;
        private Palette palette1;
        private System.Windows.Forms.Button btnToolFill;
    }
}

