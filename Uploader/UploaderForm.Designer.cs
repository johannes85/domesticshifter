namespace Uploader
{
    partial class UploaderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploaderForm));
            this.btnAutodetectDevice = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lstSerialDevices = new System.Windows.Forms.ComboBox();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.lstFileInfos = new System.Windows.Forms.ListView();
            this.key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numSector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSector)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAutodetectDevice
            // 
            this.btnAutodetectDevice.Location = new System.Drawing.Point(257, 161);
            this.btnAutodetectDevice.Name = "btnAutodetectDevice";
            this.btnAutodetectDevice.Size = new System.Drawing.Size(82, 21);
            this.btnAutodetectDevice.TabIndex = 2;
            this.btnAutodetectDevice.Text = "Autodetect";
            this.btnAutodetectDevice.UseVisualStyleBackColor = true;
            this.btnAutodetectDevice.Click += new System.EventHandler(this.btnAutodetectDevice_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Location = new System.Drawing.Point(459, 241);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lstSerialDevices
            // 
            this.lstSerialDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstSerialDevices.FormattingEnabled = true;
            this.lstSerialDevices.Location = new System.Drawing.Point(118, 161);
            this.lstSerialDevices.Name = "lstSerialDevices";
            this.lstSerialDevices.Size = new System.Drawing.Size(133, 21);
            this.lstSerialDevices.TabIndex = 0;
            // 
            // picturePreview
            // 
            this.picturePreview.BackColor = System.Drawing.Color.White;
            this.picturePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picturePreview.Location = new System.Drawing.Point(12, 12);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(100, 86);
            this.picturePreview.TabIndex = 0;
            this.picturePreview.TabStop = false;
            // 
            // lstFileInfos
            // 
            this.lstFileInfos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.key,
            this.value});
            this.lstFileInfos.Location = new System.Drawing.Point(118, 12);
            this.lstFileInfos.Name = "lstFileInfos";
            this.lstFileInfos.Size = new System.Drawing.Size(418, 133);
            this.lstFileInfos.TabIndex = 8;
            this.lstFileInfos.UseCompatibleStateImageBehavior = false;
            this.lstFileInfos.View = System.Windows.Forms.View.Details;
            // 
            // key
            // 
            this.key.Text = "Key";
            this.key.Width = 98;
            // 
            // value
            // 
            this.value.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Device:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(378, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sector:";
            // 
            // numSector
            // 
            this.numSector.Location = new System.Drawing.Point(118, 189);
            this.numSector.Name = "numSector";
            this.numSector.Size = new System.Drawing.Size(63, 20);
            this.numSector.TabIndex = 12;
            // 
            // UploaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 274);
            this.Controls.Add(this.numSector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAutodetectDevice);
            this.Controls.Add(this.lstFileInfos);
            this.Controls.Add(this.lstSerialDevices);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.picturePreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UploaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload";
            this.Load += new System.EventHandler(this.UploaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutodetectDevice;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ComboBox lstSerialDevices;
        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.ListView lstFileInfos;
        private System.Windows.Forms.ColumnHeader key;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSector;
    }
}