namespace Aplicacion.Vistas.Empleado
{
    partial class BiometricoManualForm
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
            this.m_btnAccept = new System.Windows.Forms.Button();
            this.m_txtBytes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_btnAccept
            // 
            this.m_btnAccept.Location = new System.Drawing.Point(275, 183);
            this.m_btnAccept.Name = "m_btnAccept";
            this.m_btnAccept.Size = new System.Drawing.Size(75, 23);
            this.m_btnAccept.TabIndex = 0;
            this.m_btnAccept.Text = "Aceptar";
            this.m_btnAccept.UseVisualStyleBackColor = true;
            this.m_btnAccept.Click += new System.EventHandler(this.m_btnAccept_Click);
            // 
            // m_txtBytes
            // 
            this.m_txtBytes.Location = new System.Drawing.Point(13, 13);
            this.m_txtBytes.Multiline = true;
            this.m_txtBytes.Name = "m_txtBytes";
            this.m_txtBytes.Size = new System.Drawing.Size(337, 164);
            this.m_txtBytes.TabIndex = 1;
            // 
            // BiometricoManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 218);
            this.Controls.Add(this.m_txtBytes);
            this.Controls.Add(this.m_btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BiometricoManual";
            this.Text = "BiometricoManual";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnAccept;
        private System.Windows.Forms.TextBox m_txtBytes;
    }
}