namespace Test
{
    partial class Form1
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
            this.btnPing = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUploadFile = new System.Windows.Forms.TextBox();
            this.btnChooseUploadFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstSerialDevices = new System.Windows.Forms.ComboBox();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.btnAutodetectDevice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(6, 19);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(125, 23);
            this.btnPing.TabIndex = 0;
            this.btnPing.Text = "Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(11, 194);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(524, 273);
            this.txtResult.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(137, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(125, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(393, 19);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(125, 23);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPing);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Location = new System.Drawing.Point(11, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 51);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChooseUploadFile);
            this.groupBox2.Controls.Add(this.txtUploadFile);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Location = new System.Drawing.Point(11, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 51);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upload";
            // 
            // txtUploadFile
            // 
            this.txtUploadFile.Location = new System.Drawing.Point(6, 20);
            this.txtUploadFile.Name = "txtUploadFile";
            this.txtUploadFile.Size = new System.Drawing.Size(337, 20);
            this.txtUploadFile.TabIndex = 4;
            // 
            // btnChooseUploadFile
            // 
            this.btnChooseUploadFile.Location = new System.Drawing.Point(349, 20);
            this.btnChooseUploadFile.Name = "btnChooseUploadFile";
            this.btnChooseUploadFile.Size = new System.Drawing.Size(38, 20);
            this.btnChooseUploadFile.TabIndex = 5;
            this.btnChooseUploadFile.Text = "...";
            this.btnChooseUploadFile.UseVisualStyleBackColor = true;
            this.btnChooseUploadFile.Click += new System.EventHandler(this.btnChooseUploadFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAutodetectDevice);
            this.groupBox3.Controls.Add(this.btnOpenDevice);
            this.groupBox3.Controls.Add(this.lstSerialDevices);
            this.groupBox3.Location = new System.Drawing.Point(11, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 51);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device";
            // 
            // lstSerialDevices
            // 
            this.lstSerialDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstSerialDevices.FormattingEnabled = true;
            this.lstSerialDevices.Location = new System.Drawing.Point(6, 19);
            this.lstSerialDevices.Name = "lstSerialDevices";
            this.lstSerialDevices.Size = new System.Drawing.Size(256, 21);
            this.lstSerialDevices.TabIndex = 0;
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Location = new System.Drawing.Point(268, 17);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDevice.TabIndex = 1;
            this.btnOpenDevice.Text = "Open";
            this.btnOpenDevice.UseVisualStyleBackColor = true;
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click);
            // 
            // btnAutodetectDevice
            // 
            this.btnAutodetectDevice.Location = new System.Drawing.Point(393, 17);
            this.btnAutodetectDevice.Name = "btnAutodetectDevice";
            this.btnAutodetectDevice.Size = new System.Drawing.Size(125, 23);
            this.btnAutodetectDevice.TabIndex = 2;
            this.btnAutodetectDevice.Text = "Autodetect Device";
            this.btnAutodetectDevice.UseVisualStyleBackColor = true;
            this.btnAutodetectDevice.Click += new System.EventHandler(this.btnAutodetectDevice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 515);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtResult);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MagicShifter Debug GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChooseUploadFile;
        private System.Windows.Forms.TextBox txtUploadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAutodetectDevice;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.ComboBox lstSerialDevices;
    }
}

