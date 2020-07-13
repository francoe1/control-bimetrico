namespace Aplicacion.Vistas
{
    partial class SplashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this._lblVersion = new System.Windows.Forms.Label();
            this._lblEstado = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // _lblVersion
            // 
            this._lblVersion.AutoSize = true;
            this._lblVersion.BackColor = System.Drawing.Color.Transparent;
            this._lblVersion.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblVersion.ForeColor = System.Drawing.Color.White;
            this._lblVersion.Location = new System.Drawing.Point(221, 67);
            this._lblVersion.Name = "_lblVersion";
            this._lblVersion.Size = new System.Drawing.Size(77, 14);
            this._lblVersion.TabIndex = 0;
            this._lblVersion.Text = "VERSION 1.0";
            // 
            // _lblEstado
            // 
            this._lblEstado.AutoSize = true;
            this._lblEstado.BackColor = System.Drawing.Color.Transparent;
            this._lblEstado.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEstado.ForeColor = System.Drawing.Color.White;
            this._lblEstado.Location = new System.Drawing.Point(224, 173);
            this._lblEstado.Name = "_lblEstado";
            this._lblEstado.Size = new System.Drawing.Size(58, 13);
            this._lblEstado.TabIndex = 1;
            this._lblEstado.Text = "[Iniciando]";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-6, 256);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(662, 17);
            this.progressBar1.TabIndex = 2;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(649, 262);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this._lblEstado);
            this.Controls.Add(this._lblVersion);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblVersion;
        private System.Windows.Forms.Label _lblEstado;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}