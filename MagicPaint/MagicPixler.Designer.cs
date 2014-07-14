namespace MagicPaint
{
    partial class MagicPixler
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MagicPixler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MagicPixler";
            this.Size = new System.Drawing.Size(565, 403);
            this.Click += new System.EventHandler(this.MagicPixler_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MagicPixler_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MagicPixler_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MagicPixler_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MagicPixler_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MagicPixler_MouseUp);
            this.Resize += new System.EventHandler(this.MagicPixler_Resize);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
