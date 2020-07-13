namespace Aplicacion.Vistas
{
    partial class ConsolaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsolaForm));
            this._txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _txtLog
            // 
            this._txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtLog.Location = new System.Drawing.Point(0, 0);
            this._txtLog.Multiline = true;
            this._txtLog.Name = "_txtLog";
            this._txtLog.ReadOnly = true;
            this._txtLog.Size = new System.Drawing.Size(671, 425);
            this._txtLog.TabIndex = 0;
            // 
            // Consola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 425);
            this.Controls.Add(this._txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consola";
            this.Text = "Consola";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtLog;
    }
}